using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);

            instance = this;


        }
        else
        {
            DestroyObject(gameObject);
        }

    }

    public bool playerDie = false;
    public int score = 0;
    public float playTimeCurrent = 10f;
    public float playTimeMax = 10f;
    public bool StageClear = false;

    public float magnetTimeCurrent = 0;
    public float magnetTimeMax = 5f;

    public int stage = 0;
    public int stageView = 0;
}