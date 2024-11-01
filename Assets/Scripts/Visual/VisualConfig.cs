using UnityEngine;

namespace StarsProject.Visual
{
    [CreateAssetMenu(menuName = "Assets/Constellation visual config", fileName = "Constellation visual config")]
    public class VisualConfig : ScriptableObject
    {
        [field: SerializeField] public float BorderOffset { get; private set; }
        [field: SerializeField] public SpriteVisual SpriteVisual { get; private set; }
        [field: SerializeField] public LineVisual LineVisual { get; private set; }
    }
}