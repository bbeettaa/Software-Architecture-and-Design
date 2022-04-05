using BLL.Classes.BLL.Context;
using BLL.Classes.File;
using BLL.Classes.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    public partial class MainWindow : Window
    {
        UserContext userContext;
        IComparer<Content> comparer;
        enum SortingOrder {ASC, DESC };
        SortingOrder sortingOrder;

        public MainWindow(UserContext userContext)
        {
            this.userContext = userContext;
            InitializeComponent();
            sortingOrder = SortingOrder.ASC;

            DrowListViewItems_Contents(userContext.GetContents());
            DrowListViewItems_Extensions();


        }

/*        public MainWindow()
        {
            throw new Exception("UserContext is Null");
        }
*/
        //----------------------

       
        private void DrowListViewItems_Extensions() {
            List<String> currExts = new List<string>();
            List<String> newExts = userContext.GetExtensions();

            foreach (CheckBox checkBox in this.listBoxExtension.Items)
                currExts.Add(checkBox.Name);
            foreach (var cont in userContext.GetExtensions())
                if (currExts.Contains(cont.Replace(".", "")))
                    newExts.Remove(cont);
                else {
                    var checkBoxNew = new CheckBox()
                    {
                        Name = cont.Replace(".", ""),
                        Content = cont,
                        IsChecked = true
                    };
                    checkBoxNew.Unchecked += CheckBox_Unchecked;
                    checkBoxNew.Checked += CheckBox_Checked;
                    listBoxExtension.Items.Add(checkBoxNew);
                }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            List<Content> contents = new List<Content>();
            foreach (var content in userContext.GetContents())
                contents.Add(content);

            foreach(var checkBox in this.listBoxExtension.Items)
            for (int i = 0; i < contents.Count; i++)
            {
                if ((checkBox as CheckBox).IsChecked == false && contents[i].Extension.Contains((checkBox as CheckBox).Content.ToString()))
                    contents.Remove(contents[i--]);
            }
            DrowListViewItems_Contents(contents);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Content> contents = new List<Content>();
            foreach (var content in userContext.GetContents())
                contents.Add(content);

            foreach (var checkBox in this.listBoxExtension.Items)
                for (int i = 0; i < contents.Count; i++)
                {
                    if ((checkBox as CheckBox).IsChecked == false && contents[i].Extension.Contains((checkBox as CheckBox).Content.ToString()))
                        contents.Remove(contents[i--]);
                }
            DrowListViewItems_Contents(contents);
        }


        //----------------------

        private void DrowListViewItems_Contents(List<Content> contents) {
            listView.Items.Clear();
            foreach (var content in contents)
                listView.Items.Add(content);

            DrowListViewItems_Extensions();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        //----------------------

        private void MenuItem_Checked_AscendingSort(object sender, RoutedEventArgs e)
        {
            Descending.IsCheckable = true;
            Ascending.IsCheckable = false;
            Descending.IsChecked = false;
            sortingOrder = SortingOrder.ASC;
            userContext.Sort(comparer);
        }

        private void Ascending_Unchecked(object sender, RoutedEventArgs e) { }

        private void MenuItem_Checked_DescendingSort(object sender, RoutedEventArgs e)
        {
            Descending.IsCheckable = false;
            Ascending.IsCheckable = true;
            Ascending.IsChecked = false;
            sortingOrder = SortingOrder.DESC;
            userContext.Sort(comparer);
        }

        private void Descending_Unchecked(object sender, RoutedEventArgs e){ }

        private void MenuItem_SortByName(object sender, RoutedEventArgs e)
        {
            switch (sortingOrder) {
                case SortingOrder.ASC:
                    userContext.Sort(new SortByNameAsc());
                    break;
                case SortingOrder.DESC:
                    userContext.Sort(new SortByNameDesc());
                    break;
            }
            DrowListViewItems_Contents(userContext.GetContents());
        }

        private void MenuItem_SortByExtension(object sender, RoutedEventArgs e)
        {
            switch (sortingOrder)
            {
                case SortingOrder.ASC:
                    userContext.Sort(new SortByExtensionAsc());
                    break;
                case SortingOrder.DESC:
                    userContext.Sort(new SortByExtensionDesc());
                    break;
            }
            DrowListViewItems_Contents(userContext.GetContents());
        }

        private void MenuItem_SortByDate(object sender, RoutedEventArgs e)
        {
            switch (sortingOrder)
            {
                case SortingOrder.ASC:
                    userContext.Sort(new SortByDateDesc());
                    break;
                case SortingOrder.DESC:
                    userContext.Sort(new SortByDateAsc());
                    break;
            }
            DrowListViewItems_Contents(userContext.GetContents());
        }


        private void Open_File_Click(object sender, RoutedEventArgs e)
        {
            Content content = this.listView.SelectedItem as Content;
            try
            {
                System.Diagnostics.Process.Start(content.Path + "\\" + content.Name);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (System.NullReferenceException ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void Open_Dir_Click(object sender, RoutedEventArgs e)
        {
            Content content = this.listView.SelectedItem as Content;
            try
            {
                System.Diagnostics.Process.Start(content.Path);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItem_AddFile(object sender, RoutedEventArgs e)
        {

            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = "Documents";
            dialog.Multiselect = true;
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                foreach (var name in dialog.FileNames)
                    userContext.CreateFile(name);
                DrowListViewItems_Contents(userContext.GetContents());
            }
        }

        private void MenuItem_DellFile(object sender, RoutedEventArgs e)
        {
            try
            {
                userContext.DeleteFile(this.listView.SelectedItems[0] as Content);
                DrowListViewItems_Contents(userContext.GetContents());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }












        //----------------------

    }
}
