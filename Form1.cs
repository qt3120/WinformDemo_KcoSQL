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
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace WinFormDemo
{

    public partial class Form1 : Form
    {
        private List<Student> listStudents = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] list = new String[] {"CNTT", "Kinh te", 
                                            "Ke toan",
                                            "QTKD"};
            //Add the list to the ComboBox
            comboBox1.Items.AddRange(list);
            //Set item to the first one
            comboBox1.SelectedIndex = 0;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //Get student information
            Student s = new Student();
            s.Faculty = (string)comboBox1.SelectedItem;
            s.Name = txtName.Text;
            s.StudentID = txtStudentID.Text;
            //Add the student to the list
            listStudents.Add(s);
            //Bind the student list to the Datata Grid
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listStudents;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Write the list to a JSON file
            //Uncomment if you want to tu use JSON file
            var json = JsonSerializer.Serialize(listStudents);
            System.IO.File.WriteAllText(@"D:\test.json", json);
            
            //Write the list to XML file
            //var serializer = new XmlSerializer(
            //            typeof(List<Student>),
            //            new XmlRootAttribute("Students"));
            //using (var stream = new StringWriter())
            //{
            //    serializer.Serialize(stream, listStudents);
            //    System.IO.File.WriteAllText(@"D:\test.xml",
            //        stream.ToString());
            //}  
        }
    }
}