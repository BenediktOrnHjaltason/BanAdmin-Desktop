﻿// <auto-generated />
using System;
using BanAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BanAdmin.Migrations
{
    [DbContext(typeof(BanAdminDBContext))]
    [Migration("20210919190500_AddedBans")]
    partial class AddedBans
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("BanAdmin.BanAdminDBContext+Ban", b =>
                {
                    b.Property<short>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BanEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BanStart")
                        .HasColumnType("TEXT");

                    b.Property<byte>("BanType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomBanDescription")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("DescriptionOfPerson")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Ban");
                });

            modelBuilder.Entity("BanAdmin.BanAdminDBContext+LoginDetails", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Username");

                    b.ToTable("Login");
                });
#pragma warning restore 612, 618
        }
    }
}
