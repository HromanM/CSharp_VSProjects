
namespace Oper�tory
{
	struct Hodina
	{
		public Hodina(int po��te�n�Hodnota)
		{
			this.hodnota = System.Math.Abs(po��te�n�Hodnota) % 24;
		}

		public int Hodnota
		{
			get { return this.hodnota; }
		}

		public static bool operator==(Hodina lp, int rp)
		{
			return lp.hodnota == rp;
		}

		public static bool operator!=(Hodina lp, int rp)
		{
			return lp.hodnota != rp;
		}

		public static bool operator==(int lp, Hodina rp)
		{
			return lp == rp.hodnota;
		}

		public static bool operator!=(int lp, Hodina rp)
		{
			return lp != rp.hodnota;
		}

		public override bool Equals(object other)
		{
			return (other is Hodina) && Equals((Hodina)other);
		}

		public bool Equals(Hodina other)
		{
			return this.hodnota == other.hodnota;
		}

		public override int GetHashCode()
		{
			return this.hodnota;
		}

		public static Hodina operator++(Hodina arg)
		{
			arg.hodnota++;
			if (arg.hodnota == 24)
			{
				arg.hodnota = 0;
			}
			return arg;
		}

		private int hodnota;
	}
}