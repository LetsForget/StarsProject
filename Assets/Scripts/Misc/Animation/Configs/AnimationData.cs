using System;
using UnityEngine;

namespace StarsProject.Animation
{
    [Serializable]
    public class AnimationData
    {
        [field: SerializeField] public AnimationCurve Curve { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
        [field: SerializeField] public bool UseReversedCurve { get; private set; }
        
        public AnimationCurve ReversedCurve
        {
            get
            {
                if (_reversedCurve == null || _reversedCurve.keys.Length <= 1)
                {
                    var sampleCount = 100;
                    var _reversedCurve = new AnimationCurve();
                        
                    var timeStep = (Curve.keys[^1].time - Curve.keys[0].time) / sampleCount;
                        
                    for (var i = 0; i <= sampleCount; i++)
                    {
                        var time = Curve.keys[0].time + i * timeStep;
                        var value = Curve.Evaluate(time);
                            
                        _reversedCurve.AddKey(new Keyframe(value, time));
                    }
                }

                return _reversedCurve;
            }
        }

        private AnimationCurve _reversedCurve;
    }
}