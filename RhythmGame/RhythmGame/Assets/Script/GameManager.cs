using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    #region 싱글톤
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }
    private static GameManager _instance;
    #endregion

    public Text missCountText;
    public Text perfectCountText;
    public Text titleText;

    public VideoPlayer videoPlayer;

    private SongData currentSong;


    [HideInInspector]
    public int score;
    [HideInInspector]
    public int missCount
    {
        get
        {
            return _missCount;
        }
        set
        {
            missCountText.text = string.Format("Miss : {0}", value);
            _missCount = value;
        }
    }
    private int _missCount;

    [HideInInspector]
    public int perfectCount
    {
        get
        {
            return _perfectCount;
        }
        set
        {
            perfectCountText.text = string.Format("Perfect : {0}", value);
            _perfectCount = value;
        }
    }
    private int _perfectCount;


    private void Awake()
    {
        missCount = 0;
        perfectCount = 0;
    }

    public void LoadData()
    {
        var path = 
            EditorUtility.OpenFilePanel("오픈 할 json 파일", "", ".json");
        var jsonStr = System.IO.File.ReadAllText(path);
        SongData data = JsonUtility.FromJson<SongData>(jsonStr);
        PlayGame(data);
    }



    public void PlayGame(SongData data)
    {
        titleText.text = $"{data.author} - {data.title}";
        videoPlayer.clip = Resources.Load<VideoClip>(data.bgVideo);
        videoPlayer.Play();
        currentSong = data;
    }

    private void Update()
    {
        if (currentSong == null) return;


        for(int i = currentSong.noteDatas.Count - 1; i >= 0; i--)
        {
            var item = currentSong.noteDatas[i];
            if (Mathf.Abs((float)(item.time - videoPlayer.time)) < 0.05f)
            {
                NoteManager.Instance.MakeNote(item.keyCode);
                currentSong.noteDatas.RemoveAt(i);
            }
        }
    }
}
