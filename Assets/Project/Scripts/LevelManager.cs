using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameData data;

    void LoadNextLevel()
    {

        SceneManager.LoadScene("Level 1");
    }


}
