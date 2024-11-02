using UnityEngine;

namespace StarsProject.Animation
{
    public class LineAnimation : ProgressedAnimation
    {
        public Vector3 From { get; set; }
        public Vector3 To { get; set; }
        
        private ILinePositionsChangeable target;
        
        public LineAnimation(ILinePositionsChangeable target, AnimationConfig config) : base(config)
        {
            this.target = target;
        }
        
        protected override void UpdateAnimation()
        {
            var toLerped = Vector3.Lerp(From, To, progress);
            target.SetPoints(From, toLerped);
        }
    }
}