using System.Collections.Generic;
using System.Linq;
using StarsProject.Constellations;
using StarsProject.Misc;
using StarsProject.Visual.Animation;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StarsProject.Visual
{
    public class VisualsGenerator
    {
        private VisualConfig config;

        public VisualsGenerator(VisualConfig config)
        {
            this.config = config;
        }

        public StarAnimation[] GenerateStars(Sprite starTex, Transform holder, Dictionary<uint, Star> stars)
        {
            var values = stars.Values.ToArray();
            var starAnimations = new StarAnimation[values.Length];

            for (var i = 0; i < starAnimations.Length; i++)
            {
                var star = values[i];
                
                var starVisual = Object.Instantiate(config.SpriteVisual, holder);

                starVisual.SetSprite(starTex);
                starVisual.SetColor(star.Color);
                
                starVisual.transform.position = star.Coordinate.ToVector3();
                starAnimations[i] = new StarAnimation(starVisual, star);
            }

            return starAnimations;
        }

        public SpriteVisual GeneratePreview(Sprite previewSprite, Transform holder, in ImageInfo info)
        {
            var preview = GameObject.Instantiate(config.SpriteVisual, holder);
            preview.SetSprite(previewSprite);
            
            return preview;
        }

        public StarLineSet[] GenerateLines(Transform holder, Dictionary<uint, Star> stars, LineQueuePart[] lineQueueParts)
        {
            var starLineSets = new StarLineSet[lineQueueParts.Length];

            for (var i = 0; i < lineQueueParts.Length; i++)
            {
                var queuePart = lineQueueParts[i];
                var starLines = new StarLine[queuePart.Lines.Count];

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

                    starLines[j] = new StarLine(lineVisual, from, to);
                }

                starLineSets[i] = new StarLineSet(starLines);
            }

            return starLineSets;
        }
    }
}