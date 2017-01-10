using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zákazníci
{
    public partial class FormulářZákazníka : Window
    {
        public FormulářZákazníka()
        {
            InitializeComponent();
        }

        private Binding vytvořVazbu(string parametr)
        {
            Binding vazbaZákazníka =
               BindingOperations.GetBinding(this.oslovení,
                                            ComboBox.TextProperty);
            Zákazník zákazník = vazbaZákazníka.Source as Zákazník;
            Binding vazba = new Binding();
            vazba.Source = zákazník;
            vazba.Path = new PropertyPath("Pohlaví");
            vazba.Converter = new PřevodníkPohlaví();
            vazba.ConverterParameter = parametr;
            // vazba.ValidationRules.Add(new ExceptionValidationRule());
            return vazba;
        } 

        private void uložitZákazníka_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression vvOslovení =
               this.oslovení.GetBindingExpression(ComboBox.TextProperty);
            BindingExpression vvJméno =
               this.jméno.GetBindingExpression(TextBox.TextProperty);
            BindingExpression vvPříjmení =
               this.příjmení.GetBindingExpression(TextBox.TextProperty);

            vvOslovení.UpdateSource();
            vvJméno.UpdateSource();
            vvPříjmení.UpdateSource();

            if (vvOslovení.HasError || vvJméno.HasError || vvPříjmení.HasError)
            {
                MessageBox.Show("Opravte prosím chyby", "Neuloženo");
            }
            else
            {
                Binding vazbaZákazníka =
                   BindingOperations.GetBinding(this.oslovení,
                                                ComboBox.TextProperty);
                Zákazník zákazník = vazbaZákazníka.Source as Zákazník;
                MessageBox.Show(zákazník.ToString(), "Uloženo");
            }
        }

        private void konec_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void muž_Checked(object sender, RoutedEventArgs e)
        {
            Binding vazba = vytvořVazbu("Žena");
            if (this.žena != null)
            {
                this.žena.SetBinding(RadioButton.IsCheckedProperty,
                                     vazba);
                BindingExpression vvŽena = this.žena.
                   GetBindingExpression(RadioButton.IsCheckedProperty);
                vvŽena.UpdateTarget();
            }
        }

        private void žena_Checked(object sender, RoutedEventArgs e)
        {
            Binding vazba = vytvořVazbu("Muž");
            if (this.muž != null)
            {
                this.muž.SetBinding(RadioButton.IsCheckedProperty, vazba);
                BindingExpression vvMuž = this.muž.
                   GetBindingExpression(RadioButton.IsCheckedProperty);
                vvMuž.UpdateTarget();
            }
        }
    }
}
