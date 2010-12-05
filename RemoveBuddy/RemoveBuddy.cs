using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemoveBuddy
{
    public partial class RemoveBuddy : Form
    {
        const string CONSUMERKEY = "dj0yJmk9RkNyckRCTWI5MjY1JmQ9WVdrOVJGRnRVbXd5TlRnbWNHbzlNVEU0T1RZeU9UYzJNZy0tJnM9Y29uc3VtZXJzZWNyZXQmeD1lZA--";
        const string SECRETKEY = "4043ea6ae761316491ac19ea977f589b0cf08fb6";

        private YahooIMAPI.YMEngine _engine = null;
        public RemoveBuddy()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (null != _engine) _engine.SignOff();

            _engine = new YahooIMAPI.YMEngine(CONSUMERKEY, SECRETKEY, NickTextBox.Text, PasswordTextBox.Text);
            _engine.SignOn();

            LoginButton.Enabled = false;
            LogoutButton.Enabled = true;
            RemoveBuddyButton.Enabled = true;
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (null != _engine) _engine.SignOff();
           
            LogoutButton.Enabled = false;
            RemoveBuddyButton.Enabled = false;
            LoginButton.Enabled = true;
        }

        private void RemoveBuddy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (null != _engine) _engine.SignOff();
        }

        private void RemoveBuddyButton_Click(object sender, EventArgs e)
        {
            if (_engine.ResponseContact(BuddyTextBox.Text, false, "Bye bye"))
                MessageBox.Show("Successful to remove your nick in friend list of " + BuddyTextBox.Text);
            else
                MessageBox.Show("Cannot remove your nick in friend list of "+ BuddyTextBox.Text+". Maybe your nick is not in his/her friend list" );

            BuddyTextBox.Text="";
        }
    }
}
