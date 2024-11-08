﻿using System.Collections.Generic;
using StarsProject.CelestialCoordinates;
using StarsProject.Constellations;
using StarsProject.Visual.Animation;
using StarsProject.Visual.Utils;
using UnityEngine;

namespace StarsProject.Visual
{
    public class ConstellationVisualiser : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private Transform visualHolder;
     
        [SerializeField] private VisualPrefabsConfig visualConfig;
        [SerializeField] private ConstellationAnimationConfig animationConfig;
        
        [SerializeField] private Vector2 size;
        
        private SpriteVisual previewVisual;
        private Dictionary<uint, StarVisual> starVisuals;
        private StarLineVisualSet[] starLineSteps;

        private CameraSetter cameraSetter;
        private VisualsGenerator visualGenerator;
        private AnimationShower animationShower;
        
        private void Start()
        {
            cameraSetter = new CameraSetter();
            visualGenerator = new VisualsGenerator(visualConfig);
        }
        
        public void Initialise(in ConstellationConfig config)
        {
            CelestialCoordinatesHelper.Center = config.Constellation.Coordinate;
            CelestialCoordinatesHelper.Size = size;
            
            var constellation = config.Constellation;
            
            var stars = constellation.Stars;
            cameraSetter.SetCamera(camera, size, visualConfig.BorderOffset, stars);
            
            var starSprite = config.Star;
            starVisuals = visualGenerator.GenerateStars(starSprite, visualHolder, stars);
            
            var previewSprite = config.Preview;
            previewVisual = visualGenerator.GeneratePreview(previewSprite, visualHolder, config.PreviewAddAngle, config.PreviewAddScale);

            var lines = constellation.Lines;
            starLineSteps = visualGenerator.GenerateLines(visualHolder, starVisuals, lines);
            
            animationShower = new AnimationShower(animationConfig, config.Constellation.PreviewData, previewVisual, starLineSteps);
        }

        private void Update()
        {
            animationShower.UpdateSelf();
        }

        public void OnShowHideButtonPressed()
        {
            animationShower.OnShowHideButtonPressed();
        } 

        public void OnStarSizesChanged(float maxSize, float multiplier)
        {
            foreach (var starAnim in starVisuals.Values)
            {
                starAnim.UpdateMagnitude(maxSize, multiplier);
            }
        }

        public void OnStarLineWidthChanged(float starLineWidth)
        {
            foreach (var starLineSet in starLineSteps)
            {
                foreach (var starLine in starLineSet.Lines)
                {
                    starLine.LineVisual.SetWidth(starLineWidth);
                }
            }
        }

        public void OnDisplayPreviewChanged(bool value)
        {
            animationShower.OnDisplayPreviewChanged(value);
        }
        
        public void OnDisplayLinesChanged(bool value)
        {
            animationShower.OnDisplayLinesChanged(value);
        }
    }
}