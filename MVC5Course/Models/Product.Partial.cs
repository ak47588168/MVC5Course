namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var orderLines = new FabricsEntities().OrderLine.Where(o => o.ProductId == this.ProductId).ToList();
            if (this.Stock.GetValueOrDefault(0) < orderLines.Count)
            {
                yield return new ValidationResult("庫存過小！", new[] { "Stock" });
            }
            if (Price >= 1000M)
            {
                yield return new ValidationResult("Prcie 不可大於 1000.00！", new[] { "Price" });
            }
        }
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "欄位長度不得大於 80 個字元")]
        public string ProductName { get; set; }
        [Required]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<bool> Active { get; set; }
        [Required]
        public Nullable<decimal> Stock { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
