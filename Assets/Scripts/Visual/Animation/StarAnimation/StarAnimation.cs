using StarsProject.Constellations;
using StarsProject.Misc;
using UnityEngine;

namespace StarsProject.Visual.Animation
{
    public class StarAnimation
    {
        private SpriteVisual visual;
        private Star star;

        public StarAnimation(SpriteVisual visual, Star star)
        {
            this.visual = visual;
            this.star = star;
        }

        public void UpdateMagnitude(float maxSize, float multiplier)
        {
            var newMagnitude = Mathf.Min((float)(star.Magnitude * multiplier), maxSize);
            visual.transform.localScale = CelestialCoordinateConverter.GetScale(newMagnitude / 2);
        }
    }
}