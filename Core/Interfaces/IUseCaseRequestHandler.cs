using System.Threading.Tasks;

namespace Core.Interfaces
{
    /// <summary>
    /// This is where the processing of user inputs is performed and send to output
    /// </summary>
    /// <typeparam name="TUseCaseRequest"></typeparam>
    /// <typeparam name="TUseCaseResponse"></typeparam>
    public interface IUseCaseRequestHandler<in TUseCaseRequest, out TUseCaseResponse>
        where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        Task<bool> Handle(TUseCaseRequest message, IOutputPort<TUseCaseResponse> outputPort);
    }
    /// <summary>
    /// This interface is used in scenarios where the user input is only send and no response is expected
    /// </summary>
    /// <typeparam name="TUseCaseRequest"></typeparam>
    public interface IUseCaseRequestHandler<in TUseCaseRequest>
        where TUseCaseRequest : IUseCaseRequest
    {
        Task Handle(TUseCaseRequest message);
    }
}
