using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData",menuName = "GameData/GameData")]
public class GameData : ScriptableObject
{
    public int SizeScaleFactor;
    public float ExplosionTimer;
    public string Color;
}
