namespace StarsProject.Visual.Animation.States
{
    public class ShownState : AnimationState
    {
        public override AnimationStateType Type => AnimationStateType.Shown;

        public ShownState(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimSets,
            IndexContainer indexContainer, AnimationShowerSettings settings) : base(previewAnimation,
            starLineAnimSets, indexContainer, settings)
        { }

        public override void OnEnter()
        {
            if (settings.ShowPreview)
            {
                previewAnimation.Show(true);
            }

            if (settings.ShowStarLines)
            {
                foreach (var lineSet in starLineAnimSets)
                {
                    lineSet.ShowOpacity(true);
                    lineSet.ShowLineAnimations(true);
                }
            }

            indexContainer.Value = starLineAnimSets.Length - 1;
        }
        
        public override void WantsToHide()
        {
            RaiseChangeState(AnimationStateType.Hiding);
        }

        public override void ShowPreviewSettingChanged(bool value)
        {
            if (value)
            {
                previewAnimation.Show();
            }
            else
            {
                previewAnimation.Hide();
            }
        }

        public override void ShowLinesSettingChanged(bool value)
        {
            if (value)
            {
                foreach (var lineSet in starLineAnimSets)
                {
                    lineSet.ShowLineAnimations(true);
                    lineSet.ShowOpacity();
                }
            }
            else
            {
                foreach (var lineSet in starLineAnimSets)
                {
                    lineSet.HideOpacity();
                }
            }
        }
    }
}