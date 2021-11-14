using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static void SaveData(GameDataSO gameData)
    {
        string dataString = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("data", dataString);
    }

    public static void LoadData(GameDataSO gameData)
    {
        if (!PlayerPrefs.HasKey("data"))
        {
            SaveData(gameData);
            return;
        }

        string dataString = PlayerPrefs.GetString("data");
        JsonUtility.FromJsonOverwrite(dataString, gameData);
    }
}
