using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADONetdemo
{
    public partial class Update : Form
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        public Update()
        {
            InitializeComponent();
        }
        private void Update_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Password=Admin@123;Persist Security Info=True;User ID=sa;Initial Catalog=ADODB;Data Source=DESKTOP-3TBUP87");
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("update Emp set ename=@en,deptno=@d where empno=@ep", con);
                cmd.Parameters.AddWithValue("@en", txtename.Text);
                cmd.Parameters.AddWithValue("@d", int.Parse(txtdeptno.Text));
                cmd.Parameters.AddWithValue("@ep", int.Parse(txtempno.Text));
                int R = cmd.ExecuteNonQuery();
                if (R != 0)
                    MessageBox.Show(R + " rows updated");
                else
                MessageBox.Show(" no employee exists");
            }
            catch (SqlException E)
            {
                MessageBox.Show("ename size is out of bound");
            }
            catch (FormatException E)
            {
                MessageBox.Show("enter details in deptno");
            }
            catch (InvalidOperationException E)
            {
                MessageBox.Show("no employe number exists with this number");
                txtename.Text = "";
                txtdeptno.Text = "";
                dtpdob.Text = "";
                cbbgender.Text = "";
            }
            finally
            {
                con.Close();
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select * from Emp where empno=@eno", con);
                cmd.Parameters.AddWithValue("@eno", int.Parse(txtempno.Text));
                SqlDataReader R = cmd.ExecuteReader();//used for select command
                R.Read();//empno is unique so we get only one record
                txtename.Text = R[1].ToString();//ename
                cbbgender.Text = R[2].ToString();//gender
                dtpdob.Text = R[3].ToString();//dob
                txtdeptno.Text = R[4].ToString();//deptno
               
            }
            catch(InvalidOperationException E)
            {
                MessageBox.Show("no emp number exists with this num");
            }
            catch(FormatException E)
            {
                MessageBox.Show("enter only numbers in empno");
            }
            finally
            {
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("delete from Emp where empno=@eno", con);
                cmd.Parameters.AddWithValue("@eno", int.Parse(txtempno.Text));
                int R = cmd.ExecuteNonQuery();
                
                if (R != 0)
                    MessageBox.Show(R + "rows deleted");
                else
                    MessageBox.Show("no emp no exists");
            }
            catch (FormatException E)
            {
                MessageBox.Show("enter only numbers in empno");
            }
            
            finally
            {
                con.Close();
            }
        }
    }
}
