using System;
using System.Collections.Generic;

namespace FBS.Service.Common
{
    public class Response<T>
    {
        public Response(T model, string code, string[] messages)
        {
            Model = model;
            Code = code;
            Messages = (messages == null || messages.Length.Equals(0)) ? null : messages;
        }
        public Response(T model, string code, List<string> messages)
        {
            Model = model;
            Code = code;
            Messages = (messages == null || messages.Count.Equals(0)) ? null : messages.ToArray();
        }
        public Response(T model, string code)
        {
            Model = model;
            Code = code;
            Messages = null;
        }
        public T Model { get; set; }
        public string Code { get; set; }
        public string[] Messages { get; set; }
    }
}
