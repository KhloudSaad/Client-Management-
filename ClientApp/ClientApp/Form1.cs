using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        BL.CLS_Client client = new BL.CLS_Client();

        public Form1()
        {
            InitializeComponent();
            //txtStatus.DataSource = client.GetStatus(txtStatus.Text);
            //txtStatus.Items.Add("تم الإتفاق");
            //txtStatus.Items.Add("لم يتم الإتفاق");


            txtStatus.DataSource = client.GetAllStatus();
            txtStatus.DisplayMember = "StatusName"; 
            txtStatus.ValueMember = "Status_ID";


            cmdFieldName.DataSource = client.GetAllFields();
            cmdFieldName.DisplayMember = "Field_Name";
            cmdFieldName.ValueMember = "Field_ID";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Add_Client(txtName.Text, txtNum.Text, Convert.ToInt32(txtStatus.SelectedValue), Convert.ToInt32(cmdFieldName.SelectedValue));
           
            MessageBox.Show("تمت اضافة العميل", "عملية الاضافة ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.dataGridView1.DataSource = client.GetAllClients();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = client.SearchID_Client(txtSearch.Text);
            this.dataGridView1.DataSource = dt;
        }

        private void txtStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
        /*    string sample = "تم الإتفاق";
            bool myBool = bool.Parse("تم الإتفاق");
        */

           /*
            string selectedText = txtStatus.SelectedItem.ToString();
            bool data  = Convert.ToBoolean(selectedText  "تم الإتفاق" ? 1 : 0);

            string sqlQuery = $"insert into Clients (Client_Status) values ({data})";
            */ //if (txtStatus.SelectedItem.ToString()== "تم الإتفاق") { data = 1; }
               //else { data = 0; }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد الحذف", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                == DialogResult.Yes)
            {
                client.DeleteClient(this.dataGridView1.CurrentRow.Cells[0].Value.GetHashCode());
                MessageBox.Show("تم الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.dataGridView1.DataSource = client.GetAllClients();
            }
            else
            {
                MessageBox.Show("حدث خطأ ! لم يتم الحذف", "عملية الحذف", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void cmdFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormUpdate frmup = new FormUpdate();
            frmup.txtid.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frmup.txtName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frmup.txtNum.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frmup.cmdFieldName.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frmup.txtStatus.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();

            frmup.Text = "تحديث البيانات: " + this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
           // frmup.btnOk.Text = "حدث الان";
            //frmup.state = "Update";

            frmup.ShowDialog();
            this.dataGridView1.DataSource = client.GetAllClients();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
