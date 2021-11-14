using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get => instance; set => instance = value; }

    [Header("GamePlay")]
    [SerializeField] GameObject gamePlayPanel;
    [SerializeField] Text bulletCounterText;

    private int bulletCount=0;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        gamePlayPanel.SetActive(true);
        bulletCounterText.text = bulletCount.ToString(); 
    }

    public void SetBulletCount(int count)
    {
        bulletCount += count;
        bulletCounterText.text = bulletCount.ToString();
    }


}
