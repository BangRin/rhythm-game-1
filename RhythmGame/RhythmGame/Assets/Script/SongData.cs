using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// 오투잼 식으로 a,s,d,space,j,k,l 7key로 제작 예정
/// </summary>

public class SongData
{
    public string title;
    public string author;
    public double length;
    public string bgVideo;
    public Sprite loadingImage;

    [SerializeField]
    public List<NoteData> noteDatas = new List<NoteData>();
}
