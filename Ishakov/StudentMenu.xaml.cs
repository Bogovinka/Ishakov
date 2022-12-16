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
    /// Логика взаимодействия для StudentMenu.xaml
    /// </summary>
    public partial class StudentMenu : Window
    {
        public StudentMenu(int id)
        {
            DataBaseEntities db = new DataBaseEntities();
            InitializeComponent();
            dg.ItemsSource = db.Ratings.Where(x => x.Student_id == id).ToList();
            pn.ItemsSource = db.Scheclude.Where(x => x.Days_id == 1).ToList();
            vt.ItemsSource = db.Scheclude.Where(x => x.Days_id == 2).ToList();
            sr.ItemsSource = db.Scheclude.Where(x => x.Days_id == 3).ToList();
            ct.ItemsSource = db.Scheclude.Where(x => x.Days_id == 4).ToList();
            pt.ItemsSource = db.Scheclude.Where(x => x.Days_id == 5).ToList();
            sb.ItemsSource = db.Scheclude.Where(x => x.Days_id == 6).ToList();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.L)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            }
        }
    }
}
