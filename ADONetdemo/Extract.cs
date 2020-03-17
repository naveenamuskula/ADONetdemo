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
    
    public partial class Extract : Form
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        public Extract()
        {
            InitializeComponent();
        }

        private void Extract_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Demo;Data Source=DESKTOP-3TBUP87");

        }

        private void btnGetdata_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select * from EMPDATA where deptno=@d", con);
            cmd.Parameters.AddWithValue("@d", int.Parse(txtdeptno.Text));
            SqlDataReader R = cmd.ExecuteReader();
            DataSet Ds = new DataSet();// EMPTY temporary database
            Ds.Tables.Add("Deptdata");//adding table to the temp database(creating  temp empty table)
            Ds.Tables["Deptdata"].Load(R);//loading table with dataReader(o/p of query)
            dgvData.DataSource = Ds.Tables["Deptdata"];//loaded table is shown on the grid view
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select * from EMPDATA where HIREDATE between @S and @E", con);
            cmd.Parameters.AddWithValue("@S", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@E", DateTime.Parse(dateTimePicker2.Text));
            SqlDataReader R = cmd.ExecuteReader();
            DataSet Ds = new DataSet();// EMPTY temporary database
            Ds.Tables.Add("Deptdata");//adding table to the temp database(creating  temp empty table)
            Ds.Tables["Deptdata"].Load(R);//loading table with dataReader(o/p of query)
            dgvData.DataSource = Ds.Tables["Deptdata"];//loaded table is shown on the grid view
            con.Close();

        }
    }
}
