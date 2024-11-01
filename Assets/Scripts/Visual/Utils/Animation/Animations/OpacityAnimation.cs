using System.Collections.Generic;
using UnityEngine;

namespace StarsProject.Visual.Animation
{
    public class OpacityAnimation : ProgressedAnimation
    {
        private SpriteVisual previewVisual;
        private List<LineVisual> lineVisuals;
        
        protected override void UpdateAnimation()
        {
            previewVisual.SetOpacity(progress);
            
            foreach (var lineVisual in lineVisuals)
            {
                lineVisual.SetOpacity(progress);
            }
        }
    }
}