using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
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

        private void clousebutton_MouseEnter(object sender, EventArgs e)
        {
            clousebutton.ForeColor = Color.White;
        }
        Point LastPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private string userName;
        private void button1_Click(object sender, EventArgs e)
        {
            if (userAuthSucceess())
            {
                userName = textBox1.Text;
                MessageBox.Show("Вход выполнен!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool userAuthSucceess()
        {
            if (incorrectFiledsOnForm())
            {
                MessageBox.Show("Некорректные поля на форме");
                return false;
            }


            if (hasUser(textBox1.Text, textBox2.Text))
                return true;
            else
            {
                MessageBox.Show("Неверный логин или пароль");
                return false;
            }
        }

        private bool incorrectFiledsOnForm()
        {
            if (isUnCorrectField(textBox1.Text) || isUnCorrectField(textBox2.Text))
                return true;

            return false;
        }

        private bool isUnCorrectField(string field)
        {
            if (String.IsNullOrWhiteSpace(field))
                return true;
            return false;
        }

        private bool hasUser(string login, string password)
        {
            User user = new User(login, password);

            return user.IsCorrect();
        }

        private void buttonRegistr_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dialogResultLoginForm = new FormReg().ShowDialog();
            if (dialogResultLoginForm == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;  
                
            }
            this.Show();
        }
    }

}
