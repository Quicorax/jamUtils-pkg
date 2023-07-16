using Services.Runtime.ServiceManagement;
using UnityEngine;

namespace Services.Runtime.Localization
{
    public class LocalizationService : IService
    {
        private Language _language;
        private Localizations _localizationData;

        public void SetLanguage(Language language) => _language = language;
        public string Localize(string key) => _localizationData.GetLocalizedText(key, _language);
        
        public void Initialize()
        {
            var data = FetchDependencies();
            
            _localizationData = data.LocalizationData;
            _localizationData.Initialize();
        }

        public void Clear()
        {
        }
        
        private LocalizationDependencies FetchDependencies() => 
            Resources.Load<LocalizationDependencies>("LocalizationDependencies");
    }
}