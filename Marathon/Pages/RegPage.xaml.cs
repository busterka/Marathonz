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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
           
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void RegistrButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var pass = PasswBox2.Text;
            var pass2 = PasswBox22.Text;
            var name = ImTextBox.Text;
            var fam = FamTextBox.Text;

            if (pass != pass2)
            {
                MessageBox.Show("Введите одинаковые пароли");
                return;
            }
            if (pass.Length < 4)
            {
                MessageBox.Show("пароль меньше 4 символов");
                return;
            }
            if (!email.Contains("@"))
            {
                MessageBox.Show("нет @, введите корректный email");
                return;
            }
            var correctPass = false;
            for (var i = 0; i < pass.Length; i++)
            {
                if (char.IsLetter(pass[i]))
                {
                    correctPass = true;
                }
            }
            if (!correctPass)
            {
                MessageBox.Show("некорректный пароль нет буквы");
                return;
            }
            correctPass = false;
            for (var i = 0; i < pass.Length; i++)
            {
                if (char.IsDigit(pass[i]))
                {
                    correctPass = true;
                }
            }
            if (!correctPass)
            {
                MessageBox.Show("некорректный пароль нет числа");
                return;
            }

            correctPass = false;
            for (var i = 0; i < pass.Length; i++)
            {
                if (char.IsUpper(pass[i]))
                {
                    correctPass = true;
                }
            }
            if (!correctPass)
            {
                MessageBox.Show("некорректный пароль нет большой буквы");
                return;
            }

            var specialChars = "!@#$%^&*()_+-";
            foreach (var c in pass)
            {
                if (specialChars.Contains(c))
                {
                    correctPass = true;
                }
            }
            if (!correctPass)
            {
                MessageBox.Show("некорректный пароль нет спец символа");
                return;
            }

            var u = new User();
            u.Email = email;
            u.LastName = name;
            u.FirstName = fam;
            u.Password = pass;
            u.RoleId = "R";
            Core.DB.User.Add(u);
            Core.DB.SaveChanges();
            MessageBox.Show("Пользователь добавлен");
            this.NavigationService.GoBack();

        }
    }
}
