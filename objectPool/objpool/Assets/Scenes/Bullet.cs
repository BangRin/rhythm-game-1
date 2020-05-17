using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * 0.1f;

        if (transform.position.y >= 7.5f)
        {
            ObjectPool.SaveObject(this.gameObject);
        }
    }
}
