using System;
using System.Collections.Generic;
using UnityEngine;

namespace StarsProject.Constellations
{
    [Serializable]
    public class StarLineIndexesSet
    {
        [field: SerializeField] public List<StarLineIndexes> Lines { get; private set; } = new();
    }
}