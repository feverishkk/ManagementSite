using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.Customers
{
    public class CustomerInfomation
    {
        public int UserId { get; set; }
        public string ID { get; set; }
        public string Email_Address { get; set; }
        public string UserName { get; set; }
        public DateTime MemberSince { get; set; }
        public string PreferPayment { get; set; }
        public string Gender { get; set; }
        public int IsActive { get; set; }
        public int IsEmailConfirmed { get; set; }
        public string MobileNumber { get; set; }
        public string Country { get; set; }
        public string PaidCash { get; set; } = string.Empty;
    }
}
