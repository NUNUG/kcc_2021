using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Data.Relics
{
	public class Relic : IRelic
	{
		public string Id { get; }
		public string Name { get; }
		public string Description { get; }

		public Relic(string id, string name, string description)
		{
			this.Id = id;
			this.Name = name;
			this.Description = description;
		}
	}
}
