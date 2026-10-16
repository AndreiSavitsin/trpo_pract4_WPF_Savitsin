using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
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

            try
            {
                currentDoc.Id = int.Parse(txtId.Text);
                currentDoc.Name = txtName.Text;

                currentDoc.CountPage = int.Parse(txtCountPage.Text);
                currentDoc.CountCopies = int.Parse(txtCountCopies.Text);
                currentDoc.PricePage = int.Parse(txtPricePage.Text);

                string fileName = "Documents.json";
                string jsonString = JsonSerializer.Serialize(currentDoc);
                File.AppendAllText(fileName, jsonString + Environment.NewLine);

                MessageBox.Show("Документ сохранен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNewRecord_Click(object sender, RoutedEventArgs e)
        {
            var currentDoc = (Document)Resources["CurrentDoc"];

            txtId.Text = "0";
            txtName.Text = "Название документа";
            txtCountPage.Text = "0";
            txtCountCopies.Text = "0";
            txtPricePage.Text = "0";            
        }

        private void btnFindByID_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("Documents.json"))
            {
                string fileName = "Documents.json";
                bool find = false;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while(!sr.EndOfStream)
                    {
                        string jsonString = sr.ReadLine();
                        Document document = JsonSerializer.Deserialize<Document>(jsonString)!;
                        if (txtId.Text == document.Id.ToString())
                        {
                            MessageBox.Show("Документ найден", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                            txtId.Text = document.Id.ToString();
                            txtName.Text = document.Name;
                            txtCountPage.Text = document.CountPage.ToString();
                            txtCountCopies.Text = document.CountCopies.ToString();
                            txtPricePage.Text = document.PricePage.ToString();

                            find = true;
                        }
                    }
                }
                if (find == false)
                {
                    MessageBox.Show("Документ не найден", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("Documents.json"))
            {
                bool find = false;
                string fileName = "Documents.json";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string jsonString = sr.ReadLine();
                    Document document = JsonSerializer.Deserialize<Document>(jsonString)!;
                    if (txtName.Text == document.Name)
                    {
                        MessageBox.Show("Документ найден", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                        txtId.Text = document.Id.ToString();
                        txtName.Text = document.Name;
                        txtCountPage.Text = document.CountPage.ToString();
                        txtCountCopies.Text = document.CountCopies.ToString();
                        txtPricePage.Text = document.PricePage.ToString();

                        find = true;
                    }                    
                }
                if (find == false)
                {
                    MessageBox.Show("Документ не найден", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}