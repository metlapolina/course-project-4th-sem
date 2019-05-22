using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToDoshka.Model;

namespace ToDoshka
{
    public partial class MainWindow : Window
    {
        public static Users User;

        public MainWindow(Users user)
        {
            InitializeComponent();

            User = user;

            AddAlert();
            MainFrame.Navigate(new MainPage(User));
        }
                
        private void Btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage(User));
        }
        
        private void Btn_Support_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("created by Metla Polina\n2019, Minsk", "Support", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }

        private void Btn_Alert_Click(object sender, RoutedEventArgs e)
        {
            cb_Alert.Items.Clear();
            AddAlert();
            cb_Alert.IsDropDownOpen = true;
        }

        private void AddAlert()
        {
            int count = 0;
            var tasks = Registration.unit.Tasks.Get(t => t.UserID == User.ID && t.isCheck != true);
            foreach (Tasks t in tasks)
            {
                if (t.Time != null)
                {
                    count++;
                    TextBlock text = new TextBlock { Text = "Task: " + t.Task + "\nDeadline: " + 
                        Convert.ToDateTime(t.Time).ToShortDateString(), FontSize = 16 };
                    if (t.Time <= DateTime.Now)
                    {
                        text.Foreground = Brushes.Red;
                    }
                    cb_Alert.Items.Add(text);
                }
            }
            md_Badged.Badge = count;
        }

        private void Cb_Drop_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            comboBox.IsDropDownOpen = false;
        }
        
        private void Txt_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            cb_Search.Items.Clear();
            var tasks = Registration.unit.Tasks.Get(t => t.UserID == User.ID);
            Collection<string> taskList = new Collection<string>();
            foreach (Tasks task in tasks)
            {
                taskList.Add(task.Task);
            }
            Regex regex = new Regex(@"(\w*)" + txt_Search.Text + @"(\w*)", RegexOptions.IgnoreCase);
            for (int i = 0; i < taskList.Count; i++)
            {
                Match match = regex.Match(taskList[i]);
                if (match.Success)
                {
                    var item = Registration.unit.Tasks.Get(t => t.Task == taskList[i]).FirstOrDefault();
                    cb_Search.Items.Add(new ToDoItem(item.Task, item.ID) { Width=450});
                }
            }
            cb_Search.IsDropDownOpen = true;
        }
    }
}
