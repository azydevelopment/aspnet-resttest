﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestTest.Db.Models;

namespace Db.Migrations
{
    [DbContext(typeof(DbContextDocuments))]
    [Migration("20181104005217_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestTest.Db.Models.Document", b =>
                {
                    b.Property<long>("mId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("mName")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("mUrl")
                        .IsRequired()
                        .HasColumnName("Url")
                        .HasColumnType("char(50)");

                    b.HasKey("mId");

                    b.ToTable("TableDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}
