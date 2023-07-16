using Services.Runtime.ServiceManagement;
using UnityEngine;

namespace Services.Runtime.Localization
{
    public class LocalizationSampleCaller : MonoBehaviour
    {
        [SerializeField] private SimpleEventBus _refreshText;
        [SerializeField] private Localizations _localizationsData;
        [SerializeField] private TextLocalizer _text;
        [SerializeField] private string _textKey;

        private LocalizationService _localizationService;

        private void Start()
        {
            _localizationService = ServiceLocator.GetService<LocalizationService>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _localizationService.SetLanguage(Language.English);
                _refreshText.NotifyEvent();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                _localizationService.SetLanguage(Language.Spanish);
                _refreshText.NotifyEvent();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _localizationService.SetLanguage(Language.Catalan);
                _refreshText.NotifyEvent();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _text.Print(_textKey);
            }
        }
    }
}