using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;


public class SteamTest : MonoBehaviour
{
    [SerializeField]
    Text _uiText;

    // Start is called before the first frame update
    void Start()
    {
        if (SteamManager.Initialized)
        {
            string name = SteamFriends.GetPersonaName();
            SteamFriends.ActivateGameOverlay("Players");
            _uiText.text = name;
        }
        else
            _uiText.text = "Failed";
    }
}
