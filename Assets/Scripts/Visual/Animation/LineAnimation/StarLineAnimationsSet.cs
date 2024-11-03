using System;
using StarsProject.Animation;
using StarsProject.CelestialCoordinates;

namespace StarsProject.Visual.Animation
{
    public class StarLineAnimationsSet
    {
        private StarLineVisualSet starLineSet;
        
        private LineAnimation[] lineAnims;
        private OpacityAnimation[] opacityAnims;
        private StarAnimation[] starAnims;
        
        public int AnimationsCount => opacityAnims.Length;

        public StarLineAnimationsSet(StarLineVisualSet starLineSet, AnimationConfig drawLineConfig,
            AnimationConfig opacityConfig, AnimationConfig starScaleConfig)
        {
            this.starLineSet = starLineSet;

            var lineCount = this.starLineSet.Lines.Length;

            lineAnims = new LineAnimation[lineCount];
            opacityAnims = new OpacityAnimation[lineCount];
            starAnims = new StarAnimation[lineCount];

            for (var i = 0; i < lineCount; i++)
            {
                var line = this.starLineSet.Lines[i];

                lineAnims[i] = new LineAnimation(line.LineVisual, drawLineConfig);
                opacityAnims[i] = new OpacityAnimation(line.LineVisual, opacityConfig);
                starAnims[i] = new StarAnimation(line.To, starScaleConfig);
            }

            RefreshPositions();
        }

        #region Opacity animations

        public void Appear(bool force = false, Action finishedCallback = null)
        {
            if (force)
            {
                foreach (var anim in opacityAnims)
                {
                    anim.ForceComplete();
                }
                
                finishedCallback?.Invoke();
                return;
            }
            
            foreach (var anim in opacityAnims)
            {
                anim.PlayForward(finishedCallback);
            }
        }
        
        public void Disappear(bool force = false, Action finishedCallback = null)
        {
            if (force)
            {
                foreach (var anim in opacityAnims)
                {
                    anim.ForceIncomplete();
                }
                
                finishedCallback?.Invoke();
                return;
            }
            
            foreach (var anim in opacityAnims)
            {
                anim.PlayBackward(finishedCallback);
            }
        }

        #endregion

        #region Draw line animations

        public void RunLineAnimations(bool force = false, Action finishedCallback = null)
        {
            if (force)
            {
                foreach (var lineAnimation in lineAnims)
                {
                    lineAnimation.ForceComplete();
                }
                
                finishedCallback?.Invoke();
                return;
            }

            foreach (var lineAnimation in lineAnims)
            {
                lineAnimation.PlayForward(finishedCallback);
            }
        }

        public void StopLineAnimations()
        {
            foreach (var lineAnimation in lineAnims)
            {
                lineAnimation.Stop();
            }
        }
        
        public void ResetLineAnimations()
        {
            foreach (var lineAnimation in lineAnims)
            {
                lineAnimation.ForceIncomplete();
            }
        }
        
        #endregion

        #region Star animations

        public void RunStarAnimations() 
        {
            foreach (var animation in starAnims)
            {
                animation.Show();
            }
        }

        #endregion
        
        public void UpdateSelf()
        {
            foreach (var animation in lineAnims)
            {
                animation.UpdateSelf();
            }
            
            foreach (var animation in opacityAnims)
            {
                animation.UpdateSelf();
            }
            
            foreach (var animation in starAnims)
            {
                animation.UpdateSelf();
            }
        }
        
        public void RefreshPositions()
        {
            for (var i = 0; i < lineAnims.Length; i++)
            {
                var lineAnim = lineAnims[i];
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
    }
}