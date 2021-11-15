using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get => instance; set => instance = value; }



    [Header("GamePlay")]
    [SerializeField] GameObject gamePlayPanel;
    [SerializeField] Text bulletCounterText;
    [SerializeField] GameObject settingsPanel;

    private int bulletCount=0;
    private bool isSettingPanelActive;
      

    private void Awake()
    {
        if (instance == null)
            instance = this;

        gamePlayPanel.SetActive(true);
        bulletCounterText.text = bulletCount.ToString();
        settingsPanel.SetActive(false);
    }

    public void SetBulletCount(int count)
    {
        bulletCount += count;
        bulletCounterText.text = bulletCount.ToString();
    }

    public void SettingsButton()
    {

        if (!isSettingPanelActive)
        {
            isSettingPanelActive = true;
            settingsPanel.SetActive(true);
            EventManager.isSettingPanelActive?.Invoke(true);
        }
        else
        {
            isSettingPanelActive = false;
            settingsPanel.SetActive(false);
            EventManager.isSettingPanelActive?.Invoke(false);
        }

    }

}
