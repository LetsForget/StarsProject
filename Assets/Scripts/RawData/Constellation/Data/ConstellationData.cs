using System;

namespace StarsProject.RawData.Constellations
{
    [Serializable]
    public struct ConstellationData
    {
        public string name;
        
        public double ra;
        public double dec;
        
        public ImageData image;
        public StarLineData[] pairs;
        public StarData[] stars;
    }
}
