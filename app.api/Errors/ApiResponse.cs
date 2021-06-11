namespace app.api.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Se ha producido un error en la petición",
                401 => "No se encuentra autorizado",
                404 => "El recurso no fue encontrado",
                500 => "Error interno de la aplicación",
                _ => null
            };
        }
    }
}
