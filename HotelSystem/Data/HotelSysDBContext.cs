using System;
using System.Collections.Generic;
using HotelSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Data;

public partial class HotelSysDBContext : DbContext   //HotelSysDBContext要保留最原本的樣子，所以需複製1份HotelSysDBContext2
{ 
    public HotelSysDBContext(DbContextOptions<HotelSysDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employee { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRole { get; set; }

    public virtual DbSet<Member> Member { get; set; }

    public virtual DbSet<MemberAccount> MemberAccount { get; set; }

    public virtual DbSet<MemberTel> MemberTel { get; set; }

    public virtual DbSet<Order> Order { get; set; }

    public virtual DbSet<OrderDetail> OrderDetail { get; set; }

    public virtual DbSet<OrderStatus> OrderStatus { get; set; }

    public virtual DbSet<PayType> PayType { get; set; }

    public virtual DbSet<ProcessingStatus> ProcessingStatus { get; set; }

    public virtual DbSet<Room> Room { get; set; }

    public virtual DbSet<RoomPhoto> RoomPhoto { get; set; }

    public virtual DbSet<RoomService> RoomService { get; set; }

    public virtual DbSet<RoomStatus> RoomStatus { get; set; }

    public virtual DbSet<View_EmployeeWithRole> View_EmployeeWithRole { get; set; }

    public virtual DbSet<View_RoomWithPhotos> View_RoomWithPhotos { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeID).HasName("PK__Employee__7AD04FF1C83FF9EF");

            entity.Property(e => e.EmployeeID).IsFixedLength();
            entity.Property(e => e.Account).UseCollation("Latin1_General_CS_AS");
            entity.Property(e => e.RoleCode).IsFixedLength();

            entity.HasOne(d => d.RoleCodeNavigation).WithMany(p => p.Employee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__RoleCo__4CA06362");
        });

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity.HasKey(e => e.RoleCode).HasName("PK__Employee__D62CB59DFA9BE1EC");

            entity.Property(e => e.RoleCode).IsFixedLength();
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberID).HasName("PK__Member__0CF04B3830146387");

