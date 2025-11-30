namespace _2019.Day6;

public class Day6Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");

        var spaceObjects = ParseSpaceObjects(rows);

        var orbiting = new Dictionary<string, int>();

        var result = 0;
        
        foreach (var spaceObject in spaceObjects)
        {
            result += CountOrbitedObjects(orbiting, spaceObject, spaceObjects);
        }
        
        return result;
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

public class SpaceObject(string name)
{
    public string Name { get; set; } = name;
    public string? OrbitingSpaceObject { get; set; } = null;
}