using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels
{
    public class ProductsListVM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductsListVM()
        {
            this.OrderLine = new HashSet<OrderLine>();
        }
        
        [Required(ErrorMessage = "請輸入[商品名稱]")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "請輸入[商品單價]")]
        [Range(minimum: 0, maximum: 999)]
        public Nullable<decimal> Price { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public Nullable<decimal> Stock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}