using System;
using StarsProject.Constellations;
using StarsProject.UI;
using StarsProject.Visual;
using UnityEngine;

namespace StarsProject
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private ConstellationConfig config;
        [SerializeField] private ConstellationVisualiser visualiser;
        [SerializeField] private Menu menu;
        
        private void Start()
        {
            visualiser.Initialise(config);

            UpdateStarMagnitude();
            UpdateStarLineWidth();
            
            menu.ShowHideButtonPressed += ShowHideConstellationAnimation;
            
            menu.MaximalStarMagnitudeChanged += UpdateStarMagnitude;
            menu.StarMagnitudeMultiplierChanged += UpdateStarMagnitude;
            menu.StarLineWidthChanged += UpdateStarLineWidth;
        }
        
        private void ShowHideConstellationAnimation()
        {
            visualiser.OnShowHideButtonPressed();
        }

        private void UpdateStarMagnitude()
        {
            visualiser.OnStarMagnitudeValuesChanged(menu.MaximalMagnitude, menu.MagnitudeMultiplier);
        }

        private void UpdateStarLineWidth()
        {
            visualiser.OnStarLineWidthChanged(menu.StarLineWidth);
        }
        
        private void OnDestroy()
        {
            menu.ShowHideButtonPressed -= ShowHideConstellationAnimation;
            
            menu.MaximalStarMagnitudeChanged -= UpdateStarMagnitude;
            menu.StarMagnitudeMultiplierChanged -= UpdateStarMagnitude;
            menu.StarLineWidthChanged -= UpdateStarLineWidth;
        }
    }
}