namespace StarsProject.Visual.Animation.States
{
    public class ShownState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.Shown;

        public ShownState(AnimationShowerSettings settings, PreviewAnimation previewAnim,
            StarLineAnimationsSet[] starLineAnims) : base(settings, previewAnim, starLineAnims)
        { }

        public override void OnEnter()
        {
            if (settings.DisplayStarLines)
            {
                foreach (var lineSet in starLineAnims)
                {
                    lineSet.Appear(true);
                    lineSet.RunLineAnimations(true);
                }
            }

            settings.StarLineAnimIndex = starLineAnims.Length - 1;
        }
        
        public override void WantsToHide()
        {
            RaiseChangeState(AnimationStateType.Hiding);
        }

        public override void SetPreviewDisplaying(bool value)
        {
            if (value)
            {
                previewAnim.Appear();
            }
            else
            {
                previewAnim.Disappear();
            }
        }

        public override void SetStarLinesDisplaying(bool value)
        {
            if (value)
            {
                foreach (var lineSet in starLineAnims)
                {
                    lineSet.RunLineAnimations(true);
                    lineSet.Appear();
                }
            }
            else
            {
                foreach (var lineSet in starLineAnims)
                {
                    lineSet.Disappear();
                }
            }
        }
    }
}