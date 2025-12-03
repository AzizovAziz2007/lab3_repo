using System;
using System.Collections.Generic;

namespace HotelManagementSystem.Infrastructure
{
    /// <summary>
    /// Простейший Service Locator для разрешения зависимостей
    /// В production рекомендуется использовать DI контейнер (Microsoft.Extensions.DependencyInjection)
    /// </summary>
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static void RegisterService<T>(T service)
        {
            _services[typeof(T)] = service;
        }

        public static T GetService<T>()
        {
            if (_services.TryGetValue(typeof(T), out var service))
            {
                return (T)service;
            }
            throw new InvalidOperationException($"Service {typeof(T).Name} not registered");
        }

        public static bool IsRegistered<T>()
        {
            return _services.ContainsKey(typeof(T));
        }

        public static void Clear()
        {
            _services.Clear();
        }
    }
}
