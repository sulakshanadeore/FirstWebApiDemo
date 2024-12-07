using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace consumeApi.Models
{
    public class OrdersModel
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public int Qty { get; set; }
        public string CustName { get; set; }
    }
}