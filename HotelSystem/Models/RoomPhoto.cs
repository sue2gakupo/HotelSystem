using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Models;

public partial class RoomPhoto
{
    [Key]
    public long SN { get; set; }

    [StringLength(50)]
    public string PhotoPath { get; set; } = null!;

    [StringLength(5)]
    public string RoomID { get; set; } = null!;

    [ForeignKey("RoomID")]
    [InverseProperty("RoomPhoto")]
    public virtual Room Room { get; set; } = null!; //virtual在資料庫沒有此欄位，但在程式中需要此欄位來建立關聯，這是因為資料庫中的 RoomPhoto 表格與 Room 表格之間存在一對多的關係。
}
