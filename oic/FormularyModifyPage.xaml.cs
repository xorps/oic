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

            descriptionInput.Text = formularyItem.Description.ToString();
            barcodesControl.ItemsSource = items;
            barcodesLabel.Text = items.Any() ? "Barcodes" : "No Barcodes";
        }

        private void AddBarcode_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new AddBarcodePage(formulary, formularyItem, barcodes));

        private void Cancel_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new FormularyViewPage(formulary, barcodes));

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            FormularyDescription.Create(descriptionInput.Text).Foreach(Ok: description =>
            {
                var newItem = formulary.UpdateDescription(formularyItem, description);
                NavigationService.Navigate(new FormularyModifyPage(formulary, newItem, barcodes));
            },
            Error: err => MessageBox.Show(err));
        }
    }
}
