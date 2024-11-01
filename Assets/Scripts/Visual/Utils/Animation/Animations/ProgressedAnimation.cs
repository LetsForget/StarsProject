using System;
using UnityEngine;

namespace StarsProject.Visual.Animation
{
    public abstract class ProgressedAnimation
    {
        public event Action Finished;
        
        protected AnimationConfig config;
        protected PlaybackState state;
        
        protected float time;
        protected float progress;
        
                
        public void Appear() => SetState(PlaybackState.Forward, config.AppearData.Duration, 
            config.AppearData.ReversedCurve);

        public void Disappear() => SetState(PlaybackState.Backward, config.DisappearData.Duration,
            config.DisappearData.ReversedCurve);
        
        public void UpdateSelf()
        {
            if (state == PlaybackState.Finished)
            {
                return;
            }

            AnimationData animData;
            if (state == PlaybackState.Forward)
            {
                animData = config.AppearData;
                time += Time.deltaTime;
            }
            else
            {
                animData = config.DisappearData;
                time -= Time.deltaTime;
            }
            
            var normalisedTime = time / animData.Duration;
            progress = animData.Curve.Evaluate(normalisedTime);
            
            if (time > animData.Duration || time < 0)
            {
                state = PlaybackState.Finished;
                Finished?.Invoke();
            }
            
            UpdateAnimation();
        }

        protected abstract void UpdateAnimation();
        
        protected void SetState(PlaybackState newState, float duration, AnimationCurve reversedCurve)
        {
            if (state == newState)
            {
                return;
            }

            state = newState;

            time = Mathf.Clamp(time, 0f, duration);
            time = reversedCurve.Evaluate(progress) * duration;
        }
    }
}