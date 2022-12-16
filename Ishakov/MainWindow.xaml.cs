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

namespace Ishakov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBaseEntities db = new DataBaseEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginB_Click(object sender, RoutedEventArgs e)
        {
            if (loginText.Text == "admin" && passwordText.Password == "admin")
            {
                MessageBox.Show($"Вход выполнен под пользователем администратор");
                AdminMenu am = new AdminMenu();
                am.Show();
                Close();
            }
            else if (db.Logins.Where(x => x.Login == loginText.Text && x.Password == passwordText.Password).Count() > 0)
            {
                Student s = db.Student.Where(x => x.Logins.Login == loginText.Text && x.Logins.Password == passwordText.Password).FirstOrDefault();
                MessageBox.Show($"Вход выполнен под пользователем {s.FullName}");
                StudentMenu sm = new StudentMenu(s.ID);
                sm.Show();
                Close();
            }
            else MessageBox.Show("Такого логина или пароля нет");
        }
    }
}
