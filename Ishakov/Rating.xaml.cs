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
    /// Логика взаимодействия для Rating.xaml
    /// </summary>
    public partial class Rating : Window
    {
        DataBaseEntities db = new DataBaseEntities();
        int idS;
        public Rating(int id)
        {
            InitializeComponent();
            idS = id;
            dg.ItemsSource = db.Ratings.Where(x => x.Student_id == idS).ToList();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            int[] och = { 0, 2, 3, 4, 5 };
            ((ComboBox)sender).ItemsSource = och;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedIndex > -1)
            {
                int id = Convert.ToInt32(cb.Tag);
                if (db.Ratings.Where(x => x.Items_id == id && x.Student_id == idS).Count() > 0)
                {
                    Ratings r = db.Ratings.Where(x => x.Items_id == id && x.Student_id == idS).FirstOrDefault();
                    r.Evaluation = Convert.ToInt32(cb.SelectedValue);
                    db.SaveChanges();
                }
            }
        }
    }
}
