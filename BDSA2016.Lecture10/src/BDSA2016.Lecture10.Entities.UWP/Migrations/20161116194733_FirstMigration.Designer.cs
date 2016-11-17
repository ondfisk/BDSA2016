using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BDSA2016.Lecture10.Entities;

namespace BDSA2016.Lecture10.Entities.Migrations
{
    [DbContext(typeof(AlbumContext))]
    [Migration("20161116194733_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("BDSA2016.Lecture10.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArtistId");

                    b.Property<byte[]>("Cover");

                    b.Property<string>("Title");

                    b.Property<int?>("Year");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("BDSA2016.Lecture10.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("BDSA2016.Lecture10.Entities.Album", b =>
                {
                    b.HasOne("BDSA2016.Lecture10.Entities.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId");
                });
        }
    }
}
