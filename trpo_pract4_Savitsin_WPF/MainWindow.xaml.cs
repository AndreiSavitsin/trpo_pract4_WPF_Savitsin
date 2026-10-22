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

        public MainWindow()
        {
            InitializeComponent();
            CurrentDoc.GenerateNewId();
            DataContext = CurrentDoc;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentDoc.Name == "" || CurrentDoc.CountPage <= 0 
                || CurrentDoc.CountCopies <= 0 || CurrentDoc.PricePage <= 0)
            {
                MessageBox.Show("Поля должны быть заполнены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                string fileName = CurrentDoc.Id + ".json";
                string jsonString = JsonSerializer.Serialize(CurrentDoc);
                File.WriteAllText(fileName, jsonString);

                MessageBox.Show("Документ сохранен в файл " + fileName, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNewRecord_Click(object sender, RoutedEventArgs e)
        {
            CurrentDoc = new Document();
            CurrentDoc.GenerateNewId();
            DataContext = CurrentDoc;
            txtSearchID.Text = "";
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchId = txtSearchID.Text;

            if (searchId == "")
            {
                MessageBox.Show("Введите ID для поиска", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                string fileName = searchId + ".json";

                if (File.Exists(fileName))
                {
                    try
                    {
                        string jsonString = File.ReadAllText(fileName);
                        Document foundDoc = JsonSerializer.Deserialize<Document>(jsonString)!;

                        CurrentDoc.Id = foundDoc.Id;
                        CurrentDoc.Name = foundDoc.Name;
                        CurrentDoc.CountPage = foundDoc.CountPage;
                        CurrentDoc.CountCopies = foundDoc.CountCopies;
                        CurrentDoc.PricePage = foundDoc.PricePage;

                        MessageBox.Show("Документ найден", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при чтении файла: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Документ с таким ID не найден", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}