            entity.Property(e => e.MemberID).IsFixedLength();
        });

        modelBuilder.Entity<MemberAccount>(entity =>
        {
            entity.HasKey(e => e.Account).HasName("PK__MemberAc__B0C3AC47490AD008");

            entity.Property(e => e.Account).UseCollation("Latin1_General_CS_AS");
            entity.Property(e => e.MemberID).IsFixedLength();

            entity.HasOne(d => d.Member).WithMany(p => p.MemberAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MemberAcc__Membe__3C69FB99");
        });

        modelBuilder.Entity<MemberTel>(entity =>
        {
            entity.HasKey(e => e.SN).HasName("PK__MemberTe__32151C64EBF1E36A");

            entity.Property(e => e.MemberID).IsFixedLength();

            entity.HasOne(d => d.Member).WithMany(p => p.MemberTel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MemberTel__Membe__398D8EEE");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderID).HasName("PK__Order__C3905BAFF3CBAC10");

            entity.Property(e => e.OrderID).IsFixedLength();
            entity.Property(e => e.EmployeeID).IsFixedLength();
            entity.Property(e => e.MemberID).IsFixedLength();
            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PayCode).IsFixedLength();
            entity.Property(e => e.StatusCode).IsFixedLength();

            entity.HasOne(d => d.Employee).WithMany(p => p.Order).HasConstraintName("FK__Order__EmployeeI__5535A963");

            entity.HasOne(d => d.Member).WithMany(p => p.Order)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__MemberID__5441852A");

            entity.HasOne(d => d.PayCodeNavigation).WithMany(p => p.Order)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__PayCode__5629CD9C");

            entity.HasOne(d => d.StatusCodeNavigation).WithMany(p => p.Order)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__StatusCod__571DF1D5");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderID, e.RoomID }).HasName("PK__OrderDet__40B8383E2B8BCB73");

            entity.Property(e => e.OrderID).IsFixedLength();
            entity.Property(e => e.RoomID).IsFixedLength();
            entity.Property(e => e.CheckInTime).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CheckOutTime).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__5CD6CB2B");

            entity.HasOne(d => d.Room).WithMany(p => p.OrderDetail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__RoomI__5DCAEF64");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.StatusCode).HasName("PK__OrderSta__6A7B44FD25F9960B");

            entity.Property(e => e.StatusCode).IsFixedLength();
        });

        modelBuilder.Entity<PayType>(entity =>
        {
            entity.HasKey(e => e.PayCode).HasName("PK__PayType__914DABCEA73FFCD5");

            entity.Property(e => e.PayCode).IsFixedLength();
        });

        modelBuilder.Entity<ProcessingStatus>(entity =>
        {
            entity.HasKey(e => e.PSCode).HasName("PK__Processi__31BD33E069A85AA3");

            entity.Property(e => e.PSCode).IsFixedLength();
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomID).HasName("PK__Room__328639193DBE6288");

            entity.Property(e => e.RoomID).IsFixedLength();
            entity.Property(e => e.Area).IsFixedLength();
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StatusCode).IsFixedLength();

            entity.HasOne(d => d.StatusCodeNavigation).WithMany(p => p.Room)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Room__StatusCode__440B1D61");
        });

        modelBuilder.Entity<RoomPhoto>(entity =>
        {
            entity.HasKey(e => e.SN).HasName("PK__RoomPhot__32151C64D730C0A2");

            entity.Property(e => e.RoomID).IsFixedLength();

            entity.HasOne(d => d.Room).WithMany(p => p.RoomPhoto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomPhoto_Room");
        });

        modelBuilder.Entity<RoomService>(entity =>
        {
            entity.HasKey(e => e.RoomServiceID).HasName("PK__RoomServ__A11E84A1C286D815");

            entity.Property(e => e.RoomServiceID).IsFixedLength();
            entity.Property(e => e.CreatedTime).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EmployeeID).IsFixedLength();
            entity.Property(e => e.MemberID).IsFixedLength();
            entity.Property(e => e.PSCode).IsFixedLength();
            entity.Property(e => e.RoomID).IsFixedLength();

            entity.HasOne(d => d.Employee).WithMany(p => p.RoomService).HasConstraintName("FK__RoomServi__Emplo__6477ECF3");

            entity.HasOne(d => d.Member).WithMany(p => p.RoomService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoomServi__Membe__6383C8BA");

            entity.HasOne(d => d.PSCodeNavigation).WithMany(p => p.RoomService)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoomServi__PSCod__656C112C");
        });

        modelBuilder.Entity<RoomStatus>(entity =>
        {
            entity.HasKey(e => e.StatusCode).HasName("PK__RoomStat__6A7B44FD4C2C3BE7");

            entity.Property(e => e.StatusCode).IsFixedLength();
        });

        modelBuilder.Entity<View_EmployeeWithRole>(entity =>
        {
            entity.ToView("View_EmployeeWithRole");

            entity.Property(e => e.Account).UseCollation("Latin1_General_CS_AS");
            entity.Property(e => e.EmployeeID).IsFixedLength();
            entity.Property(e => e.RoleCode).IsFixedLength();
        });

        modelBuilder.Entity<View_RoomWithPhotos>(entity =>
        {
            entity.ToView("View_RoomWithPhotos");

            entity.Property(e => e.Area).IsFixedLength();
            entity.Property(e => e.Expr1).IsFixedLength();
            entity.Property(e => e.Expr10).IsFixedLength();
            entity.Property(e => e.Expr5).IsFixedLength();
            entity.Property(e => e.RoomID).IsFixedLength();
            entity.Property(e => e.StatusCode).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    //在類別建立方法


    //public async Task<List<object>> getMemberWithTel(string MemberID)   //動態類別object
    //{
    //    return await this.MemberWithTel.FromSqlRaw($"exec getMemberWithTel {MemberID}").ToListAsync(); //把sql語法的stored procedure寫在C#，讓資料原封不動的傳遞，但是傳入的MemberID要變成變數

    //} 




}
