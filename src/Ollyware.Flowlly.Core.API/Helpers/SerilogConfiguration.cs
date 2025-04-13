using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using Ollyware.Flowlly.Core.API.Domain.ConfigurableObjects;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace Ollyware.Flowlly.Core.API.Helpers;

public static class SerilogConfiguration
{
    public static Serilog.Core.Logger Properties
    (
        ConnectionStrings connectionStrings, 
        ElasticConfigurations elasticConfigurations,
        string pathToWrite
    )
    => new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.WithMachineName()
                .WriteTo.Console()
                .WriteTo.Elasticsearch
                (
                    [new Uri(connectionStrings.ElasticSearch)],
                    opts =>
                    {
                        opts.DataStream = new DataStreamName(elasticConfigurations.IndexName);
                        opts.BootstrapMethod = BootstrapMethod.Failure;
                        opts.MinimumLevel = LogEventLevel.Information;
                    }
                )
            .Enrich.WithEnvironmentName()
            .WriteTo.Console()
            .WriteTo.File(new CompactJsonFormatter(), pathToWrite, rollingInterval: RollingInterval.Day, fileSizeLimitBytes: 10_000_000, retainedFileCountLimit: null, rollOnFileSizeLimit: true)
        .CreateLogger();
}
