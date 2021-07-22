using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using UltimateFiction.Data;
using UltimateFiction.Data.Shops;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Engine;
using UltimateFiction.ECS.Entities;
using UltimateFiction.GameCode;
using UltimateFiction.MonoGameHelpers;
using UltimateFiction.Services;
using static UltimateFiction.Data.WorldData;

namespace UltimateFiction.Scenes
{
	public abstract class AbstractOverworldScene : Scene, IOverworldScene
	{
		public override string Name => "Overworld scene";
		protected readonly GameSettings gameSettings;
		protected readonly GameContent gameContent;
		protected readonly GameStorage gameStorage;
		protected readonly TileMapService tileMapService;
		protected GamePlayData gamePlayData;
		protected TileMapComponent backgroundTileMap;
		protected List<Entity> entities;
		protected List<Entity> myEntities;
		protected Entity backgroundEntity;
		protected SpriteAnimationComponent playerSpriteAnimator;
		protected (int row, int col) originImageRowCol;
		protected SpriteComponent spriteComponent;
		protected Entity playerSpriteEntity;
		protected TextComponent debugText;
		protected Entity debugTextEntity;
		protected ColorBoxComponent debugTextBox;
		protected Entity debugTextBoxEntity;
		protected bool oldCeilingOnState = true;
		protected (int X, int Y) direction;
		protected (int X, int Y) velocity;
		protected (int X, int Y) previousVelocity;
		protected Cooldown walkingCooldown;

		protected static (int X, int Y) DIRECTION_UP = (0, -1);
		protected static (int X, int Y) DIRECTION_DOWN = (0, 1);
		protected static (int X, int Y) DIRECTION_LEFT = (-1, 0);
		protected static (int X, int Y) DIRECTION_RIGHT = (1, 0);

		protected static (int X, int Y) VELOCITY_STOPPED = (0, 0);
		protected static (int X, int Y) VELOCITY_UP = (0, -1);
		protected static (int X, int Y) VELOCITY_DOWN = (0, 1);
		protected static (int X, int Y) VELOCITY_LEFT = (-1, 0);
		protected static (int X, int Y) VELOCITY_RIGHT = (1, 0);

		public AbstractOverworldScene(
			GameSettings gameSettings,
			GameContent gameContent,
			GameTime gameTime,
			List<Entity> entities,
			GameStorage gameStorage,
			TileMapService tileMapService)
		{
			this.gameSettings = gameSettings;
			this.gameContent = gameContent;
			this.tileMapService = tileMapService;
			this.entities = entities;
			this.gameStorage = gameStorage;
			backgroundTileMap = tileMapService.TileMapComponents["CT"];
			direction = DIRECTION_DOWN;
			velocity = (0, 0);
			previousVelocity = velocity;
			//walkingCooldown = new Cooldown() { TotalTime = Cooldown.From(24) };
			walkingCooldown = new Cooldown() { TotalTime = Cooldown.From(80) };


			myEntities = new List<Entity>();

			var tilePix = this.gameSettings.TileSize.Width * this.gameSettings.Scale;


			originImageRowCol = (14, 0);
			backgroundEntity = Entity.From("Background tilemap", backgroundTileMap);
			spriteComponent = new SpriteComponent(
				"Player sprite",
				new Vector2(tilePix * this.gameSettings.PlayerTilePosition.X, tilePix * this.gameSettings.PlayerTilePosition.Y),
				originImageRowCol,
				gameContent.SpriteSheet);

			playerSpriteAnimator = new SpriteAnimationComponent(gameTime)
			{
				AnimationSpeed = 4,
				Frames = new Sprites.FrameSet()
				{
					Name = "Player sprite animator",
					ColStart = 0,
					ColCount = 2,
					Row = 0,
					SpriteId = spriteComponent.SpriteId
				},
				Active = false
			};
			playerSpriteEntity = Entity.From("Player sprite", spriteComponent, playerSpriteAnimator);

			debugText = new TextComponent()
			{
				Color = Color.White,
				Text = "This is the debug text.",
				Position = new Vector2(0 * tilePix, (gameSettings.TileViewPortSize.Rows - 1) * tilePix),
				Scale = gameSettings.Scale / 4
			};
			debugTextEntity = Entity.From("Debug text", debugText);

			debugTextBox = new ColorBoxComponent()
			{
				Color = Color.Black,
				Rect = new Rectangle(0 * tilePix, (gameSettings.TileViewPortSize.Rows - 1) * tilePix, gameSettings.ScreenSize.Width, 20 * gameSettings.Scale / 4)
			};
			debugTextBoxEntity = Entity.From("Debug text box", debugTextBox);

			debugText.Active = gameSettings.Debug;
			debugText.Visible = gameSettings.Debug;

			myEntities = new List<Entity>
			{
				backgroundEntity,
				playerSpriteEntity,
				debugTextEntity,
				debugTextBoxEntity
			};
		}

