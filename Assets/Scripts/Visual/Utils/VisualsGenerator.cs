using System.Collections.Generic;
using StarsProject.Constellations;
using StarsProject.Misc;
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

        public List<SpriteVisual> GenerateStars(Sprite starTex, Transform holder,
            Vector2 size, Dictionary<uint, Star> stars, CelestialCoordinate center)
        {
            var values = stars.Values;

            var starVisuals = new List<SpriteVisual>();

            foreach (var star in values)
            {
                var starVisual = Object.Instantiate(config.SpriteVisual, holder);

                starVisual.SetSprite(starTex);
                starVisual.SetColor(star.color);

                starVisual.transform.localScale = CelestialCoordinateConverter.GetScale(star.magnitude / 2, size);
                starVisual.transform.position = star.coordinate.ToVector3(center, size);

                starVisuals.Add(starVisual);
            }

            return starVisuals;
        }

        public SpriteVisual GeneratePreview(Sprite previewSprite, Transform holder, Vector2 size, ImageInfo info,
            CelestialCoordinate center)
        {
            var preview = GameObject.Instantiate(config.SpriteVisual, holder);

            preview.SetSprite(previewSprite);

            preview.transform.localScale = CelestialCoordinateConverter.GetScale(info.scale, size);
            preview.transform.position = info.coordinate.ToVector3(center, size);
            preview.transform.rotation = Quaternion.AngleAxis(info.angle, -Vector3.forward);

            return preview;
        }

        public List<LineVisual> GenerateLines(Transform holder, Vector2 size,
            Dictionary<uint, Star> stars, OneTimeLines[] oneTimeLines, CelestialCoordinate center)
        {
            var starLineVisuals = new List<LineVisual>();

            foreach (var oneTimeLine in oneTimeLines)
            {
                foreach (var line in oneTimeLine.Lines)
                {
                    var fromIndex = line.from;
                    var toIndex = line.to;

                    if (!stars.TryGetValue(fromIndex, out var from) || !stars.TryGetValue(toIndex, out var to))
                    {
                        Debug.LogError("Trying to set line from non existing stars!");
                        continue;
                    }

                    var lineVisual = GameObject.Instantiate(config.LineVisual, holder);

                    var fromPosition = from.coordinate.ToVector3(center, size);
                    var toPosition = to.coordinate.ToVector3(center, size);

                    lineVisual.SetPoints(fromPosition, toPosition);

                    starLineVisuals.Add(lineVisual);
                }
            }
            
            return starLineVisuals;
        }
    }
}