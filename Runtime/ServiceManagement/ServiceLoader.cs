using UnityEngine;

namespace Services.Runtime.ServiceManagement
{
    public class ServiceLoader : MonoBehaviour
    {
        private void Awake()
        {
            InitializeServices();
        }

        private void InitializeServices()
        {
            foreach (var definedService in DefinedServices.Services)
            {
                definedService.Value.Initialize();
                ServiceLocator.RegisterService(definedService.Key, definedService.Value);
            }
        }

        private void OnDestroy()
        {
            ServiceLocator.ClearServices();
        }
    }
}