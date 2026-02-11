namespace aspnet_core_integration.Infrastructure.ExternalServices.Dtos
{
    public record HistoryInvoiceDto(
     string Description,
     string? Status,
     string Type,
     string Date,
     string? Identificador,
     string Origin
 );
}
