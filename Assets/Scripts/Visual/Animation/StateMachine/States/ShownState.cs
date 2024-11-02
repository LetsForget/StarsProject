namespace StarsProject.Visual.Animation.States
{
    public class ShownState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.Shown;
        
        public ShownState(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimSets,
            IndexContainer indexContainer) : base(previewAnimation, starLineAnimSets, indexContainer)
        { }

        public override void OnEnter()
        {
            previewAnimation.Show(true);
            
            foreach (var lineSet in starLineAnimSets)
            {
                lineSet.ShowLineAnimation(true);
            }

            indexContainer.Value = starLineAnimSets.Length - 1;
        }
        
        public override void WantsToHide()
        {
            RaiseChangeState(AnimationStateType.Hiding);
        }
    }
}