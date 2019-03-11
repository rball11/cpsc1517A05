using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class ContestClass
    {
        private string _StreetAddress2;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 {
            get
            {
                return _StreetAddress2;
            }
            set
            {
                StreetAddress2 = _StreetAddress2;
            }
        }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }

        public ContestClass()
        {

        }

        public ContestClass(string firstname, string lastname, string streetaddress1, string streetaddress2, string city, string province, string postalcode, string email)
        {
            firstname = FirstName;
            lastname = LastName;
            streetaddress1 = StreetAddress1;
            streetaddress2 = StreetAddress2;
            city = City;
            province = Province;
            postalcode = PostalCode;
            email = Email;
        }
    }
}