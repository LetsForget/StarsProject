using System.Collections.Generic;
using StarsProject.Misc.StateMachine;
using StarsProject.Visual.Animation.States;

namespace StarsProject.Visual.Animation
{
    public sealed class AnimationStateMachine : StateMachine<AnimationStateType, AnimationState>
    {
        private PreviewAnimation previewAnimation;
        private StarLineAnimationsSet[] starLineAnimationsSets;
        private IndexContainer setIndexContainer;
        private AnimationShowerSettings settings;
        
        public AnimationStateMachine(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimationsSets,
            IndexContainer setIndexContainer, AnimationShowerSettings settings)
        {
            this.previewAnimation = previewAnimation;
            this.starLineAnimationsSets = starLineAnimationsSets;
            this.setIndexContainer = setIndexContainer;
            this.settings = settings;
            
            InitializeStates();

            ChangeState(AnimationStateType.Hided);
        }

        protected override void InitializeStates()
        {
            states = new Dictionary<AnimationStateType, AnimationState>
            {
                {
                    AnimationStateType.Hided,
                    new HidedState(previewAnimation, starLineAnimationsSets, setIndexContainer, settings)
                },
                {
                    AnimationStateType.Hiding,
                    new HidingState(previewAnimation, starLineAnimationsSets, setIndexContainer, settings)
                },
                {
                    AnimationStateType.ShowingFromStart,
                    new ShowingFromStartState(previewAnimation, starLineAnimationsSets, setIndexContainer, settings)
                },
                {
                    AnimationStateType.ShowingFromHiding,
                    new ShowingFromHidingState(previewAnimation, starLineAnimationsSets, setIndexContainer, settings)
                },
                {
                    AnimationStateType.Shown,
                    new ShownState(previewAnimation, starLineAnimationsSets, setIndexContainer, settings)
                }
            };

            base.InitializeStates();
        }
    }
}