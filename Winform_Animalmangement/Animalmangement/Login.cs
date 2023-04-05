using System;
using System.Windows.Forms;

namespace ProductManagemnet
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Do you want to exit ??? ", "MessageBox", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            String txtuser, txtpass;
            txtuser = this.txtuser.Text;
            txtpass = this.txtpass.Text;
            //if the username is nguyennamtruong and the pass is 123 that is correct then the user can go in the data entry
            // Message box will appear when the pass or username wrong and noticed wrong password and asks user to re-enter
            if (txtuser == "nguyennamtruong" && txtpass == "123")
            {
                this.Hide();
                AnmialManagemnet ss = new AnmialManagemnet();
                ss.ShowDialog();
            }
            else
            {
                MessageBox.Show(" Login Fail, Please login again !! ");
            }
        }
    }
}
