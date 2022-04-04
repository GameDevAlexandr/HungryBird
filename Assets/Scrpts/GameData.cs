using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private float flapPowerIns;
    [SerializeField] private float speedBreathIns;
    [SerializeField] private float oneFlapStrenghtIns;
    [SerializeField] private SaveDataScript saveDataScript;
    private static SaveDataScript saveData;
    public static float flapPower =2;
    public static float speedBreath =0.015f;
    public static float oneFlapStrenght = 0.05f;
    public static int score;
    public static int butterflyCount;
    public static int comboCount;
    private void Awake()
    {
        saveData = saveDataScript;
        flapPower = flapPowerIns;
        speedBreath = speedBreathIns;
        oneFlapStrenght = oneFlapStrenghtIns;
        score = 0;
        butterflyCount = 0;
        comboCount = 0;
    }
    public static void SaveData()
    {
        for (int i = 0; i < 3; i++)
        {
            if(score > saveData.scores[i])
            { 
                for (int j = 2; j > i; j--)
                {
                    saveData.scores[j] = saveData.scores[j - 1];
                }
                saveData.scores[i] = score;
                break;
            }
        }
    }
}
