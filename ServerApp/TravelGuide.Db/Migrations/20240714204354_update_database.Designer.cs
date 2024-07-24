﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TravelGuide.Db;

#nullable disable

namespace TravelGuide.Db.Migrations
{
    [DbContext(typeof(TravelGuideDbContext))]
    [Migration("20240714204354_update_database")]
    partial class update_database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TravelGuide.Db.Entity.FavoriteTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("TagId")
                        .HasColumnType("integer")
                        .HasColumnName("tag_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("UserId");

                    b.ToTable("favorite_tag");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("latitude");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("longitude");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<int>("TypePlaceId")
                        .HasColumnType("integer")
                        .HasColumnName("type_place_id");

                    b.HasKey("Id");

                    b.HasIndex("TypePlaceId");

                    b.ToTable("place");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.PointOfWay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("latitude");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("longitude");

                    b.Property<int>("WayId")
                        .HasColumnType("integer")
                        .HasColumnName("way_id");

                    b.HasKey("Id");

                    b.HasIndex("WayId");

                    b.ToTable("point_of_way");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("PlaceId")
                        .HasColumnType("integer")
                        .HasColumnName("place_id");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("review");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("boolean")
                        .HasColumnName("is_private");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tag");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.TagOfPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PlaceId")
                        .HasColumnType("integer")
                        .HasColumnName("place_id");

                    b.Property<int>("TagId")
                        .HasColumnType("integer")
                        .HasColumnName("tag_id");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("TagId");

                    b.ToTable("tag_of_place");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.TypePlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("type_place");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.User", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.Way", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("way");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.FavoriteTag", b =>
                {
                    b.HasOne("TravelGuide.Db.Entity.Tag", "Tag")
                        .WithMany("FavoriteTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelGuide.Db.Entity.User", "User")
                        .WithMany("FavoriteTags")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.Place", b =>
                {
                    b.HasOne("TravelGuide.Db.Entity.TypePlace", "TypePlace")
                        .WithMany("Places")
                        .HasForeignKey("TypePlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypePlace");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.PointOfWay", b =>
                {
                    b.HasOne("TravelGuide.Db.Entity.Way", "Way")
                        .WithMany("PointOfWays")
                        .HasForeignKey("WayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Way");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.Review", b =>
                {
                    b.HasOne("TravelGuide.Db.Entity.Place", "Place")
                        .WithMany("Reviews")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelGuide.Db.Entity.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.Tag", b =>
                {
                    b.HasOne("TravelGuide.Db.Entity.User", "User")
                        .WithMany("Tags")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.TagOfPlace", b =>
                {
                    b.HasOne("TravelGuide.Db.Entity.Place", "Place")
                        .WithMany("TagOfPlaces")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelGuide.Db.Entity.Tag", "Tag")
                        .WithMany("TagOfPlaces")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.Way", b =>
                {
                    b.HasOne("TravelGuide.Db.Entity.User", "User")
                        .WithMany("Ways")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.Place", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("TagOfPlaces");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.Tag", b =>
                {
                    b.Navigation("FavoriteTag");

                    b.Navigation("TagOfPlaces");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.TypePlace", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.User", b =>
                {
                    b.Navigation("FavoriteTags");

                    b.Navigation("Reviews");

                    b.Navigation("Tags");

                    b.Navigation("Ways");
                });

            modelBuilder.Entity("TravelGuide.Db.Entity.Way", b =>
                {
                    b.Navigation("PointOfWays");
                });
#pragma warning restore 612, 618
        }
    }
}
