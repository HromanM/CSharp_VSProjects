
namespace Oper�tory
{
	struct Sekunda
	{
		public Sekunda(int po��te�n�Hodnota)
		{
			this.hodnota = System.Math.Abs(po��te�n�Hodnota) % 60;
		}

		public int Hodnota
		{
			get { return this.hodnota; }
		}

		// sem p�idejte statick� implicitn� oper�tor Sekunda (int arg)
        public static implicit operator Sekunda(int arg)
        {
            return new Sekunda(arg);
        }

        // n�sleduj�c� oper�tor nema�te
		public static bool operator==(Sekunda lp, Sekunda rp)
		{
			return lp.hodnota == rp.hodnota;
		}
		
		// n�sleduj�c� oper�tor nema�te 
		public static bool operator!=(Sekunda lp, Sekunda rp)
		{
			return lp.hodnota != rp.hodnota;
		}

		public override bool Equals(object other)
		{
			return (other is Sekunda) && Equals((Sekunda)other);
		}

		public bool Equals(Sekunda other)
		{
			return this.hodnota == other.hodnota;
		}

		public override int GetHashCode()
		{
			return this.hodnota;
		}

		public static Sekunda operator++(Sekunda arg)
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