		public override void Tick(GameTime gameTime)
		{
		}

		public override void Activate(SceneController sceneController)
		{
			base.Activate(sceneController);
			entities.AddRange(myEntities);
			myEntities.ActivateAll();

			debugText.Active = gameSettings.Debug;
			debugText.Visible = gameSettings.Debug;

			playerSpriteAnimator.Active = false;
			StopWalking();

			TeleportToTile(gamePlayData.CurrentMap, gamePlayData.CurrentPlayerLocation.X, gamePlayData.CurrentPlayerLocation.Y);
			backgroundTileMap.CeilingOn = oldCeilingOnState;

			// TODO: Play music.
			// TODO: Place the player in the correct place on the map.  Need gamestate data to do this.
		}

		public override void Deactivate()
		{
			base.Deactivate();
			myEntities.DeactivateAll();
			entities.Clear();
		}

		public override void Initialize()
		{
		}

		public override void LoadContent()
		{
		}

		protected virtual WorldData.NpcInteraction GetNPCInteraction((int X, int Y) square)
		{
			return this.gameContent.WorldData.NpcInteractions.FirstOrDefault(
				npci => npci.MapCoord.XTile == square.X && npci.MapCoord.YTile == square.Y);
		}

		protected virtual WorldData.Treasure GetTreasure((int X, int Y) square)
		{
			return this.gameContent.WorldData.Treasures.FirstOrDefault(
				treasure => treasure.MapCoord.XTile == square.X && treasure.MapCoord.YTile == square.Y);
		}

		protected virtual void ShowDialog(IEnumerable<string> dialogText)
		{
			var scene = new DialogScene(gameSettings, entities, tileMapService);
			scene.Lines.AddRange(dialogText);
			sceneController.NavigateToScene(scene, true);
		}

		protected virtual void Interact()
		{
			var square = GetFacingSquare();
			var npci = GetNPCInteraction(square);
			if (npci != null)
			{
				ShowDialog(new[] { npci.DialogText });
			}
			ProcessTreasures(square);
		}

		protected virtual void ProcessTreasures((int X, int Y) square)
		{
			List<string> treasureNames = new();

			if (!gamePlayData.VisitedTreasures.Any(mc => mc.Map == backgroundTileMap.MapId && mc.XTile == square.X && mc.YTile == square.Y))
			{
				foreach (var treasure in gameContent.WorldData.Treasures.Where(t => t.MapCoord.Map == backgroundTileMap.MapId && t.MapCoord.XTile == square.X && t.MapCoord.YTile == square.Y))
				{
					if (treasure.TreasureName.ToLower() == "gold")
					{
						gamePlayData.Gold += treasure.Quantity;
						treasureNames.Add(treasure.Label);
					}
					else
					{
						// This is an item of some kind.  Find it in the templates to determine where to put it.
						var foundWeapon = gamePlayData.WeaponTemplates.Templates.FirstOrDefault(w => w.Id == treasure.TreasureName);
						if (foundWeapon != null)
						{
							gamePlayData.WeaponInventory.Add(foundWeapon);
							treasureNames.Add(foundWeapon.Name);
						}
						else
						{
							var foundArmor = gamePlayData.ArmorTemplates.Templates.FirstOrDefault(a => a.Id == treasure.TreasureName);
							if (foundArmor != null)
							{
								gamePlayData.ArmorInventory.Add(foundArmor);
								treasureNames.Add(foundArmor.Name);
							}
							else
							{
								var foundRelic = gamePlayData.RelicTemplates.Templates.FirstOrDefault(r => r.Id == treasure.TreasureName);
								if (foundRelic != null)
								{
									if (!gamePlayData.RelicInventory.Any(r => r.Id == foundRelic.Id))
										gamePlayData.RelicInventory.Add(foundRelic);
									treasureNames.Add(foundRelic.Name);
								}
								else
								{
									var foundItem = gamePlayData.ItemTemplates.Templates.FirstOrDefault(i => i.Id == treasure.TreasureName);
									if (foundItem != null)
									{
										gamePlayData.ItemInventory.Add(foundItem);
										treasureNames.Add(foundItem.Name);
									}
									else
										throw new Exception($"Undefined treasure: {treasure}");
								}
							}
						}
					}

					gamePlayData.VisitedTreasures.Add(new MapCoord(backgroundTileMap.MapId, square.X, square.Y));

					oldCeilingOnState = backgroundTileMap.CeilingOn;
					ShowDialog(treasureNames);
				}
			}
			else
			{
				oldCeilingOnState = backgroundTileMap.CeilingOn;
				ShowDialog(new[] { "Nothing here." });
			}
		}

