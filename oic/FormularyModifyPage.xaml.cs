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
    /// Interaction logic for FormularyModifyPage.xaml
    /// </summary>
    public partial class FormularyModifyPage : Page
    {
        private readonly Formulary formulary;
        private readonly FormularyItem formularyItem;
        private readonly Barcodes barcodes;

        public FormularyModifyPage(Formulary formulary, FormularyItem formularyItem, Barcodes barcodes)
        {
            this.InitializeComponent();

            this.formulary = formulary;
            this.formularyItem = formularyItem;
            this.barcodes = barcodes;

            var items = barcodes.AllFor(formularyItem.ID);

            this.descriptionInput.Text = formularyItem.Description.ToString();
            this.barcodesControl.ItemsSource = items;
            this.barcodesLabel.Visibility = items.Any() ? Visibility.Visible : Visibility.Hidden;
        }

        private void AddBarcode_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddBarcodePage(this.formulary, this.formularyItem, this.barcodes));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FormularyViewPage(this.formulary, this.barcodes));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var newItem = this.formulary.UpdateDescription(this.formularyItem, new FormularyDescription(this.descriptionInput.Text));
                this.NavigationService.Navigate(new FormularyModifyPage(formulary, newItem, barcodes));
            }
            catch (FormularyDescription.InvalidException err)
            {
                MessageBox.Show(err.HelpText);
            }
        }
    }
}
