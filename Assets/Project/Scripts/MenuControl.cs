using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuControl : MonoBehaviour
{
    public string color;
    public int sizeScale;
    public float explosionTimer;
    [SerializeField] Button colorButton;
    [SerializeField] Text sizeScaleText;
    [SerializeField] Slider timerSlider;
    [SerializeField] Text timerText;

    private void Start()
    {
        color = PlayerPrefs.GetString("Color");
        sizeScale = PlayerPrefs.GetInt("SizeScale");
        explosionTimer = PlayerPrefs.GetFloat("ExplosionTimer");


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
        PlayerPrefs.SetString("Color", color);
        PlayerPrefs.SetInt("SizeScale", sizeScale);
        PlayerPrefs.SetFloat("ExplosionTimer", explosionTimer);
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

    public void SetExplosionTimer()
    {
        explosionTimer = timerSlider.value;
        timerText.text = explosionTimer.ToString("F2");
    }
}
