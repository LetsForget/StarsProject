namespace StarsProject.Visual.Animation.States
{
    public class ShowingFromStartState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.ShowingFromStart;
        
        private int lineAnimsInProgress;
        private bool lineAnimsLaunched;

        public ShowingFromStartState(AnimationShowerSettings settings, PreviewAnimation previewAnim,
            StarLineAnimationsSet[] starLineAnims) : base(settings, previewAnim, starLineAnims)
        { }

        public override void OnEnter()
        {
            lineAnimsLaunched = false;
            
            if (settings.DisplayPreview)
            {
                previewAnim.Appear(finishedCallback: OnPreviewShown);
            }
            else
            {
                OnPreviewShown();
            }
        }
        
        private void OnPreviewShown()
        {
            LaunchLineAnimation();
        }
        

        private void LaunchLineAnimation()
        {
            lineAnimsLaunched = true;
            
            if (settings.DisplayStarLines)
            {
                var lineAnimations = starLineAnims[settings.StarLineAnimIndex];
                lineAnimsInProgress = lineAnimations.AnimationsCount;

                lineAnimations.Appear(true);
                lineAnimations.RunLineAnimations(finishedCallback: OnLineSetFinished);
            }
            else
            {
                OnLineSetFinished();
            }
        }

        private void OnLineSetFinished()
        {
            lineAnimsInProgress -= 1;

            if (lineAnimsInProgress != 0 && settings.DisplayStarLines)
            {
                return;
            }
            
            starLineAnims[settings.StarLineAnimIndex].RunStarAnimations();
            
            if (settings.StarLineAnimIndex + 1 == starLineAnims.Length)
            {
                OnLineAnimationFinished();
            }
            else
            {
                settings.StarLineAnimIndex += 1;
                LaunchLineAnimation();
            }
        }

        private void OnLineAnimationFinished()
        {
            RaiseChangeState(AnimationStateType.Shown);
        }
        
        public override void WantsToHide()
        {
            RaiseChangeState(AnimationStateType.Hiding);
        }

        public override void SetStarLinesDisplaying(bool value)
        {
            if (value)
            {
                foreach (var starLineSet in starLineAnims)
                {
                    starLineSet.Appear();
                    starLineSet.RunLineAnimations(true);
                }
            }
            else
            {
                foreach (var starLineSet in starLineAnims)
                {
                    starLineSet.Disappear();
                    starLineSet.StopLineAnimations();
                }
                
                OnLineAnimationFinished();
            }
        }

        public override void SetPreviewDisplaying(bool value)
        {
            if (value)
            {
                previewAnim.Appear();
                return;
            }
            
            previewAnim.Disappear();
            
            if (!lineAnimsLaunched)
            {
                LaunchLineAnimation();
            }
        }
    }
}