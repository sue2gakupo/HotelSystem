using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Models;

public partial class OrderStatus
{
    [Key]
    [StringLength(1)]
    public string StatusCode { get; set; } = null!;

    [StringLength(10)]
    public string Status { get; set; } = null!;

    [InverseProperty("StatusCodeNavigation")]  //告訴模型這個屬性是 Order 的外鍵關聯
    public virtual ICollection<Order> Order { get; set; } = new List<Order>();
}
