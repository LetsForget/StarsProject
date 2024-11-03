namespace StarsProject.Visual.Animation.States
{
    public class HidingState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.Hiding;
        
        private int animCount;

        public HidingState(AnimationShowerSettings settings, PreviewAnimation previewAnim,
            StarLineAnimationsSet[] starLineAnims) : base(settings, previewAnim, starLineAnims)
        { }

        public override void OnEnter()
        {
            animCount = 1;
            previewAnim.Disappear(finishedCallback: OnAnimationFinished);
           
            for (var i = 0; i < starLineAnims.Length; i++)
            {
                animCount += starLineAnims[i].AnimationsCount;
                starLineAnims[i].Disappear(finishedCallback: OnAnimationFinished);
                starLineAnims[i].StopLineAnimations();
            }
        }

        private void OnAnimationFinished()
        {
            animCount -= 1;

            if (animCount == 0)
            {
                RaiseChangeState(AnimationStateType.Hided);
            }
        }
        
        public override void WantsToShow()
        {
            RaiseChangeState(AnimationStateType.ShowingFromHiding);
        }
    }
}