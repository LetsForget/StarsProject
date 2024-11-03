using System.Collections.Generic;
using StarsProject.Misc.StateMachine;
using StarsProject.Visual.Animation.States;

namespace StarsProject.Visual.Animation
{
    public sealed class AnimationStateMachine : StateMachine<AnimationStateType, AnimationState>
    {
        private PreviewAnimation previewAnim;
        private StarLineAnimationsSet[] starLineAnims;
        private AnimationShowerSettings settings;
        
        public AnimationStateMachine(PreviewAnimation previewAnim, StarLineAnimationsSet[] starLineAnims, AnimationShowerSettings settings)
        {
            this.previewAnim = previewAnim;
            this.starLineAnims = starLineAnims;
            this.settings = settings;
            
            InitializeStates();

            ChangeState(AnimationStateType.Hided);
        }

        protected override void InitializeStates()
        {
            states = new Dictionary<AnimationStateType, AnimationState>
            {
                { AnimationStateType.Hided, new HidedState(settings, previewAnim, starLineAnims) },
                { AnimationStateType.Hiding, new HidingState(settings,previewAnim, starLineAnims) },
                { AnimationStateType.ShowingFromStart, new ShowingFromStartState(settings,previewAnim, starLineAnims) },
                { AnimationStateType.ShowingFromHiding, new ShowingFromHidingState(settings,previewAnim, starLineAnims) },
                { AnimationStateType.Shown, new ShownState(settings,previewAnim, starLineAnims) }
            };

            base.InitializeStates();
        }
    }
}