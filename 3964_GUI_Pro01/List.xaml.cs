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

namespace _3964_GUI_Pro01
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : Window
    {
        public List()
        {
            InitializeComponent();
        }

        public List<Student> DatabaseStudents { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow  Window = new MainWindow();
            this.Visibility = Visibility.Hidden;
            Window.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                DatabaseStudents = context.Students.ToList();
                StudentList.ItemsSource = DatabaseStudents;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
