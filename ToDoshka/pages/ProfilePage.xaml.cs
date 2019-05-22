using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using ToDoshka.Model;

namespace ToDoshka
{
    public partial class ProfilePage : Page
    {
        Users user = new Users();
        Attachments attach = new Attachments();
        public ProfilePage()
        {
            InitializeComponent();

            user = MainWindow.User;
            FillInfo();
            CheckAttach();

            List<string> styles = new List<string> { "Coral", "Black & White" };
            cb_Themes.SelectionChanged += SelectTheme;
            cb_Themes.ItemsSource = styles;

            List<string> langs = new List<string> { "English", "Russian" };
            cb_Langs.SelectionChanged += SelectLangs;
            cb_Langs.ItemsSource = langs;

            sp_Statistics.Children.Add(new StatisticsControl(user));
        }

        private void FillInfo()
        {
            UserName.Content = user.Surname + " " + user.Name;
            if (user.Description != null)
            {
                ProfLoc.Content = user.Description;
                tb_Desc.Text = user.Description;
            }
            lbl_Email.Text = user.Email;
            if (user.Phone != null)
            {

                lbl_Phone.Text = user.Phone;
            }
            if (user.Contact != null)
            {
                lbl_Contacts.Text = user.Contact;
            }
        }

        private void CheckAttach()
        {
            if (Registration.unit.Attachments.Get(a => a.UserID == user.ID && a.TaskID == null).Count() != 0)
            {
                attach = Registration.unit.Attachments.Get(a => a.UserID == user.ID).FirstOrDefault();
                LoadImage();
            }
            else
            {
                attach.UserID = user.ID;
                Registration.unit.Attachments.Create(attach);
                Registration.unit.Save();
            }
        }

        private void SelectTheme(object sender, SelectionChangedEventArgs e)
        {
            string style = cb_Themes.SelectedItem as string;
            Uri uri = null;
            switch (style)
            {
                case "Coral":
                    {
                        uri = new Uri("resources/themes/CoralTheme.xaml", UriKind.Relative);
                        break;
                    }
                case "Black & White":
                    {
                        uri = new Uri("resources/themes/BWTheme.xaml", UriKind.Relative);
                        break;
                    }
            }

            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            cb_Themes.SelectedItem = style;
        }
        
        private void SelectLangs(object sender, SelectionChangedEventArgs e)
        {
            string lang = cb_Langs.SelectedItem as string;
            Uri uri = null;
            switch (lang)
            {
                case "English":
                    {
                        uri = new Uri("resources/langs/lang_EN.xaml", UriKind.Relative);
                        break;
                    }
                case "Russian":
                    {
                        uri = new Uri("resources/langs/lang_RU.xaml", UriKind.Relative);
                        break;
                    }
            }
            
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            sp_Statistics.Children.RemoveAt(0);
            sp_Statistics.Children.Add(new StatisticsControl(user));
        }

        private byte[] _imageBytes = null;
        private void Btn_UploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false,
                Filter = "Images (*.jpg,*.png)|*.jpg;*.png|All Files(*.*)|*.*"
            };
            if (dialog.ShowDialog() != true) { return; }

            lbl_PhotoPath.Content = dialog.FileName;
            img_ProfilePhoto.ImageSource = new BitmapImage(new Uri(lbl_PhotoPath.Content.ToString()));

            using (var fs = new FileStream(lbl_PhotoPath.Content.ToString(), FileMode.Open, FileAccess.Read))
            {
                _imageBytes = new byte[fs.Length];
                fs.Read(_imageBytes, 0, System.Convert.ToInt32(fs.Length));
            }
            SaveImage();
        }
        
        private void SaveImage()
        {
            if (!String.IsNullOrEmpty(lbl_PhotoPath.Content.ToString()))
            {
                attach.ImagePath = lbl_PhotoPath.Content.ToString();
                attach.Image = _imageBytes;
                Registration.unit.Attachments.Update(attach);
                Registration.unit.Save();
            }
        }
        
        private void LoadImage()
        {
            try
            {
                if (attach != null && attach.Image != null && attach.ImagePath != null)
                {
                    img_ProfilePhoto.ImageSource = new BitmapImage(new Uri(attach.ImagePath));
                    lbl_PhotoPath.Content = attach.ImagePath;
                }
            }
            catch
            {
                MessageBox.Show("Photo path " + attach.ImagePath + " is not found");
            }
        }

        private void Btn_ChangeDesc_Click(object sender, RoutedEventArgs e)
        {
            ProfLoc.Content = tb_Desc.Text;
            user.Description = tb_Desc.Text;
            Registration.unit.Users.Update(user);
            Registration.unit.Save();
        }

        bool checkEmail = true;
        private void Btn_EditEmail_Click(object sender, RoutedEventArgs e)
        {
            if (checkEmail)
            {
                lbl_Email.IsReadOnly = false;
                btn_EditEmail.BorderBrush = Brushes.White;
                checkEmail = false;
            }
            else
            {
                user.Email = lbl_Email.Text;
                Registration.unit.Users.Update(user);
                Registration.unit.Save();
                lbl_Email.IsReadOnly = true;
                btn_EditEmail.BorderBrush = Brushes.Transparent;
                checkEmail = true;
            }
        }

        bool checkPhone = true;
        private void Btn_EditPhone_Click(object sender, RoutedEventArgs e)
        {
            if (checkPhone)
            {
                lbl_Phone.IsReadOnly = false;
                btn_EditPhone.BorderBrush = Brushes.White;
                checkPhone = false;
            }
            else
            {
                user.Phone = lbl_Phone.Text;
                Registration.unit.Users.Update(user);
                Registration.unit.Save();
                lbl_Phone.IsReadOnly = true;
                btn_EditPhone.BorderBrush = Brushes.Transparent;
                checkPhone = true;
            }
        }

        bool checkContact = true;
        private void Btn_EditContact_Click(object sender, RoutedEventArgs e)
        {
            if (checkContact)
            {
                lbl_Contacts.IsReadOnly = false;
                btn_EditContact.BorderBrush = Brushes.White;
                checkContact = false;
            }
            else
            {
                user.Contact = lbl_Contacts.Text;
                Registration.unit.Users.Update(user);
                Registration.unit.Save();
                lbl_Contacts.IsReadOnly = true;
                btn_EditContact.BorderBrush = Brushes.Transparent;
                checkContact = true;
            }
        }
    }
}