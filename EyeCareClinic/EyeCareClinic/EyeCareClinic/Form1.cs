using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeCareClinic
{
    public partial class Form1 : Form
    {
        Functions Con;
        public Form1()
        {
            InitializeComponent();
            Con = new Functions();
            ShowPatients();
        }

        private void ShowPatients()
        {
            try
            {
                string Query = "Select * from PatientTbl";
                PatientsList.DataSource = Con.GetData(Query);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(PatNameTb.Text == "" || PatPhoneTb.Text == "" || PatAddressTb.Text == "" || PatAllergiesTb.Text == "" || GenderCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!"); 
                }else
                {
                    string Name = PatNameTb.Text;
                    string Phone = PatPhoneTb.Text;
                    string Address = PatAddressTb.Text;
                    string Date = PatDobTb.Value.ToString("yyyy-MM-dd");
                    string Gender = GenderCb.SelectedItem.ToString();
                    string Allergies = PatAllergiesTb.Text;
                    //Console.WriteLine(PatDobTb.Value.Date.ToString());
                    string Query = "insert into PatientTbl values('{0}','{1}','{2}', '{3}' ,'{4}','{5}')";
                    Query = string.Format(Query, Name, Phone,Gender ,Allergies, Address, Date );
                    Con.SetData(Query);
                    ShowPatients();
                    MessageBox.Show("Patients Added!");
                    PatNameTb.Text = "";
                    PatPhoneTb.Text = "";
                    GenderCb.SelectedIndex = -1;
                    PatAllergiesTb.Text = "";
                    PatAddressTb.Text = "";
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        int Key = 0;

        private void PatientsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatNameTb.Text = PatientsList.SelectedRows[0].Cells[1].Value.ToString();
            PatPhoneTb.Text = PatientsList.SelectedRows[0].Cells[2].Value.ToString();
            PatAddressTb.Text = PatientsList.SelectedRows[0].Cells[3].Value.ToString();
            PatDobTb.Text = PatientsList.SelectedRows[0].Cells[4].Value.ToString();
            GenderCb.SelectedItem = PatientsList.SelectedRows[0].Cells[5].Value.ToString();
            PatAllergiesTb.Text = PatientsList.SelectedRows[0].Cells[6].Value.ToString();
            if(PatNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PatientsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PatNameTb.Text == "" || PatPhoneTb.Text == "" || PatAddressTb.Text == "" || PatAllergiesTb.Text == "" || GenderCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!");
                }
                else
                {
                    string Name = PatNameTb.Text;
                    string Phone = PatPhoneTb.Text;
                    string Address = PatAddressTb.Text; 
                    string Gender = GenderCb.SelectedItem.ToString();
                    string Allergies = PatAllergiesTb.Text;
                    string Query = "update PatientTbl set PatName = '{0}', PatPhone = '{1}',PatAdress = '{2}', PatDOB = '{3}', PatGender = '{4}', PatAllergies = '{5}' where PatId = {6}";
                    Query = string.Format(Query, Name, Phone, Gender, Allergies,Key, Address, PatDobTb.Value.Date.ToString());
                    Con.SetData(Query);
                    ShowPatients();
                    MessageBox.Show("Patients Updated!");
                    PatNameTb.Text = "";
                    PatPhoneTb.Text = "";
                    GenderCb.SelectedIndex = -1;
                    PatAllergiesTb.Text = "";
                    PatAddressTb.Text = "";
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Select a Patient!");
                }
                else
                {
                    string Query = "delete from PatientTbl where PatId = {0} ";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    ShowPatients();
                    MessageBox.Show("Patients Deleted!");
                    PatNameTb.Text = "";
                    PatPhoneTb.Text = "";
                    GenderCb.SelectedIndex = -1;
                    PatAllergiesTb.Text = "";
                    PatAddressTb.Text = "";
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
