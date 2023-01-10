﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PLD.Blazor.DataAccess;

#nullable disable

namespace PLD.Blazor.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230106173522_ModifyCommissionErrorTableJanuary0720230134")]
    partial class ModifyCommissionErrorTableJanuary0720230134
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.Activity", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("Act_Cd");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Crt_By");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Crt_Dt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Desc_Txt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Mod_By");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mod_Dt");

                    b.HasKey("Code");

                    b.ToTable("DMT_ACT");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.Carrier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Carr_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CarrierCode")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Carr_Cd");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Crt_By");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Crt_Dt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Mod_By");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mod_Dt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DMT_CARR");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.CommissionError", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Comm_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CarrierId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("Carr_Id");

                    b.Property<DateTime?>("CommEffectiveDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Pol_Dt");

                    b.Property<decimal?>("CommOverrideRate")
                        .HasColumnType("decimal(12,9)")
                        .HasColumnName("Comm_Rt");

                    b.Property<decimal?>("CommOverriderPayment")
                        .HasColumnType("numeric(16,2)")
                        .HasColumnName("Comm_Amt");

                    b.Property<decimal?>("CommPremium")
                        .HasColumnType("numeric(16,2)")
                        .HasColumnName("Comm_Prem_Amt");

                    b.Property<string>("CommPremiumMode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Prem_Mode_Cd");

                    b.Property<string>("Compensable")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("Comp_Ind");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Crt_By");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Crt_Dt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Mod_By");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mod_Dt");

                    b.Property<string>("Policy")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Pol_Num");

                    b.Property<int?>("PolicyYear")
                        .HasColumnType("int")
                        .HasColumnName("Yr_Num");

                    b.Property<int?>("ProductId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("Prod_Id");

                    b.Property<DateTime?>("TransDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Trans_Dt");

                    b.Property<string>("TransType")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("Act_Cd");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TransType");

                    b.ToTable("DMT_COMM_ERR");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Prod_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarrierId")
                        .HasColumnType("int")
                        .HasColumnName("Carr_Id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Prod_Cd");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Crt_By");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Crt_Dt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Mod_By");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mod_Dt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<bool>("ProductRateIndicator")
                        .HasColumnType("bit")
                        .HasColumnName("Prod_Rt_Ind");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int")
                        .HasColumnName("Prod_Typ_Id");

                    b.Property<bool>("ProductTypeRateIndicator")
                        .HasColumnType("bit")
                        .HasColumnName("Prod_Typ_Rt_Ind");

                    b.Property<string>("SalesLinkCarrierId")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("SalesLink_Carrier_Id");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("DMT_PROD");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Prod_Typ_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Prod_Typ_Cd");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Crt_By");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Crt_Dt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Mod_By");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mod_Dt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("DMT_PROD_TYP");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Role_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Crt_By");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Crt_Dt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Mod_By");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mod_Dt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Role_Name");

                    b.HasKey("Id");

                    b.ToTable("DMT_ROLE");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.TimeActivityMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Time_Activity_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CarrierActivity")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Src_Act_Cd");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int")
                        .HasColumnName("Carr_Id");

                    b.Property<string>("CarrierTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Src_Tm_Cd");

                    b.Property<string>("CompensableIndicator")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("Comp_Ind");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Crt_By");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Crt_Dt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Mod_By");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mod_Dt");

                    b.Property<int>("PolicyYearEnd")
                        .HasColumnType("int")
                        .HasColumnName("Yr_End_Num");

                    b.Property<int>("PolicyYearStart")
                        .HasColumnType("int")
                        .HasColumnName("Yr_Start_Num");

                    b.Property<string>("TimeCode")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("Tm_Cd");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("Act_Cd");

                    b.HasKey("Id");

                    b.HasIndex("TransactionType");

                    b.HasIndex("CarrierId", "CarrierTime", "CarrierActivity", "PolicyYearStart", "PolicyYearEnd")
                        .IsUnique();

                    b.ToTable("DMT_TM_ACT_MAP");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Birth_Date");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Crt_By");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Crt_Dt");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("First_Name");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Last_Login_Dt");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Last_Name");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Mod_By");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mod_Dt");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Password_Hash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Password_Salt");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("User_Name");

                    b.HasKey("Id");

                    b.ToTable("DMT_USER");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("Role_Id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Crt_By");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Crt_Dt");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Mod_By");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mod_Dt");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("DMT_USER_ROLE");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.CommissionError", b =>
                {
                    b.HasOne("PLD.Blazor.DataAccess.Model.Carrier", "Carrier")
                        .WithMany("CommissionErrors")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PLD.Blazor.DataAccess.Model.Product", "Product")
                        .WithMany("CommissionErrors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PLD.Blazor.DataAccess.Model.Activity", "Activity")
                        .WithMany("CommissionErrors")
                        .HasForeignKey("TransType")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Activity");

                    b.Navigation("Carrier");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.Product", b =>
                {
                    b.HasOne("PLD.Blazor.DataAccess.Model.Carrier", "Carrier")
                        .WithMany("Products")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PLD.Blazor.DataAccess.Model.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Carrier");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.TimeActivityMapping", b =>
                {
                    b.HasOne("PLD.Blazor.DataAccess.Model.Carrier", "Carrier")
                        .WithMany("TimeActivityMappings")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PLD.Blazor.DataAccess.Model.Activity", "Activity")
                        .WithMany("TimeActivityMappings")
                        .HasForeignKey("TransactionType")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Carrier");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.UserRole", b =>
                {
                    b.HasOne("PLD.Blazor.DataAccess.Model.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PLD.Blazor.DataAccess.Model.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.Activity", b =>
                {
                    b.Navigation("CommissionErrors");

                    b.Navigation("TimeActivityMappings");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.Carrier", b =>
                {
                    b.Navigation("CommissionErrors");

                    b.Navigation("Products");

                    b.Navigation("TimeActivityMappings");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.Product", b =>
                {
                    b.Navigation("CommissionErrors");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.ProductType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("PLD.Blazor.DataAccess.Model.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
