using System;
using StarsProject.Animation;
using StarsProject.CelestialCoordinates;
using StarsProject.Constellations;
using UnityEngine;

namespace StarsProject.Visual.Animation
{
    public class PreviewAnimation
    {
        private PreviewData previewData;
        private SpriteVisual visual;
        
        private OpacityAnimation animation;

        public PreviewAnimation(PreviewData previewData, SpriteVisual visual, AnimationConfig config)
        {
            this.previewData = previewData;
            this.visual = visual;
            
            animation = new OpacityAnimation(visual, config);
            
            RefreshPosition();
        }
        
        public void Appear(bool force = false, Action finishedCallback = null)
        {
            if (force)
            {
                animation.ForceComplete();
                finishedCallback?.Invoke();
                return;
            }

            animation.PlayForward(finishedCallback);
        }
        
        public void UpdateSelf()
        {
            animation.UpdateSelf();
        }
        
        public void Disappear(bool force = false, Action finishedCallback = null)
        {
            if (force)
            {
                animation.ForceIncomplete();
                finishedCallback?.Invoke();
                return;
            }

            animation.PlayBackward(finishedCallback);
        }
        
        public void RefreshPosition()
        {
            visual.transform.localScale = CelestialCoordinateConverter.GetScale(previewData.Scale);
            visual.transform.position = previewData.Coordinate.ToVector3();
            visual.transform.rotation = Quaternion.AngleAxis(previewData.Angle, -Vector3.forward);
        }
    }
}