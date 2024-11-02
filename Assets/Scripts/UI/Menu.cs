using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StarsProject.UI
{
    public class Menu : MonoBehaviour
    {
        public event Action ShowHideButtonPressed;
        
        public event Action<bool> ShowPreviewSettingChanged;
        public event Action<bool> ShowLineSettingChanged;

        public event Action MaximalStarMagnitudeChanged;
        public event Action StarMagnitudeMultiplierChanged;
        public event Action StarLineWidthChanged; 
        
        [SerializeField] private Toggle previewToggle;
        [SerializeField] private Toggle lineToggle;
        
        [SerializeField] private TMP_InputField maximalStarSizeField;
        [SerializeField] private TMP_InputField starMultiplierField;
        [SerializeField] private TMP_InputField lineWidthField;

        [SerializeField] private Button showHideButton;

        public bool ShowPreviewSettingsValue => previewToggle.isOn;
        public bool ShowLines => previewToggle.isOn;

        public float MaximalMagnitude => float.Parse(maximalStarSizeField.text,NumberStyles.Float, CultureInfo.InvariantCulture);
        public float MagnitudeMultiplier => float.Parse(starMultiplierField.text, NumberStyles.Float, CultureInfo.InvariantCulture);
        public float StarLineWidth => float.Parse(lineWidthField.text, NumberStyles.Float, CultureInfo.InvariantCulture);
        
        private void Start()
        {
            previewToggle.onValueChanged.AddListener(value => ShowPreviewSettingChanged?.Invoke(value));
            lineToggle.onValueChanged.AddListener(value => ShowLineSettingChanged?.Invoke(value));
            
            maximalStarSizeField.onValueChanged.AddListener(_ => MaximalStarMagnitudeChanged?.Invoke());
            starMultiplierField.onValueChanged.AddListener(_ => StarMagnitudeMultiplierChanged?.Invoke());
            lineWidthField.onValueChanged.AddListener(_ => StarLineWidthChanged?.Invoke());
            
            showHideButton.onClick.AddListener(() => ShowHideButtonPressed?.Invoke());
        }
        
        private void OnDestroy()
        {
            previewToggle.onValueChanged.RemoveAllListeners();
            lineToggle.onValueChanged.RemoveAllListeners();
            
            maximalStarSizeField.onValueChanged.RemoveAllListeners();
            starMultiplierField.onValueChanged.RemoveAllListeners();
            lineWidthField.onValueChanged.RemoveAllListeners();
            
            showHideButton.onClick.RemoveAllListeners();
        }
    }
}