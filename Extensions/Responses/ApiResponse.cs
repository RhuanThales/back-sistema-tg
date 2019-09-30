using Newtonsoft.Json;

namespace back_sistema_tg.Extensions.Responses
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 403:
                    return "Erro de permissão.";
                case 404:
                    return "Recurso não encontrado.";
                case 500:
                    return "Erro interno do servidor.";
                default:
                    return null;
            }
        }
    }
}