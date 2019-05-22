using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToDoshka.Model;

namespace ToDoshka
{
    public partial class ToDoItem : UserControl
    {
        Tasks task;
        int id;
        public ToDoItem(string text, int Id)
        {
            InitializeComponent();
            txt_Task.Text = text;
            id = Id;

            LoadItem();
        }

        private void LoadItem()
        {
            task = Registration.unit.Tasks.Get(t => t.ID == id).Single();
            var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == id);
            if (subtasks != null && task.isCheck == true)
            {
                foreach (Subtasks s in subtasks)
                {
                    if (s.isCheck != true)
                    {
                        s.isCheck = true;
                        Registration.unit.Subtasks.Update(s);
                        Registration.unit.Save();
                    }
                }
            }
            if (task.Importance != null)
            {
                BasicRatingBar.Value = Convert.ToInt32(task.Importance);
            }
            if (task.isCheck != null)
            {
                btn_TaskSolved.IsChecked = task.isCheck;
            }
            if (task.Time != null)
            {
                DeadlineToolTip(Convert.ToDateTime(task.Time));
                DeadlineContextMenu();
            }
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            MainPage.ToDoItem_Delete(this, id);
        }
        
        private void Btn_AddSubtask_Click(object sender, RoutedEventArgs e)
        {
            MainPage.ToDoSubItem_Add(this, id);
        }

        bool checkEdit = true;
        private void Btn_EditTask_Click(object sender, RoutedEventArgs e)
        {
            if (checkEdit)
            {
                txt_Task.IsReadOnly = false;
                md_EditTask.Foreground = Brushes.Black;
                checkEdit = false;
            }
            else
            {
                task.Task = txt_Task.Text;
                Registration.unit.Tasks.Update(task);
                Registration.unit.Save();
                txt_Task.IsReadOnly = true;
                md_EditTask.Foreground = Brushes.White;
                checkEdit = true;
            }
        }

        private void Btn_TaskSolved_Click(object sender, RoutedEventArgs e)
        {
            if (btn_TaskSolved.IsChecked==true)
            {
                task.isCheck = true;
                task.CheckTime = DateTime.Now;
            }
            else
            {
                task.isCheck = false;
                task.CheckTime = null;
            }

            Registration.unit.Tasks.Update(task);
            Registration.unit.Save();
        }

        private void BasicRatingBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e)
        {
            task.Importance = BasicRatingBar.Value;
            Registration.unit.Tasks.Update(task);
            Registration.unit.Save();
            cb_Importance.Foreground = Brushes.Black;            
        }
        
        private void Dp_Deadline_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = new DateTime();
            date = Convert.ToDateTime(dp_Deadline.SelectedDate);
            DeadlineToolTip(date);

            DeadlineContextMenu();

            task.Time = date;
            Registration.unit.Tasks.Update(task);
            Registration.unit.Save();
        }

        private void DeadlineToolTip(DateTime date)
        {
            ToolTip toolTip = new ToolTip
            {
                HasDropShadow = true,
                Foreground = Brushes.Black,
                Background = Brushes.White,
                HorizontalOffset = 40,
                VerticalOffset = -20,
                Content = new TextBlock { Text = date.ToShortDateString(), FontSize = 16, Foreground = Brushes.Gray }
            };
            dp_Deadline.ToolTip = toolTip;
            dp_Deadline.BorderBrush = Brushes.Black;
        }

        private void DeadlineContextMenu()
        {
            ContextMenu cm = new ContextMenu();
            MenuItem mi = new MenuItem
            {
                Header = "Delete"
            };
            mi.Click += DeleteDeadline_Click;
            cm.Items.Add(mi);
            btn_Deadline.ContextMenu = cm;
        }

        private void DeleteDeadline_Click(object sender, RoutedEventArgs e)
        {
            dp_Deadline.BorderBrush = Brushes.White;
            dp_Deadline.ToolTip = null;

            task.Time = null;
            Registration.unit.Tasks.Update(task);
            Registration.unit.Save();
        }
    }
}
