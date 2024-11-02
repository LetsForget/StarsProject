using StarsProject.Animation;

namespace StarsProject.Visual.Animation
{
    public class StarAnimation
    {
        private StarVisual visual;
        private ScaleAnimation scaleAnimation;

        public StarAnimation(StarVisual visual, AnimationConfig config)
        {
            this.visual = visual;
            scaleAnimation = new ScaleAnimation(visual.Visual, config);
        }

        public void Show() => scaleAnimation.Appear(() => scaleAnimation.ForceDisappear());

        public void UpdateSelf() => scaleAnimation.UpdateSelf();
    }
}