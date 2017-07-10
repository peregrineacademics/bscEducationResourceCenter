using Microsoft.Build.Evaluation;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EFCodeGenerator
{
    public class CodeGenerator
    {
        private static IOrderedEnumerable<NameAndType> _properties;
        private static IOrderedEnumerable<NameAndType> _navigationProperties;
        private static IOrderedEnumerable<NameAndType> _deleteNavigationProperties;
        private static Type _type;
        private string _projectFile;
        private string _templatePath;
        private string _tableName;
        private string _dbNameSpace;
        private string _contextName;
        private string _path;

        public CodeGenerator(string projectFileName, string dbNameSp, string table, Type objectType, string contextName)
        {
            _path = Path.GetDirectoryName(projectFileName);

            Assembly assembly = Assembly.GetExecutingAssembly();
            _projectFile = projectFileName;
            _tableName = table;
            _templatePath = Path.GetDirectoryName(assembly.Location);
            _type = objectType;
            _properties = Common.GetProperties(_type);
            _navigationProperties = Common.GetNavigationProperties(_type);
            _deleteNavigationProperties = Common.GetDeleteNavigationProperties(_type);
            _dbNameSpace = dbNameSp;
            _contextName = contextName;
        }

        public void CreateFiles()
        {
            CopyDalBase();
            CopyResponseFiles();
            CopyTransactionFile();
            CreateDtoFile();
            CreateDalGeneratedFile();
            CreateGeneratedExtendedModelFile();
            CreateInterfaceFile();
            CreateCustomTemplates();
        }

        private void CreateCustomTemplates()
        {
            // copies the template files to project. Includes the file in the project and sets it to not compile.

            string pathOld = Path.Combine(_templatePath, "Templates\\DAL.Custom", "ObjectDal.Custom.cs");
            string pathNew = Path.Combine(_path, "DAL.Custom", "ObjectDal.Custom.cs");
            string readText = File.ReadAllText(pathOld);
            SaveFileAndUpdateProject(_projectFile, _path, pathNew, readText, false, true);

            pathOld = Path.Combine(_templatePath, "Templates\\DTO.Custom", "ObjectDto.Custom.cs");
            pathNew = Path.Combine(_path, "DTO.Custom", "ObjectDto.Custom.cs");
            readText = File.ReadAllText(pathOld);
            SaveFileAndUpdateProject(_projectFile, _path, pathNew, readText, false, true);

            pathOld = Path.Combine(_templatePath, "Templates\\Model.Custom", "ObjectModel.Custom.cs");
            pathNew = Path.Combine(_path, "Models.Custom", "ObjectModel.Custom.cs");
            readText = File.ReadAllText(pathOld);
            SaveFileAndUpdateProject(_projectFile, _path, pathNew, readText, false, true);
        }

        private void CopyTransactionFile()
        {
            string pathOld = Path.Combine(_templatePath, "Templates\\Models.Generated", "Transaction.Generated.cs");
            string pathNew = Path.Combine(_path, "Models.Generated", "Transaction.Generated.cs");

            var newObjectText = ReplaceObjectAndNamespace(pathOld);
            newObjectText = newObjectText.Replace("/* insert contextName */", _contextName);

            SaveFileAndUpdateProject(_projectFile, _path, pathNew, newObjectText);
        }

        private void CopyDalBase()
        {
            string pathOld = Path.Combine(_templatePath, "Templates\\Dal", "DalBase.cs");
            string pathNew = Path.Combine(_path, "DAL","DalBase.cs");

            var newObjectText = ReplaceObjectAndNamespace(pathOld);

            SaveFileAndUpdateProject(_projectFile, _path, pathNew, newObjectText);
        }

        private void CopyResponseFiles()
        {
            string pathOld = Path.Combine(_templatePath, "Templates\\Responses.Generated", "Response.cs");
            string pathNew = Path.Combine(_path, "Responses", "Response.cs");

            var newObjectText = ReplaceObjectAndNamespace(pathOld);
            SaveFileAndUpdateProject(_projectFile, _path, pathNew, newObjectText);

            pathOld = Path.Combine(_templatePath, "Templates\\Responses.Generated", "StatusCodes.cs");
            pathNew = Path.Combine(_path, "Responses", "StatusCodes.cs");
            newObjectText = ReplaceObjectAndNamespace(pathOld);
            SaveFileAndUpdateProject(_projectFile, _path, pathNew, newObjectText);
        }

        private void CreateInterfaceFile()
        {
            string pathOld = Path.Combine(_templatePath, "Templates\\Interfaces", "IObject.cs");
            string pathNew = Path.Combine(_path, "Interfaces", "I" + _tableName + ".cs");
            var insertString = CreateAssignOrDto(_type, false);

            var newObjectText = ReplaceObjectAndNamespace(pathOld);

            newObjectText = newObjectText.Replace("/* insert here */", insertString);

            SaveFileAndUpdateProject(_projectFile, _path, pathNew, newObjectText);
        }

        private void CreateDtoFile()
        {  
            string pathOld = Path.Combine(_templatePath, "Templates\\Dto", "ObjectDto.cs");
            string pathNew = Path.Combine(_path, "DTO", _tableName + "Dto.cs");
            var insertString = CreateAssignOrDto(_type, true);

            var newObjectText = ReplaceObjectAndNamespace(pathOld);

            newObjectText = newObjectText.Replace("/* insert here */", insertString);

            var getProperties = Common.GetProperties(_type);
            insertString = "";
            if (getProperties.Any())
            {
                foreach (var p in getProperties)
                {
                    // some id fields are guid strings and not longs
                    // some id fields are guid strings and not longs
                    if (p.Name.ToLower() == "id")
                    {
                        newObjectText = newObjectText.Replace("/* insert IdType */", p.Type.ToLower() + " id");
                        newObjectText = newObjectText.Replace("/* insert IdType */", p.Type.ToLower() + " id");
                    }
                    // created by and lastUpdated by field
                    if (p.Name.ToLower().Contains("byuserid"))
                    {
                        insertString += $"\t\t\t{p.Name} = byUserId;{Environment.NewLine}";
                    }

                    else if (p.Type.ToLower() == "Byte[]".ToLower())
                        insertString += $"\t\t\t{p.Name} = new Byte[0];{Environment.NewLine}";
                    else if (p.Type.ToLower().Contains("int") || p.Type.ToLower().Contains("long"))
                    {
                        insertString += $"\t\t\t{p.Name} = 0;{Environment.NewLine}";
                    }
                    else if (p.Type.ToLower().Contains("string"))
                    {
                        insertString += $"\t\t\t{p.Name} = \"\";{Environment.NewLine}";
                    }
                    else if (p.Type.ToLower().Contains("null"))
                    {
                        insertString += $"\t\t\t{p.Name} = null;{Environment.NewLine}";
                    }
                    else if (p.Type.ToLower().Contains("date"))
                    {
                        if (p.Name.ToLower().Contains("created") || p.Name.ToLower().Contains("updated"))
                        {
                            insertString += $"\t\t\t{p.Name} = DateTime.Now;{Environment.NewLine}";
                        }
                        else
                        {
                            insertString += $"\t\t\t//\tWe are creating our own default Min Date. {Environment.NewLine}" +
                                            $"\t\t\t//\tIt is here because the min date of C# and SQL Server/MySql are different which sometimes causing problems.{Environment.NewLine}" +
                                            $"\t\t\t//\tThe is no guarantee the value is defaulted in the dab to something universal. {Environment.NewLine}" +
                                            $"\t\t\t//\tIt is pretty lame but it is a workaround for an even lamer limitation in C#/Sql Server {Environment.NewLine}" +
                                            $"\t\t\t{p.Name} = new DateTime(1900,1,1);{Environment.NewLine}";
                        }
                    }
                }
            }
            newObjectText = newObjectText.Replace("/* insert Init */", insertString);

            SaveFileAndUpdateProject(_projectFile, _path, pathNew, newObjectText);
        }

        private void CreateDalGeneratedFile()
        {
            string pathOld = Path.Combine(_templatePath, "Templates\\Dal", "Object.cs");
            string pathNew = Path.Combine(_path, "DAL", _tableName + ".cs");

            var newObjectText = ReplaceObjectAndNamespace(pathOld);

            SaveFileAndUpdateProject(_projectFile, _path, pathNew, newObjectText);
        }

        private void CreateGeneratedExtendedModelFile()
        {
            string pathOld = Path.Combine(_templatePath, "Templates\\Models.Generated", "Object.Generated.cs");
            string pathNew = Path.Combine(_path, "Models.Generated", _tableName + ".Generated.cs");

            string insertString = string.Empty;

            var newObjectText = ReplaceObjectAndNamespace(pathOld);
            string primaryKey = Common.GetPrimaryKey(_type);

            newObjectText = newObjectText.Replace("/* Primary Key */", primaryKey);


            var getProperties = Common.GetProperties(_type);

            if (getProperties.Any())
            {
                foreach (var p in getProperties)
                {
                    // some id fields are guid strings and not longs
                    if (p.Name.ToLower() == "id")
                    {
                        newObjectText = newObjectText.Replace("/* insert IdType */", p.Type.ToLower() + " id");
                    }

                    if (p.Type.ToLower() == "Byte[]".ToLower())
                        insertString += $"\t\t\tdestination.{p.Name} = source.{p.Name}.ToArray();{Environment.NewLine}";
                    else
                    {
                        insertString += $"\t\t\tdestination.{p.Name} = source.{p.Name};{Environment.NewLine}";
                    }
                }
            }
            newObjectText = newObjectText.Replace("/* insert assignProperties */", insertString);

            // Do the navigation properties
            insertString = string.Empty;
            if (_navigationProperties.Any())
            {
                insertString = _navigationProperties.Aggregate(insertString,
                    (current, p) => current + $"\t\t\t\tdestination.{p.Name} = source.{p.Name};{Environment.NewLine}");

                newObjectText =
                    newObjectText.Replace(
                        "/* insert assignNavigation */",
                        Environment.NewLine + "\t\t\tif (includeNavigation)" + Environment.NewLine + "\t\t\t{" + Environment.NewLine + insertString + "\t\t\t}");

                insertString = string.Empty;
                insertString = _navigationProperties.Aggregate(insertString,
                    (current, d) => current + $"{Environment.NewLine}\t\t\t\t\t\t\t\t.Include(n=>n.{d.Name})");

                newObjectText = newObjectText.Replace("/* insert navigationIncludes */", insertString);
            }
            else
            {
                newObjectText = newObjectText.Replace("/* insert assignNavigation */", string.Empty);
                newObjectText = newObjectText.Replace("/* insert navigationIncludes */", string.Empty);
            }

            // Do the navigation properties
            insertString = string.Empty;
            if (_deleteNavigationProperties.Any())
            {
                insertString = _deleteNavigationProperties.Aggregate(insertString,
                    (current, d) => current + $"{Environment.NewLine}\t\t\t\t\t\t\t\t\t.Include(n=>n.{d.Name})");

                newObjectText = newObjectText.Replace("/* insert deleteNavigationIncludes */", insertString);

                insertString = string.Empty;
                foreach (var n in _deleteNavigationProperties)
                {
                    insertString += $"{Environment.NewLine}\t\t\t\t\t\tif (dbItem.{n.Name}";
                    insertString += n.Type.Contains(nameof(ICollection)) ? ".Count > 0)" : " != null)";

                    if (n.Type.Contains(nameof(ICollection)))
                        insertString += $"{Environment.NewLine}\t\t\t\t\t\t\tcontext.{n.DalGetType}.RemoveRange(dbItem.{n.Name});";
                    else
                        insertString += $"{Environment.NewLine}\t\t\t\t\t\t\tcontext.{n.Type.ToString()}.RemoveRange(dbItem.{n.Name});";
                }

                insertString += $"{Environment.NewLine}";
            }
            else
            {
                newObjectText = newObjectText.Replace("/* insert deleteNavigationIncludes */", string.Empty);
            }

            newObjectText = newObjectText.Replace("/* insert NavDeletes */", insertString);

            SaveFileAndUpdateProject(_projectFile, _path, pathNew, newObjectText);
        }

        private string ReplaceObjectAndNamespace(string pathOld)
        {
            string readText = File.ReadAllText(pathOld);
            string newObjectText = readText;
            if (IsIdLong())
            {
                newObjectText = newObjectText.Replace("DalGetString => Models.Object.Get;", "DalGetString => null;");
                newObjectText = newObjectText.Replace("DalDeleteString => Models.Object.Delete;", "DalDeleteString => null;");
                newObjectText = newObjectText.Replace("/* insert IdType */", "long");
            }
            else
            {
                newObjectText = newObjectText.Replace("DalGetLong => Models.Object.Get;", "DalGetLong => null;");
                newObjectText = newObjectText.Replace("DalDeleteLong => Models.Object.Delete;", "DalDeleteLong => null;");
                newObjectText = newObjectText.Replace("/* insert IdType */", "string");
            }
            newObjectText = newObjectText.Replace("Object", _tableName);
            newObjectText = newObjectText.Replace("dbNameSpace", _dbNameSpace);
            var topLevel = _dbNameSpace.Split('.')[0];
            newObjectText = newObjectText.Replace("topLevelNameSpace", topLevel);
            newObjectText = newObjectText.Replace("/* insert contextName */", _contextName);
            if (_navigationProperties.Any())
                newObjectText = newObjectText.Replace("/* Insert Collections */", "using System.Collections.Generic;");

            return newObjectText;
        }

        private bool IsIdLong()
        {
            if (_properties.Any())
            {
                foreach (var p in _properties)
                {
                    // some id fields are guid strings and not longs
                    if (p.Name.ToLower() == "id")
                    {
                        return !p.Type.ToLower().Contains("string");
                    }
                }
            }
            return true;
        }

        private string CreateAssignOrDto(Type type, bool isDto)
        {
            string insertString = string.Empty;

            // Open the file to read from.
            var getProperties = Common.GetProperties(type);
            if (getProperties.Any())
            {
                foreach (var p in getProperties)
                {
                    insertString += "\t\t";
                    if (isDto)
                        insertString += "public ";

                    if (p.Type.ToLower().Contains("null"))
                    {
                        // nullable field let s check for the basic types datetime, String, long, int
                        if (p.ClrTypeName.ToLower().Contains("datetimeoffset"))
                        {
                            insertString += "DateTimeOffset? " + p.Name + "{ get; set; }" + Environment.NewLine;
                        }
                        else if (p.ClrTypeName.ToLower().Contains("date"))
                        {
                            insertString += "DateTime? " + p.Name + "{ get; set; }" + Environment.NewLine;
                        }
                        else if (p.ClrTypeName.ToLower().Contains("string"))
                        {
                            insertString += "string? " + p.Name + "{ get; set; }" + Environment.NewLine;
                        }
                        else if (p.ClrTypeName.ToLower().Contains("int16"))
                        {
                            insertString += "short? " + p.Name + "{ get; set; }" + Environment.NewLine;
                        }
                        else if (p.ClrTypeName.ToLower().Contains("int64"))
                        {
                            insertString += "long? " + p.Name + "{ get; set; }" + Environment.NewLine;
                        }
                        else if (p.ClrTypeName.ToLower().Contains("int"))
                        {
                            insertString += "int? " + p.Name + "{ get; set; }" + Environment.NewLine;
                        }
                        else if (p.ClrTypeName.ToLower().Contains("sbyte"))
                        {
                            insertString += "sbyte? " + p.Name + "{ get; set; }" + Environment.NewLine;
                        }
                        else if (p.ClrTypeName.ToLower().Contains("bool"))
                        {
                            insertString += "bool? " + p.Name + "{ get; set; }" + Environment.NewLine;
                        }
                        else if (p.ClrTypeName.ToLower().Contains("short"))
                        {
                            insertString += "short? " + p.Name + "{ get; set; }" + Environment.NewLine;
                        }
                        else // flag it so the build fails and the user can fix it.
                        {
                            insertString += "SomeNullableField? " + p.Name + "{ get; set; }" + Environment.NewLine;
                        }

                    }
                    else
                    {
                        // ambiguous names and types is addressed here.
                        if (p.Type == p.Name)
                            insertString += p.Type + " " + p.Name + "Prop { get; set; }" + Environment.NewLine;
                        else insertString += p.Type + " " + p.Name + "{ get; set; }" + Environment.NewLine;
                    }
                }
            }

            if (_navigationProperties.Any())
            {
                insertString += Environment.NewLine;

                foreach (var p in _navigationProperties)
                {
                    insertString += "\t\t";
                    if (isDto)
                    {
                        insertString += "public ";
                    }
                    if (p.Type.Contains(nameof(ICollection)))
                        insertString += $"ICollection<{p.DalGetType}> {p.Name}";
                    else
                    {
                        // prepend the namespace Models to avoid ambiguity from classes
                        // with the same name from other namespaces
                        insertString += "Models." + p.Type + " " + p.Name ;
                    }

                    insertString += " { get; set; }" + Environment.NewLine;
                }
            }
            return insertString;
        }
        
        private void SaveFileAndUpdateProject(string projectFile, string path, string pathNew, string newObjectText, bool overwrite = true, bool doNotCompile = false)
        {
            FileInfo file = new FileInfo(pathNew);
            file.Directory?.Create(); // If the directory already exists, this method does nothing.

            if (overwrite || !file.Exists) 
                File.WriteAllText(file.FullName, newObjectText, Encoding.UTF8);

            AddFileToSolution(projectFile, path, pathNew, doNotCompile);
        }
        private void AddFileToSolution(string projectFile, string folderPath, string filePath, bool doNotCompile = false)
        {
            try
            {
                string buildAction = "Compile";
                if (doNotCompile) buildAction = "None";
                string queryPath = filePath.Replace(folderPath + "\\", string.Empty);

                var project = new Project(projectFile);

                bool found = false;

                foreach (var item in project.Items)
                {
                    if (item.ItemType == buildAction && item.EvaluatedInclude == queryPath)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    project.AddItem(buildAction, queryPath);
                    project.Save();
                }

                ProjectCollection.GlobalProjectCollection.UnloadProject(project);
            }
            catch
            {
                // Ignore adding files
            }
        }
    }
}