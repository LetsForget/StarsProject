using System;
using System.Collections.Generic;
using StarsProject.CelestialCoordinates;
using StarsProject.Misc;
using UnityEngine;

namespace StarsProject.Constellations
{
    [Serializable]
    public class Constellation
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public PreviewData PreviewData { get; private set; }
        [field: SerializeField] public CelestialCoordinate Coordinate { get; private set; }
        [field: SerializeField] public StarLineIndexesSet[] Lines { get; private set; }
        public Dictionary<uint, StarData> Stars => stars.Dictionary;
        [SerializeField] private SerializableDictionary<uint, StarData> stars;
        
        public Constellation(string name, CelestialCoordinate coordinate, PreviewData previewData,
            Dictionary<uint, StarData> stars, StarLineIndexesSet[] lines)
        {
            Name = name;
            PreviewData = previewData;
            Coordinate = coordinate;
            this.stars = new SerializableDictionary<uint, StarData>(stars);
            Lines = lines;
        }
    }
}