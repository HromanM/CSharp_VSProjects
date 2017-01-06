using System;
using System.Timers;
using System.Windows.Threading;

namespace Operátory
{
	public delegate void Tik();

	class HodinovýStrojek
	{
		public HodinovýStrojek()
		{
            this.tikání.Tick += new EventHandler(this.pøiÈasovéUdálosti);
            this.tikání.Interval = new TimeSpan(0, 0, 1); // 1 sekunda
            this.tikání.Start();
		}
	
		public event Tik tik;

		private void pøiÈasovéUdálosti(object source, EventArgs args)
		{
			if (this.tik != null)
			{
				this.tik();
			}
		}

		private DispatcherTimer tikání = new DispatcherTimer();
	}
}
