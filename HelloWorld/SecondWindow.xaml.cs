using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {

        private GridViewColumnHeader listViewSortCol = null;
        private ListSortDirection listViewSortDir = ListSortDirection.Ascending;
       
        public SecondWindow()
        {
            InitializeComponent();
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;

        }

        private void uxUsersColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            //Get column to sort by.
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();

            //Reset sort.
            if (listViewSortCol != null)
            {
                uxList.Items.SortDescriptions.Clear();
            }

            //Default sort direction is ascending.
            ListSortDirection newDir = ListSortDirection.Ascending;
            
            //Check current sort direction, and change sort direction to descending if current direction is ascending.
            if (listViewSortDir == ListSortDirection.Ascending)
            {
                newDir = ListSortDirection.Descending;

            }

            //Store new sort values.
            listViewSortCol = column;
            listViewSortDir = newDir;

            //Do the sort.
            uxList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }


    }
}
