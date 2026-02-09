namespace aspnet_core_integration.Dtos.Common
{
    public record ApiRequestDto<T>
    {
        public string Origin { get; init; } = default!;
        public string UsrRequest { get; init; } = default!;
        public string IpRequest { get; init; } = default!;
        public string TransactionIde { get; init; } = default!;
        public T Payload { get; init; } = default!;
    }
}
