using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ToDoshka.Model;

namespace ToDoshka
{
    public partial class AttachWindow : Window
    {
        public AttachWindow(int flag, string path = "", Users user = null)
        {
            try
            {
                InitializeComponent();
                if (flag == 1)
                {
                    rtb_ShowText.Visibility = Visibility.Hidden;
                    img_ShowImage.Source = new BitmapImage(new Uri(path.ToString()));
                    gd_ShowStatistics.Background = Brushes.White;
                    wd_Attach.ResizeMode = ResizeMode.CanResize;
                }
                if (flag == 2)
                {
                    img_ShowImage.Visibility = Visibility.Hidden;
                    TextRange range = new TextRange(rtb_ShowText.Document.ContentStart, rtb_ShowText.Document.ContentEnd);
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        switch (System.IO.Path.GetExtension(path).ToLower())
                        {
                            case ".rtf":
                                range.Load(fs, DataFormats.Rtf);
                                break;
                            case ".txt":
                                range.Load(fs, DataFormats.Text);
                                break;
                            default:
                                throw new Exception("Invalid format");
                        }
                    }
                    gd_ShowStatistics.Background = Brushes.White;
                    wd_Attach.ResizeMode = ResizeMode.CanResize;
                }
                if (flag == 3)
                {
                    img_ShowImage.Visibility = Visibility.Hidden;
                    rtb_ShowText.Visibility = Visibility.Hidden;
                    gd_ShowStatistics.Background = Brushes.DarkGray;
                    gd_ShowStatistics.Children.Add(new StatisticsControl(user));
                    wd_Attach.ResizeMode = ResizeMode.NoResize;
                }
                if (flag == 4)
                {
                    img_ShowImage.Visibility = Visibility.Hidden;
                    rtb_ShowText.Visibility = Visibility.Hidden;
                    var tasks = Registration.unit.Tasks.Get(t => t.UserID == user.ID);
                    ListBox listBox = new ListBox();
                    foreach (Tasks t in tasks)
                    {
                        ToDoItem item = new ToDoItem(t.Task, t.ID)
                        {
                            Margin = new Thickness(10, 0, 0, 0)
                        };
                        listBox.Items.Add(item);
                    }
                    gd_ShowStatistics.Children.Add(listBox);
                    wd_Attach.ResizeMode = ResizeMode.NoResize;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
