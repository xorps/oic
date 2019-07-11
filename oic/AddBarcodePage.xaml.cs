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
    /// Interaction logic for AddBarcodePage.xaml
    /// </summary>
    public partial class AddBarcodePage : Page
    {
        private readonly Formulary formulary;
        private readonly FormularyItem formularyItem;
        private readonly Barcodes barcodes;

        public AddBarcodePage(Formulary formulary, FormularyItem formularyItem, Barcodes barcodes)
        {
            this.InitializeComponent();

            this.formulary = formulary;
            this.formularyItem = formularyItem;
            this.barcodes = barcodes;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Barcode.Create(formularyItem, barcodeInput.Text).Foreach(Ok: barcode =>
            {
                barcodes.Add(barcode).Foreach(Ok: () =>
                {
                    var _ = MessageBox.Show("Barcode added");
                    NavigationService.Navigate(new FormularyModifyPage(formulary, formularyItem, barcodes));
                },
                BarcodeInUse: () => MessageBox.Show("Barcode is in use"));
            },
            Error: () => MessageBox.Show("Barcode is invalid"));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FormularyModifyPage(formulary, formularyItem, barcodes));
        }
    }
}
