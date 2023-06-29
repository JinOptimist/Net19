using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.SignalR;

namespace HealthyFoodWeb.SignalRHubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            var author = "qwe";
            var admin = this.Clients.User("1");
            await admin.SendAsync("Receive", "Hi admin, I need help");

            await Clients.All.SendAsync("Receive", message, author);
        }
    }

    public class SmileUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            var userIdStr = connection.User.Claims
                .FirstOrDefault(x => x.Type == AuthService.AUTH_CLAIMS_ID_NAME)?.Value;

            return userIdStr;
        }
    }

}
