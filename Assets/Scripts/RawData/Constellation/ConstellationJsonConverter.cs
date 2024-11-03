using System.Collections.Generic;
using StarsProject.CelestialCoordinates;
using UnityEngine;
using StarsProject.Constellations;
using StarsProject.Misc;

namespace StarsProject.RawData.Constellations
{
    public static class ConstellationJsonConverter
    {
        public static List<Constellation> Convert(string dataText)
        {
            var container = JsonUtility.FromJson<ConstellationsContainer>(dataText);

            var constellations = new List<Constellation>();

            foreach (var data in container.items)
            {
                var constellation = ConvertConstellation(data);
                constellations.Add(constellation);
            }

            return constellations;
        }

        private static Constellation ConvertConstellation(ConstellationData data)
        {
            var name = data.name;
            var center = new CelestialCoordinate(data.ra, data.dec);
            var imageInfo = ConvertImageData(data.image);
            var stars = ConvertStarsArray(data.stars);
            var lines = LinesPathGenerator.GenerateLinePaths(data.pairs, stars, center);
            
            return new Constellation(name, center, imageInfo, stars, lines);
        }
        
        private static PreviewData ConvertImageData(ImageData data)
        {
            var center = new CelestialCoordinate(data.ra, data.dec);
            return new PreviewData(center, data.scale, data.angle);
        }

        private static Dictionary<uint, StarsProject.Constellations.StarData> ConvertStarsArray(StarData[] starDatas)
        {
            var stars = new Dictionary<uint, StarsProject.Constellations.StarData>();
            
            for (var i = 0; i < starDatas.Length; i++)
            {
                var id = starDatas[i].id;

                if (stars.TryGetValue(id, out _))
                {
                    Debug.LogError("Stars with same ids!");
                    continue;
                }

                var star = ConvertStar(starDatas[i]);
                stars.Add(id, star);
            }

            return stars;
            
            StarsProject.Constellations.StarData ConvertStar(StarData data)
            {
                var coord = new CelestialCoordinate(data.ra, data.dec);
                var color = ColorUtils.HexToColor(data.color);

                return new StarsProject.Constellations.StarData(coord, color, data.magnitude);
            }
        }
    }
}