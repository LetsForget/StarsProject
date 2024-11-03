using UnityEngine;

namespace StarsProject.Constellations
{
    public class ConstellationConfig : ScriptableObject
    {
        [field: SerializeField] public Constellation Constellation { get; private set; }
        [field: SerializeField] public Sprite Star { get; private set; }
        [field: SerializeField] public Sprite Preview { get; private set; }
        
        [field: SerializeField] public float PreviewAddAngle { get; private set; }
        [field: SerializeField] public Vector3 PreviewAddScale { get; private set; }
    }
}