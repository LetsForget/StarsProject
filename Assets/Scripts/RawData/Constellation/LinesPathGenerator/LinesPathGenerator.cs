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
            var usedParts = new HashSet<PointTreePart>();

            var currentStepParts = new List<PointTreePart>();
            currentStepParts.Add(startPart);
            
            var depth = 0;
     
            while (currentStepParts.Count != 0)
            {
                var newParts = new List<PointTreePart>();
                
                foreach (var stepPart in currentStepParts)
                {
                    if (!FillPath(linePaths, usedParts, depth, stepPart))
                    {
                        continue;
                    }
                    
                    newParts.AddRange(stepPart.Parents);
                    newParts.AddRange(stepPart.Children);
                }

                currentStepParts = newParts;
                
                depth += 1;
            }

            return linePaths.OrderBy(line => line.Key)
                            .Select(pair => pair.Value)
                            .ToArray();
        }

        private static bool FillPath(Dictionary<int, LineQueuePart> linePaths, HashSet<PointTreePart> usedParts, int depth, PointTreePart startPart)
        {
            if (usedParts.Contains(startPart))
            {
                return false;
            }

            var result = false;
            usedParts.Add(startPart);
            
            HandleParts(startPart.Children);
            HandleParts(startPart.Parents);

            return result;
            
            void HandleParts(List<PointTreePart> parts)
            {
                foreach (var nextPart in  parts)
                {
                    if (linePaths.SelectMany(x => x.Value.Lines).
                        Any(l =>
                        {
                            var firstCond = l.from == startPart.Index && l.to == nextPart.Index;
                            var secondCond = l.from == nextPart.Index && l.to == startPart.Index;
                            return firstCond || secondCond;
                        }))
                    {
                        continue;
                    }

                    if (!linePaths.TryGetValue(depth, out var oneTimeLines))
                    {
                        oneTimeLines = new LineQueuePart();
                        linePaths.Add(depth, oneTimeLines);
                    }

                    oneTimeLines.Lines.Add(new LineInfo(startPart.Index, nextPart.Index));
                    result = true;
                }
            }
        }
    }
}