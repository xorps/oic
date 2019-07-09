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

namespace oic
{
    /// <summary>
    /// Interaction logic for FormularyAddPage.xaml
    /// </summary>
    public partial class FormularyAddPage : Page
    {
        private readonly Formulary formulary;

        public FormularyAddPage(Formulary formulary)
        {
            this.InitializeComponent();
            this.formulary = formulary;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var description = new FormularyDescription(this.descriptionInput.Text);
                formulary.Add(description);
                var result = MessageBox.Show(description + " Added to Formulary");
                this.NavigationService.Navigate(new MainPage());
            }
            catch (FormularyDescription.InvalidException err)
            {
                MessageBox.Show(err.HelpText);
            }
        }
    }
}
