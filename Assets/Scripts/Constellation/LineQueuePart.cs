using System;
using System.Collections.Generic;
using UnityEngine;

namespace StarsProject.Constellations
{
    [Serializable]
    public class LineQueuePart
    {
        [field: SerializeField] public List<LineInfo> Lines { get; private set; } = new();
    }
}