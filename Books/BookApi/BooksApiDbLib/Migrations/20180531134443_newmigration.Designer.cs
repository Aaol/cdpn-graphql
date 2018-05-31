﻿// <auto-generated />
using System;
using BooksApiDbLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BooksApiDbLib.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20180531134443_newmigration")]
    partial class newmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BooksApiDbLib.Models.Author", b =>
                {
                    b.Property<long>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("Identifier")
                        .HasName("PK_Author");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BooksApiDbLib.Models.Book", b =>
                {
                    b.Property<long>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AuthorIdentifier");

                    b.Property<float>("Price");

                    b.Property<DateTime?>("PublishDate");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Type");

                    b.HasKey("Identifier")
                        .HasName("PK_Book");

                    b.HasIndex("AuthorIdentifier");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BooksApiDbLib.Models.BookComment", b =>
                {
                    b.Property<long>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BookIdentifier");

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<DateTime>("PublishDate");

                    b.HasKey("Identifier")
                        .HasName("PK_BookComment");

                    b.HasIndex("BookIdentifier");

                    b.ToTable("BookComments");
                });

            modelBuilder.Entity("BooksApiDbLib.Models.Book", b =>
                {
                    b.HasOne("BooksApiDbLib.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorIdentifier")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BooksApiDbLib.Models.BookComment", b =>
                {
                    b.HasOne("BooksApiDbLib.Models.Author", "Book")
                        .WithMany()
                        .HasForeignKey("BookIdentifier")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
