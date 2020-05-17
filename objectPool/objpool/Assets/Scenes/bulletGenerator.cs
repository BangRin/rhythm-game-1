using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGenerator : MonoBehaviour
{
    public GameObject Prefab;


    public void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            var obj = ObjectPool.LoadObject();
            obj.transform.position = transform.position;
        }
        if(Input.GetKey(KeyCode.W))
        {
            ObjectPool.ClearPool();
        }
    }
}
