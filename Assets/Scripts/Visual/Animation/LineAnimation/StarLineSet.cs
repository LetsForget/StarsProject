namespace StarsProject.Visual.Animation
{
    public class StarLineSet
    {
        public StarLine[] Lines { get; private set; }

        public StarLineSet(StarLine[] lines)
        {
            Lines = lines;
        }
    }
}