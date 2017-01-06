
namespace Oper�tory
{
	struct Minuta
	{
		public Minuta(int po��te�n�Hodnota)
		{
			this.hodnota = System.Math.Abs(po��te�n�Hodnota) % 60;
		}

		public int Hodnota
		{
			get { return this.hodnota; }
		}

		// sem p�idejte operator==(Minuta, int)

		// sem p�idejte operator!=(Minuta, int)

		public override bool Equals(object other)
		{
			return (other is Minuta) && Equals((Minuta)other);
		}

		public bool Equals(Minuta other)
		{
			return this.hodnota == other.hodnota;
		}

		public override int GetHashCode()
		{
			return this.hodnota;
		}

		public static Minuta operator++(Minuta arg)
		{
			arg.hodnota++;
			if (arg.hodnota == 60)
			{
				arg.hodnota = 0;
			}
			return arg;
		}

		private int hodnota;
	}
}
