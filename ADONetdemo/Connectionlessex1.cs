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
    public partial class Connectionlessex1 : Form
    {
        SqlConnection con = null;
        SqlDataAdapter adp = null;
        public Connectionlessex1()
        {
            InitializeComponent();
        }

        private void Connectionlessex1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Password=Admin@123;Persist Security Info=True;User ID=sa;Initial Catalog=Demo;Data Source=DESKTOP-3TBUP87");
            adp = new SqlDataAdapter("select * from  DEPTDATA", con);
            DataSet Ds = new DataSet();
            adp.Fill(Ds, "Dept");
            cbbdeptno.DataSource = Ds.Tables["Dept"];
            cbbdeptno.ValueMember = "DEPTNO";
            cbbdeptno.DisplayMember = "DNAME";


        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            adp = new SqlDataAdapter("select * from EMPDATA where DEPTNO=@d", con);
            adp.SelectCommand.Parameters.AddWithValue("@d",cbbdeptno.SelectedValue);
            DataSet Ds = new DataSet();//empty database
            adp.Fill(Ds, "Emp");//Emp table is created with values loaded into it using select query
            dgv1.DataSource = Ds.Tables["Emp"];
        }

        private void cbbdeptno_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
    }
}
