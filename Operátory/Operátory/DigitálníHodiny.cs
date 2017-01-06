
namespace Oper�tory
{
	class Digit�ln�Hodiny
	{
		public Digit�ln�Hodiny()
		{
			System.DateTime te� = System.DateTime.Now;
			this.hodina = new Hodina(te�.Hour);
			this.minuta = new Minuta(te�.Minute);
			this.sekunda = new Sekunda(te�.Second);
			this.impuls.tik += tikni;
		}

		public Digit�ln�Hodiny(Hodina hh, Minuta mm, Sekunda ss)
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

		private Hodinov�Strojek impuls = new Hodinov�Strojek();
		private Hodina hodina;
		private Minuta minuta;
		private Sekunda sekunda;
	}
}
