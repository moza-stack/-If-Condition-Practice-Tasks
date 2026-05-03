using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project01
{
    public partial class Form1 : Form

    {
        string[] studentNames = new string[100];
        int[] studentGrades = new int[100];

        int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           

        }

        private void label1_Click(object sender, EventArgs e)
        {
          


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //string name = txtName.Text;

                int grade =
                    //Convert.ToInt32(txtGrade.Text);

                //studentNames[count] = name;
                //studentGrades[count] = grade;

                count++;

                MessageBox.Show(
                    "Student Added Successfully");

                //txtName.Clear();
                //txtGrade.Clear();
            }

            catch (FormatException)
            {
                MessageBox.Show(
                    "Grade must be a number");
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string searchName = textBox1.Text;
                bool found = false;

                for (int i = 0; i < count; i++)
                {
                    if (studentNames[i].ToLower() == searchName.ToLower())
                    {
                        
                        for (int j = i; j < count - 1; j++)
                        {
                            studentNames[j] = studentNames[j + 1];
                            studentGrades[j] = studentGrades[j + 1];
                        }

                        count--;

                        found = true;
                        MessageBox.Show("Student deleted successfully");
                        break;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("Student not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        
    }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Columns.Add("Name", "Student Name");
            dataGridView1.Columns.Add("Grade", "Student Grade");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
