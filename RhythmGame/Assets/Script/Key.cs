using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Key : MonoBehaviour
{
    public KeyCode keyCode;
    public Image image;

    private void Awake()
    {
        NoteManager.Keys.Add(this);
    }
    void Update()
    {
        if(Input.GetKeyDown(keyCode)) // 누른 시점
        {
            NoteManager.Notes.RemoveAll(t => t == null);
            foreach (var note in NoteManager.Notes.Where(t => t.keyCode == keyCode))
            {
                var dif = Mathf.Abs(this.transform.position.y - note.transform.position.y);
                if (dif > 50f)
                    continue;
                note.Hit(dif);
            }
        }

        if(Input.GetKey(keyCode)) // 누르고 있을 때
            image.color = Color.red;
        else
            image.color = Color.white;

    }
}
