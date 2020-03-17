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
    public partial class Connectionlesscmdbuilderex2 : Form
    {
        SqlConnection con = null;
        SqlDataAdapter adp = null;
        DataSet Ds = null;
        public Connectionlesscmdbuilderex2()
        {
            InitializeComponent();
        }

        private void Connectionlesscmdbuilderex2_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Password=Admin@123;Persist Security Info=True;User ID=sa;Initial Catalog=Demo;Data Source=DESKTOP-3TBUP87");
            adp = new SqlDataAdapter("select * from DEPTDATA", con);
            Ds = new DataSet();
            adp.Fill(Ds, "D");
            cbbdeptno.DataSource = Ds.Tables["D"];
            cbbdeptno.ValueMember = "DEPTNO";
            cbbdeptno.DisplayMember = "DNAME";

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                adp = new SqlDataAdapter("select * from EMPDATA", con);
                Ds = new DataSet();//creating empty database
                adp.Fill(Ds, "E");//creating empty E table in Ds
                DataRow R = Ds.Tables["E"].NewRow();//creates memory  for a row
                                                    //storing values in the fields
                R[0] = int.Parse(txtempno.Text);
                R[1] = txtempname.Text;
                R[2] = txtjob.Text;
                R[3] = int.Parse(txtmgr.Text);
                R[4] = DateTime.Parse(dtphiredate.Text);
                R[5] = int.Parse(txtsalary.Text);
                R[6] = int.Parse(txtcommission.Text);
                R[7] = cbbdeptno.SelectedValue;
                Ds.Tables["E"].Rows.Add(R);//to link
                //sending data from dataset Ds to database
                SqlCommandBuilder cmb = new SqlCommandBuilder(adp);
                adp.InsertCommand = cmb.GetInsertCommand();
                adp.Update(Ds, "E");//only during fill cmd and update cmd database is connected to the application
                MessageBox.Show("1 row inserted");
                clear();
            }
            catch(SqlException E)
            {
                MessageBox.Show(E.Message);
            }
        }
        private void clear()
        {
            txtempno.Text = "";
            txtempname.Text = "";
            txtjob.Text = "";
            txtmgr.Text = "";
            dtphiredate.Text = "";
            txtsalary.Text = "";
            txtcommission.Text = "";
            cbbdeptno.Text = "";
        }
    }
}
