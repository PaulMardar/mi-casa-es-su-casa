namespace iQuest.TheUniverse.Infrastructure
{
    public interface IRequestHandler<in TRequest, out TResponse>
    {
        TResponse Execute(TRequest request);
    }
}