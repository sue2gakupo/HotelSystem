using System;
using System.Collections.Generic;
using HotelSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Data;

public partial class HotelSysDBContext2 : HotelSysDBContext //繼承第一代 HotelSysDBContext //這樣就可以把HotelSysDBContext重複的程式碼砍掉
{
    public HotelSysDBContext2(DbContextOptions<HotelSysDBContext> options)
        : base(options)
    {
    }

    //複製HotelSysDBContext2後，就可以新增新的方法來查詢資料庫
    public int GetRoomServiceCount()
    {
        return RoomService.CountAsync().Result;
    }


}
