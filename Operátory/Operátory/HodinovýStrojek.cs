using System;
using System.Timers;
using System.Windows.Threading;

namespace Oper�tory
{
	public delegate void Tik();

	class Hodinov�Strojek
	{
		public Hodinov�Strojek()
		{
            this.tik�n�.Tick += new EventHandler(this.p�i�asov�Ud�losti);
            this.tik�n�.Interval = new TimeSpan(0, 0, 1); // 1 sekunda
            this.tik�n�.Start();
		}
	
		public event Tik tik;

		private void p�i�asov�Ud�losti(object source, EventArgs args)
		{
			if (this.tik != null)
			{
				this.tik();
			}
		}

		private DispatcherTimer tik�n� = new DispatcherTimer();
	}
}
