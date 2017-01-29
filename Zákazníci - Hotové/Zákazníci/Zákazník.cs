using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Zákazníci
{
    enum Oslovení { Pan, Paní, Slečna }
    enum Pohlaví { Muž, Žena }

    [ValueConversion(typeof(string), typeof(Oslovení))]
    public class PřevodníkOslovení : IValueConverter
    {
        public object Convert(object value, Type targetType,
           object parameter, System.Globalization.CultureInfo culture)
        {
            Oslovení oslovení = (Oslovení)value;
            return oslovení.ToString();
        }

        public object ConvertBack(object value, Type targetType,
           object parameter, System.Globalization.CultureInfo culture)
        {
            Oslovení vrátit = Oslovení.Slečna;

            switch ((string)value)
            {
                case "Pan": vrátit = Oslovení.Pan;
                    break;
                case "Paní": vrátit = Oslovení.Paní;
                    break;
                case "Slečna": vrátit = Oslovení.Slečna;
                    break;
            }
            return vrátit;
        } 
    }

    [ValueConversion(typeof(bool), typeof(Pohlaví))]
    public class PřevodníkPohlaví : IValueConverter
    {
        public object Convert(object value, Type targetType,
           object parameter, System.Globalization.CultureInfo culture)
        {
            string idPřepínače = (string)parameter;
            Pohlaví pohlaví = (Pohlaví)value;
            bool vrátit = false;

            if (String.Equals(idPřepínače, "Žena") &&
                pohlaví.Equals(Pohlaví.Žena))
                vrátit = true;

            if (String.Equals(idPřepínače, "Muž") &&
                pohlaví.Equals(Pohlaví.Muž))
                vrátit = true;

            return vrátit;
        }

        public object ConvertBack(object value, Type targetType,
           object parameter, System.Globalization.CultureInfo culture)
        {
            if (String.Equals((string)parameter, "Žena"))
                return Pohlaví.Žena;
            else
                return Pohlaví.Muž;
        } 
    } 

    class Zákazník
    {
        private string jméno;
        private string příjmení;
        private Oslovení oslovení;
        private Pohlaví pohlaví;

        public string Jméno
        {
            get { return this.jméno; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Zadejte jméno zákazníka");
                }
                else
                {
                    this.jméno = value;
                }
            }
        }

        public string Příjmení
        {
            get { return this.příjmení; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Zadejte příjmení zákazníka");
                }
                else
                {
                    this.příjmení = value;
                }
            }
        }

        private bool ověřOsloveníAPohlaví(Oslovení navrženéOslovení,
           Pohlaví navrženéPohlaví)
        {
            bool vrátit = false;
            if (navrženéPohlaví.Equals(Pohlaví.Muž))
            {
                vrátit = (navrženéOslovení.Equals(Oslovení.Pan)) ? true : false;
            }
            if (navrženéPohlaví.Equals(Pohlaví.Žena))
            {
                vrátit = (navrženéOslovení.Equals(Oslovení.Pan)) ? false : true;
            }
            return vrátit;
        }

        public Oslovení Oslovení
        {
            get { return this.oslovení; }
            set
            {
                this.oslovení = value;
                if (!ověřOsloveníAPohlaví(value, this.pohlaví))
                {
                    throw new ApplicationException
                       ("Oslovení musí odpovídat pohlaví zákazníka");
                }
            }
        }

        public Pohlaví Pohlaví
        {
            get { return this.pohlaví; }
            set
            {
                this.pohlaví = value;
                if (!ověřOsloveníAPohlaví(this.oslovení, value))
                {
                    throw new ApplicationException
                       ("Pohlaví musí odpovídat oslovení zákazníka");
                }
            }
        }

        public override string ToString()
        {
            return this.Oslovení.ToString() + " " + this.Jméno + " " +
               this.Příjmení + " - " + this.Pohlaví.ToString();
        } 
    }
}
