using System;
using System.Collections.Generic;
using Services.Runtime.Audio;
using Services.Runtime.Localization;
using Services.Runtime.RemoteVariables;

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
