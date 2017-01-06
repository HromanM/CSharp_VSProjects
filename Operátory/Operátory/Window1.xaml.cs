using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Operátory
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            tikač.tik += new Tik(tikni);
        }

        private void tikni()
		{
			čas.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
				hodiny.Hodina,
				hodiny.Minuta,
				hodiny.Sekunda);
		}

		private HodinovýStrojek tikač = new HodinovýStrojek();
		private DigitálníHodiny hodiny = new DigitálníHodiny();
    }
}
