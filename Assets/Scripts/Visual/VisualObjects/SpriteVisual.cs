using StarsProject.Misc;
using UnityEngine;

namespace StarsProject.Visual
{
    public class SpriteVisual : MonoBehaviour
    {
        [field: SerializeField] protected SpriteRenderer Renderer { get; private set; }

        public void SetColor(Color color) => Renderer.color = color;
        public void SetSprite(Sprite starTex) => Renderer.sprite = starTex;
        public void SetOpacity(float alpha) => Renderer.color = Renderer.color.SetOpacity(alpha);
    }
}