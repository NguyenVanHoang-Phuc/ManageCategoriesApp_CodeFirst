using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManageCategoriesApp_ModelFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadCategories()
        {
            var categories = ManageCategories.Instance.GetCategories();
            dgCategories.ItemsSource = categories;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategories();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category { CategoryName = txtCategoryName.Text };
                ManageCategories.Instance.InsertCategory(category);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Category");
            }
            finally
            {
                LoadCategories();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category
                {
                    CategoryID = int.Parse(txtCategoryID.Text),
                    CategoryName = txtCategoryName.Text
                };
                ManageCategories.Instance.UpdateCategory(category);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Category");
            }
            finally
            {
                LoadCategories();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category
                {
                    CategoryID = int.Parse(txtCategoryID.Text)
                };
                ManageCategories.Instance.DeleteCategory(category);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Category");
            }
            finally
            {
                LoadCategories();
            }
        }

        private void dgCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCategories.SelectedItem == null)
                return;

            Category? selectedCategory = dgCategories.SelectedItem as Category;
            if (selectedCategory != null)
            {
                txtCategoryID.Text = selectedCategory.CategoryID.ToString();
                txtCategoryName.Text = selectedCategory.CategoryName;
            }
        }
    }


}