using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class Article
    {
        public Article()
        {
            ArticleActivity = new HashSet<ArticleActivity>();
            ArticleCompetency = new HashSet<ArticleCompetency>();
            ArticleDiscussionQuestion = new HashSet<ArticleDiscussionQuestion>();
            ArticleKeyLearningPoint = new HashSet<ArticleKeyLearningPoint>();
            ArticleQuizQuestion = new HashSet<ArticleQuizQuestion>();
            ArticleRegion = new HashSet<ArticleRegion>();
            ArticleSector = new HashSet<ArticleSector>();
            ArticleSubTopic = new HashSet<ArticleSubTopic>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public long IssueId { get; set; }
        public long ReviewerId { get; set; }
        public string Abstract { get; set; }
        public string Summary { get; set; }
        public long GuideTypeId { get; set; }
        public long ArticleStatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime LastUpdated { get; set; }
        public string UpdatedByUserId { get; set; }

        public virtual ICollection<ArticleActivity> ArticleActivity { get; set; }
        public virtual ICollection<ArticleCompetency> ArticleCompetency { get; set; }
        public virtual ICollection<ArticleDiscussionQuestion> ArticleDiscussionQuestion { get; set; }
        public virtual ICollection<ArticleKeyLearningPoint> ArticleKeyLearningPoint { get; set; }
        public virtual ICollection<ArticleQuizQuestion> ArticleQuizQuestion { get; set; }
        public virtual ICollection<ArticleRegion> ArticleRegion { get; set; }
        public virtual ICollection<ArticleSector> ArticleSector { get; set; }
        public virtual ICollection<ArticleSubTopic> ArticleSubTopic { get; set; }
        public virtual ArticleStatus ArticleStatus { get; set; }
        public virtual Users CreatedByUser { get; set; }
        public virtual GuideType GuideType { get; set; }
        public virtual Issue Issue { get; set; }
        public virtual Reviewer Reviewer { get; set; }
        public virtual Users UpdatedByUser { get; set; }
    }
}
