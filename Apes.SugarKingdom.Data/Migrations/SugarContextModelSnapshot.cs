﻿// <auto-generated />
using System;
using Apes.SugarKingdom.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Apes.SugarKingdom.Data.Migrations
{
    [DbContext(typeof(SugarContext))]
    partial class SugarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Apes.SugarKingdom.Data.VersusPoints", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<byte[]>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<byte[]>("ModifiedDate")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifiedDate");

                    b.Property<int>("Points")
                        .HasColumnType("int")
                        .HasColumnName("Points");

                    b.Property<string>("Wallet")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Wallet");

                    b.HasKey("Id");

                    b.ToTable("VersusPoints");
                });
#pragma warning restore 612, 618
        }
    }
}
