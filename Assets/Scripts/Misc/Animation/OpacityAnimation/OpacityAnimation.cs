namespace StarsProject.Animation
{
    public class OpacityAnimation : ProgressedAnimation
    {
        private IOpacityChangeable target;
        
        public OpacityAnimation(IOpacityChangeable target, AnimationConfig config) : base(config)
        {
            this.target = target;
        }
        
        protected override void UpdateAnimation()
        {
            target.SetOpacity(progress);
        }
    }
}