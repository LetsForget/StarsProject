namespace StarsProject.Visual.Animation.States
{
    public class HidedState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.Hided;

        public HidedState(AnimationShowerSettings settings, PreviewAnimation previewAnim,
            StarLineAnimationsSet[] starLineAnims) : base(settings, previewAnim, starLineAnims)
        { }

        public override void OnEnter()
        {
            previewAnim.Disappear(true);
            
            foreach (var lineSet in starLineAnims)
            {
                lineSet.Disappear(true);
            }
            
            foreach (var lineSet in starLineAnims)
            {
                lineSet.ResetLineAnimations();
            }

            settings.StarLineAnimIndex = 0;
        }

        public override void WantsToShow()
        {
            RaiseChangeState(AnimationStateType.ShowingFromStart);
        }

        
    }
}