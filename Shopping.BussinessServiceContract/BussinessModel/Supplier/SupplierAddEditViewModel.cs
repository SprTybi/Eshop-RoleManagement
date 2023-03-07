using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BussinessServiceContract.BussinessModel.Supplier
{
    public class SupplierAddEditViewModel
    {
        public int SupplierID { get; set; }
        [Required(ErrorMessage = "نام تولید کننده را وارد نمایید")]
        [StringLength(100,MinimumLength = 3,ErrorMessage = "نام تولید کننده بین 3 تا100 باشد")]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "رتبه تولید کننده را وارد نمایید")]
        public double Grade { get; set; }
        [Required(ErrorMessage = "تلفن تولید کننده را وارد نمایید")]

        public string Tel { get; set; }
        //[EmailAddress(ErrorMessage = "Invalid Mail Address")]
        //public string Email { get; set; }
    }
}
