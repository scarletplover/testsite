using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using testsite.Models;

namespace testsite.Migrations
{
    [DbContext(typeof(AcceptContext))]
    [Migration("20171126164134_AddJoyType")]
    partial class AddJoyType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<bool>("AgreePolicy");

                    b.Property<DateTime?>("BirthDay");

                    b.Property<int>("FamousPoint");

                    b.Property<bool?>("IsAccept");

                    b.Property<bool>("IsVip");

                    b.Property<string>("Issue");

                    b.Property<int>("JobTypeId");

                    b.Property<string>("MailAddress");

                    b.Property<string>("Name");

                    b.Property<string>("NameKana");

                    b.Property<string>("Office");

                    b.Property<string>("PostNo");

                    b.Property<int>("RepeatCount");

                    b.Property<int>("SkillPoint");

                    b.Property<string>("Twitter");

                    b.Property<string>("UserNotes");

                    b.Property<string>("WacateNotes");

                    b.Property<string>("Yakushoku");

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
