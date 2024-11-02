using System;
using System.Collections.Generic;
using StarsProject.Misc;
using UnityEngine;

namespace StarsProject.Constellations
{
    [Serializable]
    public class Constellation
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public ImageInfo ImageInfo { get; private set; }
        [field: SerializeField] public CelestialCoordinate Coordinate { get; private set; }
        [field: SerializeField] public LineQueuePart[] Lines { get; private set; }
        public Dictionary<uint, Star> Stars => stars.Dictionary;
        [SerializeField] private SerializableDictionary<uint, Star> stars;
        
        public Constellation(string name, CelestialCoordinate coordinate, ImageInfo imageInfo,
            Dictionary<uint, Star> stars, LineQueuePart[] lines)
        {
            Name = name;
            ImageInfo = imageInfo;
            Coordinate = coordinate;
            this.stars = new SerializableDictionary<uint, Star>(stars);
            Lines = lines;
        }
    }
}