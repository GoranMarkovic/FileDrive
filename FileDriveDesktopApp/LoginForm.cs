﻿using Azure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDriveDesktopApp
{
    public partial class LoginForm : Form
    {
        public string username{ get;}
        public int userId { get;}
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//login
        {
            //hashirati sifru i uporediti, pogledati u tutorijalu kako onaj to radi
            //isto hesiranje uraditi i kad se salje zahtjev u webapi projektu
            //tj ako uradim tamo, ne moram ovdje
            //a validaciju raditi negdje na serveru, tj webapi

            //skontati kako sacuvati trenutno ulogovanog usera
            HomePageForm homePageForm=new HomePageForm();
            homePageForm.ShowDialog();
        }



        private void button2_Click(object sender, EventArgs e)//register
        {
            RegisterForm form= new RegisterForm();
            form.ShowDialog();
        }
    }
}
