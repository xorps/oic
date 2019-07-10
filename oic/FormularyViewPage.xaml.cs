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
    /// Interaction logic for FormularyViewPage.xaml
    /// </summary>
    public partial class FormularyViewPage : Page
    {
        private readonly Formulary formulary;
        private readonly Barcodes barcodes;
        public FormularyViewPage(Formulary formulary, Barcodes barcodes)
        {
            this.InitializeComponent();

            this.formulary = formulary;
            this.barcodes = barcodes;
            this.itemsControl.ItemsSource = formulary.All();
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            var item = ((sender as Button).DataContext as FormularyItem);
            this.NavigationService.Navigate(new FormularyModifyPage(this.formulary, item, this.barcodes));
        }
    }
}
