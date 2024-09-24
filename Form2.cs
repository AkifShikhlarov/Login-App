using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Form_in_C_
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            label2.Text = Login.UserFullname;
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchbtn_click(object sender, EventArgs e)
        {
            string query = searchbox.Text;
            string youtubeSearchUrl = $"https://www.youtube.com/results?search_query={Uri.EscapeDataString(query)}";
            //webBrowser1.Navigate(youtubeSearchUrl);
            Process.Start(new ProcessStartInfo("cmd", $"/c start {youtubeSearchUrl}") { CreateNoWindow = true });
        }
        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.webBrowser1.ScriptErrorsSuppressed = true;
        }
    }
}
