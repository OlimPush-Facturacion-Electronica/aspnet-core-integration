namespace aspnet_core_integration.Infrastructure.ExternalServices.Dtos
{
    public record GenericResDto<T>(
     int Code,
     string Status,
     string Message,
     T? Data
    );
}
