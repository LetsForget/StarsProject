using System;
using UnityEngine;

namespace StarsProject.Animation
{
    public abstract class ProgressedAnimation
    {
        protected AnimationConfig config;
        protected PlaybackState state;
        
        protected float time;
        protected float progress;

        private Action finishedCallback;
        
        protected ProgressedAnimation(AnimationConfig config)
        {
            this.config = config;
        }

        public void Appear(Action finishedCallback = null)
        {
            SetState(PlaybackState.Forward, config.AppearData.Duration, config.AppearData.ReversedCurve);
            this.finishedCallback = finishedCallback;
        } 

        public void ForceAppear()
        {
            var dur = config.AppearData.Duration;
            var prog = config.AppearData.Curve.Evaluate(1);
            
            ForceFinishWithValues(dur, prog);
        }

        public void Disappear(Action finishedCallback = null)
        {
            SetState(PlaybackState.Backward, config.DisappearData.Duration, config.DisappearData.ReversedCurve);
            this.finishedCallback = finishedCallback;
        } 

        public void ForceDisappear()
        {
            var prog = config.DisappearData.Curve.Evaluate(0);
            ForceFinishWithValues(0, prog);
        }

        public void Stop()
        {
            state = PlaybackState.NotActive;
        }
        
        public void UpdateSelf()
        {
            if (state == PlaybackState.NotActive)
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
                state = PlaybackState.NotActive;

                if (finishedCallback != null)
                {
                    finishedCallback.Invoke();
                    finishedCallback = null;
                }
            }
            
            UpdateAnimation();
        }

        protected abstract void UpdateAnimation();
        
        private void SetState(PlaybackState newState, float duration, AnimationCurve reversedCurve)
        {
            if (state == newState)
            {
                return;
            }

            state = newState;

            time = Mathf.Clamp(time, 0f, duration);

            if (config.UseReversedCurve)
            {
                time = reversedCurve.Evaluate(progress) * duration;
            }
        }

        private void ForceFinishWithValues(in float time, in float progress)
        {
            this.time = time;
            this.progress = progress;

            UpdateAnimation();

            state = PlaybackState.NotActive;
        }
    }
}