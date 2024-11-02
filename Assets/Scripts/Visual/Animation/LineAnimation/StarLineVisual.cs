namespace StarsProject.Visual.Animation
{
    public class StarLineVisual
    {
        public LineVisual LineVisual { get; private set; }
        public StarVisual From { get; private set; }
        public StarVisual To { get; private set; }

        public StarLineVisual(LineVisual lineVisual, StarVisual from, StarVisual to)
        {
            LineVisual = lineVisual;
            From = from;
            To = to;
        }
    }
}