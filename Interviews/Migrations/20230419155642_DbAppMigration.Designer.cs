﻿// <auto-generated />
using Interviews.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Interviews.Migrations
{
    [DbContext(typeof(MobylabAppContext))]
    [Migration("20230419155642_DbAppMigration")]
    partial class DbAppMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Interviews.Models.Category", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("c_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CId"));

                    b.Property<string>("CName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("c_name");

                    b.HasKey("CId")
                        .HasName("categories_pkey");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Interviews.Models.Company", b =>
                {
                    b.Property<int>("CompId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("comp_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CompId"));

                    b.Property<string>("CompName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("comp_name");

                    b.Property<int>("CompPositionId")
                        .HasColumnType("integer")
                        .HasColumnName("comp_position_id");

                    b.HasKey("CompId")
                        .HasName("companies_pkey");

                    b.HasIndex("CompPositionId");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("Interviews.Models.Level", b =>
                {
                    b.Property<int>("LId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("l_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LId"));

                    b.Property<string>("LDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("l_description");

                    b.HasKey("LId")
                        .HasName("levels_pkey");

                    b.ToTable("levels", (string)null);
                });

            modelBuilder.Entity("Interviews.Models.Position", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("p_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PId"));

                    b.Property<string>("PName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("p_name");

                    b.HasKey("PId")
                        .HasName("positions_pkey");

                    b.ToTable("positions", (string)null);
                });

            modelBuilder.Entity("Interviews.Models.Resource", b =>
                {
                    b.Property<int>("RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("r_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RId"));

                    b.Property<int>("RCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("r_category_id");

                    b.Property<int>("RCompanyId")
                        .HasColumnType("integer")
                        .HasColumnName("r_company_id");

                    b.Property<int>("RLevelId")
                        .HasColumnType("integer")
                        .HasColumnName("r_level_id");

                    b.Property<string>("RName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("r_name");

                    b.Property<string>("RUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("r_url");

                    b.HasKey("RId")
                        .HasName("resources_pkey");

                    b.HasIndex("RCategoryId");

                    b.HasIndex("RCompanyId");

                    b.HasIndex("RLevelId");

                    b.ToTable("resources", (string)null);
                });

            modelBuilder.Entity("Interviews.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("passwordhash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("passwordsalt");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("user_pkey");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Interviews.Models.Company", b =>
                {
                    b.HasOne("Interviews.Models.Position", "CompPosition")
                        .WithMany("Companies")
                        .HasForeignKey("CompPositionId")
                        .IsRequired()
                        .HasConstraintName("comp_pos_fk");

                    b.Navigation("CompPosition");
                });

            modelBuilder.Entity("Interviews.Models.Resource", b =>
                {
                    b.HasOne("Interviews.Models.Category", "RCategory")
                        .WithMany("Resources")
                        .HasForeignKey("RCategoryId")
                        .IsRequired()
                        .HasConstraintName("r_cat_fk");

                    b.HasOne("Interviews.Models.Company", "RCompany")
                        .WithMany("Resources")
                        .HasForeignKey("RCompanyId")
                        .IsRequired()
                        .HasConstraintName("r_comp_fk");

                    b.HasOne("Interviews.Models.Level", "RLevel")
                        .WithMany("Resources")
                        .HasForeignKey("RLevelId")
                        .IsRequired()
                        .HasConstraintName("r_lvl_fk");

                    b.Navigation("RCategory");

                    b.Navigation("RCompany");

                    b.Navigation("RLevel");
                });

            modelBuilder.Entity("Interviews.Models.Category", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("Interviews.Models.Company", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("Interviews.Models.Level", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("Interviews.Models.Position", b =>
                {
                    b.Navigation("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}
