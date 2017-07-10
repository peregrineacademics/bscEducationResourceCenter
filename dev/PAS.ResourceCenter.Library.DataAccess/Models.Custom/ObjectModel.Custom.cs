using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using dbNameSpace.DTO;
using dbNameSpace.Interfaces;

namespace dbNameSpace.Models
{
    /* INSTRUCTIONS

     1. Make a copy of this file and name is with your class name.Custom.cs
     2. Include the file in the project.
     3. Find an replace the word "Object" in this file to the class you are implementing.
     4. This template file is added to the project as a noncompliing file
     5. Right click the file an select properties. Change the build action property from None to compile

   */
    public partial class Object : IObject
    {
        internal static List<ObjectDto> Select()
        {
            var results = new List<ObjectDto>();

            using (var context = new DbContext())
            {
                var dbItems = context.Object;
                if (dbItems.Any())
                    dbItems.ToList()
                        .ForEach(o =>
                        {
                            var dto = new ObjectDto("Id will be filled in the Assign statement");
                            dto.Assign(o);
                            results.Add(dto);
                        });
            }
            return results;
        }
    }
}