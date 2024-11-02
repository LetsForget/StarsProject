using System;

namespace StarsProject.Constellations
{
    [Serializable]
    public class ImageInfo
    {
        public CelestialCoordinate coordinate;
        public float scale;
        public float angle;

        public ImageInfo(CelestialCoordinate coordinate, float scale, float angle)
        {
            this.coordinate = coordinate;
            this.scale = scale;
            this.angle = angle;
        }
    }
}