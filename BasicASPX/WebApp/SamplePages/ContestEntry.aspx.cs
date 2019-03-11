using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        public static List<ContestClass> EntryCollection;
        //requiredfield      - ensures that entry is not skipped
        //rangevalidator     - checks that the entry is within a lower-upper range of numbers or characters
        //requiredexpression - check that user entry matches a pattern defined by a regular expression. ie) phone, email etc
        //comparevalidator   - data type check, check an entered value against a constant value, check an entered value A against entered value B
        //customvalidator    - calls a user method on your web server

        //validationsummary

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                EntryCollection = new List<ContestClass>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //this test will fire the validation controls on the server side.

                //if additional validation is required, do that first.
                if (Terms.Checked)
                {
                    //user has agreed to the terms
                    //collect the data then create/load a contest entry to the collection
                }
                else
                {
                    Message.Text = "You did not agree to the contest terms. Your entry is denied.";
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            Province.ClearSelection();
            PostalCode.Text = "";
            EmailAddress.Text = "";
            Terms.Checked = false;
            CheckAnswer.Text = "";
        }
    }
}