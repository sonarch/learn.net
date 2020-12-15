﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Packt.Shared
{
    [Table("Order Details")]
    [Index(nameof(OrderID), Name = "OrderID")]
    [Index(nameof(OrderID), Name = "OrdersOrder_Details")]
    [Index(nameof(ProductID), Name = "ProductID")]
    [Index(nameof(ProductID), Name = "ProductsOrder_Details")]
    public partial class OrderDetail
    {
        [Key]
        public long OrderID { get; set; }
        [Key]
        public long ProductID { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        [Column(TypeName = "smallint")]
        public long Quantity { get; set; }
        [Column(TypeName = "real")]
        public double Discount { get; set; }

        [ForeignKey(nameof(OrderID))]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductID))]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; }
    }
}
