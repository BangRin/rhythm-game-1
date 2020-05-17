using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text text;
    float exp = 0;
    public TestData data = new TestData();

    void Start()
    {
        var json = PlayerPrefs.GetString("Account/charData222", "");
        if (string.IsNullOrEmpty(json) == false)
        {
            data = JsonUtility.FromJson<TestData>(json);
        }
        else
        {
            data.name = "나는 바보다";
        }
        Debug.Log(data.name);
    }
    private void Update()
    {
        data.exp += 0.01f;
        text.text = data.exp.ToString();
        data.name = "나는 바보가 아니다";
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetString("Account/charData222", JsonUtility.ToJson(data));
        PlayerPrefs.Save();
    }
}


public class TestData
{
    public string name = "";
    public float exp = 0f;
}