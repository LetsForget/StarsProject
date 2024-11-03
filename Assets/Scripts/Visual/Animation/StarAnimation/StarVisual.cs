using StarsProject.CelestialCoordinates;
using StarsProject.Constellations;
using UnityEngine;

namespace StarsProject.Visual.Animation
{
    public class StarVisual
    {
        public SpriteVisual Visual { get; private set; }
        public StarData Star { get; private set; }
        
        public StarVisual(SpriteVisual visual, StarData star)
        {
            Visual = visual;
            Star = star;
        }

        public void UpdateMagnitude(float maxSize, float multiplier)
        {
            var newMagnitude = Mathf.Min((float)(Star.Magnitude * multiplier), maxSize);
            Visual.transform.localScale = CelestialCoordinateConverter.GetScale(newMagnitude / 2);
        }
    }
}