using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ToDoshka.Model;

namespace ToDoshka
{
    public partial class Registration : Window
    {
        public static UnitOfWork unit = new UnitOfWork();

        public Registration()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool correct = CheckTextBoxes();
                if (correct)
                {
                    var user = unit.Users.Get(u => u.User == Login.Text && u.Password == Password.Password).FirstOrDefault();
                    if (user != null)
                    {
                        MainWindow mainWindow = new MainWindow(user);
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("This user doesn't exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        TextBoxInvalidData(Login);
                        PasswordInvalidData(Password);
                    }
                }  
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckTextBoxes()
        {
            if (Login.Text.Length != 0 && Password.Password.Length != 0)
            {
                return true;
            }
            else
            {
                TextBoxInvalidData(Login);
                Login.ToolTip = AddToolTip("Wrong login", "");
                md_Login.Foreground = Brushes.Red;
                PasswordInvalidData(Password);
                Password.ToolTip = AddToolTip("Wrong password", "");
                md_Password.Foreground = Brushes.Red;
                return false;
            }
        }

        private ToolTip AddToolTip(string error, string message)
        {
            StackPanel sPanel = new StackPanel();
            sPanel.Children.Add(new TextBlock { Text = error, FontSize = 16 });
            sPanel.Children.Add(new TextBlock { Text = message, FontSize = 14 });
            ToolTip toolTip = new ToolTip
            {
                Foreground = Brushes.Red,
                Background = Brushes.White,
                HasDropShadow = true,
                HorizontalOffset = 100,
                VerticalOffset = -10,
                Content = sPanel
            };
            return toolTip;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool c1 = CheckEmail();
                bool c2 = CheckNames();
                bool c3 = CheckPassword();
                bool c4 = CheckExist();
                if (c4)
                {
                    if (c1 && c2 && c3)
                    {
                        if (PasswordBoxdReg1.Password == PasswordBoxdReg2.Password)
                        {
                            Users user = new Users
                            {
                                User = txt_Login.Text,
                                Name = txt_Name.Text,
                                Surname = txt_Surname.Text,
                                Email = txt_Email.Text,
                                Password = PasswordBoxdReg1.Password
                            };
                            unit.Users.Create(user);
                            unit.Save();
                            MainWindow mainWindow = new MainWindow(user);
                            mainWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            PasswordInvalidData(PasswordBoxdReg2);
                            PasswordBoxdReg2.ToolTip = AddToolTip("Wrong password", "Passwords don't match.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("This user is already exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckNames()
        {
            bool check = true;
            string pattern = @"^[a-zA-Zа-яА-Я]{1}[a-zA-Zа-яА-Я0-9]{3,14}$";
            Regex reg = new Regex(pattern);
            if (txt_Login.Text.Length != 0)
            {
                Match match1 = reg.Match(txt_Login.Text);
                if (!match1.Success)
                {
                    TextBoxInvalidData(txt_Login);
                    txt_Login.ToolTip = AddToolTip("Wrong login", "Login must contain the letters and numbers. Length 4-15 characters.");
                    check = false;
                }
            }
            else
            {
                TextBoxInvalidData(txt_Login);
                check = false;
            }
            if (txt_Name.Text.Length != 0)
            {
                Match match2 = reg.Match(txt_Name.Text);
                if (!match2.Success)
                {
                    TextBoxInvalidData(txt_Name);
                    txt_Name.ToolTip = AddToolTip("Wrong name", "Name must contain the letters and numbers. Length 4-15 characters.");
                    check = false;
                }
            }
            else
            {
                TextBoxInvalidData(txt_Name);
                check = false;
            }
            if (txt_Surname.Text.Length != 0)
            {
                Match match3 = reg.Match(txt_Surname.Text);
                if (!match3.Success)
                {
                    TextBoxInvalidData(txt_Surname);
                    txt_Surname.ToolTip = AddToolTip("Wrong surname", "Surname must contain the letters and numbers. Length 4-15 characters.");
                    check = false;
                }
            }
            else
            {
                TextBoxInvalidData(txt_Surname);
                check = false;
            }
            return check;
        }

        private bool CheckEmail()
        {
            if (txt_Email.Text.Length != 0)
            {
                string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                     @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
                Regex reg= new Regex(pattern, RegexOptions.IgnoreCase);
                Match match = reg.Match(txt_Email.Text);
                if (!match.Success)
                {
                    TextBoxInvalidData(txt_Email);
                    txt_Email.ToolTip = AddToolTip("Wrong email", "Incorrect data.");
                    return false;
                }
                return true;
            }
            else
            {
                TextBoxInvalidData(txt_Email);
            }
            return false;
        }

        private bool CheckPassword()
        {
            if (PasswordBoxdReg1.Password.Length != 0)
            {
                string pattern = @"^[a-zA-Zа-яА-Я0-9!@#$%^&*]{6,15}$";
                Regex reg = new Regex(pattern);
                Match match = reg.Match(PasswordBoxdReg1.Password);
                if (!match.Success)
                {
                    PasswordInvalidData(PasswordBoxdReg1);
                    PasswordBoxdReg1.ToolTip = AddToolTip("Wrong password", "The password must contain letters, numbers and special characters. Length 6-15 characters.");
                    PasswordBoxdReg2.Password = "";
                    return false;
                }
                return true;
            }
            else
            {
                PasswordInvalidData(PasswordBoxdReg1);
                PasswordInvalidData(PasswordBoxdReg2);
            }
            return false;
        }

        private bool CheckExist()
        {
            var user = unit.Users.Get(u => u.User == txt_Login.Text && u.Password == PasswordBoxdReg1.Password && u.Email == txt_Email.Text).FirstOrDefault();
            if (user != null)
            {
                return false;
            }
            return true;
        }

        private void TextBoxInvalidData(TextBox sender)
        {
            sender.BorderBrush = Brushes.Red;
            sender.Foreground = Brushes.Red;
        }

        private void PasswordInvalidData(PasswordBox sender)
        {
            sender.BorderBrush = Brushes.Red;
            sender.Foreground = Brushes.Red;
        }

        private void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BorderBrush = Brushes.Gray;
            textBox.Foreground = Brushes.Black;
            textBox.ToolTip = null;
            md_Login.Foreground = Brushes.Gray;

        }

        private void Password_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PasswordBox password = (PasswordBox)sender;
            password.BorderBrush = Brushes.Gray;
            password.Foreground = Brushes.Black;
            password.ToolTip = null;
            md_Password.Foreground = Brushes.Gray;
        }
        
    }
}
