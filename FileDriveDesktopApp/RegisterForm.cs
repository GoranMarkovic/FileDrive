using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDriveDesktopApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username=registerUsername.Text;
            string password=registerPassword.Text;
            await Register(username, password);


        }

        private async Task Register(string username, string password)
        {
            string url = "https://localhost:7079/users/post";
            var json = new StringContent("{\"username\": \"" + username + "\"," +
                "\"passwordHash\": \"" + password + "\"," +
                "\"passwordSalt\": \"" + password + "\"}", Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            using var response = await client.PostAsync(url, json);

            string responseBody = await response.Content.ReadAsStringAsync();
            debugtextbox.Text = responseBody;
            //this.Close();
        }
    }
}
