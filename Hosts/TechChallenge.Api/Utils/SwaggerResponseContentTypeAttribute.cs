using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechChallenge.Api.Utils
{
    /// <summary>
    /// SwaggerResponseContentTypeAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SwaggerResponseContentTypeAttribute : Attribute
    {
        /// <summary>
        /// SwaggerResponseContentTypeAttribute
        /// </summary>
        /// <param name="responseType"></param>
        public SwaggerResponseContentTypeAttribute(string responseType)
        {
            ResponseType = responseType;
        }
        /// <summary>
        /// Response Content Type
        /// </summary>
        public string ResponseType { get; private set; }

        /// <summary>
        /// Remove all other Response Content Types
        /// </summary>
        public bool Exclusive { get; set; }
    }
}