namespace _2019.Day6;

public class Day6Part2 : Part<int>
{
 public override int Run(string input)
    {
        var rows = input.Split("\r\n");

        var spaceObjects = ParseSpaceObjects(rows);

        var orbiting = new Dictionary<string, int>();

        var youObject = spaceObjects.First(so => so.Name == "YOU");
        var sanObject = spaceObjects.First(so => so.Name == "SAN");

        var youPath = FindPathToStart(youObject, spaceObjects);
        var sanPath = FindPathToStart(sanObject, spaceObjects);

        var commonPoint = "";
        
        for (var i = 0; i < youPath.Count; i++)
        {
            if (youPath[i] == sanPath[i])
            {
                continue;
            }

            commonPoint = youPath[i - 1];
            break;
        }

        var result = CountPathToPoint(youPath, commonPoint) + CountPathToPoint(sanPath, commonPoint);
        
        return result;
    }

    private static int CountPathToPoint(List<string> path, string point)
    {
        var result = 0;
        for (var i = path.Count - 2; i >= 0; i--)
        {
            if(path[i] == point) break;
            result++;
        }

        return result;
    }

    private static List<string> FindPathToStart(SpaceObject currentObject, List<SpaceObject> spaceObjects)
    {
        if (currentObject.OrbitingSpaceObject is null)
        {
            return [currentObject.Name];
        }

        var path = FindPathToStart(spaceObjects.First(so => so.Name == currentObject.OrbitingSpaceObject),
            spaceObjects);
        
        path.Add(currentObject.Name);
        
        return path;
    }

    private static int CountOrbitedObjects(Dictionary<string, int> mainOrbiting, SpaceObject currentObject, List<SpaceObject> spaceObjects)
    {
        if (currentObject.OrbitingSpaceObject is null)
        {
            mainOrbiting.TryAdd(currentObject.Name, 0);
            return 0;
        }

        if (mainOrbiting.TryGetValue(currentObject.OrbitingSpaceObject, out var value))
        {
            mainOrbiting.TryAdd(currentObject.Name, value + 1);
            return value + 1;
        }

        var objectsCount = CountOrbitedObjects(mainOrbiting, spaceObjects.First(so => so.Name == currentObject.OrbitingSpaceObject), spaceObjects);

        mainOrbiting.Add(currentObject.Name, objectsCount + 1);

        return objectsCount + 1;
    }

    private static List<SpaceObject> ParseSpaceObjects(string[] rows)
    {
        var spaceObjects = new List<SpaceObject>();

        foreach (var row in rows)
        {
            var data = row.Split(")");

            var orbitedObject = spaceObjects.FirstOrDefault(so => so.Name == data[0]);
            
            if (orbitedObject == null)
            {
                orbitedObject = new SpaceObject(data[0]);
                spaceObjects.Add(orbitedObject);
            }
            
            var orbitingObject = spaceObjects.FirstOrDefault(so => so.Name == data[1]);
            if (orbitingObject == null)
            {
                orbitingObject = new SpaceObject(data[1]);
                spaceObjects.Add(orbitingObject);
            }
            orbitingObject.OrbitingSpaceObject = orbitedObject.Name;
        }

        return spaceObjects;
    }
}