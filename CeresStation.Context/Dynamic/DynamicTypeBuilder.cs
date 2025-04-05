using System.Collections.Concurrent;
using System.Reflection;
using System.Reflection.Emit;

namespace CeresStation.Core;

/// <summary>
/// Construct a dynamic DTO class that corresponds to the provided properties
/// </summary>
public static class DynamicTypeBuilder
{
    private static readonly ConcurrentDictionary<string, Type> typeCache = new();

    public static Type GetDynamicType(List<PropertyInfo> properties)
    {
        string typeName = "DynamicDto_" + string.Join("_", properties.Select(p => p.Name));

        // Get from dictionary if possible 
        if (typeCache.TryGetValue(typeName, out Type? existingType))
        {
            return existingType;
        }

        // Create a dynamic assembly for our type
        AssemblyName assemblyName = new("DynamicDtoAssembly");
        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Public | TypeAttributes.Class);
        
        foreach (PropertyInfo prop in properties)
        {
            FieldBuilder fieldBuilder = typeBuilder.DefineField($"_{prop.Name}", prop.PropertyType, FieldAttributes.Private);
            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(prop.Name, PropertyAttributes.HasDefault, prop.PropertyType, null);

            MethodBuilder getterBuilder = typeBuilder.DefineMethod($"get_{prop.Name}",
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                prop.PropertyType, Type.EmptyTypes);

            ILGenerator getterIl = getterBuilder.GetILGenerator();
            getterIl.Emit(OpCodes.Ldarg_0);
            getterIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getterIl.Emit(OpCodes.Ret);

            MethodBuilder setterBuilder = typeBuilder.DefineMethod($"set_{prop.Name}",
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                null, [prop.PropertyType]);

            ILGenerator setterMsil = setterBuilder.GetILGenerator();
            setterMsil.Emit(OpCodes.Ldarg_0);
            setterMsil.Emit(OpCodes.Ldarg_1);
            setterMsil.Emit(OpCodes.Stfld, fieldBuilder);
            setterMsil.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getterBuilder);
            propertyBuilder.SetSetMethod(setterBuilder);
        }

        // Finalize type, cache, return.
        Type generatedType = typeBuilder.CreateType();
        typeCache.TryAdd(typeName, generatedType);
        return generatedType;
    }
}
