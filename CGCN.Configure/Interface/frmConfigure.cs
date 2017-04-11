using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace CGCN.Configure.Interface
{
    public partial class frmConfigure : Form
    {
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection();
        string connectString;

        InitFile initFile = new InitFile();

        public frmConfigure()
        {
            InitializeComponent();
        }

        private void frmConfigure_Load(object sender, EventArgs e)
        {
            txtServername.Text = initFile.Server;
            txtPort.Text = initFile.Port;   
            txtDBName.Text = initFile.Database;
            txtAccount.Text = initFile.Account;
            txtPass.Text = initFile.Password;   
        }

        private void btnTestCon_Click(object sender, EventArgs e)
        {
            try
            {
                connectString = "Server=" + txtServername.Text.Trim() + ";Port=" + txtPort.Text.Trim() + ";User Id=" + txtAccount.Text.Trim()
                        + ";password=" + txtPass.Text + ";Database=" + txtDBName.Text + ";Encoding=UNICODE;";
                this.npgsqlConnection = new NpgsqlConnection();
                this.npgsqlConnection.ConnectionString = connectString;
                this.npgsqlConnection.Open();
                if (this.npgsqlConnection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Kiểm tra kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.npgsqlConnection.Close();
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Không thể kết nối! Chi tiết:\n" + ex.Message.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            initFile.Server = txtServername.Text.Trim();
            initFile.Port = txtPort.Text.Trim();
            initFile.Database = txtDBName.Text.Trim();
            initFile.Account = txtAccount.Text.Trim();
            initFile.Password = txtPass.Text.Trim();
            initFile.Update();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtServername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { txtPort.Focus(); }
        }

        private void txtPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { txtDBName.Focus(); }
        }

        private void txtDBName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { txtAccount.Focus(); }
        }

        private void txtAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { txtPass.Focus(); }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnTestCon_Click(sender,e); }
        }
    }
}
