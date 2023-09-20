using StationMonnitorAPI.Models.RedisModels;
using StationMonnitorAPI.Services.Interfaces;
using Microsoft.Extensions.Logging;
using ServiceStack.Redis;
using System;

namespace StationMonnitorAPI.Services
{
    public class RedisCacheService: IRedisCacheService
    {
        private readonly ILogger _logger;
        private readonly IRedisClientsManager _redisClientsManager;

        public RedisCacheService(IRedisClientsManager redisClientsManager, ILogger<RedisCacheService> logger)
        {
            _redisClientsManager = redisClientsManager;
            _logger = logger;
        }

        public bool Delete<T>(Guid key)
        {
            try
            {
                using (IRedisClient redis = _redisClientsManager.GetClient())
                {
                    var item = redis.As<T>();
                    item.RemoveEntry(key.ToString());
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("failed to delete cache item {key} {Ex}", key, ex);
                return false;
            }
        }

        public T Get<T>(Guid key) 
        {
            try
            {
                using (IRedisClient redis = _redisClientsManager.GetClient())
                {
                    var item = redis.As<T>();
                    var result = item.GetValue(key.ToString());

                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("failed to get cache item {key} {Ex}", key, ex);
                return default(T);
            }
        }

        public bool Set<T>(Guid key, T value, TimeSpan? expiry = null) 
        {
            try
            {
                using (IRedisClient redis = _redisClientsManager.GetClient())
                {
                    var item = redis.As<T>();
                    item.SetValue(key.ToString(), value, expiry ?? TimeSpan.FromHours(1));

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("failed to set cache item {key} {Ex}", key, ex);
                return false;
            }
        }
    }
}
