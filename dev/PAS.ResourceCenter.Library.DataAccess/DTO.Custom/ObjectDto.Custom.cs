using System;
using System.Collections.Generic;
using dbNameSpace.Interfaces;
using dbNameSpace.Models;
using dbNameSpace.Responses;

namespace dbNameSpace.DTO
{
    /* INSTRUCTIONS

     1. Make a copy of this file and name is with your class nameDto.Custom.cs
     2. Include the file in the project.
     3. Find an replace the word "Object" in this file to the class you are implementing.
     4. This template file is added to the project as a noncompliing file
     5. Right click the file and select properties. Change the build action property from None to Compile

   */

    public partial class ObjectDto : IObject
    {
        // Custom DTO methods go in here. They are usally a wrapper call into the DAL.
        // you can put the code that has the actual db calls in Models.Custom folder.
        // There is another template there and in DAL.Custom
        // This file will not be overwritten if you regenerate a new DAL

        // Example
        public static Response<ObjectDto> Select()
        {
            // This doesnt have to call just a custom DAL class.
            return new DAL.Custom.Object().Select();
        }
    }
}