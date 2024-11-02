using System;
using StarsProject.Animation;
using StarsProject.Misc;

namespace StarsProject.Visual.Animation
{
    public class StarLineAnimationsSet
    {
        private StarLineSet startLineSet;
        private LineAnimation[] lineAnimations;
        private OpacityAnimation[] opacityAnimations;

        public int AnimationsCount => opacityAnimations.Length;
        
        public StarLineAnimationsSet(StarLineSet startLineSet, AnimationConfig drawLineConfig, AnimationConfig opacityConfig)
        {
            this.startLineSet = startLineSet;
            var lineCount = this.startLineSet.Lines.Length;
            
            lineAnimations = new LineAnimation[lineCount];
            opacityAnimations = new OpacityAnimation[lineCount];
            
            for (var i = 0 ; i < lineCount; i++)
            {
                var line = this.startLineSet.Lines[i];
                
                var lineAnimation = new LineAnimation(line.LineVisual, drawLineConfig);
                lineAnimations[i] = lineAnimation;

                var opacityAnimation = new OpacityAnimation(line.LineVisual, opacityConfig);
                opacityAnimations[i] = opacityAnimation;
            }
            
            RefreshPositions();
        }
        
        public void RefreshPositions()
        {
            for (var i = 0; i < lineAnimations.Length; i++)
            {
                var lineAnim = lineAnimations[i];
                var startLine = startLineSet.Lines[i];

                lineAnim.From = startLine.From.Coordinate.ToVector3();
                lineAnim.To = startLine.To.Coordinate.ToVector3();
            }
        }
        
        public void UpdateSelf()
        {
            foreach (var animation in lineAnimations)
            {
                animation.UpdateSelf();
            }
        }

        public void ShowLineAnimation(bool force = false, Action finishedCallback = null)
        {
            Show(true);

            if (force)
            {
                foreach (var lineAnimation in lineAnimations)
                {
                    lineAnimation.ForceAppear();
                }
                
                finishedCallback?.Invoke();
                return;
            }

            foreach (var lineAnimation in lineAnimations)
            {
                lineAnimation.Appear(finishedCallback);
            }
        }
        
        public void StopLineAnimations()
        {
            foreach (var lineAnimation in lineAnimations)
            {
                lineAnimation.ForceAppear();
            }
        }
        
        public void Show(bool force = false, Action finishedCallback = null)
        {
            if (force)
            {
                foreach (var anim in opacityAnimations)
                {
                    anim.ForceAppear();
                }
                
                finishedCallback?.Invoke();
                return;
            }
            
            foreach (var anim in opacityAnimations)
            {
                anim.Appear(finishedCallback);
            }
        }
        
        public void HideOpacity(bool force = false, Action finishedCallback = null)
        {
            if (force)
            {
                foreach (var anim in opacityAnimations)
                {
                    anim.ForceDisappear();
                }
                
                finishedCallback?.Invoke();
                return;
            }
            
            foreach (var anim in opacityAnimations)
            {
                anim.Disappear(finishedCallback);
            }
        }
    }
}