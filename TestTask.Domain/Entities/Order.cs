using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestTask.Domain.Entities
{
    public class Order
    {
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please enter a number")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Please enter a creation date")]
        [Range(typeof(DateTime), "1/1/2000", "1/1/2032",
            ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime CreationDate { get; set; }

        public DateTime? ShippingDate { get; set; }

        [Required(ErrorMessage = "Please enter a manager")]
        public string Manager { get; set; }

        public string Note { get; set; }
    }
}
