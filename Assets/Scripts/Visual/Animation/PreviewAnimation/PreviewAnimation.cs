using System;
using StarsProject.Animation;
using StarsProject.Constellations;
using StarsProject.Misc;
using UnityEngine;

namespace StarsProject.Visual.Animation
{
    public class PreviewAnimation
    {
        private ImageInfo imageInfo;
        private SpriteVisual visual;
        
        private OpacityAnimation animation;

        public PreviewAnimation(ImageInfo imageInfo, SpriteVisual visual, AnimationConfig config)
        {
            this.imageInfo = imageInfo;
            this.visual = visual;
            
            animation = new OpacityAnimation(visual, config);
            
            RefreshPosition();
        }

        public void RefreshPosition()
        {
            visual.transform.localScale = CelestialCoordinateConverter.GetScale(imageInfo.scale);
            visual.transform.position = imageInfo.coordinate.ToVector3();
            visual.transform.rotation = Quaternion.AngleAxis(imageInfo.angle, -Vector3.forward);
        }

        public void UpdateSelf()
        {
            animation.UpdateSelf();
        }
        
        public void Show(bool force = false, Action finishedCallback = null)
        {
            if (force)
            {
                animation.ForceAppear();
                finishedCallback?.Invoke();
                return;
            }

            animation.Appear(finishedCallback);
        }
        
        public void Hide(bool force = false, Action finishedCallback = null)
        {
            if (force)
            {
                animation.ForceDisappear();
                finishedCallback?.Invoke();
                return;
            }

            animation.Disappear(finishedCallback);
        }
    }
}