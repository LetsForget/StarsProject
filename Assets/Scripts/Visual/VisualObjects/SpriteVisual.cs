using StarsProject.Animation;
using StarsProject.Misc;
using UnityEngine;

namespace StarsProject.Visual
{
    public class SpriteVisual : MonoBehaviour, IOpacityChangeable, IScaleChangeable
    {
        [field: SerializeField] protected SpriteRenderer Renderer { get; private set; }

        public void SetColor(Color color) => Renderer.color = color;
        public void SetSprite(Sprite starTex) => Renderer.sprite = starTex;
        public void SetOpacity(float alpha) => Renderer.color = Renderer.color.SetOpacity(alpha);
        public void SetScale(float scale) => Renderer.transform.localScale = Vector3.one * scale;
        public void SetScale(Vector3 scale) => Renderer.transform.localScale = scale;
        public void SetRotation(float angle) => Renderer.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}