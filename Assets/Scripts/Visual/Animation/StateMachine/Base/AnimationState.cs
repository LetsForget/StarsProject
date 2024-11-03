using StarsProject.Misc.StateMachine;

namespace StarsProject.Visual.Animation.States
{
    public abstract class AnimationState : State<AnimationStateType>
    {
        protected AnimationShowerSettings settings;
        
        protected PreviewAnimation previewAnim;
        protected StarLineAnimationsSet[] starLineAnims;

        protected AnimationState(AnimationShowerSettings settings, PreviewAnimation previewAnim, StarLineAnimationsSet[] starLineAnims)
        {
            this.settings = settings;
            
            this.previewAnim = previewAnim;
            this.starLineAnims = starLineAnims;
        }

        public override void Update()
        {
            previewAnim.UpdateSelf();
            
            foreach (var lineSet in starLineAnims)
            {
                lineSet.UpdateSelf();
            }
        }
        
        public virtual void WantsToShow() { }
        
        public virtual void WantsToHide() { }

        public virtual void SetPreviewDisplaying(bool value) { }

        public virtual void SetStarLinesDisplaying(bool value) { }
    }
}