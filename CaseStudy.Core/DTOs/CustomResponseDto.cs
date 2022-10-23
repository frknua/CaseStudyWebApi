using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CaseStudy.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }


        public List<String> Errors { get; set; }


        public static CustomResponseDto<T> Success(HttpStatusCode statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Success(HttpStatusCode statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(HttpStatusCode statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDto<T> Fail(HttpStatusCode statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
