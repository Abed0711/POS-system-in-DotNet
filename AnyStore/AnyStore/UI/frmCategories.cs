using AnyStore.BLL;
using AnyStore.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyStore.UI
{
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            // write the code to display all the categories for data grid view
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;
          // dgvCategories.Datasource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        categoriesBLL c =new categoriesBLL();
        categoriesDAL dal = new categoriesDAL();
        userDAL udal = new userDAL();

        private void btnADD_Click(object sender, EventArgs e)
        {
            //Get the value from Category Form
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;

            // Getting Id in added by field
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUser);
            // Passing the id of the logged in user in added by field
            c.added_by = usr.id;
            // creating boolean method to insert data into database
            bool success = dal.Insert(c);
            // if the category is inserted successfully then the value o fthe success will be true else it will be false
            if(success==true)
            {
                //New categories inserted successfully
                MessageBox.Show("New Category Inserted Successfully.");
                Clear();
                // Refresh Data GridView
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                // FAILED To inserted new category
                MessageBox.Show("Failed To Inserted New Category.");
                Clear(); 
            }




        }
        public void Clear()
        {
            txtCategoryID.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtSearch.Text = "";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Finding the row index of  the row clicked on Data GridView
            int RowIndex = e.RowIndex;
            txtCategoryID.Text = dgvCategories.Rows[RowIndex].Cells[0].Value.ToString();
            txtTitle.Text = dgvCategories.Rows[RowIndex].Cells[1].Value.ToString();
            txtDescription.Text = dgvCategories.Rows[RowIndex].Cells[2].Value.ToString();

        }

        private void btnUPDATE_Click(object sender, EventArgs e)
        {
            // Get the values from the Category form
            c.id = int.Parse(txtCategoryID.Text);
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;
            // Getting Id in added by field
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUser);
            // Passing the id of the logged in user in added by field
            c.added_by = usr.id;


            //Creating Boolean variable to update categories and check 
            bool success = dal.Update(c);
            // if the category is updated successfully then the value of success will be true else it will be false
            if(success==true)
            {
                //Category updated Successfully
                MessageBox.Show("New Category Updated Successfully.");
                Clear();
                //Refresh Data Grid View
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;


            }
            else
            {
                //Failed to Update Category g
                MessageBox.Show("Failed to Update Category.");
                
            }



        }

        private void btnDELETE_Click(object sender, EventArgs e)

        {

            // Get the values from the Category form
            c.id = Convert.ToInt32(txtCategoryID.Text);


            //Creating Boolean Variable to Delete The Category
            bool success = dal.Delete(c);
           
            //if the Category id Deleted Successfully then the value of Success will be true else it will be false
            if (success == true)
            {
                //Category Deleted Successfully
                MessageBox.Show(" Category Deleted Successfully.");
                Clear();
                //Refresh Data Grid View
                
            }
            else
            {
                //Failed to Delete Category 
                MessageBox.Show("Failed to Delete Category.");
            }

            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //get the keywords
            string keywords = txtSearch.Text;
            //File the categories based on keywords
            if (keywords!=null)
            {
                //Use search Method to Display category
                DataTable dt = dal.Search(keywords);
                dgvCategories.DataSource = dt;
            }
            else
            {
                //use the select method to display all categories
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt; 

            }

        }
    }
}
