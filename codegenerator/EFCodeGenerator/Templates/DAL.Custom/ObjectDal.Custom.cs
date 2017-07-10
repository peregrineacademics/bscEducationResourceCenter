using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dbNameSpace.DTO;
using dbNameSpace.Interfaces;
using dbNameSpace.Responses;

namespace dbNameSpace.DAL.Custom
{
    /* INSTRUCTIONS

     1. Make a copy of this file and name it with your class nameDto.Custom.cs
     2. Include the file in the project.
     3. Find an replace the word "Object" in this file to the class you are implementing.
     4. This template file is added to the project as a noncompliing file
     5. Right click the file and select properties. Change the build action property from None to Compile

   */
    internal class Object // : DalBase<Object, ObjectDto>  use the DAL base if you are going to implement the needed methods.
    {
        // DalBase methods go here if you use them.

        // Custom methods go here.
        internal Response<ObjectDto> Select()
        {
            Response<ObjectDto> result;
            try
            {
                List<ObjectDto> dbResults = Models.Custom.Select();
                result = new Response<ObjectDto>();
                if (dbResults != null)
                    result.Items.AddRange(dbResults);
            }
            catch (Exception ex)
            {
                result = new Response<ObjectDto>(StatusCodes.EXCEPTION, ex);
            }
            return result;
        }
    }
}
