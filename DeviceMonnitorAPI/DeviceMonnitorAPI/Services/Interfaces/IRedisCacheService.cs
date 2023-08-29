using System;
using System.Collections.Generic;

namespace DeviceMonnitorAPI.Services.Interfaces
{
    public interface IRedisCacheService
    {
        bool Delete<T>(Guid key);

        T Get<T>(Guid key);

        bool Set<T>(Guid key, T value, TimeSpan? expiry = null);
    }
}
