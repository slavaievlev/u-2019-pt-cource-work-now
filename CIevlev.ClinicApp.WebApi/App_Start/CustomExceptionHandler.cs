using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using SIevlev.ClinicApp.Interfaces.Exceptions;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.WebApi
{
    public class CustomExceptionHandler : ExceptionHandler
    {
        private const string NotFoundExType = "NotFoundException";
        private const string ValidationExType = "ValidationException";

        public override void Handle(ExceptionHandlerContext context)
        {
            switch (context.Exception)
            {
                case DoctorNotFoundException ex:
                {
                    var result = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new ObjectContent(typeof(ExceptionResponseModel),
                            new ExceptionResponseModel(NotFoundExType, ex.Message), new JsonMediaTypeFormatter())
                    };

                    context.Result = new HttpErrorResult(result);

                    break;
                }

                case PatientNotFoundException ex:
                {
                    var result = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new ObjectContent(typeof(ExceptionResponseModel),
                            new ExceptionResponseModel(NotFoundExType, ex.Message), new JsonMediaTypeFormatter())
                    };
                    
                    context.Result = new HttpErrorResult(result);

                    break;
                }
            }
        }

        private class HttpErrorResult : IHttpActionResult
        {
            private readonly HttpResponseMessage _httpResponseMessage;

            public HttpErrorResult(HttpResponseMessage httpResponseMessage)
            {
                _httpResponseMessage = httpResponseMessage;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(_httpResponseMessage);
            }
        }
    }
}