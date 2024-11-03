namespace StarsProject.Visual.Animation.States
{
    public class ShowingFromHidingState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.ShowingFromHiding;

        public ShowingFromHidingState(AnimationShowerSettings settings, PreviewAnimation previewAnim,
            StarLineAnimationsSet[] starLineAnims) : base(settings, previewAnim, starLineAnims)
        { }

        public override void OnEnter()
        {
            for (var i = 0; i <= settings.StarLineAnimIndex; i++)
            {
                starLineAnims[i].Appear();
            }
            
            RaiseChangeState(AnimationStateType.ShowingFromStart);
        }
        
        public override void WantsToHide()
        {
            RaiseChangeState(AnimationStateType.Hiding);
        }
    }
}