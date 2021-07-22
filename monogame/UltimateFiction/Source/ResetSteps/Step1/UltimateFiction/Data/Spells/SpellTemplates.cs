using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Data.Spells
{
	public class SpellTemplates
	{
		public List<ISpell> Templates { get; }

		public SpellTemplates()
		{
			Templates = new List<ISpell>();
			foreach (var spell in CreateTemplates()) Templates.Add(spell);
		}

		public static IEnumerable<ISpell> CreateTemplates()
		{
			yield return new Spell("spell_fire1", "Fire", "Lights a fire under your enemies.", MagicType.Black, 1, 15, 3, false, false, true, false);
			yield return new Spell("spell_fire2", "Fire2", "A pillar of fire rises about your enemies..", MagicType.Black, 3, 20, 7, false, false, false, true);
			yield return new Spell("spell_fire3", "Fire3", "Engulf your enemies with an intense inferno.", MagicType.Black, 5, 30, 15, false, false, false, true);
			yield return new Spell("spell_fire4", "Fire4", "Fire and brimstone rains from the sky!", MagicType.Black, 7, 40, 25, false, false, false, true);

			yield return new Spell("spell_ice1", "Ice", "Give your enemies a chill.", MagicType.Black, 2, 20, 3, false, false, true, false);
			yield return new Spell("spell_ice2", "Ice2", "Slows your enemies movement.", MagicType.Black, 4, 25, 7, false, false, false, true);
			yield return new Spell("spell_ice3", "Ice3", "Enemies lose their fingers to frostbite.", MagicType.Black, 6, 35, 15, false, false, false, true);
			yield return new Spell("spell_ice4", "Ice4", "Crush your enemies bones with the weight of ice.", MagicType.Black, 8, 45, 25, false, false, false, true);

			yield return new Spell("spell_lightning1", "Lightning", "A tremendous static shock.", MagicType.Black, 3, 25, 3, false, false, true, false);
			yield return new Spell("spell_lightning2", "Lightning2", "A series of dyno discharges.", MagicType.Black, 5, 30, 7, false, false, false, true);
			yield return new Spell("spell_lightning3", "Lightning3", "Powerful energy arcs from your fingertips.", MagicType.Black, 7, 40, 15, false, false, false, true);
			yield return new Spell("spell_lightning4", "Lightning3", "The power of the sky descends to smite your enemies.", MagicType.Black, 9, 50, 25, false, false, false, true);

			yield return new Spell("spell_melee1", "Melee", "Conjures an animated blade to fight for you.", MagicType.Black, 4, 50, 10, false, false, true, false);
			yield return new Spell("spell_melee2", "Melee2", "Conjures animated blades to fight for you.", MagicType.Black, 6, 70, 20, false, false, true, false);
			yield return new Spell("spell_melee3", "Melee3", "Conjures many animated blades to fight for you.", MagicType.Black, 8, 90, 30, false, false, true, false);
			yield return new Spell("spell_melee4", "Melee4", "Summonds forth blades from within your enemy's very body.", MagicType.Black, 10, 110, 40, false, false, true, false);

			yield return new Spell("spell_cure1", "Cure1", "Restores some health for one hero.", MagicType.White, 1, -30, 3, true, false, false, false);
			yield return new Spell("spell_cure2", "Cure2", "Restores more health for one hero", MagicType.White, 3, -150, 7, true, false, false, false);
			yield return new Spell("spell_cure3", "Cure3", "Restores a lot of health for one hero.", MagicType.White, 5, -350, 15, true, false, false, false);
			yield return new Spell("spell_cure4", "Cure4", "Restores all health for one hero.", MagicType.White, 7, -10000, 25, true, false, false, false);

			yield return new Spell("spell_cureall1", "CureAll1", "Restores some health for all heroes.", MagicType.White, 3, -120, 3, false, true, false, false);
			yield return new Spell("spell_cureall2", "CureAll2", "Restores more health for all heroes.", MagicType.White, 5, -600, 15, false, true, false, false);
			yield return new Spell("spell_cureall3", "CureAll3", "Restores a lot of health for all heroes.", MagicType.White, 7, -1400, 35, false, true, false, false);
			yield return new Spell("spell_cureall4", "CureAll4", "Restores all health for all heroes.", MagicType.White, 9, -50000, 40, false, true, false, false);

			yield return new Spell("spell_life1", "Life1", "Raises a slain hero from the dead with 1 HP.", MagicType.White, 4, -1400, 35, true, false, false, false);
			yield return new Spell("spell_life2", "Life2", "Raises a slain hero from the dead with full HP.", MagicType.White, 8, -50000, 40, true, false, false, false);

			// Spells can't be done like this.  With only a damage property, we can't do things like defense and agility.  We need an action for each one, but that requires some battle knowledge.  Are we in a battle?  How will it wear off after battle?
			//yield return new Spell("spell_def1", "Def1", "Increase defense for a hero.", MagicType.White, 2, , 40, false, true, false, false);

			yield return new Spell("spell_suckerpunch", "Sucker Punch", "", MagicType.Enemy, 0, 30, 0, true, false, false, false);
			yield return new Spell("spell_highkick", "High Kick", "", MagicType.Enemy, 0, 30, 0, true, false, false, false);
			yield return new Spell("spell_swashbuckle", "Swashbuckle", "", MagicType.Enemy, 0, 30, 0, true, false, false, false);
			yield return new Spell("spell_bite", "Bite", "", MagicType.Enemy, 0, 30, 0, true, false, false, false);
			yield return new Spell("spell_pummel", "Pummel", "", MagicType.Enemy, 0, 30, 0, true, false, false, false);

		}
	}
}
