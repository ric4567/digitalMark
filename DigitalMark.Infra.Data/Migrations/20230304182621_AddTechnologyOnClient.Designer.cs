﻿// <auto-generated />
using System;
using DigitalMark.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DigitalMark.Infra.Data.Migrations
{
    [DbContext(typeof(DigitalMarkContext))]
    [Migration("20230304182621_AddTechnologyOnClient")]
    partial class AddTechnologyOnClient
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DigitalMark.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tecnology")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("DigitalMark.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClientId1")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ClientId1");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("DigitalMark.Domain.Entities.Project", b =>
                {
                    b.HasOne("DigitalMark.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalMark.Domain.Entities.Client", null)
                        .WithMany("Projects")
                        .HasForeignKey("ClientId1");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("DigitalMark.Domain.Entities.Client", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}