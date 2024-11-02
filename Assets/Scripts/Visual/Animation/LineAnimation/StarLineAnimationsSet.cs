using System;
using StarsProject.Animation;
using StarsProject.Misc;

namespace StarsProject.Visual.Animation
{
    public class StarLineAnimationsSet
    {
        private StarLineVisualSet starLineSet;
        private LineAnimation[] lineAnimations;
        private OpacityAnimation[] opacityAnimations;
        private StarAnimation[] starAnimations;
        
        public int AnimationsCount => opacityAnimations.Length;
        
        public StarLineAnimationsSet(StarLineVisualSet starLineSet, AnimationConfig drawLineConfig, AnimationConfig opacityConfig, AnimationConfig starScaleConfig)
        {
            this.starLineSet = starLineSet;
            
            var lineCount = this.starLineSet.Lines.Length;
            
            lineAnimations = new LineAnimation[lineCount];
            opacityAnimations = new OpacityAnimation[lineCount];
            starAnimations = new StarAnimation[lineCount];
            
            for (var i = 0 ; i < lineCount; i++)
            {
                var line = this.starLineSet.Lines[i];
                
                lineAnimations[i] = new LineAnimation(line.LineVisual, drawLineConfig);
                opacityAnimations[i] = new OpacityAnimation(line.LineVisual, opacityConfig);
                starAnimations[i] = new StarAnimation(line.From, starScaleConfig);
            }
            
            RefreshPositions();
        }
        
        public void RefreshPositions()
        {
            for (var i = 0; i < lineAnimations.Length; i++)
            {
                var lineAnim = lineAnimations[i];
                var startLine = starLineSet.Lines[i];

                var fromStar = startLine.From.Star;
                var toStar = startLine.To.Star;

                var fromPos = fromStar.Coordinate.ToVector3();
                var toPos = toStar.Coordinate.ToVector3();
                
                var direction = (toPos - fromPos) / 2;
                var middlePoint = (fromPos + toPos) / 2;
                
                lineAnim.From = middlePoint - direction * 0.9f;
                lineAnim.To = middlePoint + direction * 0.9f;
            }
        }
        
        public void UpdateSelf()
        {
            foreach (var animation in lineAnimations)
            {
                animation.UpdateSelf();
            }
            
            foreach (var animation in opacityAnimations)
            {
                animation.UpdateSelf();
            }
            
            foreach (var animation in starAnimations)
            {
                animation.UpdateSelf();
            }
        }

        public void ShowStarAnimation()
        {
            foreach (var animation in starAnimations)
            {
          //      animation.Show();
            }
        }
        
        public void ShowLineAnimations(bool force = false, Action finishedCallback = null)
        {
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
        
        public void HideLines(bool force, Action finishedCallback = null)
        {
            if (force)
            {
                foreach (var lineAnimation in lineAnimations)
                {
                    lineAnimation.ForceDisappear();
                }
                
                finishedCallback?.Invoke();
                return;
            }

            foreach (var lineAnimation in lineAnimations)
            {
                lineAnimation.Disappear(finishedCallback);
            }
        }
        
        public void StopLineAnimations()
        {
            foreach (var lineAnimation in lineAnimations)
            {
                lineAnimation.Stop();
            }
        }
        
        public void ShowOpacity(bool force = false, Action finishedCallback = null)
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