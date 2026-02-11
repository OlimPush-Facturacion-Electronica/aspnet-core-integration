namespace aspnet_core_integration.Infrastructure.ExternalServices.Dtos
{
    public record ReceptionApiRespDto(
        string Status,
        bool FailedCommunicationWithSri,
        string? KeyAccess,
        List<HistoryInvoiceDto>? HistoryInvoice
    );
}
