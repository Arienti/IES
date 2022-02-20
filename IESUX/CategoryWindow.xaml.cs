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
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
   
    public partial class CategoryWindow : Window
    {
        private CategoriesBusiness categories;

        public bool AddMode = true;

        public CategoryWindow(CategoriesBusiness categories)
        {
            this.categories = categories;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryDTO category = new CategoryDTO();

            try
            {
                category.CategoryId = int.Parse(CategoryID.Text);
                category.CategoryName = CategoryName.Text;
            }
            catch (Exception exception)
            {
                CategoryIdError.Text = exception.Message;
                return;
            }
            ResultDTO result = new ResultDTO();
            if (AddMode)
            {
                result = categories.Add(category);
            }
            else
            {
                result = categories.Edit(category);
            }

            if (result.Error == true)
            {
                CategoryNameError.Text = result.Message;
            }
            else
            {
                this.DialogResult = true;
                Close();
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OKButton_Click(null, null);
            }
            else
           if (e.Key == Key.Escape)
            {
                CancelButton_Click(null, null);
            }
        }
    }
}
