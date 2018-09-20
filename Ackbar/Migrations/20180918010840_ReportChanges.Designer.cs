﻿// <auto-generated />
using Ackbar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Ackbar.Migrations
{
    [DbContext(typeof(GameGuideContext))]
    [Migration("20180918010840_ReportChanges")]
    partial class ReportChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ackbar.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ReportUrl");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Ackbar.Models.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Age");

                    b.Property<string>("CoverImage");

                    b.Property<string>("Description");

                    b.Property<string>("Duration");

                    b.Property<string>("Name");

                    b.Property<string>("NumberOfPlayers");

                    b.Property<long?>("ProfileId");

                    b.Property<string>("Publisher");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Ackbar.Models.Like", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("GameId");

                    b.Property<long?>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Ackbar.Models.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Ackbar.Models.Profile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("AgencyId");

                    b.Property<long?>("AppearanceId");

                    b.Property<long?>("ConflictId");

                    b.Property<long?>("InvestmentId");

                    b.Property<long?>("RulesId");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("AppearanceId");

                    b.HasIndex("ConflictId");

                    b.HasIndex("InvestmentId");

                    b.HasIndex("RulesId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Ackbar.Models.ProfileTypes.Agency", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Gradation");

                    b.Property<int>("Participation");

                    b.Property<int>("Result");

                    b.HasKey("Id");

                    b.ToTable("Agency");
                });

            modelBuilder.Entity("Ackbar.Models.ProfileTypes.Appearance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Quality");

                    b.Property<int>("Theme");

                    b.Property<int>("Transmediality");

                    b.Property<int>("VisualIdentity");

                    b.HasKey("Id");

                    b.ToTable("Appearance");
                });

            modelBuilder.Entity("Ackbar.Models.ProfileTypes.Conflict", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CognitiveAbility");

                    b.Property<int>("Competitivity");

                    b.Property<int>("Economy");

                    b.Property<int>("Feedback");

                    b.Property<int>("Interaction");

                    b.Property<int>("MentalAbility");

                    b.Property<int>("PhysicalAbility");

                    b.Property<int>("SocialAbility");

                    b.Property<int>("Structure");

                    b.Property<int>("Symmetry");

                    b.HasKey("Id");

                    b.ToTable("Conflict");
                });

            modelBuilder.Entity("Ackbar.Models.ProfileTypes.Investment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Duration");

                    b.Property<int>("Monetary");

                    b.Property<int>("Setup");

                    b.Property<int>("Space");

                    b.HasKey("Id");

                    b.ToTable("Investment");
                });

            modelBuilder.Entity("Ackbar.Models.ProfileTypes.Rules", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Actions");

                    b.Property<int>("Components");

                    b.Property<int>("Conditions");

                    b.Property<int>("IdealNumberOfPlayers");

                    b.Property<int>("Randomness");

                    b.Property<int>("RealNumberOfPlayers");

                    b.Property<int>("Resources");

                    b.Property<int>("Variance");

                    b.Property<int>("VictoryConditions");

                    b.HasKey("Id");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("Ackbar.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<long?>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique()
                        .HasFilter("[PlayerId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ackbar.Models.View", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("GameId");

                    b.Property<long?>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Views");
                });

            modelBuilder.Entity("Ackbar.Models.Customer", b =>
                {
                    b.HasOne("Ackbar.Models.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("Ackbar.Models.Customer", "UserId");
                });

            modelBuilder.Entity("Ackbar.Models.Game", b =>
                {
                    b.HasOne("Ackbar.Models.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("Ackbar.Models.Like", b =>
                {
                    b.HasOne("Ackbar.Models.Game", "Game")
                        .WithMany("Likes")
                        .HasForeignKey("GameId");

                    b.HasOne("Ackbar.Models.Player", "Player")
                        .WithMany("Likes")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("Ackbar.Models.Profile", b =>
                {
                    b.HasOne("Ackbar.Models.ProfileTypes.Agency", "Agency")
                        .WithMany()
                        .HasForeignKey("AgencyId");

                    b.HasOne("Ackbar.Models.ProfileTypes.Appearance", "Appearance")
                        .WithMany()
                        .HasForeignKey("AppearanceId");

                    b.HasOne("Ackbar.Models.ProfileTypes.Conflict", "Conflict")
                        .WithMany()
                        .HasForeignKey("ConflictId");

                    b.HasOne("Ackbar.Models.ProfileTypes.Investment", "Investment")
                        .WithMany()
                        .HasForeignKey("InvestmentId");

                    b.HasOne("Ackbar.Models.ProfileTypes.Rules", "Rules")
                        .WithMany()
                        .HasForeignKey("RulesId");
                });

            modelBuilder.Entity("Ackbar.Models.User", b =>
                {
                    b.HasOne("Ackbar.Models.Player", "Player")
                        .WithOne("User")
                        .HasForeignKey("Ackbar.Models.User", "PlayerId");
                });

            modelBuilder.Entity("Ackbar.Models.View", b =>
                {
                    b.HasOne("Ackbar.Models.Game", "Game")
                        .WithMany("Views")
                        .HasForeignKey("GameId");

                    b.HasOne("Ackbar.Models.Player", "Player")
                        .WithMany("Views")
                        .HasForeignKey("PlayerId");
                });
#pragma warning restore 612, 618
        }
    }
}
