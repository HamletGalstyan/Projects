using Newtonsoft.Json;
using Payment.Manager;
using Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Payment.Controllers
{

    [RoutePrefix("api/PaymentController")]
    public class PaymentController : ApiController
    {
        [HttpPost]
        [Route("GeneratePayment")]
        public HttpResponseMessage GeneratePayment(PaymentGenerateRequestModel model)
        {

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            PaymentGenerateResponseModel responsemodel = new PaymentGenerateResponseModel();
            if (!ModelState.IsValid)
            {
                responsemodel.IsSuccess = false;
                responsemodel.Message = "False Request";

                httpResponse.Content = new StringContent(JsonConvert.SerializeObject(responsemodel));
                httpResponse.StatusCode = HttpStatusCode.ExpectationFailed;
                return httpResponse;
            }
            responsemodel = PaymentDB.GeneratePayment(model);
            httpResponse.Content = new StringContent(JsonConvert.SerializeObject(responsemodel));
            httpResponse.StatusCode = HttpStatusCode.Accepted;
            return httpResponse;


        }

        [HttpPost]
        [Route("CheckPaymantQR")]
        public HttpResponseMessage CheckPaymantQR(PaymentCheckPaymantQRRequest model)
        {
            PaymentCheckPaymantQRResponse response = new PaymentCheckPaymantQRResponse();
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            if (!ModelState.IsValid)
            {
                response.IsSucces = false;
                response.Message = "There is not such action";
                responseMessage.Content = new StringContent(JsonConvert.SerializeObject(response));
                responseMessage.StatusCode = HttpStatusCode.BadRequest;
                return responseMessage;
            }
            response = PaymentDB.CheckPaymant(model);
            responseMessage.Content = new StringContent(JsonConvert.SerializeObject(response));
            responseMessage.StatusCode = HttpStatusCode.Accepted;
            return responseMessage;

        }

        [HttpPost]
        [Route("CheckPaymentSms")]

        public HttpResponseMessage CheckPaymentSmsCode(PaymentChackPaymentSmsCodeRequestModel model)
        {
            PaymentChackPaymentSmsCodeResponseModel responseModel = new PaymentChackPaymentSmsCodeResponseModel();
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            if (!ModelState.IsValid)
            {
                responseModel.IsSuccess = false;
                responseMessage.StatusCode = HttpStatusCode.BadRequest;
                responseModel.Message = "There is not such action";
                responseMessage.Content = new StringContent(JsonConvert.SerializeObject(responseModel));
                return responseMessage;

            }
            responseModel = PaymentDB.ChackPaymentSmsCode(model);
            responseMessage.Content = new StringContent(JsonConvert.SerializeObject(responseModel));
            responseMessage.StatusCode = HttpStatusCode.Accepted;
            return responseMessage;
        }


        [HttpPost]
        [Route("Pay")]
        public HttpResponseMessage Pay(PaymentPayRequestModel model)
        {
            PaymentPayResponseModel responseModel = new PaymentPayResponseModel();
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            if (!ModelState.IsValid)
            {
                responseModel.IsSuccess = false;
                responseModel.Message = "False request for payment";
                responseMessage.StatusCode = HttpStatusCode.BadRequest;
                responseMessage.Content = new StringContent(JsonConvert.SerializeObject(responseModel));
                return responseMessage;
            }
            responseModel = PaymentDB.Pay(model);
            responseMessage.Content = new StringContent(JsonConvert.SerializeObject(responseModel));
            responseMessage.StatusCode = HttpStatusCode.Accepted;
            return responseMessage;
        }

        [HttpPost]
        [Route("CheckStatus")]
        public HttpResponseMessage CheckStatus(CheckPaymantStatusRequestModel model)
        {
            CheckPaymantStatusResponseModel responseModel = new CheckPaymantStatusResponseModel();
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            if(!ModelState.IsValid)
            {
                responseModel.IsSuccess = false;
                responseModel.Message = "False request for payment";
                responseMessage.StatusCode = HttpStatusCode.BadRequest;
                responseMessage.Content = new StringContent(JsonConvert.SerializeObject(responseModel));
                return responseMessage;
            }
            responseModel = PaymentDB.CheckStatus(model);
            responseMessage.Content = new StringContent(JsonConvert.SerializeObject(responseModel));
            responseMessage.StatusCode = HttpStatusCode.Accepted;
            return responseMessage;

        }






    }
}
