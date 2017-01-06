
namespace Operátory
{
	class DigitálníHodiny
	{
		public DigitálníHodiny()
		{
			System.DateTime teï = System.DateTime.Now;
			this.hodina = new Hodina(teï.Hour);
			this.minuta = new Minuta(teï.Minute);
			this.sekunda = new Sekunda(teï.Second);
			this.impuls.tik += tikni;
		}

		public DigitálníHodiny(Hodina hh, Minuta mm, Sekunda ss)
		{
			this.hodina = hh;
			this.minuta = mm;
			this.sekunda = ss;
			this.impuls.tik += tikni;
		}

		public int Hodina
		{
			get { return this.hodina.Hodnota; }
		}

		public int Minuta
		{
			get { return this.minuta.Hodnota; }
		}

		public int Sekunda
		{
		   get { return this.sekunda.Hodnota; }
		}

		private void tikni()
		{
			this.sekunda++;
			if (this.sekunda == 0)
			{
				this.minuta++;
				if (this.minuta == 0)
				{
					this.hodina++;
				}
			}
		}

		private HodinovıStrojek impuls = new HodinovıStrojek();
		private Hodina hodina;
		private Minuta minuta;
		private Sekunda sekunda;
	}
}
