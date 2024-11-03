using System.Collections.Generic;
using StarsProject.CelestialCoordinates;
using StarsProject.Constellations;
using StarsProject.Visual.Animation;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StarsProject.Visual
{
    public class VisualsGenerator
    {
        private VisualPrefabsConfig config;

        public VisualsGenerator(VisualPrefabsConfig config)
        {
            this.config = config;
        }

        public Dictionary<uint, StarVisual> GenerateStars(Sprite starTex, Transform holder, Dictionary<uint, StarData> stars)
        {
            var starVisuals = new Dictionary<uint,StarVisual>();

            foreach (var valuePair in stars)
            {
                var index = valuePair.Key;
                var star = valuePair.Value;
                
                var starVisual = Object.Instantiate(config.SpriteVisual, holder);

                starVisual.SetSprite(starTex);
                starVisual.SetColor(star.Color);
                
                starVisual.transform.position = star.Coordinate.ToVector3();
                starVisuals.Add(index, new StarVisual(starVisual, star));
            }

            return starVisuals;
        }

        public SpriteVisual GeneratePreview(Sprite previewSprite, Transform holder, float additionalAngle, Vector3 additionalScale)
        {
            var preview = GameObject.Instantiate(config.SpriteVisual, holder);
            preview.SetSprite(previewSprite);
            preview.SetScale(additionalScale);
            preview.SetRotation(additionalAngle);
            
            return preview;
        }

        public StarLineVisualSet[] GenerateLines(Transform holder, Dictionary<uint, StarVisual> stars, StarLineIndexesSet[] lineQueueParts)
        {
            var starLineSets = new StarLineVisualSet[lineQueueParts.Length];

            for (var i = 0; i < lineQueueParts.Length; i++)
            {
                var queuePart = lineQueueParts[i];
                var starLines = new StarLineVisual[queuePart.Lines.Count];

                for (var j = 0; j < starLines.Length; j++)
                {
                    var line = queuePart.Lines[j];
                    
                    var fromIndex = line.from;
                    var toIndex = line.to;

                    if (!stars.TryGetValue(fromIndex, out var from) || !stars.TryGetValue(toIndex, out var to))
                    {
                        Debug.LogError("Trying to set line from non existing stars!");
                        continue;
                    }

                    var lineVisual = Object.Instantiate(config.LineVisual, holder);
                    lineVisual.SetOpacity(0);

                    starLines[j] = new StarLineVisual(lineVisual, from, to);
                }

                starLineSets[i] = new StarLineVisualSet(starLines);
            }

            return starLineSets;
        }
    }
}