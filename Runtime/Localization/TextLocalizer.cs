using Services.Runtime.ServiceManagement;
using TMPro;
using UnityEngine;

namespace Services.Runtime.Localization
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextLocalizer : MonoBehaviour
    {
        [SerializeField] private SimpleEventBus _refreshText;
        [SerializeField] private string _textKey;

        private LocalizationService _localizationService;
        private TMP_Text _text;

        public void Print(string textKey)
        {
            _textKey = textKey;
            _text.text = _localizationService.Localize(textKey);
        }

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();

            _refreshText.Event += ForceUpdate;
        }

        private void Start()
        {
            _localizationService = ServiceLocator.GetService<LocalizationService>();

            if (!string.IsNullOrEmpty(_textKey))
            {
                Print(_textKey);
            }
        }

        private void ForceUpdate()
        {
            if (!string.IsNullOrEmpty(_textKey))
            {
                Print(_textKey);
            }
        }

        private void OnDisable()
        {
            _refreshText.Event -= ForceUpdate;
        }
    }
}