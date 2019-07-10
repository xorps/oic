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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Formulary formulary = new Formulary();
        private readonly Barcodes barcodes = new Barcodes();

        public MainWindow()
        {
            this.InitializeComponent();
            this.frame.Navigate(new MainPage());
        }

        private void MenuItem_FormularyAddClick(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new FormularyAddPage(formulary));
        }

        private void MenuItem_FormularyViewClick(object sender, RoutedEventArgs e)
        {
            this.frame.Navigate(new FormularyViewPage(formulary, barcodes));
        }
    }
}
