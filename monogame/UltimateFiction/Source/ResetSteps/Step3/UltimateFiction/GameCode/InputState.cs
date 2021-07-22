using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.GameCode
{
	public class InputState
	{
		public bool EscPressed { get; set; }
		public bool EnterPressed { get; set; }
		public bool UpArrowPressed { get; set; }
		public bool DownArrowPressed { get; set; }
		public bool LeftArrowPressed { get; set; }
		public bool RightArrowPressed { get; set; }
		public bool ZButtonPressed { get; set; }
		public bool XButtonPressed { get; set; }

		public bool UpArrowHeld { get; set; }
		public bool DownArrowHeld { get; set; }
		public bool LeftArrowHeld { get; set; }
		public bool RightArrowHeld { get; set; }
	}
}
