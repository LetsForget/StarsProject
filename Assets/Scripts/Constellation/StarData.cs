using System;
using StarsProject.CelestialCoordinates;
using UnityEngine;

namespace StarsProject.Constellations
{
    [Serializable]
    public class StarData
    {
        [field: SerializeField] public CelestialCoordinate Coordinate { get; private set; }
        [field: SerializeField] public Color Color { get; private set; }
        [field: SerializeField] public double Magnitude { get; private set; }
        
        public StarData(CelestialCoordinate coordinate, Color color, double magnitude)
        {
            Coordinate = coordinate;
            Color = color;
            Magnitude = magnitude;
        }
    }
}