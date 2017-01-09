using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ringers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ResetWindow();
        }

        public void ResetWindow()
        {
            Towers.Items.Clear();
            foreach (string item in towers)
                Towers.Items.Add(item);
            Towers.Text = Towers.Items[0] as string;
            Name.Text = String.Empty;
            Surname.Text = String.Empty;

            Metods.Items.Clear();
            CheckBox method;
            foreach (string item in ringMelodies)
            {
                method = new CheckBox();
                method.Margin = new Thickness(0, 0, 0, 10);
                method.Content = item;
                Metods.Items.Add(method);
            }

            Captain.IsChecked = false;
            Novice.IsChecked = true;
            System.Windows.Forms.DateTimePicker memberDate = 
                HostMemberSince.Child as System.Windows.Forms.DateTimePicker;
            memberDate.Value = DateTime.Today;
        }

        private string[] towers = { "Lipnik nad Becvou", "Drevohostice", "Domazlice", "Jankovice" };
        private string[] ringMelodies = {"Ave Maria", "Sneni", "Romance", "Nocturno", "Rubinstein",
            "Praotec", "Star0 vysehradske poteseni", "Gyga" };

        private void buttonClean_Click(object sender, RoutedEventArgs e)
        {
            this.ResetWindow();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string nameATower = String.Format(
                "Clenem {0} {1} z veze v obci {2} vyzvani metody:",
                Name.Text, Surname.Text, Towers.Text);
            StringBuilder details = new StringBuilder();
            details.AppendLine(nameATower);
            foreach(CheckBox cb in Metods.Items)
            {
                if (cb.IsChecked.Value)
                    details.AppendLine(cb.Content.ToString());
            }
            MessageBox.Show(details.ToString(), "Udaje o clenovi");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Opravdu chcete skoncit?",
                "Potvrzeni",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);
            e.Cancel = (result == MessageBoxResult.No);
        }
    }
}
