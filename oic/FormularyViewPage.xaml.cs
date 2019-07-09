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
        public FormularyViewPage(Formulary formulary)
        {
            this.InitializeComponent();

            this.itemsControl.ItemsSource = formulary.All();
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            var item = ((sender as Button).DataContext as FormularyItem);
            MessageBox.Show("Modify Item " + item.Description);
        }
    }
}
