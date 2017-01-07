
namespace Operátory
{
	struct Minuta
	{
		public Minuta(int poèáteèníHodnota)
		{
			this.hodnota = System.Math.Abs(poèáteèníHodnota) % 60;
		}

		public int Hodnota
		{
			get { return this.hodnota; }
		}

		// sem pøidejte operator==(Minuta, int)
        public static bool operator==(Minuta m, int i)
        {
            return m.hodnota == i;
        }
        public static bool operator==(int i, Minuta m)
        {
            return m.hodnota == i;
        }
        public static bool operator==(Minuta m, Minuta n)
        {
            return m.hodnota == n.hodnota;
        }

        // sem pøidejte operator!=(Minuta, int)
        public static bool operator !=(Minuta m, int i)
        {
            return m.hodnota != i;
        }
        public static bool operator !=(int i, Minuta m)
        {
            return m.hodnota != i;
        }
        public static bool operator !=(Minuta m, Minuta n)
        {
            return m.hodnota != n.hodnota;
        }

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
