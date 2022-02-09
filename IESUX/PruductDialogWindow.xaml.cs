using IESUX.Business;
using IESUX.Models;
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
using System.Windows.Shapes;

namespace IESUX
{
    /// <summary>
    /// Interaction logic for PruductDialogWindow.xaml
    /// </summary>
    public partial class PruductDialogWindow : Window
    {
        private ProductsBusiness products;

        public PruductDialogWindow(ProductsBusiness products)
        {
            this.products = products;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
           
            Close();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            ProductDTO product = new ProductDTO();
            product.Id = int.Parse(ID.Text);
            product.Description = Description.Text;
            product.Cost = float.Parse(Cost.Text);
            ResultDTO result = products.Add(product);

            if (result.Error == true)
            {
                TotalCost.Text = result.Message;
            }
            else
            {
                Close();
            }
        }
    }
}
