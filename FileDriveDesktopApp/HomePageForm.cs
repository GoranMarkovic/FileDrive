using FileDriveWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FileDriveDesktopApp
{
    public partial class HomePageForm : Form
    {

        int userId = 4;
        public HomePageForm()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)//download
        {
            string url = "https://localhost:7079/users/get";
            using var client = new HttpClient();
            using var response = await client.GetAsync(url);

            string responseBody = await response.Content.ReadAsStringAsync();
            //string json = "[{ \"UserId\":6,\"Username\":\"Goran Markovic\",\"PasswordHash\":\"MTIz\",\"PasswordSalt\":\"MzIx\"}]";            //string responseBody = "[{\"userId\":6,\"username\":\"Goran Markovic\",\"passwordHash\":\"MTIz\",\"passwordSalt\":\"MzIx\",\"files\":[],\"sharedFiles\":[]},{ \"userId\":8,\"username\":\"Boris Grumic\",\"passwordHash\":\"MTEx\",\"passwordSalt\":\"MjIy\",\"files\":[],\"sharedFiles\":[]}]";

            var users = JsonSerializer.Deserialize<List<User>>(responseBody);
            //extBox1.AppendText(users.ToString());
            if (users == null)
                textBox1.Text = "Null";
            else
            {
                int i = 1;
                foreach (var user in users)
                {
                    textBox1.AppendText(user.UserId.ToString()+Environment.NewLine);
                    textBox1.AppendText(user.Username.ToString() + Environment.NewLine);
                    textBox1.AppendText(System.Text.Encoding.UTF8.GetString(user.PasswordHash) + Environment.NewLine);
                    textBox1.AppendText(System.Text.Encoding.UTF8.GetString(user.PasswordSalt) + Environment.NewLine);
                }

            }

        }
    }
}
