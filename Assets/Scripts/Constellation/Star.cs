using System;
using UnityEngine;

namespace StarsProject.Constellations
{
    [Serializable]
    public struct Star
    {
        public CelestialCoordinate coordinate;
        public Color color;
        public double magnitude;
        
        public Star(CelestialCoordinate coordinate, Color color, double magnitude)
        {
            this.coordinate = coordinate;
            this.color = color;
            this.magnitude = magnitude;
        }
    }
}