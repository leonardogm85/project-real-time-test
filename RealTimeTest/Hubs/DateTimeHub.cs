using Microsoft.AspNetCore.SignalR;

namespace RealTimeTest.Hubs;

public sealed class DateTimeHub : Hub
{
    public async Task SendDateTime()
    {
        while (true)
        {
            await Clients.Caller.SendAsync(
                "ReceiveDateTime",
                DateTime.UtcNow);
            await Task.Delay(1000);
        }
    }

    public async Task SendDateTimeWithSpecificMethod(string specificMethod)
    {
        while (true)
        {
            await Clients.Caller.SendAsync(
                specificMethod,
                DateTime.UtcNow);
            await Task.Delay(1000);
        }
    }
}
