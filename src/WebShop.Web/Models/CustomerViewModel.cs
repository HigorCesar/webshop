﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Web.Models
{
    public class CustomerViewModel
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}