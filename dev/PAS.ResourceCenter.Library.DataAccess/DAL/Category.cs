using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.DTO;
using PAS.ResourceCenter.Library.DataAccess.Interfaces;
using PAS.ResourceCenter.Library.DataAccess.Models;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal class Category : DalBase<Category, CategoryDto, ICategory>
    {
        internal override Func<CategoryDto, CategoryDto> DalCreate => Models.Category.Create;
        internal override Func<long, bool, CategoryDto> DalGetLong => Models.Category.Get;
        internal override Func<string, bool, CategoryDto> DalGetString => null;
        internal override Func<Expression<Func<ICategory, bool>>, bool, List<CategoryDto>> DalSelect => Models.Category.Select;
        internal override Func<CategoryDto, CategoryDto> DalUpdate => Models.Category.Update;
        internal override Func<long, bool, CategoryDto> DalDeleteLong => Models.Category.Delete;
        internal override Func<string, bool, CategoryDto> DalDeleteString => null;
    }
}
