using PAS.ResourceCenter.Library.DataAccess.Models;// Note: Add using statement here for the DAL dll (using PAS.ResourceCenter.Library.DataAccess.Models;) 
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace EFCodeGenerator
{
    public static class Common
    {
        public static string _defaultNamespace = string.Empty;
        public static string _modelsNamespace = string.Empty;
        public static string _contextClassFullName = string.Empty;
        public static string _contextClassName = string.Empty;

        public static ercContext GetDBContext()
        {
            return new ercContext();
        }

        public static void InitializeNamespaceAndClass()
        {
            // Note: Please replace the DbContext keyword with the context name of the DAL dll being generated (i.e. ercContext) 
            Type type = typeof(ercContext);
            if (type != null)
            {
                _defaultNamespace = type.Module.Name.Replace(".dll", string.Empty);
                _modelsNamespace = type.Namespace;
                _contextClassFullName = type.FullName;
                _contextClassName = type.Name;
            }
        }

        public static string GetPrimaryKey(Type type)
        {
            using (var context = GetDBContext())
            {
                var keyName = context.Model.FindEntityType(type).FindPrimaryKey().Properties
                    .Select(x => x.Name).FirstOrDefault();
                return keyName;
            }
        }

        public static IOrderedEnumerable<NameAndType> GetProperties(Type type)
        {
            IOrderedEnumerable<NameAndType> ret = null;

            // Note: Please replace the DbContext keyword with the context name of the DAL dll being generated (i.e. bscContext) 
            using (var context = GetDBContext())
            {
                var getProperties = context.Model.FindEntityType(type)
                    .GetProperties()
                    .Select(x => new NameAndType()
                    {
                        Name = x.Name,
                        Type = x.FieldInfo.FieldType.Name,
                        ClrTypeName = x.ClrType.FullName,
                        DalGetType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(x.FieldInfo.FieldType.Name.ToLower())
                    })
                    .OrderBy(r => r.Name);

                ret = getProperties;
            }

            return ret;
        }

        public static IOrderedEnumerable<NameAndType> GetNavigationProperties(Type type)
        {
            IOrderedEnumerable<NameAndType> ret = null;

            // Note: Please replace the DbContext keyword with the context name of the DAL dll being generated (i.e. bscContext) 
            using (var context = GetDBContext())
            {
                var columntypes = context.Model.FindEntityType(type)
                    .GetNavigations()
                    .Select(x => new NameAndType()
                        {
                            Name = x.Name,
                            Type = x.ClrType.Name,
                            DalGetType = x.ClrType.GenericTypeArguments.Count() == 0 ? x.Name : x.ClrType.GenericTypeArguments[0].Name
                        }
                    )
                    .OrderBy(r => r.Name);

                ret = columntypes;
            }

            return ret;
        }

        public static IOrderedEnumerable<NameAndType> GetDeleteNavigationProperties(Type type)
        {
            IOrderedEnumerable<NameAndType> ret = null;

            // Note: Please replace the DbContext keyword with the context name of the DAL dll being generated (i.e. bscContext) 
            using (var context = GetDBContext())
            {
                var columntypes = context.Model.FindEntityType(type)
                    .GetNavigations()
                    .Where(x => x.IsDependentToPrincipal() == false)
                    .Select(x => new NameAndType()
                        {
                            Name = x.Name,
                            Type = x.ClrType.Name,
                            DalGetType = x.ClrType.GenericTypeArguments.Count() == 0 ? x.Name : x.ClrType.GenericTypeArguments[0].Name
                        }
                    )
                    .OrderBy(r => r.Name);

                ret = columntypes;
            }

            return ret;
        }
    }
}
