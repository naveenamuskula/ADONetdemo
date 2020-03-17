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
    public partial class Connectionlesscmdbuilderex3 : Form
    {
        SqlConnection con = null;
        SqlDataAdapter adp = null;
        DataSet Ds = null;
        public Connectionlesscmdbuilderex3()
        {
            InitializeComponent();
        }

        private void Connectionlesscmdbuilderex3_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Password=Admin@123;Persist Security Info=True;User ID=sa;Initial Catalog=Demo;Data Source=DESKTOP-3TBUP87");
            adp = new SqlDataAdapter("select * from DEPTDATA", con);
            Ds = new DataSet();
            adp.Fill(Ds, "D");
            cbbdeptno.DataSource = Ds.Tables["D"];
            cbbdeptno.ValueMember = "DEPTNO";
            cbbdeptno.DisplayMember = "DNAME";
        }

        private void txtempno_Leave(object sender, EventArgs e)
        {
            adp = new SqlDataAdapter("Select * from EMPDATA where empno=@e", con);
            adp.SelectCommand.Parameters.AddWithValue("@e", int.Parse(txtempno.Text));
            Ds = new DataSet();
            adp.Fill(Ds, "E");
            //assigning data from dataset to text boxes
            DataRow R=Ds.Tables["E"].Rows[0];//declaring 0th row
            txtempname.Text = R[1].ToString();//first index of 0th row
            txtjob.Text = R[2].ToString();
            txtmgr.Text = R[3].ToString();
            dtphiredate.Text = R[4].ToString();
            txtsalary.Text = R[5].ToString();
            txtcommission.Text = R[6].ToString();
            cbbdeptno.Text = R[7].ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            adp = new SqlDataAdapter("Select * from EMPDATA where empno=@e", con);
            adp.SelectCommand.Parameters.AddWithValue("@e", int.Parse(txtempno.Text));
            Ds = new DataSet();
            adp.Fill(Ds, "E");
            DataRow R = Ds.Tables["E"].Rows[0];
            R[2] = txtjob.Text;
            R[3] = txtmgr.Text;
            R[5] = int.Parse(txtsalary.Text);
            if (txtcommission.MaxLength != 0)
             R[6] = int.Parse(txtcommission.Text);
            R[7] = cbbdeptno.SelectedValue;
            SqlCommandBuilder cmb = new SqlCommandBuilder(adp);
            adp.UpdateCommand = cmb.GetUpdateCommand();
            adp.Update(Ds, "E");
            MessageBox.Show("1 row updated");


        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            adp = new SqlDataAdapter("Select * from EMPDATA where empno=@e", con);
            adp.SelectCommand.Parameters.AddWithValue("@e", int.Parse(txtempno.Text));
            Ds = new DataSet();
            adp.Fill(Ds, "E");
            Ds.Tables["E"].Rows[0].Delete();
            SqlCommandBuilder cmb = new SqlCommandBuilder(adp);
            adp.DeleteCommand = cmb.GetDeleteCommand();
            adp.Update(Ds, "E");
            MessageBox.Show("1 row deletled");


        }
    }
}
