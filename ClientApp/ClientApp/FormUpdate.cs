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
    public partial class FormUpdate : Form
    {
        BL.CLS_Client client = new BL.CLS_Client();

        public FormUpdate()
        {
            InitializeComponent();
            txtStatus.DataSource = client.GetAllStatus();
            txtStatus.DisplayMember = "StatusName";
            txtStatus.ValueMember = "Status_ID";


            cmdFieldName.DataSource = client.GetAllFields();
            cmdFieldName.DisplayMember = "Field_Name";
            cmdFieldName.ValueMember = "Field_ID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.UpdateClient(Convert.ToInt32(txtid.Text), txtName.Text, txtNum.Text,
                           Convert.ToInt32(cmdFieldName.SelectedValue), Convert.ToInt32(txtStatus.SelectedValue));

            MessageBox.Show("تم تعديل بيانات الطالب", "عملية تعديل البيانات ",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
