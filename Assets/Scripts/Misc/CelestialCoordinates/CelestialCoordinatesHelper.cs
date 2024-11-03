using UnityEngine;

namespace StarsProject.CelestialCoordinates
{
    public class CelestialCoordinatesHelper
    {
        private CelestialCoordinate center;
        private Vector2 size;
        
        private static CelestialCoordinatesHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CelestialCoordinatesHelper();
                }

                return _instance;
            }
        }

        private static CelestialCoordinatesHelper _instance;

        public static Vector2 Size
        {
            get => Instance.size;
            set => Instance.size = value;
        }

        public static CelestialCoordinate Center
        {
            get => Instance.center;
            set => Instance.center = value;
        }
    }
}