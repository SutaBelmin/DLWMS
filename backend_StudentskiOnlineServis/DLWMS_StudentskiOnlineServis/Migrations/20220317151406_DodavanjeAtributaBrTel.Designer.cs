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
    [Migration("20220317151406_DodavanjeAtributaBrTel")]
    partial class DodavanjeAtributaBrTel
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

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.CHAT", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("datumPoruke")
                        .HasColumnType("datetime2");

                    b.Property<int>("korisnik1_ID")
                        .HasColumnType("int");

                    b.Property<int>("korisnik2_ID")
                        .HasColumnType("int");

                    b.Property<string>("sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("korisnik1_ID");

                    b.HasIndex("korisnik2_ID");

                    b.ToTable("Poruke");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Cas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lekcija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PredmetID")
                        .HasColumnType("int");

                    b.Property<int>("ProfesorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PredmetID");

                    b.HasIndex("ProfesorID");

                    b.ToTable("Casovi");
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

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Ocjena", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RokID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("_Ocjena")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RokID");

                    b.HasIndex("StudentID");

                    b.ToTable("Ocjene");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Odgovor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PitanjeID")
                        .HasColumnType("int");

                    b.Property<string>("SadrzajOdgovora")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Tacan")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("PitanjeID");

                    b.ToTable("Odgovori");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Pitanje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Indeks")
                        .HasColumnType("int");

                    b.Property<int>("RokID")
                        .HasColumnType("int");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RokID");

                    b.ToTable("Pitanja");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Prisustvo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CasID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CasID");

                    b.HasIndex("StudentID");

                    b.ToTable("Prisustva");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Rok", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Aktivan")
                        .HasColumnType("bit");

                    b.Property<int?>("BrojPitanja")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumOdrzavanja")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Predmet")
                        .HasColumnType("int");

                    b.Property<string>("NazivTesta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfesorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Id_Predmet");

                    b.HasIndex("ProfesorID");

                    b.ToTable("Rokovi");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Rok_Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OdgovorID")
                        .HasColumnType("int");

                    b.Property<int>("RokID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<bool>("StudentZaokruzio")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("OdgovorID");

                    b.HasIndex("RokID");

                    b.HasIndex("StudentID");

                    b.ToTable("OdgovoriNaPitanja");
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

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Potvrda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Izdata")
                        .HasColumnType("bit");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datum_izdavanja")
                        .HasColumnType("datetime2");

                    b.Property<int?>("referentId")
                        .HasColumnType("int");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.Property<int>("svrhaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("referentId");

                    b.HasIndex("studentId");

                    b.HasIndex("svrhaId");

                    b.ToTable("Potvrda");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Predmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Godina")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oznaka")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Profesor_Predmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("predmetId")
                        .HasColumnType("int");

                    b.Property<int>("profesorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("predmetId");

                    b.HasIndex("profesorId");

                    b.ToTable("Profesor_Predmet");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Student_Predmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("isPolozio")
                        .HasColumnType("bit");

                    b.Property<int>("predmetId")
                        .HasColumnType("int");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("predmetId");

                    b.HasIndex("studentId");

                    b.ToTable("Student_Predmet");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.SvrhaPotvrde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SvrhaPotvrde");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Uspjeh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("datum_upisa")
                        .HasColumnType("datetime2");

                    b.Property<int>("ocjena")
                        .HasColumnType("int");

                    b.Property<int>("profesor_predmetId")
                        .HasColumnType("int");

                    b.Property<int>("student_predmetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("profesor_predmetId");

                    b.HasIndex("student_predmetId");

                    b.ToTable("Uspjeh");
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

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Referent.Models.Referent", b =>
                {
                    b.HasBaseType("DLWMS_StudentskiOnlineServis.Modul_1.Models.KorisnickiNalog");

                    b.Property<string>("Ime")
                        .HasColumnName("Referent_Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnName("Referent_Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Referent");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Student", b =>
                {
                    b.HasBaseType("DLWMS_StudentskiOnlineServis.Modul_1.Models.KorisnickiNalog");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnName("Student_DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .HasColumnName("Student_Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnName("Student_Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("broj_indeksa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("slika_studenta")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.AutentifikacijaToken", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.CHAT", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.KorisnickiNalog", "korisnik1")
                        .WithMany()
                        .HasForeignKey("korisnik1_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.KorisnickiNalog", "korisnik2")
                        .WithMany()
                        .HasForeignKey("korisnik2_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Cas", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorID")
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

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Ocjena", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.Rok", "rok")
                        .WithMany()
                        .HasForeignKey("RokID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Odgovor", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.Pitanje", "Pitanje")
                        .WithMany()
                        .HasForeignKey("PitanjeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Pitanje", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.Rok", "Rok")
                        .WithMany()
                        .HasForeignKey("RokID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Prisustvo", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.Cas", "Cas")
                        .WithMany()
                        .HasForeignKey("CasID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Rok", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("Id_Predmet")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_1.Models.Rok_Student", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.Odgovor", "Odgovor")
                        .WithMany()
                        .HasForeignKey("OdgovorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.Rok", "Rok")
                        .WithMany()
                        .HasForeignKey("RokID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Potvrda", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Referent.Models.Referent", "referent")
                        .WithMany()
                        .HasForeignKey("referentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Student.Models.SvrhaPotvrde", "svrha")
                        .WithMany()
                        .HasForeignKey("svrhaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Profesor_Predmet", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Predmet", "predmet")
                        .WithMany()
                        .HasForeignKey("predmetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_1.Models.Profesor", "profesor")
                        .WithMany()
                        .HasForeignKey("profesorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Student_Predmet", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Predmet", "predmet")
                        .WithMany()
                        .HasForeignKey("predmetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Uspjeh", b =>
                {
                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Profesor_Predmet", "profesor_predmet")
                        .WithMany()
                        .HasForeignKey("profesor_predmetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DLWMS_StudentskiOnlineServis.Modul_Student.Models.Student_Predmet", "student_predmet")
                        .WithMany()
                        .HasForeignKey("student_predmetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
