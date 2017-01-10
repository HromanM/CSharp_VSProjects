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
using System.IO;
using Microsoft.Win32;

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

            MenuItem contextMenuItemSave = new MenuItem();
            contextMenuItemSave.Header = "Uloz clena";
            contextMenuItemSave.Click += new RoutedEventHandler(saveMember_Click);

            MenuItem contextMenuItemClean = new MenuItem();
            contextMenuItemClean.Header = "Vycisti okno";
            contextMenuItemClean.Click += new RoutedEventHandler(buttonClean_Click);

            windowContextMenu = new ContextMenu();
            windowContextMenu.Items.Add(contextMenuItemSave);
            windowContextMenu.Items.Add(contextMenuItemClean);
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
        private ContextMenu windowContextMenu = null;

        private void buttonClean_Click(object sender, RoutedEventArgs e)
        {
            this.ResetWindow();
        }

       /* private void buttonAdd_Click(object sender, RoutedEventArgs e)
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
        }*/

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

        private void saveMember_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.DefaultExt = "txt";
            saveDlg.AddExtension = true;
            saveDlg.FileName = "Members";
            saveDlg.InitialDirectory = @"C:\Users\yt\Documents\prace\Skoleni\C#\CSharp_VSProjects\Ringers";
            saveDlg.OverwritePrompt = true;
            saveDlg.Title = "Ringers";
            saveDlg.ValidateNames = true;
            if (saveDlg.ShowDialog().Value)
            {
                using (StreamWriter strWriter = new StreamWriter(saveDlg.FileName))
                {

                    strWriter.WriteLine("Jmeno: {0}", Name.Text);
                    strWriter.WriteLine("Prijmeni: {0}", Surname.Text);
                    strWriter.WriteLine("Vez: {0}", Towers.Text);
                    strWriter.WriteLine("Je kapitan: {0}", Captain.IsChecked.ToString());
                    System.Windows.Forms.DateTimePicker memberDate =
                        HostMemberSince.Child as System.Windows.Forms.DateTimePicker;
                    strWriter.WriteLine("Clenem od: {0}", memberDate.Value.ToString());
                    strWriter.WriteLine("Metody: ");
                    foreach (CheckBox item in Metods.Items)
                    {
                        if (item.IsChecked.Value)
                            strWriter.WriteLine(item.Content.ToString());
                    }
                    MessageBox.Show("Udaje ulozeny", "Ulozeno");
                }
            }
        }

        private void endApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void newMember_Click(object sender, RoutedEventArgs e)
        {
            this.ResetWindow();
            saveMember.IsEnabled = true;
            Name.IsEnabled = true;
            Surname.IsEnabled = true;
            Towers.IsEnabled = true;
            Captain.IsEnabled = true;
            HostMemberSince.IsEnabled = true;
            YearsOfExp.IsEnabled = true;
            Metods.IsEnabled = true;
           // buttonAdd.IsEnabled = true;
            buttonClean.IsEnabled = true;
            this.ContextMenu = windowContextMenu;
        }

        private void aboutApp_Click(object sender, RoutedEventArgs e)
        {
            OAplikaci aboutWindow = new OAplikaci();
            aboutWindow.ShowDialog();
        }

        private void buttonRead_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader strReader = new StreamReader("Members.txt"))
            {
                MessageBox.Show(strReader.ReadLine(), "Nacteno");   
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Name.Text = String.Empty;
            Surname.Text = String.Empty;
        }
    }
}
