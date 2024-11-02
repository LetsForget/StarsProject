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
        
        public AnimationStateMachine(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimationsSets, IndexContainer setIndexContainer)
        {
            this.previewAnimation = previewAnimation;
            this.starLineAnimationsSets = starLineAnimationsSets;
            this.setIndexContainer = setIndexContainer;
            
            InitializeStates();
            
            ChangeState(AnimationStateType.Hided);
        }

        protected override void InitializeStates()
        {
            states = new Dictionary<AnimationStateType, AnimationState>
            {
                { AnimationStateType.Hided, new HidedState(previewAnimation, starLineAnimationsSets, setIndexContainer) },
                { AnimationStateType.Hiding, new HidingState(previewAnimation, starLineAnimationsSets, setIndexContainer)},
                { AnimationStateType.ShowingFromStart, new ShowingFromStartState(previewAnimation, starLineAnimationsSets, setIndexContainer)},
                { AnimationStateType.ShowingFromHiding, new ShowingFromHidingState(previewAnimation, starLineAnimationsSets, setIndexContainer)},
                { AnimationStateType.Shown, new ShownState(previewAnimation, starLineAnimationsSets, setIndexContainer)}
            };

            base.InitializeStates();
        }
    }
}