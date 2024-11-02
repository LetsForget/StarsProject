namespace StarsProject.Visual.Animation
{
    public class StarLineVisualSet
    {
        public StarLineVisual[] Lines { get; private set; }

        public StarLineVisualSet(StarLineVisual[] lines)
        {
            Lines = lines;
        }
    }
}