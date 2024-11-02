using StarsProject.Misc.StateMachine;

namespace StarsProject.Visual.Animation.States
{
    public abstract class AnimationState : State<AnimationStateType>
    {
        protected PreviewAnimation previewAnimation;
        protected StarLineAnimationsSet[] starLineAnimSets;
        protected IndexContainer indexContainer;
        protected AnimationShowerSettings settings;

        protected AnimationState(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimSets,
            IndexContainer indexContainer, AnimationShowerSettings settings)
        {
            this.previewAnimation = previewAnimation;
            this.starLineAnimSets = starLineAnimSets;
            this.indexContainer = indexContainer;
            this.settings = settings;
        }

        public override void Update()
        {
            previewAnimation.UpdateSelf();
            
            foreach (var lineSet in starLineAnimSets)
            {
                lineSet.UpdateSelf();
            }
        }
        
        public virtual void WantsToShow() { }
        
        public virtual void WantsToHide() { }

        public virtual void ShowPreviewSettingChanged(bool value) { }

        public virtual void ShowLinesSettingChanged(bool value) { }
    }
}