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
using System.Windows.Shapes;

namespace Ishakov
{
    /// <summary>
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        DataBaseEntities db = new DataBaseEntities();
        int SchecludeCount = 1;
        public void RelListScheclude(int count)
        {
            Days d = db.Days.Where(x => x.ID == count).FirstOrDefault();
            day.Content = d.Name;
            lv.ItemsSource = db.Scheclude.Where(x => x.Days_id == count).ToList();
        }
        public AdminMenu()
        {
            InitializeComponent();
            list.ItemsSource = db.Student.ToList();
            RelListScheclude(SchecludeCount);
            back.Content = "<";
            add.Content = ">";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            int idS = Convert.ToInt32(b.Tag);
            Rating r = new Rating(idS);
            r.Show();
        }

        private void back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SchecludeCount > 1) SchecludeCount--;
            else SchecludeCount = 6;
            RelListScheclude(SchecludeCount);
        }

        private void add_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SchecludeCount < 6) SchecludeCount++;
            else SchecludeCount = 1;
            RelListScheclude(SchecludeCount);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            int id = Convert.ToInt32(cb.Tag);
            Scheclude less = db.Scheclude.Where(x => x.ID == id).FirstOrDefault();
            less.Items_id = Convert.ToInt32(cb.SelectedValue);
            db.SaveChanges();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.ItemsSource = db.Items.ToList();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.L)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            }
        }
    }
}
