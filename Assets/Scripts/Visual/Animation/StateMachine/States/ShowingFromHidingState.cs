namespace StarsProject.Visual.Animation.States
{
    public class ShowingFromHidingState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.ShowingFromHiding;
  
        public ShowingFromHidingState(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimSets,
            IndexContainer indexContainer, AnimationShowerSettings settings) : base(previewAnimation, starLineAnimSets, indexContainer, settings)
        { }

        public override void OnEnter()
        {
            for (var i = 0; i <= indexContainer.Value; i++)
            {
                starLineAnimSets[i].ShowOpacity();
            }
            
            RaiseChangeState(AnimationStateType.ShowingFromStart);
        }
        
        public override void WantsToHide()
        {
            RaiseChangeState(AnimationStateType.Hiding);
        }
    }
}