namespace StarsProject.Animation
{
    public class ScaleAnimation : ProgressedAnimation
    {
        private IScaleChangeable target;
        
        public ScaleAnimation(IScaleChangeable target, AnimationConfig config) : base(config)
        {
            this.target = target;
        }

        protected override void UpdateAnimation()
        {
            target.SetScale(progress);
        }
    }
}