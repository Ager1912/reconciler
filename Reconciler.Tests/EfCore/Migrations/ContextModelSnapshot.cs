﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reconciler.Tests;

namespace Reconciler.EfCore.Tests.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reconciler.Tests.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Reconciler.Tests.AddressImage", b =>
                {
                    b.Property<Guid>("AddressId");

                    b.Property<string>("EncodedImageData");

                    b.HasKey("AddressId");

                    b.ToTable("AddressImages");
                });

            modelBuilder.Entity("Reconciler.Tests.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AddressId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Reconciler.Tests.PersonTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("PersonId");

                    b.Property<Guid>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("TagId");

                    b.ToTable("PersonTags");
                });

            modelBuilder.Entity("Reconciler.Tests.PersonTagPayload", b =>
                {
                    b.Property<Guid>("PersonTagId");

                    b.HasKey("PersonTagId");

                    b.ToTable("PersonTagPayloads");
                });

            modelBuilder.Entity("Reconciler.Tests.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("No");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Reconciler.Tests.AddressImage", b =>
                {
                    b.HasOne("Reconciler.Tests.Address")
                        .WithOne("Image")
                        .HasForeignKey("Reconciler.Tests.AddressImage", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Reconciler.Tests.Person", b =>
                {
                    b.HasOne("Reconciler.Tests.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Reconciler.Tests.PersonTag", b =>
                {
                    b.HasOne("Reconciler.Tests.Person", "Person")
                        .WithMany("Tags")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Reconciler.Tests.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Reconciler.Tests.PersonTagPayload", b =>
                {
                    b.HasOne("Reconciler.Tests.PersonTag")
                        .WithOne("Payload")
                        .HasForeignKey("Reconciler.Tests.PersonTagPayload", "PersonTagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
