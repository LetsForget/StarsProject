namespace StarsProject.Visual.Animation.States
{
    public class ShowingFromHidingState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.ShowingFromHiding;
        
        private int appearingLinesCount;
        
        public ShowingFromHidingState(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimSets,
            IndexContainer indexContainer) : base(previewAnimation, starLineAnimSets, indexContainer)
        { }

        public override void OnEnter()
        {
            for (var i = 0; i <= indexContainer.Value; i++)
            {
                appearingLinesCount += starLineAnimSets[i].AnimationsCount;
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