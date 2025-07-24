using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Models;

[Keyless]
public partial class View_RoomWithPhotos
{
    [StringLength(5)]
    public string Expr1 { get; set; } = null!;

    [StringLength(40)]
    public string Expr2 { get; set; } = null!;

    public byte Expr3 { get; set; }

    [Column(TypeName = "money")] //用decimal避免精度遺失(decimal 是一種高精度的 128 位元浮點數資料型別，常用於需要高精度計算的場合，例如金額、財務數據)
    public decimal Expr4 { get; set; }

    [StringLength(1)]
    public string Expr5 { get; set; } = null!;

    public byte Expr6 { get; set; }

    [StringLength(400)]
    public string Expr7 { get; set; } = null!;

    public string? Expr8 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Expr9 { get; set; }

    [StringLength(1)]
    public string Expr10 { get; set; } = null!;

    [StringLength(50)]
    public string PhotoPath { get; set; } = null!;

    [StringLength(10)]
    public string Status { get; set; } = null!;

    [StringLength(5)]
    public string RoomID { get; set; } = null!;

    [StringLength(40)]
    public string RoomName { get; set; } = null!;

    public byte PeopleNum { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [StringLength(1)]
    public string Area { get; set; } = null!;

    public byte Floor { get; set; }

    [StringLength(400)]
    public string Introduction { get; set; } = null!;

    public string? Note { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [StringLength(1)]
    public string StatusCode { get; set; } = null!;
}
