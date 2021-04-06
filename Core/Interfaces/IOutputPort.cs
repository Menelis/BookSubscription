namespace Core.Interfaces
{
    /// <summary>
    /// Every input that will be supplied to application will be send here for output response to the client application
    /// </summary>
    /// <typeparam name="TUseCaseResponse"></typeparam>
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);
    }
}
