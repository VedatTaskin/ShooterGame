using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData",menuName = "GameData/GameData")]
public class GameDataSO : ScriptableObject
{
    public int SizeScaleFactor;
    public float ExplosionTimer;
    public string Color;
}
