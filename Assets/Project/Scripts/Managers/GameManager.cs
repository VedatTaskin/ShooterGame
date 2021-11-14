using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameDataSO data;

    // Start is called before the first frame update
    void Start()
    {
        SaveManager.LoadData(data);
    }


}
