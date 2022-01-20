﻿// <auto-generated />
using System;
using DLWMS_StudentskiOnlineServis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DLWMS_StudentskiOnlineServis.Migrations
{
    [DbContext(typeof(DLWMS_baza))]
    [Migration("20220120172037_IzmjenaStruktureLogina")]
    partial class IzmjenaStruktureLogina
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.AutentifikacijaToken", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IP_Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<string>("Vrijednost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("AutentifikacijaToken");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Fakultet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Fakulteti");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FakultetEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FakultetID")
                        .HasColumnType("int");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivatniEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("FakultetID");

                    b.ToTable("KorisnickiNalog");

                    b.HasDiscriminator<string>("Discriminator").HasValue("KorisnickiNalog");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Verifikacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Verifikacije");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("broj_indeksa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("slika_studenta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("KorisnikID");

                    b.ToTable("Studenti");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Korisnik", b =>
                {
                    b.HasBaseType("DLWMS_StudentskiOnlineServis.Modul_1.Models.KorisnickiNalog");

                    b.Property<string>("DLWMS_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumPrijave")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Privatni_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vrsta_Korisnika")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Korisnik");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Profesor", b =>
                {
                    b.HasBaseType("DLWMS_StudentskiOnlineServis.Modul_1.Models.KorisnickiNalog");

                    b.Property<string>("Ime")
                        .HasColumnName("Profesor_Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnName("Profesor_Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Profesor");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.AutentifikacijaToken", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.KorisnickiNalog", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.Fakultet", "Fakultet")
                        .WithMany()
                        .HasForeignKey("FakultetID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Student", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
