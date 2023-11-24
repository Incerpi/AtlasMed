﻿// <auto-generated />
using System;
using AtlasMed_GS.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace AtlasMed_GS.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231124042547_origin")]
    partial class origin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AtlasMed_GS.Models.Consulta", b =>
                {
                    b.Property<int>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdConsulta"));

                    b.Property<DateTime>("Horario")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("IdHospital")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("IdMedico")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("IdProntuario")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("IdConsulta");

                    b.HasIndex("IdHospital");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.HasIndex("IdProntuario");

                    b.ToTable("TB_CONSULTA");
                });

            modelBuilder.Entity("AtlasMed_GS.Models.Hospital", b =>
                {
                    b.Property<int>("IdHospital")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHospital"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdHospital");

                    b.ToTable("TB_HOSPITAL");
                });

            modelBuilder.Entity("AtlasMed_GS.Models.Medicacao", b =>
                {
                    b.Property<int>("IdMedicacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicacao"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Dosagem")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PrincipioAtivo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdMedicacao");

                    b.ToTable("TB_MEDICACAO");
                });

            modelBuilder.Entity("AtlasMed_GS.Models.Medico", b =>
                {
                    b.Property<int>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedico"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("IdHospital")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdMedico");

                    b.HasIndex("IdHospital");

                    b.ToTable("TB_MEDICO");
                });

            modelBuilder.Entity("AtlasMed_GS.Models.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaciente"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdPaciente");

                    b.ToTable("TB_PACIENTE");
                });

            modelBuilder.Entity("AtlasMed_GS.Models.Prontuario", b =>
                {
                    b.Property<int>("IdProntuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProntuario"));

                    b.Property<string>("Alergias")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("IdMedicacao")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("IdProntuario");

                    b.HasIndex("IdMedicacao");

                    b.ToTable("TB_PRONTUARIO");
                });

            modelBuilder.Entity("AtlasMed_GS.Models.Consulta", b =>
                {
                    b.HasOne("AtlasMed_GS.Models.Hospital", "Hospital")
                        .WithMany()
                        .HasForeignKey("IdHospital")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtlasMed_GS.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtlasMed_GS.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtlasMed_GS.Models.Prontuario", "Prontuario")
                        .WithMany()
                        .HasForeignKey("IdProntuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");

                    b.Navigation("Prontuario");
                });

            modelBuilder.Entity("AtlasMed_GS.Models.Medico", b =>
                {
                    b.HasOne("AtlasMed_GS.Models.Hospital", "Hospital")
                        .WithMany()
                        .HasForeignKey("IdHospital")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("AtlasMed_GS.Models.Prontuario", b =>
                {
                    b.HasOne("AtlasMed_GS.Models.Medicacao", "Medicacao")
                        .WithMany()
                        .HasForeignKey("IdMedicacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicacao");
                });
#pragma warning restore 612, 618
        }
    }
}
