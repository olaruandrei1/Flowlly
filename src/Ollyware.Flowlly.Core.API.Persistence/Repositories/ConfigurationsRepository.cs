using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Repositories;
using Ollyware.Flowlly.Core.API.Domain.Entities;
using Ollyware.Flowlly.Core.API.Persistence.DatabaseContexts;
using Ollyware.Flowlly.Core.API.Persistence.DatabaseContexts.BaseContext;

namespace Ollyware.Flowlly.Core.API.Persistence.Repositories;

internal class ConfigurationsRepository(ConfigurationContext _configurationContext) : InitiateRepository<ConfigurationEntity>(_configurationContext), IConfigurationsRepository
{
}
