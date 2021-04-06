namespace Core.Interfaces
{
    /// <summary>
    /// This will handle request sent to application and return responses back so that they can be sent to output port
    /// </summary>
    /// <typeparam name="TUseCaseResponse"></typeparam>
    public interface IUseCaseRequest<out TUseCaseResponse> {}
    /// <summary>
    /// This interface will handle requests in situations where there is no response required
    /// </summary>
    public interface IUseCaseRequest { }
}
