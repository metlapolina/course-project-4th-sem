using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ToDoshka.Model;

namespace ToDoshka
{
    public partial class StatisticsControl : UserControl
    {
        Users User;
        public StatisticsControl(Users user)
        {
            InitializeComponent();

            User = user;

            FillData();
            DataContext = this;

            int week = 6;
            var points = new Collection<DateValue>();
            for(int i = week; i >= 0; i--)
            {
                points.Add(new DateValue(DateTime.Now.AddDays(-i), Registration.unit.Tasks.Get(j => j.UserID == user.ID && Convert.ToDateTime(j.CheckTime).ToShortDateString() == DateTime.Now.AddDays(-i).ToShortDateString()).Count()));
            }
            this.Points = points;

        }

        private void FillData()
        {
            dp_Start.SelectedDate = DateTime.Now.AddDays(-6);
            dp_Finish.SelectedDate = DateTime.Now;

            int countChecked = Registration.unit.Tasks.Get(t => t.UserID == User.ID && t.isCheck == true).Count();
            int countUnchecked = Registration.unit.Tasks.Get(t => t.UserID == User.ID && t.isCheck != true).Count();
            lbl_Scheduled.Content += " " + countUnchecked.ToString();
            lbl_Completed.Content += " " + countChecked.ToString();
        }

        public IList<DateValue> Points { get; private set; }

        private void Btn_Build_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            DataContext = this;
            var points = new Collection<DateValue>();
            DateTime d1 = dp_Start.SelectedDate.Value;
            DateTime d2 = dp_Finish.SelectedDate.Value;
            if (d2 > d1)
            {
                int days = Convert.ToInt32((d2-d1).Days);
                for (int i = days; i >= 0; i--)
                {
                    points.Add(new DateValue(DateTime.Now.AddDays(-i), Registration.unit.Tasks.Get(j => j.UserID == User.ID && 
                        Convert.ToDateTime(j.CheckTime).ToShortDateString() == DateTime.Now.AddDays(-i).ToShortDateString()).Count()));
                }
                this.Points = points;
            }
            else
            {
                MessageBox.Show("The date range is incorrect.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class DateValue
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public DateValue(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }
    }
}
