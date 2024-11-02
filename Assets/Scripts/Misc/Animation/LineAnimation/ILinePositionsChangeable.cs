using UnityEngine;

namespace StarsProject.Animation
{
    public interface ILinePositionsChangeable
    {
        void SetPoints(Vector3 from, Vector3 to);
    }
}