using System;

namespace StarsProject.CelestialCoordinates
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
    }
}