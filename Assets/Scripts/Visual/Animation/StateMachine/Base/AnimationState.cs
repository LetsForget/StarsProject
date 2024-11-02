﻿using StarsProject.Misc.StateMachine;

namespace StarsProject.Visual.Animation.States
{
    public abstract class AnimationState : State<AnimationStateType>
    {
        protected PreviewAnimation previewAnimation;
        protected StarLineAnimationsSet[] starLineAnimSets;
        protected IndexContainer indexContainer;

        protected AnimationState(PreviewAnimation previewAnimation, StarLineAnimationsSet[] starLineAnimSets, IndexContainer indexContainer)
        {
            this.previewAnimation = previewAnimation;
            this.starLineAnimSets = starLineAnimSets;
            this.indexContainer = indexContainer;
        }

        public override void Update()
        {
            previewAnimation.UpdateSelf();
            
            foreach (var lineSet in starLineAnimSets)
            {
                lineSet.UpdateSelf();
            }
        }
        
        public virtual void WantsToShow() { }
        
        public virtual void WantsToHide() { }
    }
}