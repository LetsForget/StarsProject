using StarsProject.Constellations;

namespace StarsProject.Visual.Animation
{
    public class StarLine
    {
        public LineVisual LineVisual { get; private set; }
        public Star From { get; private set; }
        public Star To { get; private set; }

        public StarLine(LineVisual lineVisual, Star from, Star to)
        {
            LineVisual = lineVisual;
            From = from;
            To = to;
        }
    }
}