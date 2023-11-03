using BussinessObject.Models;
using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    public async Task SendMessage(Message newMessage)
    {
        await Clients.All.SendAsync("ReceiveMessage", newMessage);
    }
}
