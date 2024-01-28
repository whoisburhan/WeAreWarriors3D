using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledIbjectInfo> ObjectPools = new List<PooledIbjectInfo>();

    public static GameObject SpawnObject(GameObject objectToSpwan, Vector3 spawnPosition, Quaternion spawnRotation) 
    {
        PooledIbjectInfo pool = ObjectPools.Find(p => p.LookUpString == objectToSpwan.name);

        // If pool doesn't exist
        if(pool == null) 
        {
            pool = new PooledIbjectInfo() { LookUpString = objectToSpwan.name };
            ObjectPools.Add(pool);
        }

        //if there any inactive objects in the pool
        GameObject spawnableObj = pool.InactiveIbjects.FirstOrDefault();

        if(spawnableObj == null) 
        {
            spawnableObj = Instantiate(objectToSpwan, spawnPosition, spawnRotation);
        }
        else 
        {
            spawnableObj.transform.position = spawnPosition;
            spawnableObj.transform.rotation = spawnRotation;
            pool.InactiveIbjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }

        return spawnableObj;
    }

    public static void ReturnObjectToPool(GameObject obj) 
    {
        string goName = obj.name.Substring(0,obj.name.Length - 7);
        PooledIbjectInfo pool = ObjectPools.Find(p => p.LookUpString == goName);

        if(pool == null)
        {
            Debug.LogWarning("Trying to release an object that is not pooled" + obj.name);
        }
        else 
        {
            obj.SetActive(false);
            pool.InactiveIbjects.Add(obj);
        }
    }
}

public class PooledIbjectInfo 
{
    public string LookUpString;
    public List<GameObject> InactiveIbjects = new List<GameObject>(); 
}
