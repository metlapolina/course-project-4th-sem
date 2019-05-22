using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToDoshka.Model;

namespace ToDoshka
{
    public partial class ToDoSubItem : UserControl
    {
        bool imgClick = false;
        bool fClick = false;
        Attachments attach = new Attachments();
        Subtasks subtask;
        int id;
        private byte[] _imageBytes = null;
        private byte[] _fileBytes = null;

        public ToDoSubItem(int Id, string text = "")
        {
            InitializeComponent();

            id = Id;
            txt_Subtask.Text = text;

            LoadSubtasks();
            
        }

        private void LoadSubtasks()
        {
            subtask = Registration.unit.Subtasks.Get(s => s.ID == id).Single();
            attach.SubtaskID = subtask.ID;
            if (subtask.isCheck != null)
            {
                btn_SubtaskSolved.IsChecked = subtask.isCheck;
            }
            else
            {
                btn_SubtaskSolved.IsChecked = false;
            }
            if (Registration.unit.Attachments.Get(a => a.SubtaskID == subtask.ID && a.TaskID == null).Count() != 0)
            {
                attach = Registration.unit.Attachments.Get(a => a.SubtaskID == subtask.ID).FirstOrDefault();
                LoadAttachs();
            }
            else
            {
                Registration.unit.Attachments.Create(attach);
                Registration.unit.Save();
            }
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            MainPage.ToDoSubItem_Delete(this, id);
        }

        private void Btn_AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            if (imgClick == false)
            {
                var dialog = new OpenFileDialog
                {
                    CheckFileExists = true,
                    Multiselect = false,
                    Filter = "Images (*.jpg,*.png)|*.jpg;*.png|All Files(*.*)|*.*"
                };
                if (dialog.ShowDialog() != true) { return; }

                string path = dialog.FileName;

                using (var fs = new FileStream(path.ToString(), FileMode.Open, FileAccess.Read))
                {
                    _imageBytes = new byte[fs.Length];
                    fs.Read(_imageBytes, 0, System.Convert.ToInt32(fs.Length));
                }
                SaveImage(path);
                md_AddPhoto.Foreground = Brushes.Black;
                imgClick = true;
                AddPhotoContextMenu();
            }
            else
            {
                AddPhotoContextMenu();
            }
        }

        private void ShowImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AttachWindow window = new AttachWindow(1, attach.ImagePath)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                window.ShowDialog();
                imgClick = false;
            }
            catch
            {
                MessageBox.Show("Image path " + attach.ImagePath + " is not found");
            }
        }

        private void DeleteImage_Click(object sender, RoutedEventArgs e)
        {
            attach.ImagePath = null;
            attach.Image = null;
            Registration.unit.Attachments.Update(attach);
            Registration.unit.Save();
            md_AddPhoto.Foreground = Brushes.White;
            btn_AddPhoto.ContextMenu = null;
        }

        private void SaveImage(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path.ToString()))
                {
                    attach.ImagePath = path.ToString();
                    attach.Image = _imageBytes;
                    Registration.unit.Attachments.Update(attach);
                    Registration.unit.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Maybe the image path is too long.\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadAttachs()
        {
            if (attach != null && attach.Image != null && attach.ImagePath != null)
            {
                md_AddPhoto.Foreground = Brushes.Black;
                imgClick = true;
                AddPhotoContextMenu();
            }
            if (attach != null && attach.File != null && attach.FilePath != null)
            {
                md_AddFile.Foreground = Brushes.Black;
                fClick = true;
                AddFileContextMenu();
            }
        }

        private void AddPhotoContextMenu()
        {
            ContextMenu cm = new ContextMenu();
            MenuItem mi1 = new MenuItem
            {
                Header = "Show"
            };
            mi1.Click += ShowImage_Click;
            MenuItem mi2 = new MenuItem
            {
                Header = "Delete"
            };
            mi2.Click += DeleteImage_Click;
            cm.Items.Add(mi1);
            cm.Items.Add(mi2);
            btn_AddPhoto.ContextMenu = cm;
        }

        private void AddFileContextMenu()
        {
            ContextMenu cm = new ContextMenu();
            MenuItem mi1 = new MenuItem
            {
                Header = "Show"
            };
            mi1.Click += ShowFile_Click;
            MenuItem mi2 = new MenuItem
            {
                Header = "Delete"
            };
            mi2.Click += DeleteFile_Click;
            cm.Items.Add(mi1);
            cm.Items.Add(mi2);
            btn_AddFile.ContextMenu = cm;
        }

        private void Btn_AddFile_Click(object sender, RoutedEventArgs e)
        {
            if (fClick == false)
            {
                OpenFileDialog dlg = new OpenFileDialog
                {
                    CheckFileExists = true,
                    Multiselect = false,
                    Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*"
                };
                if (dlg.ShowDialog() != true) { return; }

                string path = dlg.FileName;

                using (var fs = new FileStream(path.ToString(), FileMode.Open, FileAccess.Read))
                {
                    _fileBytes = new byte[fs.Length];
                    fs.Read(_fileBytes, 0, System.Convert.ToInt32(fs.Length));
                }
                SaveFile(path);

                md_AddFile.Foreground = Brushes.Black;
                fClick = true;
                AddFileContextMenu();
            }
            else
            {
                AddFileContextMenu();
            }
        }

        private void SaveFile(string path)
        {
            try
            {
                if (!String.IsNullOrEmpty(path.ToString()))
                {
                    attach.FilePath = path.ToString();
                    attach.File = _fileBytes;
                    Registration.unit.Attachments.Update(attach);
                    Registration.unit.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Maybe the file path is too long.\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AttachWindow window = new AttachWindow(2, attach.FilePath)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                window.ShowDialog();
                fClick = false;
            }
            catch
            {
                MessageBox.Show("File path "+attach.FilePath+" is not found");
            }
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            attach.FilePath = null;
            attach.File = null;
            Registration.unit.Attachments.Update(attach);
            Registration.unit.Save();
            md_AddFile.Foreground = Brushes.White;
            btn_AddFile.ContextMenu = null;
        }

        bool checkEdit = true;
        private void Btn_EditSubtask_Click(object sender, RoutedEventArgs e)
        {
            if (checkEdit)
            {
                txt_Subtask.IsReadOnly = false;
                md_EditSubtask.Foreground = Brushes.Black;
                checkEdit = false;
            }
            else
            {
                subtask.Subtask = txt_Subtask.Text;
                Registration.unit.Subtasks.Update(subtask);
                Registration.unit.Save();
                txt_Subtask.IsReadOnly = true;
                md_EditSubtask.Foreground = Brushes.White;
                checkEdit = true;
            }
        }

        private void Btn_SubtaskSolved_Click(object sender, RoutedEventArgs e)
        {
            if (btn_SubtaskSolved.IsChecked == true)
            {
                subtask.isCheck = true;
                Registration.unit.Subtasks.Update(subtask);
                Registration.unit.Save();
            }
            else
            {
                subtask.isCheck = false;
                Registration.unit.Subtasks.Update(subtask);
                Registration.unit.Save();
            }
        }
    }
}
