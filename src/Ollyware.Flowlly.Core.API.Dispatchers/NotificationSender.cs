using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ollyware.Flowlly.Core.API.Domain.ChannelEntitites;
using System.Threading.Channels;

namespace Ollyware.Flowlly.Core.API.Dispatchers;

public class NotificationSender : BackgroundService
{
    private readonly Channel<NotificationSenderData> _channel;
    private readonly IServiceScopeFactory _scopeFactory;

    public NotificationSender(Channel<NotificationSenderData> channel, IServiceScopeFactory scopeFactory) => (_channel, _scopeFactory) = (channel, scopeFactory);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

    }
}