		protected virtual void ProcessTriggers()
		{
			var square = gamePlayData.CurrentPlayerLocation;
			foreach (var trigger in gameContent.WorldData.Triggers.Where(t => t.MapCoord.Map == backgroundTileMap.MapId && t.MapCoord.XTile == square.X && t.MapCoord.YTile == square.Y))
			{
				var actionName = trigger.ActionName;
				if (actionName == "ceiling_on")
				{
					CeilingOn();
				}
				if (actionName == "ceiling_off")
				{
					CeilingOff();
				}
			}
		}

		protected virtual void ProcessTeleports()
		{
			var square = gamePlayData.CurrentPlayerLocation;
			var teleport = gameContent.WorldData.Teleports.FirstOrDefault(t => t.SourceMapCoord.Map == gamePlayData.CurrentMap && t.SourceMapCoord.XTile == square.X && t.SourceMapCoord.YTile == square.Y);
			if (teleport != null)
				TeleportToTile(teleport.TargetMapCoord.Map, teleport.TargetMapCoord.XTile, teleport.TargetMapCoord.YTile);
		}

		protected virtual void ProcessShops()
		{
			var square = gamePlayData.CurrentPlayerLocation;
			var shop = gameContent.WorldData.Shops.FirstOrDefault(s => s.MapCoord.Map == gamePlayData.CurrentMap && s.MapCoord.XTile == square.X && s.MapCoord.YTile == square.Y);
			if (shop != null)
			{
				oldCeilingOnState = backgroundTileMap.CeilingOn;

				var newDialog = new DialogScene(gameSettings, entities, tileMapService);
				if (shop.ShopType == ShopType.Inn)
				{
					// Restore all health
					var needsHealing = gamePlayData.Heroes.Any(hero => hero.HP < hero.MaxHP);

					gamePlayData.Heroes.ForEach(h => h.HealAll());
					var resumePoint = gameContent.WorldData.ResumePoints.First(rp => rp.InnName == shop.ShopName);

					// Save game.
					gamePlayData.ResumeMap = resumePoint.MapCoord.Map;
					gamePlayData.ResumeMapLocation = resumePoint.MapCoord.Coord;
					gameStorage.WriteSaveGameData(gamePlayData);

					if (needsHealing)
						newDialog.Lines.AddRange(new[] { "You have been healed." });
					else
						newDialog.Lines.AddRange(new[] { "You don't need healing right now." });
				}
				else if (shop.ShopType == ShopType.Clinic)
				{
					// Resurrect the dead party members, if any.
					if (gamePlayData.Heroes.Any(h => h.HP <= 0))
					{
						gamePlayData.Heroes.ForEach(h => h.HP = Math.Min(1, h.HP));
						newDialog.Lines.AddRange(new[] { "Rise from your grave!" });
					}
					else newDialog.Lines.AddRange(new[] { "I cannot help you now." });
				}
				else
				{
					newDialog.Lines.AddRange(new[] { "Gone fishing."});
				}

				// For now, we don't support any shops except Inn and Clinic.  If we want to add support, add it here.

				sceneController.NavigateToScene(newDialog);
			}
		}

