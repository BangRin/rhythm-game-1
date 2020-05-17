using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public GameObject prefab;
    public List<GameObject> objPool = new List<GameObject>();

    void Start()
    {
        Instance = this;
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objPool.Add(obj);
        }
    }

    public static void SaveObject(GameObject obj)
    {
        Instance.objPool.Add(obj);
        obj.SetActive(false);
    }

    public static GameObject LoadObject()
    {
        if (Instance.objPool.Count > 0)
        {
            var obj = Instance.objPool[0];
            Instance.objPool.Remove(obj);
            obj.SetActive(true);
            return obj;
        }

        GameObject obj2 = Instantiate(Instance.prefab);
        obj2.SetActive(true);
        return obj2;
    }
    public static void ClearPool()
    {
        foreach(var obj in Instance.objPool)
        {
            Destroy(obj);
        }
        Instance.objPool.Clear();
    }
}
