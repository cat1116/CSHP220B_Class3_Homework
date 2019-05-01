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
using System.Data.Entity;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();

        public MainWindow()
        {
            InitializeComponent();
            //uxName.DataContext = user;
            //uxNameError.DataContext = user;

            var sample = new SampleEntities();

            sample.Users.Load();

            uxList.ItemsSource = sample.Users.Local;


            uxContainer.DataContext = user;

            //WindowState = WindowState.Maximized;

        }

        private void UxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);

            var window = new SecondWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }

        //private void UxNameAndPassword_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if(uxName.Text != string.Empty && uxPassword.Text != string.Empty)
        //    {
        //        uxSubmit.IsEnabled = true;
        //        uxSubmit.Background = Brushes.Red;



        //    }
        //    else
        //    {
        //        uxSubmit.IsEnabled = false;
        //        uxSubmit.Background = Brushes.Gray;


        //    }
        //}
    }
}
