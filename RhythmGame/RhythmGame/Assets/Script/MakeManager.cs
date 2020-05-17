using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class MakeManager : MonoBehaviour
{
    #region 싱글톤
    public static MakeManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<MakeManager>();
            return _instance;
        }
    }
    private static MakeManager _instance;
    #endregion


    public VideoPlayer player;
    public Text keysUI;

    private SongData currentSongData;
    
    private void Start()
    {
        currentSongData = new SongData();
        currentSongData.length = player.length;
        currentSongData.title = "Memories";
        currentSongData.author = "Marron5";
        currentSongData.bgVideo = "bgVideo";
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            MakeNote(KeyCode.A);
        if (Input.GetKeyDown(KeyCode.S))
            MakeNote(KeyCode.S);
        if (Input.GetKeyDown(KeyCode.D))
            MakeNote(KeyCode.D);
        if (Input.GetKeyDown(KeyCode.Space))
            MakeNote(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.J))
            MakeNote(KeyCode.J);
        if (Input.GetKeyDown(KeyCode.K))
            MakeNote(KeyCode.K);
        if (Input.GetKeyDown(KeyCode.L))
            MakeNote(KeyCode.L);
    }

    

    public void MakeNote(KeyCode code)
    {
        NoteData target = new NoteData();
        target.keyCode = code;
        target.time = player.time;
        currentSongData.noteDatas.Add(target);

        keysUI.text = $"현재 키 : {currentSongData.noteDatas.Count}개";
    }

    public void Save()
    {
        var str = JsonUtility.ToJson(currentSongData);
        var path = EditorUtility.SaveFilePanel("저장 위치", ""
            , $"{currentSongData.author}-{currentSongData.title}"
            , ".json");

        File.WriteAllText(path, str);
    }
}
