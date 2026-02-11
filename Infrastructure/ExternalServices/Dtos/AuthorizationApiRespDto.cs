namespace aspnet_core_integration.Infrastructure.ExternalServices.Dtos
{
    public record AuthorizationApiRespDto(
      string Status,
      bool FailedCommunicationWithSri,
      string KeyAccess,
      string? AuthorizationNumber,
      string Environment,
      DateTime? AuthorizationDate,
      string? Voucher,
      string? PdfBase64,
      List<HistoryInvoiceDto>? HistoryInvoice
  );
}
