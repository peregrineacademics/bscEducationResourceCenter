using System;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;
using System.Collections.Generic;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DTO
{
    public partial class CategoryDto : ICategory
    {
        public CategoryDto(string byUserId = "")
        {
			GroupId = 0;
			Id = 0;
			Name = "";
			ParentId = 0;

        }

        public CategoryDto(ICategory item, bool includeNavigation = false)
        {
            if (item != null)
                Assign(item, includeNavigation);
        }

		public Int64 GroupId{ get; set; }
		public Int64 Id{ get; set; }
		public Boolean IsEnabled{ get; set; }
		public String Name{ get; set; }
		public Int64 ParentId{ get; set; }

		public ICollection<ReviewCategory> ReviewCategory { get; set; }
		public ICollection<ReviewerCategory> ReviewerCategory { get; set; }


        internal void Assign(ICategory item, bool includeNavigation = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Category.Assign(item, this, includeNavigation);
        }

        public static Response<CategoryDto> Create(CategoryDto item)
        {
            if (item == null)
            {
                return new Response<CategoryDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Category().Create(item);
        }

        public static Response<CategoryDto> Get(long id, bool includeNavigation = false)
        {
            return new DAL.Category().Get(id, includeNavigation);
        }

        public static Response<CategoryDto> Select(Expression<Func<ICategory, bool>> whereClause = null, bool includeNavigation = false)
        {
            return new DAL.Category().Select(whereClause, includeNavigation);
        }

        public static Response<CategoryDto> Update(CategoryDto item)
        {
            if (item == null)
            {
                return new Response<CategoryDto>(StatusCodes.EXCEPTION);
            }

            return new DAL.Category().Update(item);
        }

        public Response<CategoryDto> Update()
        {
            return new DAL.Category().Update(this);
        }

        public static Response<CategoryDto> Delete(long id, bool cascade = false)
        {
            return new DAL.Category().Delete(id, cascade);
        }
    }
}