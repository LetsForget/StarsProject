namespace StarsProject.Visual.Animation.States
{
    public class ShowingFromStartState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.ShowingFromStart;
        
        private int lineAnimationsInProgress;
        
        public ShowingFromStartState(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimSets,
            IndexContainer indexContainer) : base(previewAnimation, starLineAnimSets, indexContainer)
        { }
        
        public override void OnEnter()
        {
            LaunchLineAnimation();
        }

        private void LaunchLineAnimation()
        {
            var lineAnimations = starLineAnimSets[indexContainer.Value];
            lineAnimationsInProgress = lineAnimations.AnimationsCount;

            lineAnimations.ShowLineAnimation(finishedCallback: OnLineSetFinished);
        }

        private void OnLineSetFinished()
        {
            lineAnimationsInProgress -= 1;

            if (lineAnimationsInProgress != 0)
            {
                return;
            }
            
            if (indexContainer.Value + 1 == starLineAnimSets.Length)
            {
                RaiseChangeState(AnimationStateType.Shown);
            }
            else
            {
                indexContainer.Value += 1;
                LaunchLineAnimation();
            }
        }

        public override void Update()
        {
            foreach (var lineSet in starLineAnimSets)
            {
                lineSet.UpdateSelf();
            }
        }
        
        public override void WantsToHide()
        {
            RaiseChangeState(AnimationStateType.Hiding);
        }
    }
}