		protected virtual void Walk()
		{
			velocity = direction;
		}

		protected virtual void FaceDirection(int spriteDirection)
		{
			// Change the stationary sprite image.
			var oldRowcol = spriteComponent.ImageRowCol;
			spriteComponent.ImageRowCol = (oldRowcol.Row, originImageRowCol.col + spriteDirection);
			// In case we start walking, also change the animated sprite image.
			playerSpriteAnimator.Frames.ColStart = originImageRowCol.col + spriteDirection;
		}

		protected virtual void StopWalking()
		{
			velocity = VELOCITY_STOPPED;
		}

		protected virtual bool Walking()
		{
			return velocity != VELOCITY_STOPPED;
		}

		private (int X, int Y) AddXY((int X, int Y) addend1, (int X, int Y) addend2)
		{
			return (addend1.X + addend2.X, addend1.Y + addend2.Y);
		}

		protected virtual (int X, int Y) GetFacingSquare()
		{
			return AddXY(gamePlayData.CurrentPlayerLocation, direction);
		}

		public virtual bool CanWalk((int TileX, int TileY) coord)
		{
			return CanWalk(coord.TileX, coord.TileY);
		}

		public virtual bool CanWalk(int tileX, int tileY)
		{
			var tilemap = gameContent.TileMaps[backgroundTileMap.ContentName];
			var layer = tilemap.Map.Layers[(int)TiledMapLayer.CanWalk];
			var tileIndex = (tileX, tileY).XyToGid(tilemap.TileWH.Width);
			var gid = layer.Tiles[tileIndex].Gid;
			if (gid <= 0)
				return false;

			gid = gid - 4096;
			int canWalkId = 1;
			int canCanoe = 2;
			int canSailId = 3;

			return gid == canWalkId;
		}

		protected virtual void AttemptToWalk(int spriteDirection, (int X, int Y) walkDirection)
		{
			if (walkDirection != velocity)
				FaceDirection(spriteDirection);
			direction = walkDirection;
			if (CanWalk(GetFacingSquare()))
				Walk();
		}

		protected virtual void CeilingOn()
		{
			backgroundTileMap.CeilingOn = true;
		}

		protected virtual void CeilingOff()
		{
			backgroundTileMap.CeilingOn = false;
		}

		//public override void Update(GameTime gameTime)
		//{
		//}

		public virtual void TeleportToTile(string map, int x, int y)
		{
			if (map != backgroundTileMap.MapId)
			{
				backgroundTileMap = tileMapService.UseBackgroundTileMap(backgroundEntity, map);
			}
			gamePlayData.CurrentMapLocation = (x-7, y-7);
			gamePlayData.CurrentMap = map;
			var viewport = backgroundTileMap.MapViewport;
			viewport.X = gamePlayData.CurrentMapLocation.X * gameSettings.TileSize.Width;
			viewport.Y = gamePlayData.CurrentMapLocation.Y * gameSettings.TileSize.Height;

			backgroundTileMap.MapViewport = viewport;
			CeilingOn();
		}

		public virtual void SetGameData(GamePlayData gamePlayData)
		{
			this.gamePlayData = gamePlayData;
		}

		public override void Draw(GameTime gameTime)
		{
		}

		public void UpdateDebugText()
		{
			var currentBG = entities.SelectMany(e => e.Components, (e, c) => (e, c)).Where(x => x.c.ComponentType == ComponentType.TileMap).Select(x => x.c.ToString()).FirstOrDefault() ?? "NONE";
			if (debugText != null)
			{
				debugText.Text =
					new StringBuilder()
						.Append($"VP:(x{backgroundTileMap.MapViewport.X}, y{backgroundTileMap.MapViewport.Y}) ")
						.Append($"Pos:({gamePlayData.CurrentPlayerLocation.X},{gamePlayData.CurrentPlayerLocation.Y}) ")
						.Append($"ImgRowCol:({spriteComponent.ImageRowCol.Row},{spriteComponent.ImageRowCol.Col}) ")
						.Append($"Map:({currentBG})")
						.ToString();
			}
		}
	}
}
