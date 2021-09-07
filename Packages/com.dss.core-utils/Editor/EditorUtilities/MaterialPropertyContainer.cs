using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace DSS.CoreUtils.EditorUtilities
{

public class PropertyFinder
{
    private MaterialProperty[] properties;

    public PropertyFinder(MaterialProperty[] properties)
    {
        this.properties = properties;
    }

    public MaterialProperty this[string name]
    {
        get { return FindPropertyByName(properties, name); }
    }

    private static MaterialProperty FindPropertyByName(MaterialProperty[] properties, string name)
    {
        foreach (MaterialProperty p in properties)
        {
            if (p.name.Equals(name))
            {
                return p;
            }
        }
        return null;
    }
}

}  // namespace DSS.CoreUtils.EditorUtilities
