using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ToDoshka.Model;

namespace ToDoshka
{
    public partial class MainPage : Page
    {
        static Users user = new Users();
        Attachments attach = new Attachments();
        static StackPanel sp_Person;
        static StackPanel sp_Work;
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(Users user)
        {
            InitializeComponent();

            MainPage.user = user;

            FillFields();
            LoadImage();
            ShowTasks();
        }
        
        private void FillFields()
        {
            sp_Person = pnl_TasksP;
            sp_Work = pnl_TasksW;

            lbl_Name.Content = user.Surname + " " + user.Name;
            lbl_Discription.Content = user.Description;
            txt_Date.Text += " " + DateTime.Now.ToShortDateString();

            lbl_Scheduled.Content += " " + Registration.unit.Tasks.Get(t => t.UserID == user.ID && t.isCheck != true).Count();
            lbl_Completed.Content += " " + Registration.unit.Tasks.Get(t => t.UserID == user.ID && t.isCheck == true).Count();
        }
        private void LoadImage()
        {
            try
            {
                attach = Registration.unit.Attachments.Get(a => a.UserID == user.ID).FirstOrDefault();
                if (attach != null && attach.Image != null && attach.ImagePath != null)
                {
                    img_ProfilePhoto.ImageSource = new BitmapImage(new Uri(attach.ImagePath));
                }
            }
            catch
            {
                MessageBox.Show("Photo path " + attach.ImagePath + " is not found");
            }
        }
        private void ShowTasks()
        {
            var tasks = Registration.unit.Tasks.Get(t => t.UserID == user.ID).OrderByDescending(o => o.Importance);
            if (tasks != null)
            {
                foreach (Tasks task in tasks)
                {
                    if (task.CheckTime != null && task.CheckTime < DateTime.Now.AddDays(-1)) { }
                    else
                    {
                        var item = AddTaskItem(task.Task, task.ID, Convert.ToBoolean(task.isWork));
                        var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == task.ID);
                        if (subtasks != null)
                        {
                            foreach (Subtasks subtask in subtasks)
                            {
                                AddSubTaskItem(subtask.ID, Convert.ToBoolean(task.isWork), item, subtask.Subtask);
                            }
                        }
                    }
                }
            }
        }

        public static ToDoItem AddTaskItem( string text, int id, bool isWork)
        {
            ToDoItem item = new ToDoItem(text, id)
            {
                Margin = new Thickness(15, 10, 10, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            if (isWork == true)
            {
                sp_Work.Children.Add(item);
            }
            else
            {
                sp_Person.Children.Add(item);
            }
            return item;
        }

        public static void AddSubTaskItem(int id, bool isWork, ToDoItem item, string text = null)
        {
            ToDoSubItem subitem = new ToDoSubItem(id, text)
            {
                Margin = new Thickness(20, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            
            if (isWork == true)
            {
                int i = sp_Work.Children.IndexOf(item);
                sp_Work.Children.Insert(i + 1, subitem);
            }
            else
            {
                int i = sp_Person.Children.IndexOf(item);
                sp_Person.Children.Insert(i + 1, subitem);
            }
        }
        
        public static void CreateTaskItem(string text, bool isWork)
        {
            try
            {
                Tasks task;
                if (isWork)
                {
                    task = new Tasks { UserID = user.ID, Task = text, isWork = true, isCheck = false };
                }
                else
                {
                    task = new Tasks { UserID = user.ID, Task = text, isWork = false, isCheck = false };
                }
                Registration.unit.Tasks.Create(task);
                Registration.unit.Save();

                int id = Registration.unit.Tasks.Get(t => t.Task == text).FirstOrDefault().ID;
                AddTaskItem(text, id, isWork);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                
        private void Btn_AddTaskP_Click(object sender, RoutedEventArgs e)
        {
            string task = txt_AddTaskP.Text;
            if (task.Length != 0)
            {
                CreateTaskItem(task, false);
                txt_AddTaskP.Text = "";
            }
            else
            {
                MessageBox.Show("The task is empty!","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_AddTaskW_Click(object sender, RoutedEventArgs e)
        {
            string task = txt_AddTaskW.Text;
            if (task.Length != 0)
            {
                CreateTaskItem(task, true);
                txt_AddTaskW.Text = "";
            }
            else
            {
                MessageBox.Show("The task is empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("pages/ProfilePage.xaml", UriKind.Relative));
        }
        
        public static void ToDoItem_Delete(UIElement item, int id)
        {
            try
            {
                var task = Registration.unit.Tasks.Get(t => t.UserID == user.ID && t.ID==id).Single();
                var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == id);
                int count = subtasks.Count();
                if (task.isWork == true) {
                    int i = sp_Work.Children.IndexOf(item);
                    for (int j = 0; j < count; j++)
                        sp_Work.Children.RemoveAt(i+1);
                    sp_Work.Children.Remove(item);
                }
                else
                {
                    int i = sp_Person.Children.IndexOf(item);
                    for (int j = 0; j < count; j++)
                        sp_Person.Children.RemoveAt(i + 1);
                    sp_Person.Children.Remove(item);
                }
                Registration.unit.Tasks.Update(task);
                Registration.unit.Tasks.Remove(task);
                Registration.unit.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public static void ToDoSubItem_Add(UIElement item, int id)
        {
            try
            {
                Tasks task = Registration.unit.Tasks.Get(t => t.ID == id).FirstOrDefault();
                Subtasks subtask = new Subtasks { TaskID=id, isCheck=false };
                Registration.unit.Subtasks.Create(subtask);
                Registration.unit.Save();

                int Id = Registration.unit.Subtasks.Get(s => s.TaskID == id).LastOrDefault().ID;
                AddSubTaskItem(Id, Convert.ToBoolean(task.isWork), (ToDoItem)item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ToDoSubItem_Delete(UIElement item, int id)
        {
            try
            {
                var subtask = Registration.unit.Subtasks.Get(s => s.ID == id).Single();
                Tasks task = Registration.unit.Tasks.Get(t => t.ID == subtask.TaskID).FirstOrDefault();
                Registration.unit.Subtasks.Update(subtask);
                Registration.unit.Subtasks.Remove(subtask);
                Registration.unit.Save();
                if (task.isWork == true)
                {
                    sp_Work.Children.Remove(item);
                }
                else
                {
                    sp_Person.Children.Remove(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Statistics_Click(object sender, RoutedEventArgs e)
        {
            AttachWindow window = new AttachWindow(3,"", user)
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window.ShowDialog();
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            var x = MessageBox.Show("Do you really want to leave?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (x.Equals(MessageBoxResult.Yes))
            {
                Registration registration = new Registration();
                registration.Show();
                MainWindow.GetWindow(this).Close();
            }
        }

        private void Btn_AllTask_Click(object sender, RoutedEventArgs e)
        {
            AttachWindow window = new AttachWindow(4, "", user)
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window.ShowDialog();
        }
    }
}
