namespace aspnet_core_integration.Infrastructure.Http
{
    public interface IHttpClientService
    {
        Task<TResponse> PostAsync<TRequest, TResponse>(
           string url,
           TRequest body
       );

        Task<TResponse> GetAsync<TResponse>(
            string url,
            string accessToken
        );
    }
}
