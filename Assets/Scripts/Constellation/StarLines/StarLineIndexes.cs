using System;

namespace StarsProject.Constellations
{
    [Serializable]
    public struct StarLineIndexes
    {
        public uint from;
        public uint to;

        public StarLineIndexes(uint from, uint to)
        {
            this.from = from;
            this.to = to;
        }
    }
}