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

        private void ShowSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            if (LanguageComboBox.SelectedItem is Language selectedLanguage)
            {
                MessageBox.Show($"You selected: {selectedLanguage.Name} with value: {selectedLanguage.Value}");
            }
        }

        private void LanguageComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            NameTextBlock.Text = LanguageComboBox.SelectedItem is Language lang ? $"Selected Language: {lang.Name}" : "No language selected";
            ValueTextBlock.Text = LanguageComboBox.SelectedItem is Language lang2 ? $"Value: {lang2.Value}" : "No value selected";
        }
    }
}