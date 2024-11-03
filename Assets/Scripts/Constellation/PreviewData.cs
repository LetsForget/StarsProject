using System;
using StarsProject.CelestialCoordinates;
using UnityEngine;

namespace StarsProject.Constellations
{
    [Serializable]
    public class PreviewData
    {
        [field: SerializeField] public CelestialCoordinate Coordinate { get; set; }
        [field: SerializeField] public float Scale { get; set; }
        [field: SerializeField] public float Angle { get; set; }

        public PreviewData(CelestialCoordinate coordinate, float scale, float angle)
        {
            Coordinate = coordinate;
            Scale = scale;
            Angle = angle;
        }
    }
}