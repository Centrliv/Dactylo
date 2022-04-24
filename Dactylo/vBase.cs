using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devart.Data.MySql;

namespace Dactylo
{
    public partial class vBase : Form
    {
        public vBase()
        {
            InitializeComponent();
        }
        static string conString = "User Id=root;Password=123456;Host=localhost;Database=dactylo_db;Unicode=True;Persist Security Info=True";
        MySqlCommand cmd = new MySqlCommand();
        public List<string> type = new List<string>();

        private void addBase_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(conString);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string SQLcom = "SELECT * FROM bases_types";
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                type.Add(reader[1].ToString());
            }
            cmd.Parameters.Clear();
            con.Close();
            SQLcom = "SELECT id_type, title, content, date FROM bases WHERE id_base = @id";
            con.Open();
            cmd.Parameters.AddWithValue("@id", DataBank.vbase);
            cmd.Connection = con;
            cmd.CommandText = SQLcom;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                typ.Value = int.Parse(reader[0].ToString());
                tit.Text = reader[1].ToString();
                txt.Text = reader[2].ToString();
                dat.Value = DateTime.Parse(reader[3].ToString());
            }
            cmd.Parameters.Clear();
            con.Close();
            ttype.Text = type[Convert.ToInt32(typ.Value - 1)];
        }

        private void back_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void viewBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
        }
    }
}
