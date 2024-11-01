using System;

namespace StarsProject.Constellations
{
    [Serializable]
    public struct LineInfo
    {
        public uint from;
        public uint to;

        public LineInfo(uint from, uint to)
        {
            this.from = from;
            this.to = to;
        }
    }
}