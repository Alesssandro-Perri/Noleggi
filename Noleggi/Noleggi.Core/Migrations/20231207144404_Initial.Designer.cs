﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Noleggi.Core.Services;

#nullable disable

namespace Noleggi.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231207144404_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("Noleggi.Core.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascita")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clienti");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cognome = "Perri",
                            DataNascita = new DateTime(2005, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alessandro.perri@samtrevano.ch",
                            Indirizzo = "Via Boschina 2, Bedano",
                            Nome = "Alessandro",
                            Numero = "+41765545772"
                        },
                        new
                        {
                            Id = 2,
                            Cognome = "Muniz",
                            DataNascita = new DateTime(2004, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "diego.muniz@samtrevano.ch",
                            Indirizzo = "Via stazione, Quartino",
                            Nome = "Diego",
                            Numero = "+41765349425"
                        },
                        new
                        {
                            Id = 3,
                            Cognome = "Ierardi",
                            DataNascita = new DateTime(2005, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alex.ierardi@samtrevano.ch",
                            Indirizzo = "Via montagne, Biasca",
                            Nome = "Alex",
                            Numero = "+41794321432"
                        },
                        new
                        {
                            Id = 4,
                            Cognome = "Monga",
                            DataNascita = new DateTime(2005, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "christian.monga@samtrevano.ch",
                            Indirizzo = "Via gerra, Bedano",
                            Nome = "Christian",
                            Numero = "+41791234567"
                        },
                        new
                        {
                            Id = 5,
                            Cognome = "Ratti",
                            DataNascita = new DateTime(2005, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "edoardo.ratti@samtrevano.ch",
                            Indirizzo = "Via cinquale, Caslano",
                            Nome = "Edoardo",
                            Numero = "+41795432100"
                        });
                });

            modelBuilder.Entity("Noleggi.Core.Models.Noleggio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("CostoEffettivo")
                        .HasColumnType("REAL");

                    b.Property<double>("CostoTeorico")
                        .HasColumnType("REAL");

                    b.Property<double>("CostoTotale")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("DataConsegnaEffettiva")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataFineNoleggio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataRitiro")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeNoleggio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PeriodicitaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RisorsaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PeriodicitaId");

                    b.HasIndex("RisorsaId");

                    b.ToTable("Noleggi");
                });

            modelBuilder.Entity("Noleggi.Core.Models.Periodicita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Durata")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Giorno")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Periodi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Durata = "Giornaliera",
                            Giorno = 1
                        },
                        new
                        {
                            Id = 2,
                            Durata = "Settimanale",
                            Giorno = 7
                        },
                        new
                        {
                            Id = 3,
                            Durata = "Mensile",
                            Giorno = 30
                        },
                        new
                        {
                            Id = 4,
                            Durata = "Annuale",
                            Giorno = 360
                        });
                });

            modelBuilder.Entity("Noleggi.Core.Models.PeriodicitaRisorsa", b =>
                {
                    b.Property<int>("RisorsaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PeriodicitaId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("RisorsaId", "PeriodicitaId");

                    b.HasIndex("PeriodicitaId");

                    b.ToTable("PeriodicitaRisorse");

                    b.HasData(
                        new
                        {
                            RisorsaId = 1,
                            PeriodicitaId = 1,
                            Costo = 1.0,
                            Id = 1
                        },
                        new
                        {
                            RisorsaId = 1,
                            PeriodicitaId = 2,
                            Costo = 10.0,
                            Id = 2
                        },
                        new
                        {
                            RisorsaId = 1,
                            PeriodicitaId = 3,
                            Costo = 100.0,
                            Id = 3
                        },
                        new
                        {
                            RisorsaId = 1,
                            PeriodicitaId = 4,
                            Costo = 1000.0,
                            Id = 4
                        },
                        new
                        {
                            RisorsaId = 2,
                            PeriodicitaId = 1,
                            Costo = 2.0,
                            Id = 5
                        },
                        new
                        {
                            RisorsaId = 2,
                            PeriodicitaId = 2,
                            Costo = 20.0,
                            Id = 6
                        });
                });

            modelBuilder.Entity("Noleggi.Core.Models.Risorsa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Stato")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Risorse");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Categoria = "Informatica",
                            Nome = "MacBook",
                            Stato = "Disponibile"
                        },
                        new
                        {
                            Id = 2,
                            Categoria = "Informatica",
                            Nome = "Iphone 15",
                            Stato = "Disponibile"
                        },
                        new
                        {
                            Id = 3,
                            Categoria = "Elettrodomestici",
                            Nome = "Aspirapolvere - Dyson",
                            Stato = "Disponibile"
                        },
                        new
                        {
                            Id = 4,
                            Categoria = "Elettrodomestici",
                            Nome = "Friggitrice",
                            Stato = "Disponibile"
                        },
                        new
                        {
                            Id = 5,
                            Categoria = "Gaming",
                            Nome = "Controller PS5",
                            Stato = "Disponibile"
                        });
                });

            modelBuilder.Entity("Noleggi.Core.Models.Noleggio", b =>
                {
                    b.HasOne("Noleggi.Core.Models.Cliente", "Cliente")
                        .WithMany("Noleggi")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Noleggi.Core.Models.Periodicita", "Periodicita")
                        .WithMany("Noleggi")
                        .HasForeignKey("PeriodicitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Noleggi.Core.Models.Risorsa", "Risorsa")
                        .WithMany("Noleggi")
                        .HasForeignKey("RisorsaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Periodicita");

                    b.Navigation("Risorsa");
                });

            modelBuilder.Entity("Noleggi.Core.Models.PeriodicitaRisorsa", b =>
                {
                    b.HasOne("Noleggi.Core.Models.Periodicita", "Periodicita")
                        .WithMany("PeriodicitaRisorse")
                        .HasForeignKey("PeriodicitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Noleggi.Core.Models.Risorsa", "Risorsa")
                        .WithMany("PeriodicitaRisorse")
                        .HasForeignKey("RisorsaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Periodicita");

                    b.Navigation("Risorsa");
                });

            modelBuilder.Entity("Noleggi.Core.Models.Cliente", b =>
                {
                    b.Navigation("Noleggi");
                });

            modelBuilder.Entity("Noleggi.Core.Models.Periodicita", b =>
                {
                    b.Navigation("Noleggi");

                    b.Navigation("PeriodicitaRisorse");
                });

            modelBuilder.Entity("Noleggi.Core.Models.Risorsa", b =>
                {
                    b.Navigation("Noleggi");

                    b.Navigation("PeriodicitaRisorse");
                });
#pragma warning restore 612, 618
        }
    }
}
