﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//the annotations used within the .Data project will require the System.ComponentModel.DataAnnotations assembly
//this assembly is added via your References

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace NorthwindSystem.Data
{
    //use an annotation to link this class to the appropriate SQL table
    [Table("Products")]

    public class Product
    {
        //mapping of the SQL table attributes will be to class properties, one to one relationship
        private string _QuantityPerUnit;

        //use an annotation to identify the primary key
        //1) identify PKey on your SQL table (default)
                //[Key] assumes identity PKey ending in ID or Id
                //or
                //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //2) a compound PKey on your SQL table
                //[Key, Column(Order=n)] where n is the numeric value of the physical order of the attribute in the key
        //3) a user supplied PKey on your SQL table
                //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit
        {
            get
            {
                return _QuantityPerUnit;
            }
            set
            {
                _QuantityPerUnit = string.IsNullOrEmpty(value.Trim()) ? null : value;
            }
        }
        public decimal? UnitPrice { get; set; }
        public Int16? UnitsInStock { get; set; }
        public Int16? UnitsOnOrder { get; set; }
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        //sample of a computed field on your SQL table
        //to annotate this property to be taken as a SQL computed field, use:
                //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                //public decimal somecomputedsqlfield { get; set; }
        
        //creating a read only property that is NOT an actual field on your SQL table means that no data is actually transferred
        //example FirstName and LastName are often combined into a single field for display such as FullName
        //use the NotMapped annotation to handle this
        //[NotMapped]
        //public string FullName
        //{
        //    get
        //    {
        //        return FirstName + " " + LastName;
        //    }
        //}
    }
}
