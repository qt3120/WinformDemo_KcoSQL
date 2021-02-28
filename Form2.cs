using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WinFormDemo
{
    public partial class Form2 : Form
    {
        List<Student> listStudent;
        public Form2()
        {
            InitializeComponent();
        }
        private void ButtonCheck(int currentIndex) {
            if (currentIndex == 0)
                btnBack.Enabled = false;
            else if (currentIndex == listStudent.Count - 1)
                btnNext.Enabled = false;
            else {
                btnNext.Enabled = true;
                btnBack.Enabled = true;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            String[] list = new String[] {"CNTT", "Kinh te",
                                            "Ke toan",
                                            "QTKD"};
            //Add the list to the ComboBox
            comboBox2.Items.AddRange(list);
            //Set item to the first one
            comboBox2.SelectedIndex = 0;
            //Read student information
            try
            {
                var listString = System.IO.File.ReadAllText(@"D:\test.json");
                listStudent = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(listString);

            }
            catch (Exception se) {
                listStudent = null;
                MessageBox.Show(se.Message, "Error", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (listStudent.Count > 0) {
                Student s = listStudent[0];
                txtName.Text = s.Name;
                txtStudentID.Text = s.StudentID;
                comboBox2.SelectedIndex = comboBox2.Items.IndexOf(s.Faculty);
                this.ButtonCheck(0);
            }
            else { 
                MessageBox.Show("There is no record.", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Check Email
            String text = txtEmail.Text;
            Boolean flag = false;
            if (text.IndexOf('@') > -1)
                if (text.Substring(text.IndexOf('@')).IndexOf('.') > -1)
                    flag = true;
            if (!flag)
            {
                MessageBox.Show("Email is not correct", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                txtEmail.SelectAll();
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string text = new String(txtPhoneNumber.Text);
            char ch = text.ToCharArray()[text.Length - 1];
            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
            {
                MessageBox.Show("No character");
                txtPhoneNumber.Text = text.Substring(0, text.Length - 1);
                txtPhoneNumber.Select(text.Length, text.Length);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Write your code here
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //Write your code here
        }
    }
}
