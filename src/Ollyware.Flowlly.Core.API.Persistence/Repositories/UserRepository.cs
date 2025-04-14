using Ollyware.Flowlly.Core.API.Application.Contracts.Persistence.Repositories;
using Ollyware.Flowlly.Core.API.Domain.Entities;
using Ollyware.Flowlly.Core.API.Persistence.DatabaseContexts;
using Ollyware.Flowlly.Core.API.Persistence.DatabaseContexts.BaseContext;

namespace Ollyware.Flowlly.Core.API.Persistence.Repositories;

internal class UserRepository(UserContext _userContext) : InitiateRepository<UserEntity>(_userContext), IUserRepository
{

}
