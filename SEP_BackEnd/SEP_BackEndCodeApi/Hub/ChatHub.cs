using BussinessObject.Models;
using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    public async Task SendMessage(Message newMessage)
    {
        await Clients.All.SendAsync("ReceiveMessage", newMessage);
    }
    public override Task OnConnectedAsync()
    {
        // Handle connected logic
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        // Handle disconnected logic
        return base.OnDisconnectedAsync(exception);
    }
}
