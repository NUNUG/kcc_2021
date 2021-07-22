using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Tiling
{
	public class LayerType
	{
		public int Value { get; protected set; }
		protected LayerType(int layerType)
		{
			Value = layerType;
		}

		public static LayerType Background => new LayerType(0);
		public static LayerType MonsterZones => new LayerType(1);
		public static LayerType CanWalk => new LayerType(2);
		public static LayerType Ceiling => new LayerType(3);
		public static LayerType Events => new LayerType(4);

		public override string ToString()
		{
			switch (Value)
			{
				case 0: return "Background";
				case 1: return "MonsterZones";
				case 2: return "CanWalk";
				case 3: return "Ceiling";
				case 4: return "Events";
				default: return $"Unsupported LayerType ({Value})";
			}
		}

		public static implicit operator int(LayerType layerType) => layerType.Value;
		public static explicit operator LayerType(int value) => new LayerType(value);

		public override bool Equals(object obj)
		{
			if (obj is LayerType)
				return ((LayerType)obj).Value.Equals(Value);
			return false;
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}
	}
}
