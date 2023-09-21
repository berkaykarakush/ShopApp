namespace BusinessLayer.Abstract.Hubs
{
    public interface IChatHubService
    {
        Task SendMessage(string user, string message);
    }
}
