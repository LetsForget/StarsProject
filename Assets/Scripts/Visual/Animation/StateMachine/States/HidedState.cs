namespace StarsProject.Visual.Animation.States
{
    public class HidedState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.Hided;

        public HidedState(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimSets,
            IndexContainer indexContainer, AnimationShowerSettings settings) : base(previewAnimation,
            starLineAnimSets, indexContainer, settings)
        { }

        public override void OnEnter()
        {
            previewAnimation.Hide(true);
            
            foreach (var lineSet in starLineAnimSets)
            {
                lineSet.HideOpacity(true);
            }
            
            foreach (var lineSet in starLineAnimSets)
            {
                lineSet.HideLines(true);
            }

            indexContainer.Value = 0;
        }

        public override void WantsToShow()
        {
            RaiseChangeState(AnimationStateType.ShowingFromStart);
        }
    }
}