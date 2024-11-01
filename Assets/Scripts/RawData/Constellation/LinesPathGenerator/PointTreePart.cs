using System.Collections.Generic;

namespace StarsProject.RawData.Constellations
{
    public class PointTreePart
    {
        public List<PointTreePart> Parents { get; private set; }
        public uint Index { get; private set; }
        public List<PointTreePart> Children { get; private set; }

        public PointTreePart(uint index)
        {
            Parents = new List<PointTreePart>();
            Index = index;
            Children = new List<PointTreePart>();
        }
    }
}