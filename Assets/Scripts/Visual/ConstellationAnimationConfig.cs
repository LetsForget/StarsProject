using StarsProject.Animation;
using UnityEngine;

namespace StarsProject.Visual.Animation
{
    [CreateAssetMenu(menuName = "Assets/Constellation animation config", fileName = "Constellation animation config")]
    public class ConstellationAnimationConfig : ScriptableObject
    {
        [field: SerializeField] public AnimationConfig PreviewOpacityConfig { get; private set; }
        [field: SerializeField] public AnimationConfig LineOpacityConfig { get; private set; }
        [field: SerializeField] public AnimationConfig LineDrawConfig { get; private set; }
    }
}