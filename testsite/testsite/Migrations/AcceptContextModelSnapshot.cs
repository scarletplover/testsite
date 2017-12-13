using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using testsite.Models;

namespace testsite.Migrations
{
    [DbContext(typeof(AcceptContext))]
    partial class AcceptContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("testsite.Models.JobType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("JobTypes");
                });

            modelBuilder.Entity("testsite.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Address2")
                        .HasMaxLength(255);

                    b.Property<bool>("AgreePolicy");

                    b.Property<DateTime>("ApplicationDate");

                    b.Property<DateTime?>("BirthDay")
                        .IsRequired();

                    b.Property<int>("FamousPoint");

                    b.Property<bool?>("IsAccept");

                    b.Property<bool?>("IsVip");

                    b.Property<string>("Issue")
                        .HasMaxLength(500);

                    b.Property<int>("JobTypeId");

                    b.Property<string>("MailAddress")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("NameKana")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Office")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("PostNo");

                    b.Property<int>("RepeatCount");

                    b.Property<int>("SkillPoint");

                    b.Property<string>("Twitter")
                        .HasMaxLength(15);

                    b.Property<string>("UserNotes")
                        .HasMaxLength(500);

                    b.Property<string>("WacateNotes")
                        .HasMaxLength(500);

                    b.Property<string>("Yakushoku")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("JobTypeId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("testsite.Models.Member", b =>
                {
                    b.HasOne("testsite.Models.JobType", "JobType")
                        .WithMany()
                        .HasForeignKey("JobTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
