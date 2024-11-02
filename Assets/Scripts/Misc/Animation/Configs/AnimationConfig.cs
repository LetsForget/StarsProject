using UnityEngine;

namespace StarsProject.Animation
{
    [CreateAssetMenu(menuName = "Assets/Animation config", fileName = "Animation config")]
    public class AnimationConfig : ScriptableObject
    {
        [field: SerializeField] public AnimationData AppearData { get; private set; }
        [field: SerializeField] public AnimationData DisappearData { get; private set; }
    }
}