using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class bbwContext : DbContext
    {
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleActivity> ArticleActivity { get; set; }
        public virtual DbSet<ArticleCompetency> ArticleCompetency { get; set; }
        public virtual DbSet<ArticleDiscussionQuestion> ArticleDiscussionQuestion { get; set; }
        public virtual DbSet<ArticleKeyLearningPoint> ArticleKeyLearningPoint { get; set; }
        public virtual DbSet<ArticleQuizQuestion> ArticleQuizQuestion { get; set; }
        public virtual DbSet<ArticleRegion> ArticleRegion { get; set; }
        public virtual DbSet<ArticleSector> ArticleSector { get; set; }
        public virtual DbSet<ArticleStatus> ArticleStatus { get; set; }
        public virtual DbSet<ArticleSubTopic> ArticleSubTopic { get; set; }
        public virtual DbSet<Competency> Competency { get; set; }
        public virtual DbSet<Discipline> Discipline { get; set; }
        public virtual DbSet<GuideType> GuideType { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Reviewer> Reviewer { get; set; }
        public virtual DbSet<RoleClaims> RoleClaims { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<SubTopic> SubTopic { get; set; }
        public virtual DbSet<UserClaims> UserClaims { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=bbw;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.Property(e => e.Abstract)
                    .IsRequired()
                    .HasColumnName("abstract");

                entity.Property(e => e.ArticleStatusId).HasColumnName("articleStatusId");

                entity.Property(e => e.CreatedByUserId)
                    .IsRequired()
                    .HasColumnName("createdByUserId")
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasColumnType("datetime");

                entity.Property(e => e.GuideTypeId).HasColumnName("guideTypeId");

                entity.Property(e => e.IssueId).HasColumnName("issueId");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("lastUpdated")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReviewerId).HasColumnName("reviewerId");

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasColumnName("summary");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(1024);

                entity.Property(e => e.UpdatedByUserId)
                    .IsRequired()
                    .HasColumnName("updatedByUserId")
                    .HasMaxLength(450);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url");

                entity.HasOne(d => d.ArticleStatus)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.ArticleStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_article_articleStatus");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.ArticleCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_article_users");

                entity.HasOne(d => d.GuideType)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.GuideTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_article_guideType");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_article_issue");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.ReviewerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_article_reviewer");

                entity.HasOne(d => d.UpdatedByUser)
                    .WithMany(p => p.ArticleUpdatedByUser)
                    .HasForeignKey(d => d.UpdatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_article_users1");
            });

            modelBuilder.Entity<ArticleActivity>(entity =>
            {
                entity.ToTable("articleActivity");

                entity.Property(e => e.Activity)
                    .IsRequired()
                    .HasColumnName("activity");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.Ordinal).HasColumnName("ordinal");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleActivity)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articleActivity_article");
            });

            modelBuilder.Entity<ArticleCompetency>(entity =>
            {
                entity.ToTable("articleCompetency");

                entity.HasIndex(e => new { e.ArticleId, e.CompetencyId })
                    .HasName("IX_articleId_competencyId")
                    .IsUnique();

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.CompetencyId).HasColumnName("competencyId");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleCompetency)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articleCompetency_article");

                entity.HasOne(d => d.Competency)
                    .WithMany(p => p.ArticleCompetency)
                    .HasForeignKey(d => d.CompetencyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articleCompetency_competency");
            });

            modelBuilder.Entity<ArticleDiscussionQuestion>(entity =>
            {
                entity.ToTable("articleDiscussionQuestion");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.Ordinal).HasColumnName("ordinal");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleDiscussionQuestion)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articleDiscussionQuestion_article");
            });

            modelBuilder.Entity<ArticleKeyLearningPoint>(entity =>
            {
                entity.ToTable("articleKeyLearningPoint");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.KeyLearningPoint)
                    .IsRequired()
                    .HasColumnName("keyLearningPoint");

                entity.Property(e => e.Ordinal).HasColumnName("ordinal");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleKeyLearningPoint)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articleKeyLearningPoint_article");
            });

            modelBuilder.Entity<ArticleQuizQuestion>(entity =>
            {
                entity.ToTable("articleQuizQuestion");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.Ordinal).HasColumnName("ordinal");

                entity.Property(e => e.QuestionTypeId).HasColumnName("questionTypeId");

                entity.Property(e => e.QuizQuestion)
                    .IsRequired()
                    .HasColumnName("quizQuestion");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleQuizQuestion)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articleQuizQuestion_article");
            });

            modelBuilder.Entity<ArticleRegion>(entity =>
            {
                entity.ToTable("articleRegion");

                entity.HasIndex(e => new { e.ArticleId, e.RegionId })
                    .HasName("IX_articleId_regionId")
                    .IsUnique();

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.RegionId).HasColumnName("regionId");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleRegion)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articleRegion_article");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.ArticleRegion)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articleRegion_region");
            });

            modelBuilder.Entity<ArticleSector>(entity =>
            {
                entity.ToTable("articleSector");

                entity.HasIndex(e => new { e.ArticleId, e.SectorId })
                    .HasName("IX_articleId_sectorId")
                    .IsUnique();

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.SectorId).HasColumnName("sectorId");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleSector)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articleSector_article");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.ArticleSector)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articleSector_sector");
            });

            modelBuilder.Entity<ArticleStatus>(entity =>
            {
                entity.ToTable("articleStatus");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<ArticleSubTopic>(entity =>
            {
                entity.ToTable("articleSubTopic");

                entity.HasIndex(e => new { e.ArticleId, e.SubTopicId })
                    .HasName("IX_articleId_subTopicId")
                    .IsUnique();

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.SubTopicId).HasColumnName("subTopicId");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleSubTopic)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articleSubTopic_article");

                entity.HasOne(d => d.SubTopic)
                    .WithMany(p => p.ArticleSubTopic)
                    .HasForeignKey(d => d.SubTopicId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_articleSubTopic_subTopic");
            });

            modelBuilder.Entity<Competency>(entity =>
            {
                entity.ToTable("competency");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.ToTable("discipline");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<GuideType>(entity =>
            {
                entity.ToTable("guideType");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.ToTable("issue");

                entity.Property(e => e.CoverImage)
                    .IsRequired()
                    .HasColumnName("coverImage");

                entity.Property(e => e.CreatedByUserId)
                    .IsRequired()
                    .HasColumnName("createdByUserId")
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.IssueDate)
                    .HasColumnName("issueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("lastUpdated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedByUserId)
                    .IsRequired()
                    .HasColumnName("updatedByUserId")
                    .HasMaxLength(450);

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.IssueCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_issue_users");

                entity.HasOne(d => d.UpdatedByUser)
                    .WithMany(p => p.IssueUpdatedByUser)
                    .HasForeignKey(d => d.UpdatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_issue_users1");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Reviewer>(entity =>
            {
                entity.ToTable("reviewer");

                entity.HasIndex(e => new { e.LastName, e.FirstName, e.MiddleInitial })
                    .HasName("IX_lastName_firstName_middleInitial")
                    .IsUnique();

                entity.Property(e => e.CreatedByUserId)
                    .IsRequired()
                    .HasColumnName("createdByUserId")
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Degree)
                    .IsRequired()
                    .HasColumnName("degree")
                    .HasMaxLength(64);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(64);

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(64);

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("lastUpdated")
                    .HasColumnType("datetime");

                entity.Property(e => e.MiddleInitial)
                    .IsRequired()
                    .HasColumnName("middleInitial")
                    .HasMaxLength(64);

                entity.Property(e => e.UpdatedByUserId)
                    .IsRequired()
                    .HasColumnName("updatedByUserId")
                    .HasMaxLength(450);

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.ReviewerCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewer_users");

                entity.HasOne(d => d.UpdatedByUser)
                    .WithMany(p => p.ReviewerUpdatedByUser)
                    .HasForeignKey(d => d.UpdatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewer_users1");
            });

            modelBuilder.Entity<RoleClaims>(entity =>
            {
                entity.ToTable("roleClaims");

                entity.Property(e => e.ClaimType).HasColumnName("claimType");

                entity.Property(e => e.ClaimValue).HasColumnName("claimValue");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("roleId")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_IdentityRoleClaim<string>_IdentityRole_roleId");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrencyStamp");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NormalizedName)
                    .HasColumnName("normalizedName")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.ToTable("sector");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<SubTopic>(entity =>
            {
                entity.ToTable("subTopic");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.DisciplineId).HasColumnName("disciplineId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.SubTopic)
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_subTopic_discipline");
            });

            modelBuilder.Entity<UserClaims>(entity =>
            {
                entity.ToTable("userClaims");

                entity.Property(e => e.ClaimType).HasColumnName("claimType");

                entity.Property(e => e.ClaimValue).HasColumnName("claimValue");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_IdentityUserClaim<string>_ApplicationUser_userId");
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK_IdentityUserLogin<string>");

                entity.ToTable("userLogins");

                entity.Property(e => e.LoginProvider)
                    .HasColumnName("loginProvider")
                    .HasMaxLength(450);

                entity.Property(e => e.ProviderKey)
                    .HasColumnName("providerKey")
                    .HasMaxLength(450);

                entity.Property(e => e.ProviderDisplayName).HasColumnName("providerDisplayName");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_IdentityUserLogin<string>_ApplicationUser_userId");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_IdentityUserRole<string>");

                entity.ToTable("userRoles");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(450);

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_IdentityUserRole<string>_IdentityRole_roleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_IdentityUserRole<string>_ApplicationUser_userId");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.AccessFailedCount).HasColumnName("accessFailedCount");

                entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrencyStamp");

                entity.Property(e => e.DateCreated).HasColumnName("dateCreated");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.EmailConfirmed).HasColumnName("emailConfirmed");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(256);

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(256);

                entity.Property(e => e.LastUpdated).HasColumnName("lastUpdated");

                entity.Property(e => e.LockoutEnabled).HasColumnName("lockoutEnabled");

                entity.Property(e => e.LockoutEnd).HasColumnName("lockoutEnd");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middleName")
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail)
                    .HasColumnName("normalizedEmail")
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName)
                    .HasColumnName("normalizedUserName")
                    .HasMaxLength(256);

                entity.Property(e => e.PasswordHash).HasColumnName("passwordHash");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("phoneNumberConfirmed");

                entity.Property(e => e.SecurityStamp).HasColumnName("securityStamp");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(256);

                entity.Property(e => e.TwoFactorEnabled).HasColumnName("twoFactorEnabled");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(256);
            });
        }
    }
}