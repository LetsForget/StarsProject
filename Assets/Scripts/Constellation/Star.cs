using System;
using UnityEngine;

namespace StarsProject.Constellations
{
    [Serializable]
    public class Star
    {
        [field: SerializeField] public CelestialCoordinate Coordinate { get; private set; }
        [field: SerializeField] public Color Color { get; private set; }
        [field: SerializeField] public double Magnitude { get; private set; }
        
        public Star(CelestialCoordinate coordinate, Color color, double magnitude)
        {
            Coordinate = coordinate;
            Color = color;
            Magnitude = magnitude;
        }
    }
}