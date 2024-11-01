using System;
using System.Collections.Generic;
using System.Linq;
using StarsProject.Constellations;
using StarsProject.Misc;
using UnityEngine;


namespace StarsProject.Visual.Utils
{
    public class CameraSetter
    {
        public void SetCamera(Camera camera, Vector2 size, float offset, Dictionary<uint, Star> stars, CelestialCoordinate center)
        {
            Vector3 camPos = size / 2;
            camPos.z = -10;
            camera.transform.position = camPos;

            var firstStar = stars.Values.First();
            var minY = firstStar.coordinate.ToVector3(center, size).y;
            var maxY = minY;

            foreach (var star in stars.Values)
            {
                var starY = star.coordinate.ToVector3(center, size).y;
                
                minY = Math.Min(starY, minY);
                maxY = Math.Max(starY, maxY);
            }

            var camSize = (maxY - minY) / 2;
            camera.orthographicSize = camSize + offset;
        }
    }
}