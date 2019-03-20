using NorthwindSystem.BLL;
using NorthwindSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApp.SamplePages
{
    public partial class SqlProcQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //clear old messages
            MessageLabel.Text = "";

            //load the dropdownlist on hte first time processing this page
            if (!Page.IsPostBack)
            {
                //all calls should be done in user friendly error handling
                try
                {
                    //when the page is first loaded, obtain the complete list of categories from the database
                    CategoryController sysmgr = new CategoryController();
                    List<Category> results = sysmgr.Category_List();
                    //sort this list alphabetically
                    results.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                    //assign the data to the dropdownlist control
                    CategoryList.DataSource = results;
                    //indicate the DataTextField and DataValue field
                    CategoryList.DataTextField = nameof(Category.CategoryName);
                    CategoryList.DataValueField = nameof(Category.CategoryID);
                    //bind the datasource and add a prompt
                    CategoryList.DataBind();
                    CategoryList.Items.Insert(0, "Select ...");


                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //ensure that a selection was made
            if (CategoryList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a category of products from the list to display...";
            }
            else
            {
                //within user friendly error handling
                try
                {
                    //connect to the appropriate controller
                    ProductController sysmgr = new ProductController();
                    //issue a request to the controller's appropriate method
                    List<Product> datainfo = sysmgr.Product_GetByCategory(int.Parse(CategoryList.SelectedValue));
                    //check results
                    if (datainfo.Count() == 0)
                    {
                        //  none (.Count() == 0): message to user
                        MessageLabel.Text = "No products for selected category was found.";
                        //optionally clear out display
                        CategoryProductList.DataSource = null;
                        CategoryProductList.DataBind();
                    }
                    else
                    {
                        //  found: load a gridview
                        //optional sort on ProductName
                        datainfo.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                        CategoryProductList.DataSource = datainfo;
                        CategoryProductList.DataBind();
                    }


                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            CategoryList.ClearSelection();
            CategoryProductList.DataSource = null;
            CategoryProductList.DataBind();
        }
    }
}