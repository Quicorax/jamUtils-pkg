using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.Runtime.ServiceManagement
{
    public class ServiceLoader : MonoBehaviour
    {
		[SerializeField] private string _nextScene;

        private void Awake()
        {
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

			SceneManager.LoadScene(_nextScene);
        }

        private void OnDestroy()
        {
            ServiceLocator.ClearServices();
        }
    }
}