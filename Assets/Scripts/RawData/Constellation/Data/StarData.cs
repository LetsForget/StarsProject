using System;

namespace StarsProject.RawData.Constellations
{
    [Serializable]
    public struct StarData
    {
        public uint id;
        public double ra;
        public double dec;
        public double magnitude;
        public string color;
    }
}