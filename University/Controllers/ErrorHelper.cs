using System;

namespace University.Controllers
{
    public sealed class ErrorHelper
    {
        private static readonly Lazy<ErrorHelper> uniqueInstance = new Lazy<ErrorHelper>(() => new ErrorHelper());
        public static ErrorHelper MyProperty { get; set; }
        public ErrorHelper Instance { get { return uniqueInstance.Value; } }

        private ErrorHelper()
        {
        }

        public void CheckObject(object _object)//todo enternal redurrect to an error page
        {
            if( _object.Equals(null))
            {
                
            }
        }

        public enum Errors
        {
            BadRequest = 400,
            NotFound = 404,
            InternalServerError = 500
        }

        

     
    }
}