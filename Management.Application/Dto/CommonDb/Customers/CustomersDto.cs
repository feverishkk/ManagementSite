using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Dto.Customers
{
    public class CustomersDto
    {
        public int UserId { get; set; }
        public string ID { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public DateTime MemberSince { get; set; }
        public int Gender { get; set; }
        public int IsActive { get; set; }
        public int IsEmailConfirmed { get; set; }
        public string MobileNumber { get; set; }
        public string Country { get; set; }
        public string PreferPayment { get; set; }
        public int PaidCash { get; set; }
    }
}
