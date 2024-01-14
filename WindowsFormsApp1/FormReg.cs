using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class FormReg : Form
    {
        public FormReg()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void clousebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registracia_button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(login_textBox1.Text))
            {
                MessageBox.Show("Пустой логин");
                return;
            }
            if (String.IsNullOrWhiteSpace(Parol_textBox1.Text))
            {
                MessageBox.Show("Пустой пароль");
                return;
            }
            if (Parol_textBox1.Text != Parol_textBox2.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            if (Parol_textBox1.Text.Length < 8)
            {
                MessageBox.Show("Пароль должен быть не менее 8 символов");
                return;
            }

            DateB db = new DateB("Data Source=dateB.db;Version=3;");

            if (Parol_textBox1.Text == Parol_textBox2.Text && isCorrect())
            {
                if (db.createUser(login_textBox1.Text, Parol_textBox1.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    
                }
                return;
            }
            else
            {
                MessageBox.Show("Ошибка ввода данных");
            }


        }

        private bool isCorrect()
        {
           
            return !(String.IsNullOrWhiteSpace(Parol_textBox1.Text) && String.IsNullOrWhiteSpace(Parol_textBox2.Text) && String.IsNullOrWhiteSpace(login_textBox1.Text));
        }

        Point LastPoint;
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                 this.Left += e.X - LastPoint.X;
                 this.Top += e.Y - LastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
           LastPoint = new Point(e.X, e.Y);
        }
        
    }
}


 