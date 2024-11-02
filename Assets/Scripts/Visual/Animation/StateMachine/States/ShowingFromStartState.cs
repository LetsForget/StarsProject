namespace StarsProject.Visual.Animation.States
{
    public class ShowingFromStartState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.ShowingFromStart;
        
        private int lineAnimationsInProgress;
        private bool previewAnimationLaunched;
        
        public ShowingFromStartState(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimSets,
            IndexContainer indexContainer, AnimationShowerSettings settings) : base(previewAnimation,
            starLineAnimSets, indexContainer, settings)
        { }

        public override void OnEnter()
        {
            previewAnimationLaunched = false;
            
            LaunchLineAnimation();
        }

        private void LaunchLineAnimation()
        {
            if (settings.ShowStarLines)
            {
                var lineAnimations = starLineAnimSets[indexContainer.Value];
                lineAnimationsInProgress = lineAnimations.AnimationsCount;

                lineAnimations.ShowOpacity(true);
                lineAnimations.ShowLineAnimations(finishedCallback: OnLineSetFinished);
                lineAnimations.ShowStarAnimation();
            }
            else
            {
                OnLineSetFinished();
            }
        }

        private void OnLineSetFinished()
        {
            lineAnimationsInProgress -= 1;

            if (lineAnimationsInProgress != 0 && settings.ShowStarLines)
            {
                return;
            }
            
            if (indexContainer.Value + 1 == starLineAnimSets.Length)
            {
                if (settings.ShowPreview)
                {
                    previewAnimation.Show(finishedCallback: OnPreviewShown);
                }
                else
                {
                    OnPreviewShown();
                }
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

        public override void ShowLinesSettingChanged(bool value)
        {
            if (value)
            {
                foreach (var starLineSet in starLineAnimSets)
                {
                    starLineSet.ShowOpacity();
                    starLineSet.ShowLineAnimations(true);
                }
            }
            else
            {
                foreach (var starLineSet in starLineAnimSets)
                {
                    starLineSet.HideOpacity();
                    starLineSet.StopLineAnimations();
                }
                
                OnLineSetFinished();
            }
        }
    }
}