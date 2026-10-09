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

namespace trpo_pract4_Savitsin_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Document CurrentDoc = new Document();
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = CurrentDoc;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var currentDoc = (Document)Resources["CurrentDoc"];

            if (txtName.Text == "" || txtCountPage.Text == "" 
                || txtCountCopies.Text == "" || txtPricePage.Text == "")
            {
                MessageBox.Show("Поля должны быть заполнены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            currentDoc.Id = rnd.Next(0, 100);
            currentDoc.Name = txtName.Text;

            try
            {
                currentDoc.CountPage = int.Parse(txtCountPage.Text);
                currentDoc.CountCopies = int.Parse(txtCountCopies.Text);
                currentDoc.PricePage = int.Parse(txtPricePage.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNewRecord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFindByID_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}