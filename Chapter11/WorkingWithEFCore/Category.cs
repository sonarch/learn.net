using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkingWithEFCore
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}