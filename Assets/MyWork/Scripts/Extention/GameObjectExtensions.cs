using UnityEngine;
using System.Linq;

public static class GameObjectExtensions
{
    public static T GetComponentByInterface<T>(this GameObject gameObject) where T : class
    {
        
        Component[] components = gameObject.GetComponents<Component>();
        return components.OfType<T>().FirstOrDefault();
    }
}
