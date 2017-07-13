using Microsoft.AspNetCore.Mvc.Rendering;
using PAS.ResourceCenter.Web.Administration.Helpers;
using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Web.Administration.Common
{
    public static class MiscUtilities
    {
        public static List<SelectListItem> GetTrueFalse()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            listItems.Add(new SelectListItem() { Text = Constants._valueTrue, Value = Constants._valueTrue });
            listItems.Add(new SelectListItem() { Text = Constants._valueFalse, Value = Constants._valueFalse });

            return listItems;
        }

        public static List<SelectListItem> GetYesNo()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            listItems.Add(new SelectListItem() { Text = Constants._valueYes, Value = Constants._valueTrue });
            listItems.Add(new SelectListItem() { Text = Constants._valueNo, Value = Constants._valueFalse });

            return listItems;
        }

        public static T GetDBValue<T>(string key)
        {
            var value = Common.DBUtilities.GetSiteSettings(key);

            if (string.IsNullOrWhiteSpace(value))
            {
                return default(T);
            }

            if (typeof(T) == typeof(bool) && value.Is<int>())
            {
                return (T)Convert.ChangeType(value.As<int>(), typeof(T));
            }

            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static List<SelectListItem> GetRolesForUser(string roleName)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            if (roleName == Constants._rolePASAdministrator)
            {
                listItems.Add(new SelectListItem() { Text = Constants._valueRoleLearner, Value = Constants._valueRoleLearner });
                listItems.Add(new SelectListItem() { Text = Constants._valueRoleFaculty, Value = Constants._valueRoleFaculty });
                listItems.Add(new SelectListItem() { Text = Constants._valueRoleFacultyAdministrator, Value = Constants._valueRoleFacultyAdministrator });
                listItems.Add(new SelectListItem() { Text = Constants._valueRoleEditor, Value = Constants._valueRoleEditor });
                listItems.Add(new SelectListItem() { Text = Constants._valueRolePASReadOnly, Value = Constants._valueRolePASReadOnly });
                listItems.Add(new SelectListItem() { Text = Constants._valueRolePASAdministrator, Value = Constants._valueRolePASAdministrator });
            }
            else if (roleName == Constants._roleEditor)
            {
                listItems.Add(new SelectListItem() { Text = Constants._valueRoleLearner, Value = Constants._valueRoleLearner });
                listItems.Add(new SelectListItem() { Text = Constants._valueRoleFaculty, Value = Constants._valueRoleFaculty });
                listItems.Add(new SelectListItem() { Text = Constants._valueRoleFacultyAdministrator, Value = Constants._valueRoleFacultyAdministrator });
                listItems.Add(new SelectListItem() { Text = Constants._valueRoleEditor, Value = Constants._valueRoleEditor });
            }

            return listItems;
        }
    }
}
