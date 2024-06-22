using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Gelirler : Form
    {
        public Gelirler()
        {
            InitializeComponent();
        }

        SqlHelper ces = new SqlHelper();
        private void Ekle_Click(object sender, EventArgs e)
        {
            int daireno = Convert.ToInt32(comboBox1.Text);
            int para = (int)numericUpDown1.Value;
            DateTime yeni = dateTimePicker1.Value;

            SqlParameter p1 = new SqlParameter("DaireNo", daireno);
            SqlParameter p2 = new SqlParameter("Para", para);
            SqlParameter p3 = new SqlParameter("Tarih", yeni);

            ces.ExecuteProc("aidat", p2,p1,p3);
        }

        private void Gelirler_Load(object sender, EventArgs e)
        {
            DataTable dt1 = ces.GetTable("select * from AidatOdemesi");

            foreach (DataRow herhangi in dt1.Rows)
            {
                listBox1.Items.Add(herhangi["DaireNo"]).ToString();
                listBox2.Items.Add(herhangi["Para"]).ToString();
                listBox3.Items.Add(herhangi["Tarih"]).ToString();
            }
        }
    }
}
