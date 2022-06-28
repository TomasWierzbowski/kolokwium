using Microsoft.EntityFrameworkCore;
using System;

namespace kolokwium.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<File>Files { get; set; }
        public DbSet<Member>Members { get; set; }
        public DbSet<Membership>Memberships { get; set; }
        public DbSet<Organization>Organizations { get; set; }
        public DbSet<Team>Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<File>(f => {
                f.HasKey(e => new {
                    e.FileID,
                    e.TeamID
                });
                f.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                f.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                f.Property(e => e.FileSize).IsRequired();

                f.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamID);

                f.HasData(
                    new File {FileID = 1,TeamID = 1, FileName = "nazwa 1", FileExtension = "png", FileSize = 1 },
                    new File {FileID = 2,TeamID = 2, FileName = "nazwa 2", FileExtension = "pdf", FileSize = 2 }
                    );

            });

            modelbuilder.Entity<Member>(m => {
                m.HasKey(e => e.MemberID);
                m.Property(e => e.OrganizationID).IsRequired();
                m.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                m.Property(e => e.MemberSurname).IsRequired().HasMaxLength(50);
                m.Property(e => e.MemberNickName).HasMaxLength(20);

                m.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID);

                m.HasData(
                    new Member { MemberID = 1, OrganizationID = 1, MemberName = "imie 1", MemberSurname = "nazwisko 1", MemberNickName="pseudonim 1" },
                    new Member { MemberID = 2, OrganizationID = 2, MemberName = "imie 2", MemberSurname = "nazwisko 2", MemberNickName="pseudonim 2" }
                    );

            });

            modelbuilder.Entity<Membership>(m => {
                m.HasKey(e => new {
                    e.MemberID,
                    e.TeamID
                });
                m.Property(e => e.MembershipDate).IsRequired();

                m.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID);
                m.HasOne(e => e.Team).WithMany(e => e.Memberships).OnDelete(DeleteBehavior.NoAction).HasForeignKey(e => e.TeamID);

                m.HasData(
                    new Membership { MemberID = 1, TeamID = 1, MembershipDate = DateTime.Parse("2022-03-01") },
                    new Membership { MemberID = 2, TeamID = 2, MembershipDate = DateTime.Parse("2021-03-01") }
                    );

            });

            modelbuilder.Entity<Organization>(o => {
                o.HasKey(e => e.OrganizationID);
                o.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                o.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);

                o.HasData(
                    new Organization { OrganizationID = 1, OrganizationName="name 1", OrganizationDomain="sport" },
                    new Organization { OrganizationID = 2, OrganizationName="name 2", OrganizationDomain="IT" }
                    );

            });

            modelbuilder.Entity<Team>(t => {
                t.HasKey(e => e.TeamID);
                t.Property(e => e.OrganizationID).IsRequired();
                t.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                t.Property(e => e.TeamDescription).HasMaxLength(500);

                t.HasOne(e => e.Organizations).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID);

                t.HasData(
                    new Team { TeamID = 1, OrganizationID=1, TeamName="nazwa 1", TeamDescription="opis 1" },
                    new Team { TeamID = 2, OrganizationID=2, TeamName="nazwa 2", TeamDescription="opis 2" }
                    );

            });

        }
        }
}
