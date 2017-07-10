using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class ercContext : DbContext
    {
        public virtual DbSet<Competency> Competency { get; set; }
        public virtual DbSet<Discipline> Discipline { get; set; }
        public virtual DbSet<DiscussionQuestion> DiscussionQuestion { get; set; }
        public virtual DbSet<EdgeGuide> EdgeGuide { get; set; }
        public virtual DbSet<GuideType> GuideType { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<LogSource> LogSource { get; set; }
        public virtual DbSet<LogType> LogType { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<QuizAnswer> QuizAnswer { get; set; }
        public virtual DbSet<QuizQuestion> QuizQuestion { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<ReviewActivity> ReviewActivity { get; set; }
        public virtual DbSet<ReviewCompetency> ReviewCompetency { get; set; }
        public virtual DbSet<ReviewDiscipline> ReviewDiscipline { get; set; }
        public virtual DbSet<ReviewEdgeGuide> ReviewEdgeGuide { get; set; }
        public virtual DbSet<ReviewRegion> ReviewRegion { get; set; }
        public virtual DbSet<ReviewSector> ReviewSector { get; set; }
        public virtual DbSet<ReviewStatus> ReviewStatus { get; set; }
        public virtual DbSet<ReviewSubRegion> ReviewSubRegion { get; set; }
        public virtual DbSet<ReviewSubTopic> ReviewSubTopic { get; set; }
        public virtual DbSet<Reviewer> Reviewer { get; set; }
        public virtual DbSet<RoleClaims> RoleClaims { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<SiteSetting> SiteSetting { get; set; }
        public virtual DbSet<SubRegion> SubRegion { get; set; }
        public virtual DbSet<SubTopic> SubTopic { get; set; }
        public virtual DbSet<UserClaims> UserClaims { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=erc;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competency>(entity =>
            {
                entity.ToTable("competency");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

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

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<DiscussionQuestion>(entity =>
            {
                entity.ToTable("discussionQuestion");

                entity.Property(e => e.Ordinal).HasColumnName("ordinal");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question");

                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.DiscussionQuestion)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_discussionQuestion_review");
            });

            modelBuilder.Entity<EdgeGuide>(entity =>
            {
                entity.ToTable("edgeGuide");

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

                entity.Property(e => e.CoverStoryUrl)
                    .IsRequired()
                    .HasColumnName("coverStoryUrl")
                    .HasMaxLength(256);

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

                entity.Property(e => e.IssueName)
                    .IsRequired()
                    .HasColumnName("issueName")
                    .HasMaxLength(50);

                entity.Property(e => e.IssueTitle)
                    .IsRequired()
                    .HasColumnName("issueTitle")
                    .HasMaxLength(256);

                entity.Property(e => e.IssueUrlName)
                    .IsRequired()
                    .HasColumnName("issueUrlName")
                    .HasMaxLength(50);

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

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.Property(e => e.CreatedByUserId)
                    .IsRequired()
                    .HasColumnName("createdByUserId")
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasColumnType("datetime");

                entity.Property(e => e.LinkId).HasColumnName("linkId");

                entity.Property(e => e.LinkUserId)
                    .IsRequired()
                    .HasColumnName("linkUserId")
                    .HasMaxLength(128);

                entity.Property(e => e.LogSourceId).HasColumnName("logSourceId");

                entity.Property(e => e.LogTypeId).HasColumnName("logTypeId");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_log_users");

                entity.HasOne(d => d.LogSource)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.LogSourceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_log_logSource");

                entity.HasOne(d => d.LogType)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.LogTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_log_logType");
            });

            modelBuilder.Entity<LogSource>(entity =>
            {
                entity.ToTable("logSource");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<LogType>(entity =>
            {
                entity.ToTable("logType");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.ToTable("questionType");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<QuizAnswer>(entity =>
            {
                entity.ToTable("quizAnswer");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnName("answer");

                entity.Property(e => e.Ordinal).HasColumnName("ordinal");

                entity.Property(e => e.QuizQuestionId).HasColumnName("quizQuestionId");

                entity.HasOne(d => d.QuizQuestion)
                    .WithMany(p => p.QuizAnswer)
                    .HasForeignKey(d => d.QuizQuestionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_quizAnswer_quizQuestion");
            });

            modelBuilder.Entity<QuizQuestion>(entity =>
            {
                entity.ToTable("quizQuestion");

                entity.Property(e => e.Ordinal).HasColumnName("ordinal");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question");

                entity.Property(e => e.QuestionTypeId).HasColumnName("questionTypeId");

                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.QuizQuestion)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_quizQuestion_questionType");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.QuizQuestion)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_quizQuestion_review");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("review");

                entity.Property(e => e.Abstract)
                    .IsRequired()
                    .HasColumnName("abstract");

                entity.Property(e => e.CreatedByUserId)
                    .IsRequired()
                    .HasColumnName("createdByUserId")
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasColumnType("datetime");

                entity.Property(e => e.GuideTypeId).HasColumnName("guideTypeId");

                entity.Property(e => e.IssueId).HasColumnName("issueId");

                entity.Property(e => e.KeyWords)
                    .IsRequired()
                    .HasColumnName("keyWords");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("lastUpdated")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReviewStatusId).HasColumnName("reviewStatusId");

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

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.ReviewCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_review_usersCreated");

                entity.HasOne(d => d.GuideType)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.GuideTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_review_guideType");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_review_issue");

                entity.HasOne(d => d.ReviewStatus)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.ReviewStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_review_reviewStatus");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.ReviewerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_review_reviewer");

                entity.HasOne(d => d.UpdatedByUser)
                    .WithMany(p => p.ReviewUpdatedByUser)
                    .HasForeignKey(d => d.UpdatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_review_usersUpdated");
            });

            modelBuilder.Entity<ReviewActivity>(entity =>
            {
                entity.ToTable("reviewActivity");

                entity.Property(e => e.Activity)
                    .IsRequired()
                    .HasColumnName("activity");

                entity.Property(e => e.Ordinal).HasColumnName("ordinal");

                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewActivity)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewActivity_review");
            });

            modelBuilder.Entity<ReviewCompetency>(entity =>
            {
                entity.ToTable("reviewCompetency");

                entity.HasIndex(e => new { e.ReviewId, e.CompetencyId })
                    .HasName("IX_reviewId_competencyId")
                    .IsUnique();

                entity.Property(e => e.CompetencyId).HasColumnName("competencyId");

                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.HasOne(d => d.Competency)
                    .WithMany(p => p.ReviewCompetency)
                    .HasForeignKey(d => d.CompetencyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewCompetency_competency");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewCompetency)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewCompetency_review");
            });

            modelBuilder.Entity<ReviewDiscipline>(entity =>
            {
                entity.ToTable("reviewDiscipline");

                entity.HasIndex(e => new { e.ReviewId, e.DisciplineId })
                    .HasName("IX_reviewId_disciplineId")
                    .IsUnique();

                entity.Property(e => e.DisciplineId).HasColumnName("disciplineId");

                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.ReviewDiscipline)
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewDiscipline_discipline");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewDiscipline)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewDiscipline_review");
            });

            modelBuilder.Entity<ReviewEdgeGuide>(entity =>
            {
                entity.ToTable("reviewEdgeGuide");

                entity.HasIndex(e => new { e.ReviewId, e.EdgeGuideId })
                    .HasName("IX_reviewId_edgeGuideId")
                    .IsUnique();

                entity.Property(e => e.EdgeGuideId).HasColumnName("edgeGuideId");

                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.HasOne(d => d.EdgeGuide)
                    .WithMany(p => p.ReviewEdgeGuide)
                    .HasForeignKey(d => d.EdgeGuideId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewEdgeGuide_edgeGuide");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewEdgeGuide)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewEdgeGuide_review");
            });

            modelBuilder.Entity<ReviewRegion>(entity =>
            {
                entity.ToTable("reviewRegion");

                entity.HasIndex(e => new { e.ReviewId, e.RegionId })
                    .HasName("IX_reviewId_regionId")
                    .IsUnique();

                entity.Property(e => e.RegionId).HasColumnName("regionId");

                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.ReviewRegion)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewRegion_region");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewRegion)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewRegion_review1");
            });

            modelBuilder.Entity<ReviewSector>(entity =>
            {
                entity.ToTable("reviewSector");

                entity.HasIndex(e => new { e.ReviewId, e.SectorId })
                    .HasName("IX_reviewId_sectorId")
                    .IsUnique();

                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.Property(e => e.SectorId).HasColumnName("sectorId");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewSector)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewSector_review");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.ReviewSector)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewSector_sector");
            });

            modelBuilder.Entity<ReviewStatus>(entity =>
            {
                entity.ToTable("reviewStatus");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<ReviewSubRegion>(entity =>
            {
                entity.ToTable("reviewSubRegion");

                entity.HasIndex(e => new { e.ReviewId, e.SubRegionId })
                    .HasName("IX_reviewId_subRegionId")
                    .IsUnique();

                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.Property(e => e.SubRegionId).HasColumnName("subRegionId");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewSubRegion)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewRegion_review");

                entity.HasOne(d => d.SubRegion)
                    .WithMany(p => p.ReviewSubRegion)
                    .HasForeignKey(d => d.SubRegionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewSubRegion_subRegion");
            });

            modelBuilder.Entity<ReviewSubTopic>(entity =>
            {
                entity.ToTable("reviewSubTopic");

                entity.HasIndex(e => new { e.ReviewId, e.SubTopicId })
                    .HasName("IX_reviewId_subTopicId")
                    .IsUnique();

                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.Property(e => e.SubTopicId).HasColumnName("subTopicId");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewSubTopic)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewSubTopic_review");

                entity.HasOne(d => d.SubTopic)
                    .WithMany(p => p.ReviewSubTopic)
                    .HasForeignKey(d => d.SubTopicId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewSubTopic_subTopic");
            });

            modelBuilder.Entity<Reviewer>(entity =>
            {
                entity.ToTable("reviewer");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_userId")
                    .IsUnique();

                entity.Property(e => e.Biography)
                    .IsRequired()
                    .HasColumnName("biography");

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

                entity.Property(e => e.HideFromReviewerList).HasColumnName("hideFromReviewerList");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("lastUpdated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedByUserId)
                    .IsRequired()
                    .HasColumnName("updatedByUserId")
                    .HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(450);

                entity.HasOne(d => d.UpdatedByUser)
                    .WithMany(p => p.ReviewerUpdatedByUser)
                    .HasForeignKey(d => d.UpdatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewer_updatedByUser");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.ReviewerUser)
                    .HasForeignKey<Reviewer>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reviewer_users");
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
                    .HasName("IX_name");

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

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<SiteSetting>(entity =>
            {
                entity.ToTable("siteSetting");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_name")
                    .IsUnique();

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasColumnName("displayName")
                    .HasMaxLength(50);

                entity.Property(e => e.IsBoolean).HasColumnName("isBoolean");

                entity.Property(e => e.IsCollection).HasColumnName("isCollection");

                entity.Property(e => e.IsPassword).HasColumnName("isPassword");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");
            });

            modelBuilder.Entity<SubRegion>(entity =>
            {
                entity.ToTable("subRegion");

                entity.HasIndex(e => new { e.RegionId, e.Name })
                    .HasName("IX_regionId_name")
                    .IsUnique();

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("nchar(64)");

                entity.Property(e => e.RegionId).HasColumnName("regionId");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.SubRegion)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_subRegion_region");
            });

            modelBuilder.Entity<SubTopic>(entity =>
            {
                entity.ToTable("subTopic");

                entity.HasIndex(e => new { e.DisciplineId, e.Name })
                    .HasName("IX_disciplineId_name")
                    .IsUnique();

                entity.Property(e => e.DisciplineId).HasColumnName("disciplineId");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

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
                entity.ToTable("userRoles");

                entity.HasIndex(e => new { e.UserId, e.RoleId })
                    .HasName("IX_userId_roleId")
                    .IsUnique();

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("roleId")
                    .HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
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
                    .HasName("IX_email");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("IX_userName");

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

                entity.Property(e => e.ScreenName)
                    .IsRequired()
                    .HasColumnName("screenName")
                    .HasMaxLength(256);

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