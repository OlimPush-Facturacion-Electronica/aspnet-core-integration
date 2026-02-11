namespace aspnet_core_integration.Infrastructure.ExternalServices.Dtos
{
    public record CreateInvoiceResDto(
     ReceptionApiRespDto Reception,
     string Message,
     AuthorizationApiRespDto? Authorization
 );
}
