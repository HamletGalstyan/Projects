using Payment.Models;
using Payment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Manager
{
    public class PaymentDB
    {
        private static List<Payments> payments = new List<Payments>();
        public static int TerminaleMoney = 200000;

        public static PaymentGenerateResponseModel GeneratePayment(PaymentGenerateRequestModel model)
        {
            PaymentGenerateResponseModel responseModel = new PaymentGenerateResponseModel();
            Payments newpayment = new Payments(model.Acc, model.Amount, model.Description);
            payments.Add(newpayment);
            responseModel.PaymentId = payments.Count;
            responseModel.IsSuccess = true;
            responseModel.Message = "Payment created";
            return responseModel;
        }

        public static PaymentCheckPaymantQRResponse CheckPaymant(PaymentCheckPaymantQRRequest paymantQRRequest)
        {

            PaymentCheckPaymantQRResponse paymantQRResponse = new PaymentCheckPaymantQRResponse();

            if (paymantQRRequest.PaymentId < payments.Count && paymantQRRequest.PaymentId >= 0)
            {
                if (payments[paymantQRRequest.PaymentId].State == 1)
                {
                    Utility.SendSMS.SendSms(payments[paymantQRRequest.PaymentId].MobilePhone, payments[paymantQRRequest.PaymentId].SmsCode);
                    payments[paymantQRRequest.PaymentId].State = 2;
                    paymantQRResponse.IsSucces = true;
                    payments[paymantQRRequest.PaymentId].LastModifiedTime = DateTime.Now;
                    return paymantQRResponse;
                }
            }
            paymantQRResponse.IsSucces = false;
            paymantQRResponse.Message = "It does not exist an operation with such data";
            return paymantQRResponse;
        }
        
        public static PaymentChackPaymentSmsCodeResponseModel ChackPaymentSmsCode(PaymentChackPaymentSmsCodeRequestModel model)
        {
            PaymentChackPaymentSmsCodeResponseModel responseModel = new PaymentChackPaymentSmsCodeResponseModel(); 
            if (model.PaymentId>=0 && payments.Count > model.PaymentId)
            {
                if(payments[model.PaymentId].State==2)
                {
                    if(model.SmsCode == payments[model.PaymentId].SmsCode)
                    {
                        payments[model.PaymentId].State = 3;
                        responseModel.IsSuccess = true;
                        responseModel.Message = "Ok";
                        payments[model.PaymentId].LastModifiedTime = DateTime.Now;
                        return responseModel;

                    }
                }
            }
            responseModel.Message = "Bad request";
            responseModel.IsSuccess = false;
            return responseModel;

        }

        public static PaymentPayResponseModel Pay(PaymentPayRequestModel model)
        {
            PaymentPayResponseModel responseModel = new PaymentPayResponseModel();
            if (model.PaymentId>=0&&model.PaymentId<=payments.Count)
            {
                if (payments[model.PaymentId].Amount<TerminaleMoney&& payments[model.PaymentId].State==3)
                {
                    PAY.Credit(payments[model.PaymentId].Acc, payments[model.PaymentId].Amount);
                    payments[model.PaymentId].State = 4;
                    responseModel.IsSuccess = true;
                    responseModel.Message = "There is such money in terminale,the transaction is in progress";
                    payments[model.PaymentId].LastModifiedTime = DateTime.Now;
                    payments[model.PaymentId].AppproveData = DateTime.Now;
                    return responseModel;
                }
            }
            responseModel.IsSuccess = false;
            responseModel.Message = "The transaction is censeled";
            return responseModel;
        }  
        
        public static CheckPaymantStatusResponseModel CheckStatus(CheckPaymantStatusRequestModel model)
        {
            CheckPaymantStatusResponseModel responseModel = new CheckPaymantStatusResponseModel();
            if (model.PaymentId >= 0 && model.PaymentId <= payments.Count)
            {
                if (payments[model.PaymentId].State == 4 && payments[model.PaymentId].AppproveData != null)
                {
                    responseModel.IsSuccess = true;
                    responseModel.Message = "The transcation is success!";
                    return responseModel;
                }
            }
            responseModel.IsSuccess = false;
            responseModel.Message = "The transcation is censeled!";
            return responseModel;
        }
        
    }
}