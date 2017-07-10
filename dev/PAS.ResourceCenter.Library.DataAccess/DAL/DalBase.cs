using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PAS.ResourceCenter.Library.DataAccess.Models;
using PAS.ResourceCenter.Library.DataAccess.Responses;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.DAL
{
    internal abstract class DalBase<T, TDto, TIDto>
    {
        internal abstract Func<TDto, TDto> DalCreate { get; }
        internal abstract Func<long, bool, TDto> DalGetLong { get; }
        internal abstract Func<string, bool, TDto> DalGetString { get; }
        internal abstract Func<Expression<Func<TIDto, bool>>, bool, List<TDto>> DalSelect { get; }        
        internal abstract Func<TDto, TDto> DalUpdate { get; }
        internal abstract Func<long, bool, TDto> DalDeleteLong { get; }
        internal abstract Func<string, bool, TDto> DalDeleteString { get; }
        
        internal Response<TDto> Create(TDto dto)
        {
            Response<TDto> result = new Response<TDto>();

            try
            {
                if (dto == null)
                    throw new ArgumentNullException($"{typeof(TDto).Name}");

                dto = DalCreate(dto);
                result = new Response<TDto>
                {
                    Message = $"Create succeed for {typeof(TDto).Name}"
                };

                result.Items.Add(dto);
            }
            catch (Exception ex)
            {
                result = new Response<TDto>(StatusCodes.EXCEPTION, ex)
                {
                    Message = $"Create failed for {typeof(TDto).Name}"
                };
            }

            return result;
        }
        
        internal Response<TDto> Get(long id, bool includeNavigation = false)
        {
            Response<TDto> result = new Response<TDto>();

            try
            {
                TDto dbResults = DalGetLong(id, includeNavigation);
                if (dbResults != null)
                    result.Items.Add(dbResults);

                result.Message = $"Get succeeded for {typeof(TDto).Name} id={id}";
            }
            catch (Exception ex)
            {
                result = new Response<TDto>(StatusCodes.EXCEPTION, ex)
                {
                    Message = $"Get failed for {typeof(TDto).Name} id={id}"
                };
            }

            return result;
        }

        internal Response<TDto> Get(string id, bool includeNavigation = false)
        {
            Response<TDto> result = new Response<TDto>();

            try
            {
                TDto dbResults = DalGetString(id, includeNavigation);
                if (dbResults != null)
                    result.Items.Add(dbResults);

                result.Message = $"Get succeeded for {typeof(TDto).Name} id={id}";
            }
            catch (Exception ex)
            {
                result = new Response<TDto>(StatusCodes.EXCEPTION, ex)
                {
                    Message = $"Get failed for {typeof(TDto).Name} id={id}"
                };
            }

            return result;
        }

        internal Response<TDto> Select(Expression<Func<TIDto, bool>> whereClause = null, bool includeNavigation = false)
        {
            Response<TDto> result = new Response<TDto>();

            try
            {
                List<TDto> dbResults = DalSelect(whereClause, includeNavigation);
                if (dbResults != null)
                    result.Items.AddRange(dbResults);

                result.Message = $"Select succeeded for {typeof(TDto).Name}";
                if (whereClause != null)
                    result.Message += $" for where clause = {whereClause.ToString()}";
            }
            catch (Exception ex)
            {
                result = new Response<TDto>(StatusCodes.EXCEPTION, ex)
                {
                    Message = $"Select failed for {typeof(TDto).Name}"
                };
                if (whereClause != null)
                    result.Message += $" for where clause = {whereClause.ToString()}";
            }

            return result;
        }

        internal Response<TDto> Update(TDto dto)
        {
            Response<TDto> result = new Response<TDto>();

            try
            {
                if (dto == null)
                    throw new ArgumentNullException($"{typeof(TDto).Name}");

                dto = DalUpdate(dto);
                result = new Response<TDto>
                {
                    Message = $"Update succeed for {typeof(TDto).Name}"
                };
                result.Items.Add(dto);
            }
            catch (Exception ex)
            {
                result = new Response<TDto>(StatusCodes.EXCEPTION, ex)
                {
                    Message = $"Update failed for {typeof(TDto).Name}"
                };
            }

            return result;
        }

        internal Response<TDto> Delete(long id, bool cascade = false)
        {
            Response<TDto> result = new Response<TDto>();

            try
            {
                DalDeleteLong(id, cascade);

                result = new Response<TDto>
                {
                    Message = $"Delete succeeded for {typeof(TDto).Name} id={id}"
                };
            }
            catch (Exception ex)
            {
                result = new Response<TDto>(StatusCodes.EXCEPTION, ex)
                {
                    Message = $"Delete failed for {typeof(TDto).Name} id={id}"
                };
            }

            return result;
        }

        internal Response<TDto> Delete(string id, bool cascade = false)
        {
            Response<TDto> result = new Response<TDto>();

            try
            {
                DalDeleteString(id, cascade);

                result = new Response<TDto>
                {
                    Message = $"Delete succeeded for {typeof(TDto).Name} id={id}"
                };
            }
            catch (Exception ex)
            {
                result = new Response<TDto>(StatusCodes.EXCEPTION, ex)
                {
                    Message = $"Delete failed for {typeof(TDto).Name} id={id}"
                };
            }

            return result;
        }
    }
}