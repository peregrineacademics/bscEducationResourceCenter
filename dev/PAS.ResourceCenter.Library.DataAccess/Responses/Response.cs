using System;
using System.Collections.Generic;
using System.Linq;

// This file is generated. DO NOT MODIFY
namespace PAS.ResourceCenter.Library.DataAccess.Responses
{
    public class Response<T>
    {
        public Response() : this(Responses.StatusCodes.OK, null, string.Empty)
        {
        }

        public Response(Responses.StatusCodes status) : this(status, null, string.Empty)
        {
        }

        public Response(Responses.StatusCodes status, string message = "") : this(status,null,message)
        {           
        }

        public Response(Responses.StatusCodes status, Exception ex = null, string message = "")
        {
            Status = status;
            Message = message;
            Items = new List<T>();
            Ex = ex;
        }

        public List<T> Items { get;}
        public string Message { get; set; }
        public Responses.StatusCodes Status { get; set; }
        public Exception Ex { get; }

        public T First()
        {
            return Items.FirstOrDefault();
        }
    }
}