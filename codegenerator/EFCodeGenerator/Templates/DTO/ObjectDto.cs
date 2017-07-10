using System;
using System.Linq.Expressions;
using dbNameSpace.Interfaces;
using dbNameSpace.Models;
using dbNameSpace.Responses;
/* Insert Collections */

// This file is generated. DO NOT MODIFY
namespace dbNameSpace.DTO
{
    public partial class ObjectDto : IObject
    {
        public ObjectDto(string byUserId = "")
        {
/* insert Init */
        }

        public ObjectDto(IObject item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

/* insert here */

        internal void Assign(IObject item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Object.Assign(item, this, includeNavigation);
        }

        public static Response<ObjectDto> Create(ObjectDto item)
        {
            if (item == null)
            {
                return new Response<ObjectDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Object().Create(item);
        }

        public static Response<ObjectDto> Get(/* insert IdType */ id, bool includeNavigation = false)
        {
            return new DAL.Object().Get(id, includeNavigation);
        }

        public static Response<ObjectDto> Select(Expression<Func<IObject, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.Object().Select(whereClause, includeNavigation);
        }

        public static Response<ObjectDto> Update(ObjectDto item)
        {
            if (item == null)
            {
                return new Response<ObjectDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Object().Update(item);
        }

        public Response<ObjectDto> Update()
        {
            return new DAL.Object().Update(this);
        }

        public static Response<ObjectDto> Delete(/* insert IdType */ id, bool cascade = false)
        {
            return new DAL.Object().Delete(id, cascade);
        }
    }
}