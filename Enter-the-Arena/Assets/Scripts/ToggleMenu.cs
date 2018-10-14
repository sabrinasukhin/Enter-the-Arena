using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ToggleMenu : MonoBehaviour
{
    public GameObject menu;
    private bool isVisible;

    private SteamVR_TrackedObject lcon;
    private SteamVR_TrackedObject rcon;

    void Start()
    {
        lcon = GetComponent<SteamVR_TrackedObject>();
        rcon = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isVisible = !isVisible;
            menu.SetActive(isVisible);
        }

        if (isVisible)
        {
            Time.timeScale = 0f;
        }

        else if (!isVisible)
        {
            Time.timeScale = 1.0f;
        }
    }
}
