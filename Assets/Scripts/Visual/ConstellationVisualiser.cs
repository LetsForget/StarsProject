using System;
using System.Collections.Generic;
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
     
        [SerializeField] private VisualConfig visualConfig;
        [SerializeField] private ConstellationAnimationConfig animationConfig;
        
        [SerializeField] private Vector2 size;
        
        private SpriteVisual previewVisual;
        private List<SpriteVisual> starVisuals;
        private StarLineSet[] starLineSteps;

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
            var center = constellation.Coordinate;
            
            cameraSetter.SetCamera(camera, size, visualConfig.BorderOffset, stars, center);
            
            var starSprite = config.Star;
            starVisuals = visualGenerator.GenerateStars(starSprite, visualHolder, stars);
            
            var previewSprite = config.Preview;
            var imageInfo = constellation.ImageInfo;
            previewVisual = visualGenerator.GeneratePreview(previewSprite, visualHolder, in imageInfo);

            var lines = constellation.Lines;
            starLineSteps = visualGenerator.GenerateLines(visualHolder, stars, lines);
            
            animationShower = new AnimationShower(animationConfig, config.Constellation.ImageInfo, previewVisual, starLineSteps);
        }

        private void Update()
        {
            animationShower.UpdateSelf();

            if (Input.GetKeyDown(KeyCode.S))
            {
                animationShower.Show();
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                animationShower.Hide();
            }
        }
    }
}