using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagemnet
{
    public partial class AnmialManagemnet : Form
    {
        public AnmialManagemnet()
        {
            InitializeComponent();
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double age { get; set; }
        public int number { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }


        int n = 0;
        AnmialManagemnet[] plists = new AnmialManagemnet[100];
        int index;
        bool fsearch = false;
        bool fedit = false;
        private void ProductManagemnet_Load(object sender, EventArgs e)
        {

        }
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        private void btn_brown_Click(object sender, EventArgs e)
        {


            openFileDialog1.InitialDirectory = "D:\\Tutor\\ProductMamagement\\Image ";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "(*.jgp) |*jpg |(*.png) |*.png |(*.gif) |*.gif| (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_image.Text = openFileDialog1.FileName;

                string imagepath = openFileDialog1.FileName;
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                AnmialManagemnet p = new AnmialManagemnet();
                p.ID = txt_ID.Text;
                p.Name = txt_Name.Text;
                p.Gender = cb_Gender.SelectedItem.ToString();
                p.age = double.Parse(txt_age.Text);
                p.number = int.Parse(txt_number.Text);
                p.Image = openFileDialog1.FileName;
                p.Description = richTextBox1.Text;
                plists[n] = p;
                n++;
                LoadData(plists);
                MessageBox.Show(this, "Successfully added ", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private bool checkInput()
        {
            if (txt_ID.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "ID can not blank !!! ", "Noltice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ID.Focus();
                return false;
            }
            if (txt_Name.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Name can not blank!!! ", "Noltice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_image.Focus();
                return false;

            }
            if (cb_Gender.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Gender can not blank!!! ", "Noltice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cb_Gender.Focus();
                return false;
            }
            if (txt_age.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Age can not blank!!!", "Noltice ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            try
            {
                string temp = txt_age.Text.Trim();
                double.Parse(temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Species is numberic character only !!!", "Noitice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_age.Focus();
                return false;

            }
            if (txt_number.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Quanlity can not blank!!!", "Noitice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            try
            {
                string temp = txt_number.Text;
                double.Parse(temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Quanlity is numberic character only!!!", "Noitice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_number.Focus();
                return false;
            }
            if (txt_image.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Image can not blank!!!", "Noitice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void LoadData(AnmialManagemnet[] pLists)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Gender", typeof(string)));
            dt.Columns.Add(new DataColumn("age", typeof(double)));
            dt.Columns.Add(new DataColumn("number", typeof(int)));
            dt.Columns.Add(new DataColumn("Image", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));

            for (int i = 0; i < n; i++)
            {
                AnmialManagemnet p = pLists[i];
                if (p != null)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = p.ID;
                    dr[1] = p.Name;
                    dr[2] = p.Gender;
                    dr[3] = p.age;
                    dr[4] = p.number;
                    dr[5] = p.Image;
                    dr[6] = p.Description;
                    dt.Rows.Add(dr);

                }
            }
            dataGridView1.DataSource = dt.DefaultView;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if ( MessageBox.Show(this, "Do you want to exit ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            AnmialManagemnet p = plists[index];
            PutData(p);
        }
        public void PutData(AnmialManagemnet p)
        {
            txtID.Text = p.ID;
            txtName.Text = p.Name;
            cbGender.Text = p.Gender;
            txtage.Text = p.age.ToString();
            txtnumber.Text = p.number.ToString();
            txtImage.Text = p.Image.ToString();
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            rtbDescrible.Text = p.Description;
            txtID.ReadOnly = true;
            txtName.ReadOnly = true;
            cbGender.Enabled = true;
            txtage.Enabled = true;
            txtnumber.Enabled = true;
            txtImage.Enabled = true;
            rtbDescrible.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tbP2_Click(object sender, EventArgs e)
        {
            txtID.ReadOnly = true;
            txtName.ReadOnly = true;
            txtage.ReadOnly = true;
            cbGender.Enabled = true;
            txtnumber.Enabled = true;
            txtImage.Enabled = true;
            rtbDescrible.Enabled = true;

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (!fsearch)
            {
                txtID.ReadOnly = false;
                btn_search.Text = "View Result ";

            }
            else
            {
                string id = txtID.Text;
                bool found = false;
                for (int i = 0; i < n; i++)
                {
                    AnmialManagemnet p = plists[i];
                    if (p.ID == id)
                    {
                        PutData(p);
                        found = true;
                    }
                }
                if (!found)
                {
                    MessageBox.Show(this, "animal no found ", "Result ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                btn_search.Text = "Search ";
                txtID.ReadOnly = true;
            }
            fsearch = !fsearch;

        }

        private void btnbrown_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "D:\\Tutor\\ProductMamagement\\Image ";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "(*.jgp) |*jpg |(*.png) |*.png |(*.gif) |*.gif| (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_image.Text = openFileDialog1.FileName;

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (!fedit)
            {
                txtName.ReadOnly = false;
                cbGender.Enabled = true;
                txtage.ReadOnly = false;
                txtnumber.ReadOnly = false;
                txtImage.ReadOnly = false;
                rtbDescrible.ReadOnly = false; btn_update.Text = "Save";
            }
            else
            {
                txtID.ReadOnly = true;
                AnmialManagemnet p = plists[index];
                p.Name = txtName.Text;
                p.Gender = cbGender.SelectedItem.ToString();
                p.age = double.Parse(txtage.Text); 
                p.number = int.Parse(txtnumber.Text);
                p.Image = txtImage.Text;
                p.Description = rtbDescrible.Text;
                btn_update.Text = "Update";
                LoadData(plists);
                MessageBox.Show(this, "Update successful!!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            fedit = !fedit;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
           
                while (index < n - 1)
                {
                    plists[index] = plists[index + 1];
                    index++;
                }
                
                plists[n - 1] = null;
                n = n - 1;

               
                LoadData(plists);
                MessageBox.Show(this, "Delete successful!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

         private void btnexit_Click(object sender, EventArgs e)
         {
            if (MessageBox.Show(this, "Do you want to exit ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
         }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

