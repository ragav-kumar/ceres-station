namespace CeresStation.Model;

public static class TypeHelper
{
    public static Type GetType(string typeName) =>
        Type.GetType($"CeresStation.Model.{typeName}")
        ?? throw new ArgumentException($"Type {typeName} not found");
}
