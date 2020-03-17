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
    public partial class Connectionlesscmdbuilderex1 : Form
    {
        SqlConnection con = null;
        SqlDataAdapter adp = null;
        public Connectionlesscmdbuilderex1()
        {
            InitializeComponent();
        }

        private void Connectionlesscmdbuilderex1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Password=Admin@123;Persist Security Info=True;User ID=sa;Initial Catalog=Demo;Data Source=DESKTOP-3TBUP87");
            adp = new SqlDataAdapter("select * from EMPDATA", con);
            DataSet Ds = new DataSet();
            SqlCommandBuilder cmb = new SqlCommandBuilder(adp);
            SqlCommand cmd = cmb.GetInsertCommand();//commandbuilder will generate DML cmds for EMPDATA
            SqlCommand cmd1= cmb.GetDeleteCommand();
            SqlCommand cmd2 = cmb.GetUpdateCommand();
            MessageBox.Show(cmd.CommandText);
        }
    }
}
