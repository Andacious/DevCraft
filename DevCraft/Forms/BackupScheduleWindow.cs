using System;
using System.Windows.Forms;
using DevCraft.Core;
using DevCraft.Core.Logic;
using DevCraft.Core.Objects;
using DevCraft.Core.Schedules;
using Day = DevCraft.Core.Objects.Day;

namespace DevCraft.UI.Forms
{
    public partial class BackupScheduleWindow : Form
    {
        private readonly IServerInstance _minecraft;
        private readonly BackupManager _backupManager;

        public BackupScheduleWindow(IServerInstance minecraft, BackupManager backupManager)
        {
            InitializeComponent();

            _minecraft = minecraft;
            _backupManager = backupManager;

            // set contents of drop down lists
            ddFrequency.DataSource = Enum.GetValues(typeof(Frequency));
            ddDay.DataSource = Enum.GetValues(typeof(Day));
            ddCustomInterval.DataSource = Enum.GetValues(typeof(Interval));

            // assign event handlers
            txtCustomInterval.KeyPress += rawInterval_KeyPress;
        }

        private void ddFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var freq = (Frequency)ddFrequency.SelectedIndex;

            RenderControls(freq);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _backupManager.InitializeBackups(BuildScheduleFromControls(), _minecraft); 

            Close();
        }

        private void rawInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            // no decimals
            // no dashes
            // only numbers and backspace (hopefully)
            // currently doesn't support ctrl + v checking

            if (e.KeyChar == '\b' || (char.IsNumber(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-'))
            {
                lblErrorLabel.Text = String.Empty;
                okButton.Enabled = true;
                e.Handled = false;
            }
            else
            {
                lblErrorLabel.Text = Resources.ErrorInvalidInput;
                e.Handled = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            lblErrorLabel.Text = String.Empty;
            Close();
        }

        private void RenderControls(Frequency freq)
        {
            switch (freq)
            {
                case Frequency.Weekly:
                    {
                        EnableDay(true);
                        EnableTime(true);
                        EnableCustom(false);
                        break;
                    }
                case Frequency.Daily:
                    {
                        EnableDay(false);
                        EnableTime(true);
                        EnableCustom(false);
                        break;
                    }
                case Frequency.Custom:
                    {
                        EnableDay(false);
                        EnableTime(false);
                        EnableCustom(true);
                        break;
                    }
            }
        }

        private void EnableDay(bool enable)
        {
            lblDay.Enabled = enable;
            ddDay.Enabled = enable;
        }

        private void EnableTime(bool enable)
        {
            lblTime.Enabled = enable;
            pkrTime.Enabled = enable;
        }

        private void EnableCustom(bool enable)
        {
            lblCustomInterval.Enabled = enable;
            txtCustomInterval.Enabled = enable;
            ddCustomInterval.Enabled = enable;
        }

        private ISchedule BuildScheduleFromControls()
        {
            var freq = (Frequency)ddFrequency.SelectedIndex;

            switch (freq)
            {
                case Frequency.Weekly:
                    {
                        var weeklySched = new WeeklySchedule
                        {
                            Day = (Day)ddDay.SelectedIndex,
                            Time = pkrTime.Value
                        };

                        return weeklySched;
                    }
                case Frequency.Daily:
                    {
                        var dailySched = new DailySchedule
                        {
                            Time = pkrTime.Value
                        };

                        return dailySched;
                    }
                case Frequency.Custom:
                    {
                        var customSched = new CustomSchedule
                        {
                            CustomInterval = Convert.ToInt64(txtCustomInterval.Text),
                            CustomIntervalType = (Interval)ddCustomInterval.SelectedIndex
                        };

                        return customSched;
                    }
                default:
                    throw new NotImplementedException("This frequency is not supported.");
            }
        }
    }
}