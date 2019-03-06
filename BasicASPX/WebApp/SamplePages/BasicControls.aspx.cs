﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        //create a static List<T> that will hang around between postings of the webpage
        //this could also have been done using a ViewState variable 
        //using a ViewState variable would require the user to retrieve the data on each posting
        public static List<DDLClass> DataCollection;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page_Load executes EACH AND EVERY TIME there is a posting to this page
            //Page_Load is executed BEFORE any submit events

            //this method is an excellent place to do form initialization. you can test your postings using Page.IsPostBack
            //IsPostBack == IsPost() in Razor forms

            //only executed on first pass, not ispost
            //create an instance for the static data collection
            if (!Page.IsPostBack)
            {
                DataCollection = new List<DDLClass>
                {
                    //Add instances to this collection using the DDLClass greedy constructor
                    new DDLClass(1, "COMP1008"),
                    new DDLClass(2, "CPSC1517"),
                    new DDLClass(3, "DMIT2018"),
                    new DDLClass(4, "DMIT1508")
                };

                //sorting a List<T>
                //use the .Sort() method
                //(x,y) this represents any 2 items in your list
                //compare x.Field to y.Field; ascending
                //compare y.Field to x.Field; descending
                DataCollection.Sort((x,y) => x.DisplayField.CompareTo(y.DisplayField));

                //put the data collection into the dropdownlist (DDL)
                //A) assign the collection to the controls DataSource
                CollectionList.DataSource = DataCollection;
                //B) assign the field names to the properties of the DDL for data association
                    //DataValueField represents the value of the item
                    //DataTextField represents the display of the line item
                CollectionList.DataValueField = "ValueField";
                CollectionList.DataTextField = "DisplayField";
                    //OR  CollectionList.DataTextField = nameof(DDLCLass.DisplayField);
                //C) bind the data to the web control
                    //NOTE: this statement is NOT required in a Windows Form Application
                CollectionList.DataBind();
                    //you can put a prompt on their dropdownlist control
                CollectionList.Items.Insert(0, "Select ...");
            }//closes !Page.IsPostBack
        }

        protected void SubmitButtonChoice_Click(object sender, EventArgs e)
        {
            //to grab the contents of a control will depend on the
            //   access technique of the control
            //for a TextBox, Label,Literal use .Text
            //for Lists(RadioButtonList, DropDownList) you may use
            // a) .SelectedValue -> associate data value field
            // b) .SelectedIndex -> the phyiscal index position in the list
            // c) .SelectedItem -> associate data display field
            //for a CheckBox use .Checked (true or false)

            //for the most part, all data from a control returns as 
            //   a string except for boolean type controls

            string submitchoice = TextBoxNumberChoice.Text;
            int anum = 0;
            if (string.IsNullOrEmpty(submitchoice))
            {
                MessageLabel.Text = "Enter a number from 1 to 4.";
            }
            else if (!int.TryParse(submitchoice, out anum))
            {
                MessageLabel.Text = "Entered value must be a number";
            }
            else if (anum > 4 || anum < 1)
            {
                MessageLabel.Text = "Enter a number from 1 to 4.";
            }
            else
            {
                //when positioning in a list it is BEST to position
                //   using the SelectedValue unless you wish to
                //   position in a specific physical location such as
                //   your prompt line,  then use SelectedIndex

                //SelectedValue expects a string value
                //SelectedIndex expects a numeric value
                RadioButtonListChoice.SelectedValue = submitchoice;

                //boolean control are set using true or false
                if (submitchoice.Equals("2") || submitchoice.Equals("3"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }

                CollectionList.SelectedValue = submitchoice;

                //display label will show the various values
                //obtained from a list using SelectedValue, SelectedIndex
                //and SelectItem
                DisplayReadOnly.Text = CollectionList.SelectedItem.Text
                    + " at index " + CollectionList.SelectedIndex
                    + " has a value of " + CollectionList.SelectedValue;
            }
        }
    }
}