using StarsProject.Animation;

namespace StarsProject.Visual.Animation
{
    public class StarAnimation
    {
        private ScaleAnimation scaleAnim;

        public StarAnimation(StarVisual visual, AnimationConfig config)
        {
            scaleAnim = new ScaleAnimation(visual.Visual, config);
        }

        public void Show()
        {
            scaleAnim.PlayForward(OnScaleAnimFinished);
        }

        private void OnScaleAnimFinished()
        {
            scaleAnim.ForceIncomplete();
        }
        
        public void UpdateSelf()
        {
            scaleAnim.UpdateSelf();
        }
    }
}