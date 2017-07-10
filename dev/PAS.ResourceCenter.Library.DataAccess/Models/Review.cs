using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Review
    {
        public Review()
        {
            DiscussionQuestion = new HashSet<DiscussionQuestion>();
            QuizQuestion = new HashSet<QuizQuestion>();
            ReviewActivity = new HashSet<ReviewActivity>();
            ReviewCompetency = new HashSet<ReviewCompetency>();
            ReviewDiscipline = new HashSet<ReviewDiscipline>();
            ReviewEdgeGuide = new HashSet<ReviewEdgeGuide>();
            ReviewRegion = new HashSet<ReviewRegion>();
            ReviewSector = new HashSet<ReviewSector>();
            ReviewSubRegion = new HashSet<ReviewSubRegion>();
            ReviewSubTopic = new HashSet<ReviewSubTopic>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public long IssueId { get; set; }
        public long ReviewerId { get; set; }
        public string Abstract { get; set; }
        public string Summary { get; set; }
        public long GuideTypeId { get; set; }
        public long ReviewStatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime LastUpdated { get; set; }
        public string UpdatedByUserId { get; set; }
        public string KeyWords { get; set; }

        public virtual ICollection<DiscussionQuestion> DiscussionQuestion { get; set; }
        public virtual ICollection<QuizQuestion> QuizQuestion { get; set; }
        public virtual ICollection<ReviewActivity> ReviewActivity { get; set; }
        public virtual ICollection<ReviewCompetency> ReviewCompetency { get; set; }
        public virtual ICollection<ReviewDiscipline> ReviewDiscipline { get; set; }
        public virtual ICollection<ReviewEdgeGuide> ReviewEdgeGuide { get; set; }
        public virtual ICollection<ReviewRegion> ReviewRegion { get; set; }
        public virtual ICollection<ReviewSector> ReviewSector { get; set; }
        public virtual ICollection<ReviewSubRegion> ReviewSubRegion { get; set; }
        public virtual ICollection<ReviewSubTopic> ReviewSubTopic { get; set; }
        public virtual Users CreatedByUser { get; set; }
        public virtual GuideType GuideType { get; set; }
        public virtual Issue Issue { get; set; }
        public virtual ReviewStatus ReviewStatus { get; set; }
        public virtual Reviewer Reviewer { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}
