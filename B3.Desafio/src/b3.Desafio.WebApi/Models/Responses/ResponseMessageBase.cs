using b3.Desafio.WebApi.Models.Requests;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;

namespace b3.Desafio.WebApi.Models.Responses
{
    public class ResponseMessageBase
    { 
        public int StatusCode { get; private set; }
        public object Dados { get; private set; }
        public object Errors { get; private set; }
        public bool IsErrors { get; set; }

        public ResponseMessageBase(int statusCode, object dados, bool isErrors = false, RequestModelBase modelRequest = null)
        {
            StatusCode = statusCode;
            Dados = dados;
            IsErrors = isErrors; 
            if(IsErrors)
                GetErrorModelState(modelRequest);
        }

        private void GetErrorModelState(RequestModelBase modelRequest)
        {
            Errors = modelRequest.Errors;
        }
    }
}
