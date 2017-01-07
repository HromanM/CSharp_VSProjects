
namespace Operátory
{
	struct Sekunda
	{
		public Sekunda(int poèáteèníHodnota)
		{
			this.hodnota = System.Math.Abs(poèáteèníHodnota) % 60;
		}

		public int Hodnota
		{
			get { return this.hodnota; }
		}

		// sem pøidejte statický implicitní operátor Sekunda (int arg)
        public static implicit operator Sekunda(int arg)
        {
            return new Sekunda(arg);
        }

        // následující operátor nemažte
		public static bool operator==(Sekunda lp, Sekunda rp)
		{
			return lp.hodnota == rp.hodnota;
		}
		
		// následující operátor nemažte 
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
