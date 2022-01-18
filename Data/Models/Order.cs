using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Input name")]
        [Required]
        [StringLength(20, ErrorMessage = "Length more then {1} characters")]
        public string name { get; set; }
        [Display(Name = "Input surname")]
        [StringLength(50, ErrorMessage = "Length more then {1} characters")]
        public string surname { get; set; }
        [Display(Name = "Input address")]
        [StringLength(1000, ErrorMessage = "Length more then {1} characters")]
        public string address { get; set; }
        [Display(Name = "Input phone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(150, ErrorMessage = "Length more then {1} characters")]
        public string phone { get; set; }
        [Display(Name = "Input e-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(150, ErrorMessage = "Length more then {1} characters")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
