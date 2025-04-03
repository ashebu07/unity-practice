using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : MonoBehaviour
{
    public GameObject settingPanel;

    void Start()
    {
        settingPanel.SetActive(false);
    }

    public void TogglePopup()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
    }
}
