using System;

namespace StarsProject.Constellations
{
    [Serializable]
    public struct CelestialCoordinate
    {
        public double ra;
        public double dec;
 
        public CelestialCoordinate(double ra, double dec)
        {
            this.ra = ra;
            this.dec = dec;
        }

        public static CelestialCoordinate Zero => new(0, 0);
    }
}