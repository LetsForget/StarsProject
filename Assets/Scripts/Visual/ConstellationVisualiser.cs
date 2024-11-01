using System.Collections.Generic;
using StarsProject.Constellations;
using StarsProject.Visual.Utils;
using UnityEngine;

namespace StarsProject.Visual
{
    public class ConstellationVisualiser : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private Transform visualHolder;
        [SerializeField] private VisualConfig visualConfig;
        
        [SerializeField] private Vector2 size;
        
        private List<SpriteVisual> starVisuals;
        private SpriteVisual previewVisual;
        private List<LineVisual> starLineVisuals;

        private CameraSetter cameraSetter;
        private VisualsGenerator visualGenerator;

        private void Start()
        {
            cameraSetter = new CameraSetter();
            visualGenerator = new VisualsGenerator(visualConfig);
        }
        
        public void Show(in ConstellationConfig config)
        {
            var constellation = config.Constellation;
            var stars = constellation.Stars;
            var center = constellation.Coordinate;
            
            cameraSetter.SetCamera(camera, size, visualConfig.BorderOffset, stars, center);
            
            var starSprite = config.Star;
            starVisuals = visualGenerator.GenerateStars(starSprite, visualHolder, size, stars, center);
            
            var previewSprite = config.Preview;
            var imageInfo = constellation.ImageInfo;
            previewVisual = visualGenerator.GeneratePreview(previewSprite, visualHolder, size, imageInfo, center);

            var lines = constellation.Lines;
            starLineVisuals = visualGenerator.GenerateLines(visualHolder, size, stars, lines, center);
        }
    }
}