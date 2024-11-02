using StarsProject.Animation;
using StarsProject.Misc;
using UnityEngine;

namespace StarsProject.Visual
{
    public class LineVisual : MonoBehaviour, ILinePositionsChangeable, IOpacityChangeable
    {
        [field: SerializeField] public LineRenderer LineRenderer { get; private set; }

        public void SetPoints(Vector3 from, Vector3 to)
        {
            LineRenderer.SetPositions(new[] { from, to });
        }

        public void SetOpacity(float alpha)
        {
            LineRenderer.startColor = LineRenderer.startColor.SetOpacity(alpha);
            LineRenderer.endColor = LineRenderer.endColor.SetOpacity(alpha);
        }

        public void SetWidth(float starLineWidth)
        {
            LineRenderer.startWidth = starLineWidth;
            LineRenderer.endWidth = starLineWidth;
        }
    }
}