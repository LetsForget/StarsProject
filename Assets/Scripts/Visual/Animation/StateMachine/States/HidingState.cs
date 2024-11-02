namespace StarsProject.Visual.Animation.States
{
    public class HidingState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.Hiding;
        
        private int animCount;
        
        public HidingState(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimSets,
            IndexContainer indexContainer) : base(previewAnimation, starLineAnimSets, indexContainer)
        { }
        
        public override void OnEnter()
        {
            animCount = 1;
            previewAnimation.Hide(finishedCallback: OnAnimationFinished);
           
            for (var i = 0; i < starLineAnimSets.Length; i++)
            {
                animCount += starLineAnimSets[i].AnimationsCount;
                starLineAnimSets[i].HideOpacity(finishedCallback: OnAnimationFinished);
                starLineAnimSets[i].StopLineAnimations();
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
        
        public override void Update()
        {
            previewAnimation.UpdateSelf();
            
            for (var i = 0; i < starLineAnimSets.Length; i++)
            {
                starLineAnimSets[i].UpdateSelf();
            }
        }
        
        public override void WantsToShow()
        {
            RaiseChangeState(AnimationStateType.ShowingFromHiding);
        }
    }
}