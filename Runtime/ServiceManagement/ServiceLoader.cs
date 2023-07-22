using UnityEngine;

namespace Services.Runtime.ServiceManagement
{
    public class ServiceLoader : MonoBehaviour
    {
		private bool _initialized;

        private void Awake()
        {
			if(_initialized)
			{
				return;
			}

			_initialized = true;
            
			InitializeServices();
            DontDestroyOnLoad(gameObject);
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