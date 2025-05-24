using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WaterQuality.Common.Response;
public class DefaultResponse(
    object? objectResponse = null,
    HttpStatusCode httpStatus = HttpStatusCode.OK,
    string message = "")
{
    public HttpStatusCode HttpStatus { get; set; } = httpStatus;

    public string Message { get; set; } = message;

    public object? ObjectResponse { get; set; } = objectResponse;
}
