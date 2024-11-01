using UnityEngine;

namespace StarsProject.Visual.Animation
{
    [CreateAssetMenu(menuName = "Assets/Constellation animation config", fileName = "Constellation animation config")]
    public class AnimationConfig : ScriptableObject
    {
        [field: SerializeField] public AnimationData AppearData { get; private set; }
        [field: SerializeField] public AnimationData DisappearData { get; private set; }
    }
}