using System.Windows;
using System.IO;
using WpfJsonToCombobox.Models;

namespace WpfJsonToCombobox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadJson();
        }

        private void LoadJson()
        {
            string jsonPath = @"Assets\languages.json";
            string jsonContent = File.ReadAllText(jsonPath);
            List<Language>? languages = System.Text.Json.JsonSerializer.Deserialize<List<Language>>(jsonContent);
            if (languages != null)
            {
                LanguageComboBox.ItemsSource = languages;
                LanguageComboBox.DisplayMemberPath = "Name";
                LanguageComboBox.SelectedValuePath = "Value";
                LanguageComboBox.SelectedIndex = 0;
            }
        }
    }
}