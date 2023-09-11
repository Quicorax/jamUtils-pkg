using System;
using System.Collections.Generic;
using Services.Runtime.Audio;
using Services.Runtime.Localization;

namespace Services.Runtime.ServiceManagement
{
    public static class DefinedServices
    {
        public static readonly Dictionary<Type, IService> Services = new()
        {
            { typeof(AudioService), new AudioService() },
            { typeof(LocalizationService), new LocalizationService() },
            { typeof(RemoteVariablesService), new RemoteVariablesService() },
        };
    }
}