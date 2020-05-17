﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NoteManager : MonoBehaviour
{
    #region 싱글톤
    public static NoteManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<NoteManager>();
            return _instance;
        }
    }
    private static NoteManager _instance;
    #endregion

    public static List<Note> Notes = new List<Note>();
    public static List<Key> Keys = new List<Key>();

    public Transform noteParent;
    public Note notePrefab;

    public void MakeNote(KeyCode _keyCode)
    {
        Key target = Keys.FirstOrDefault(item => item.keyCode == _keyCode);

        if(target == null)
        {
            Debug.LogError("키를 찾을 수 없습니다.");
            return;
        }

        var obj = Instantiate(notePrefab.gameObject, noteParent);
        obj.transform.position = target.transform.position + Vector3.up * 800f;
        obj.transform.localScale = target.transform.localScale;
        var script = obj.GetComponent<Note>();
        script.Init(_keyCode);
        Notes.Add(script);
    }
}