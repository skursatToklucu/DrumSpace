namespace DrumSpace.Application.Common.Interfaces.Response
{
    public interface ISingleResponse<TData> : IResponse
    {
        TData Data { get; set; }
    }
}