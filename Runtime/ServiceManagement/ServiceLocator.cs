using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Runtime.ServiceManagement
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, IService> _services = new();

        public static void RegisterService<T>(Type type, T service) where T : class, IService
        {
            if (_services.ContainsKey(type))
            {
                Debug.LogError("Service already registered: " + type.Name);
                return;
            }

            _services.Add(type, service);
        }

        public static T GetService<T>() where T : class, IService
        {
            if (!_services.TryGetValue(typeof(T), out var service))
            {
                Debug.LogError("Service not registered: " + typeof(T).Name);
                return default;
            }

            return (T)service;
        }

        public static void ClearServices()
        {
            foreach (var service in _services.Values)
            {
                service.Clear();
            }

            _services.Clear();
        }
    }
}