using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuControl : MonoBehaviour
{
    [HideInInspector] public string color;
    [HideInInspector] public int sizeScale;
    [HideInInspector] public float explosionTimer;
    [HideInInspector] public bool explosionTimerIsActive;

    [SerializeField] private GameDataSO data;

    [SerializeField] Button colorButton;
    [SerializeField] Text sizeScaleText;
    [SerializeField] Slider timerSlider;
    [SerializeField] GameObject timerSliderGO;
    [SerializeField] Text timerText;
    [SerializeField] Text explosionActivateButtonText;


    private void Start()
    {
        color = data.Color;
        sizeScale = data.SizeScaleFactor;
        explosionTimer = data.ExplosionTimer;
        explosionTimerIsActive = data.ExplosionTimerIsActive;


        // open - close explosion timer
        if (!explosionTimerIsActive)
        {
            timerSliderGO.SetActive(false);
            explosionActivateButtonText.text = "Activate";
        }
        else
        {
            timerSliderGO.SetActive(true);
            explosionActivateButtonText.text = "Deactivate";
        }


        // set color
        if (color=="black")
        {
            colorButton.image.color = Color.black;
        }
        else if (color == "red")
        {
            colorButton.image.color = Color.red;
        }


        //set timer
        timerSlider.value = explosionTimer;
        timerText.text = explosionTimer.ToString("F2");
        //set size
        sizeScaleText.text = sizeScale.ToString();

    }

    public void StartGame()
    {
        data.Color = color;
        data.SizeScaleFactor = sizeScale;
        data.ExplosionTimer = explosionTimer;
        data.ExplosionTimerIsActive = explosionTimerIsActive;
        SaveManager.SaveData(data);
        SceneManager.LoadScene("Level 1");
    }

    public void ChangeColor()
    {
        if (color == "black")
        {
            colorButton.image.color= Color.red;
            color = "red";
        }
        else
        {
            colorButton.image.color = Color.black;
            color = "black";
        }
    }

    public void SetSize()
    {
        if (sizeScale >= 4)
        {
            sizeScale = 0;
        }
        sizeScale++;
        sizeScaleText.text = sizeScale.ToString();        
    }
    
    public void ToggleExplosionTimer()
    {
        if (!explosionTimerIsActive)
        {
            timerSliderGO.SetActive(true);
            explosionTimerIsActive = true;
            explosionActivateButtonText.text = "Deactivate";
        }
        else
        {
            timerSliderGO.SetActive(false);
            explosionTimerIsActive = false;
            explosionActivateButtonText.text = "Activate";
        }

    }

    public void SetExplosionTimer()
    {
        explosionTimer = timerSlider.value;
        timerText.text = explosionTimer.ToString("F2");
    }
}
