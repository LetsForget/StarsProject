using StarsProject.Constellations;

namespace StarsProject.Visual.Animation
{
    public class AnimationShower
    {
        private AnimationStateMachine stateMachine;
        private AnimationShowerSettings settings;
        
        public AnimationShower(ConstellationAnimationConfig config, PreviewData previewInfo, SpriteVisual previewVisual, StarLineVisualSet[] starLineSets)
        { 
            var previewAnim = new PreviewAnimation(previewInfo, previewVisual, config.PreviewOpacityConfig);
            var starLineAnims = new StarLineAnimationsSet[starLineSets.Length];
            
            for (var i = 0; i < starLineAnims.Length; i++)
            {
                starLineAnims[i] = new StarLineAnimationsSet(starLineSets[i], config.LineDrawConfig,
                    config.LineOpacityConfig, config.StarScaleConfig);
            }
            
            settings = new AnimationShowerSettings();
            stateMachine = new AnimationStateMachine(previewAnim, starLineAnims, settings);
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

        public void OnDisplayPreviewChanged(bool value)
        {
            settings.DisplayPreview = value;
            stateMachine.CurrentState.SetPreviewDisplaying(value);
        }

        public void OnDisplayLinesChanged(bool value)
        {
            settings.DisplayStarLines = value;
            stateMachine.CurrentState.SetStarLinesDisplaying(value);
        }
    }
}