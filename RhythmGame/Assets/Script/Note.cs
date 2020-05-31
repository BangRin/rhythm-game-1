using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public KeyCode keyCode;
    public float speed;

    public void Init(KeyCode _keyCode, float _speed = 300f)
    {
        keyCode = _keyCode;
        speed = _speed;
    }

    public void Hit(float dif)
    {
        if (dif > 50f)
            return;

        if(dif > 30f) // 30.1f ~ 50 사이는 미스
        {
            GameManager.Instance.missCount++;
        }
        else // 0 ~ 30 사이는 퍼팩트
        {
            GameManager.Instance.perfectCount++;
        }

        Remove();
    }

    void Remove()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -320)
            Remove();
    }
}
