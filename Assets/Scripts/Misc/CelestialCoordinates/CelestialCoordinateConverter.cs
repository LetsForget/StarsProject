using System;
using UnityEngine;

namespace StarsProject.CelestialCoordinates
{
    public static class CelestialCoordinateConverter
    {
        public static readonly float RAMax = 24;
        public static readonly float DecMax = 180;
        
        public static Vector3 ToVector3(this CelestialCoordinate coordinate)
        {
            var center = CelestialCoordinatesHelper.Center;
            var size = CelestialCoordinatesHelper.Size;
            
            var decOffset = DecMax / 2 - center.dec;
            var raOffset = RAMax / 2 - center.ra;
            
            var dec = coordinate.dec + decOffset;
            var ra = coordinate.ra + raOffset;

            var x = ra % RAMax / RAMax * size.x;
            var y = dec / DecMax * size.y;
            var z = 0f;

            return new Vector3((float)x, (float)y, z);
        }

        public static Vector3 GetScale(double scale)
        {
            var size = CelestialCoordinatesHelper.Size;
            
            var x = scale / 7.5 / RAMax * size.x;
            var y = scale * 2 / DecMax * size.y;
            var z = 1;

            return new Vector3((float)x, (float)y, z);
        }

        public static double Distance(this CelestialCoordinate from, CelestialCoordinate to)
        {
            var ra1 = from.ra * Math.PI / 12;
            var ra2 = to.ra * Math.PI / 12;
            
            var dec1 = from.dec * Math.PI / 180f;
            var dec2 = to.dec * Math.PI / 180f;
            
            var angleRad = Math.Acos(
                Math.Sin(dec1) * Math.Sin(dec2) +
                Math.Cos(dec1) * Math.Cos(dec2) * Math.Cos(ra1 - ra2)
            );

            // Convert the result from radians to degrees
            var angleDeg = angleRad * 180f / Math.PI;

            return angleDeg;
        }
    }
}