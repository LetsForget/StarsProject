using System;

namespace StarsProject.RawData.Constellations
{
    [Serializable]
    public struct ImageData
    {
        public double ra;
        public double dec;
        public float scale;
        public float angle;
    }
}