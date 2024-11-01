using UnityEngine;

namespace StarsProject.Visual.Animation
{
    public class LineAnimation : ProgressedAnimation
    {
        private Vector3 from, to;
        private LineVisual lineVisual;
        
        protected override void UpdateAnimation()
        {
            var toLerped = Vector3.Lerp(from, to, progress);
            lineVisual.SetPoints(from, toLerped);
        }
    }
}