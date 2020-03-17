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
    public partial class insert : Form
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        public insert()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void insert_Load(object sender, EventArgs e)
        {
            //step1:give the connection
            con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ADODB;Data Source=DESKTOP-3TBUP87");
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            try
            {
                //step2
                con.Open();
                //step3
                cmd = new SqlCommand("insert into Emp values(@eno,@en,@g,@d)", con);
                cmd.Parameters.AddWithValue("@eno", int.Parse(txtempno.Text));
                cmd.Parameters.AddWithValue("@en", txtename.Text);
                cmd.Parameters.AddWithValue("@g", cbbgender.Text);
                cmd.Parameters.AddWithValue("@d", DateTime.Parse(dtpdob.Text));
                //step4
                int R = cmd.ExecuteNonQuery();
                MessageBox.Show(R + " row inserted");
            }
            catch (SqlException E)
            {
                if (E.Message.Contains("PK_Emp"))
                    MessageBox.Show("employe num must be unique");
                if (E.Message.Contains("CK_gender"))
                    MessageBox.Show("gender should be selected  from drop down");
                if (E.Message.Contains("CK_dob"))
                    MessageBox.Show("age must be  greater than 21");
            }
            catch(FormatException E)
            {
                MessageBox.Show("enter all details");
            }
            finally
            {
                //step5
                con.Close();
            }
        }
    }
}
