using StarsProject.Constellations;
using StarsProject.Visual;
using UnityEngine;

namespace StarsProject
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private ConstellationConfig config;
        [SerializeField] private ConstellationVisualiser visualiser;
        
        private void Start()
        {
            visualiser.Show(config);
        }
    }
}