using StarsProject.Constellations;

namespace StarsProject.Visual.Animation
{
    public class AnimationShower
    {
        private AnimationStateMachine stateMachine;
        private AnimationShowerSettings settings;
        
        public AnimationShower(ConstellationAnimationConfig config, ImageInfo previewInfo, SpriteVisual previewVisual, StarLineSet[] starLineSets)
        { 
            var previewAnimation = new PreviewAnimation(previewInfo, previewVisual, config.PreviewOpacityConfig);
            var starLineAnimationSets = new StarLineAnimationsSet[starLineSets.Length];
            var indexContainer = new IndexContainer();
            settings = new AnimationShowerSettings();
            
            for (var i = 0; i < starLineAnimationSets.Length; i++)
            {
                starLineAnimationSets[i] = new StarLineAnimationsSet(starLineSets[i], config.LineDrawConfig, config.LineOpacityConfig);
            }
            
            stateMachine = new AnimationStateMachine(previewAnimation, starLineAnimationSets, indexContainer, settings);
        }

        public void OnShowHideButtonPressed()
        {
            switch (stateMachine.CurrentState.Type)
            {
                case AnimationStateType.Hided:
                case AnimationStateType.Hiding:
                    Show();
                    break;
                case AnimationStateType.ShowingFromHiding:
                case AnimationStateType.ShowingFromStart:
                case AnimationStateType.Shown:
                    Hide();
                    break;
            }
        }
        
        private void Show() => stateMachine.CurrentState.WantsToShow();

        private void Hide() => stateMachine.CurrentState.WantsToHide();

        public void UpdateSelf() => stateMachine.Update();

        public void OnShowPreviewSettingChanged(bool value)
        {
            settings.ShowPreview = value;
            stateMachine.CurrentState.ShowPreviewSettingChanged(value);
        }

        public void OnShowLinesSettingChanged(bool value)
        {
            settings.ShowStarLines = value;
            stateMachine.CurrentState.ShowLinesSettingChanged(value);
        }
    }
}