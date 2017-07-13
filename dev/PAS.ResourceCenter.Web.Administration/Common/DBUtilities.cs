using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using PAS.ResourceCenter.Web.Administration.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAS.ResourceCenter.Web.Administration.Common
{
    public static class DBUtilities
    {
        public static string GetUserIdByUserName(string userName)
        {
            string ret = string.Empty;

            var result = UsersDto.Select(x => x.UserName.Equals(userName));
            if (result.Status == StatusCodes.OK)
            {
                if (result.Items.Count > 0)
                    ret = result.First().Id;
            }
            else
            {
                throw (result.Ex);
            }

            return ret;

        }

        public static string GetUsersFullName(string userName)
        {
            string ret = string.Empty;

            var result = UsersDto.Select(x => x.UserName.Equals(userName));
            if (result.Status == StatusCodes.OK)
            {
                if (result.Items.Count > 0)
                {
                    var user = result.First();

                    ret = (user.FirstName + " " + user.LastName).Trim();
                }
            }
            else
            {
                throw (result.Ex);
            }

            return ret;
        }

        public static string GetUsersFullNameById(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return string.Empty;
            }

            string ret = string.Empty;

            var result = UsersDto.Get(userId);
            if (result.Status == StatusCodes.OK)
            {
                if (result.Items.Count > 0)
                {
                    var user = result.First();

                    ret = (user.LastName + ", " + user.FirstName).Trim();
                }
            }
            else
            {
                throw (result.Ex);
            }

            return ret;
        }

        public static bool CheckIfEmailExists(string email, string userId)
        {
            bool ret = false;

            var result = UsersDto.Select(x => x.UserName.Equals(email));
            if (result.Status == StatusCodes.OK)
            {
                if (result.Items.Count > 0)
                {
                    if (result.First().Id != userId)
                        ret = true;
                }
            }
            else
            {
                throw (result.Ex);
            }

            return ret;
        }

        public static string GetSiteSettings(string name)
        {
            string ret = string.Empty;

            var result = SiteSettingDto.Select(x => x.Name.Equals(name));
            if (result.Status == StatusCodes.OK)
            {
                if (result.Items.Count > 0)
                    ret = result.First().Value;
            }
            else
            {
                throw (result.Ex);
            }

            return ret;
        }

        public static string GetReviewTitleById(long reviewId)
        {
            string ret = string.Empty;

            var result = ReviewDto.Get(reviewId);
            if (result.Status == StatusCodes.OK)
            {
                if (result.Items.Count > 0)
                {
                    var review = result.First();

                    ret = review.Title.Trim();
                }
            }
            else
            {
                throw (result.Ex);
            }

            return ret;
        }

        public static string GetIssueDateStringById(long issueId)
        {
            string ret = string.Empty;

            var result = IssueDto.Get(issueId);
            if (result.Status == StatusCodes.OK)
            {
                if (result.Items.Count > 0)
                {
                    var review = result.First();

                    ret = "Issue " + review.IssueDate.ToString(Constants._formatDate4);
                }
            }
            else
            {
                throw (result.Ex);
            }

            return ret;
        }

        public static List<LogViewModel> GetLogsPerUser(string userId)
        {
            List<LogViewModel> ret = new List<LogViewModel>();

            var result = LogDto.Select(x => x.LinkUserId.Equals(userId) &&
                x.LogTypeId.Equals(Library.Common.Definitions.LogType.User));
            if (result.Status == StatusCodes.OK)
            {
                if (result.Items.Count > 0)
                {
                    foreach (var item in result.Items.OrderBy(x => x.DateCreated))
                    {
                        LogViewModel model = new LogViewModel();
                        model.CreatedByUserId = item.CreatedByUserId;
                        model.Message = item.Message;
                        model.CreatedOn = item.DateCreated;
                        ret.Add(model);
                    }
                }
            }
            else
            {
                throw (result.Ex);
            }

            return ret;
        }

        public static string GetRoleIdByName(string name)
        {
            string ret = string.Empty;

            var result = RolesDto.Select(x => x.Name.Equals(name));
            if (result.Status == StatusCodes.OK)
            {
                if (result.Items.Count > 0)
                    ret = result.First().Id;
            }
            else
            {
                throw (result.Ex);
            }

            return ret;
        }

        public static int GetReviewsCountByUserId(string userId)
        {
            int ret = 0;

            var result = ReviewDto.Select(x => x.ReviewerId.Equals(userId));
            if (result.Status == StatusCodes.OK)
            {
                ret = result.Items.Count;
            }
            else
            {
                throw (result.Ex);
            }

            return ret;
        }
    }
}
