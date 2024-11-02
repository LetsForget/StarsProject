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
                previewAnimation.Show(finishedCallback: OnPreviewShown);
            }
            else
            {
                indexContainer.Value += 1;
                LaunchLineAnimation();
            }
        }

        private void OnPreviewShown()
        {
            RaiseChangeState(AnimationStateType.Shown);
        }
        
        public override void WantsToHide()
        {
            RaiseChangeState(AnimationStateType.Hiding);
        }
    }
}