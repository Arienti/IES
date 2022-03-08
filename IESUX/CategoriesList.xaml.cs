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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IESUX
{
    /// <summary>
    /// Interaction logic for CategoriesList.xaml
    /// </summary>
    public partial class CategoriesList : Page
    {
        private CategoriesBusiness categories = new CategoriesBusiness();
        public CategoriesList()
        {
            InitializeComponent();

            RefreshCategoryList();
        }
        private void RefreshCategoryList()
        {
            List<CategoryDTO> categoriesDTO = categories.Get();
            dataGrid.Items.Clear();

            foreach (CategoryDTO category in categoriesDTO)
            {
                dataGrid.Items.Add(category);
            }
        }
        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow categoryWindow = new CategoryWindow(categories);
            categoryWindow.Title = "Add Category";
            //categoryWindow.Owner = this;

            if (categoryWindow.ShowDialog() == true)
            {
                RefreshCategoryList();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow categoryWindow = new CategoryWindow(categories);
            //categoryWindow.Owner = this;
            categoryWindow.Title = "Edit Category";

            categoryWindow.AddMode = false;
            categoryWindow.CategoryID.IsReadOnly = true;


            CategoryDTO categoryDTO = dataGrid.SelectedItem as CategoryDTO;
            categoryWindow.CategoryID.Text = categoryDTO.CategoryId.ToString();
            categoryWindow.CategoryName.Text = categoryDTO.CategoryName.ToString();

            if (categoryWindow.ShowDialog() == true)
            {
                RefreshCategoryList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            CategoryDTO category = dataGrid.SelectedItem as CategoryDTO;
            ResultDTO resultDTO = categories.Delete(category);
            List<CategoryDTO> categoryDTO = new List<CategoryDTO>();
            foreach (CategoryDTO categories in categoryDTO)
            {
                dataGrid.Items.Remove(categories);
            }
            RefreshCategoryList();
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
