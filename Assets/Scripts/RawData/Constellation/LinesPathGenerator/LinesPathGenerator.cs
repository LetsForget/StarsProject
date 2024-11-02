using System.Collections.Generic;
using System.Linq;
using StarsProject.Constellations;
using StarsProject.Misc;

namespace StarsProject.RawData.Constellations
{
    public static class LinesPathGenerator
    {
        public static LineQueuePart[] GenerateLinePaths(LineData[] lineDatas, Dictionary<uint, Star> stars,
            CelestialCoordinate center)
        {
            var tree = GenerateTree(lineDatas);
            return GeneratePath(tree, stars, center);
        }

        private static List<PointTreePart> GenerateTree(LineData[] lineDatas)
        {
            var rawTreeParts = new Dictionary<uint, List<uint>>();
            var treeParts = new Dictionary<uint, PointTreePart>();

            foreach (var line in lineDatas)
            {
                if (rawTreeParts.TryGetValue(line.from, out var childs))
                {
                    childs.Add(line.to);
                    continue;
                }

                var part = new List<uint> { line.to };
                rawTreeParts.Add(line.from, part);

                treeParts.Add(line.from, new PointTreePart(line.from));
            }

            foreach (var rawTreePart in rawTreeParts)
            {
                var treePart = treeParts[rawTreePart.Key];

                foreach (var index in rawTreePart.Value)
                {
                    if (!treeParts.TryGetValue(index, out var child))
                    {
                        child = new PointTreePart(index);
                        treeParts.Add(index, child);
                    }

                    child.Parents.Add(treePart);

                    treePart.Children.Add(treeParts[index]);
                }
            }

            return treeParts.Values.ToList();
        }

        private static LineQueuePart[] GeneratePath(List<PointTreePart> parts, Dictionary<uint, Star> stars,
            CelestialCoordinate center)
        {
            var startPart = parts.OrderBy(p => stars[p.Index].Coordinate.Distance(center)).First();

            var linePaths = new Dictionary<int, LineQueuePart>();
            
            FillPath(linePaths, 0, startPart, true);
            FillPath(linePaths, 0, startPart, false);

            return linePaths.OrderBy(line => line.Key)
                            .Select(pair => pair.Value)
                            .ToArray();
        }

        private static void FillPath(Dictionary<int, LineQueuePart> linePaths, int depth, PointTreePart startPart,
            bool direction)
        {
            var parts = direction ? startPart.Children : startPart.Parents;

            foreach (var part in parts)
            {
                FillPath(linePaths, depth + 1, part, direction);
                
                if (!linePaths.TryGetValue(depth, out var oneTimeLines))
                {
                    oneTimeLines = new LineQueuePart();
                    linePaths.Add(depth, oneTimeLines);
                }

                oneTimeLines.Lines.Add(new LineInfo(startPart.Index, part.Index));
            }
        }
    }
}