using Marathon.Class;
using Marathon.Entities;
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

namespace Marathon.Pages
{
    /// <summary>
    /// Логика взаимодействия для RunnerTablePage.xaml
    /// </summary>
    public partial class RunnerTablePage : Page
    {
        public RunnerTablePage()
        {
            InitializeComponent();
            var runners = Core.DB.Runner.ToList();

            RunnersDataGrid.ItemsSource = runners;
            CountriesCombobox.ItemsSource = Core.DB.Country.ToList();
        }

        private void CountryFilterButton_Click(object sender, RoutedEventArgs e)
        {
            var item = CountriesCombobox.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Страна не выбрана");
                return;
            }
            var selectedCountry = item as Country;
            var runnersFromOneCountry = Core.DB.Runner.Where(r => r.CountryCode == selectedCountry.CountryCode).ToList();
            RunnersDataGrid.ItemsSource = runnersFromOneCountry;
        }

        private void AllCountryButton_Click(object sender, RoutedEventArgs e)
        {
            var item = CountriesCombobox.SelectedItem;
            var selectedCountry = item as Country;
            var runnersFromOneCountry = Core.DB.Runner.ToList();
            RunnersDataGrid.ItemsSource = runnersFromOneCountry;
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentEmail = EmailTextBox.Text;
            if (currentEmail == "")
            {
                MessageBox.Show("Пусто");
                return;
            }
            //var runnersWithThisEmail = Core.DB.Runner.Where(r => r.Email == currentEmail).ToList();
            var runnersWithThisEmail = Core.DB.Runner.Where(r => r.Email.StartsWith(currentEmail)).ToList();
            RunnersDataGrid.ItemsSource = runnersWithThisEmail;
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentName = NameTextBox.Text;
            if (currentName == "")
            {
                var item = CountriesCombobox.SelectedItem;
                var selectedCountry = item as Country;
                var runnersFromOneCountry = Core.DB.Runner.ToList();
                RunnersDataGrid.ItemsSource = runnersFromOneCountry;
                //MessageBox.Show("Пусто");
                //return;
            }
            var runnersWithThisName = Core.DB.Runner.Where(r => r.User.FirstName.StartsWith(currentName) || r.User.LastName.StartsWith(currentName)).ToList();
            RunnersDataGrid.ItemsSource = runnersWithThisName;
        }
    }
}


