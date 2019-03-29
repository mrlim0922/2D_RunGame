using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image PlayTimeBar;

    public GameObject[] NumberImage;
    public Sprite[] Number;

    public GameObject EndPanel;

    public GameObject[] StageMap;
    public GameObject LoadMap;
    public Text StageText;



    void Start()
    {
        SoundManager.Instance.PlaySound("BG_Sound");
        if(DataManager.Instance.StageClear == false)
        {
            DataManager.Instance.score = 0;
            DataManager.Instance.playerDie = false;
            DataManager.Instance.playTimeCurrent = DataManager.Instance.playTimeMax;
        } else
        {
            DataManager.Instance.playerDie = false;
            DataManager.Instance.StageClear = false;
        }



    }

    void Update()
    {
        //스테이지 보여주기.
        if (DataManager.Instance.stage == 0)
        {
            StageText.text = "START";
        }
        else
        {
            StageText.text = "STAGE " + DataManager.Instance.stageView.ToString();
        }

        if (DataManager.Instance.playerDie == false)
        {
            DataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime;
            PlayTimeBar.fillAmount = DataManager.Instance.playTimeCurrent / DataManager.Instance.playTimeMax;

            //시간 되면 죽이기.
            if (DataManager.Instance.playTimeCurrent < 0)
            {
                DataManager.Instance.playerDie = true;
                SoundManager.Instance.StopSound("BG_Sound");
                EndPanel.SetActive(true);
            }

            if (DataManager.Instance.magnetTimeCurrent > 0)
            {
                DataManager.Instance.magnetTimeCurrent -= 1 * Time.deltaTime;
            }
        }

        //넘버 띄우기.
        int temp = DataManager.Instance.score / 10000;
        NumberImage[0].GetComponent<Image>().sprite = Number[temp];

        int temp2 = DataManager.Instance.score % 10000;
        temp2 = temp2 / 1000;
        NumberImage[1].GetComponent<Image>().sprite = Number[temp2];

        int temp3 = DataManager.Instance.score % 1000;
        temp3 = temp3 / 100;
        NumberImage[2].GetComponent<Image>().sprite = Number[temp3];

        int temp4 = DataManager.Instance.score % 100;
        temp4 = temp4 / 10;
        NumberImage[3].GetComponent<Image>().sprite = Number[temp4];

        int temp5 = DataManager.Instance.score % 10;
        NumberImage[4].GetComponent<Image>().sprite = Number[temp5];

    }

    public void ReStart_Button()
    {
        DataManager.Instance.stage = 0;
        DataManager.Instance.stageView = 0;
        SceneManager.LoadScene("play");
    }

    public void Next_Stage()
    {
        DataManager.Instance.stage += 1;
        DataManager.Instance.stageView += 1;

        if (DataManager.Instance.stage > StageMap.Length)
        {
            DataManager.Instance.stage = DataManager.Instance.stage % StageMap.Length;
            if (DataManager.Instance.stage == 0)
                DataManager.Instance.stage = StageMap.Length;
        }
        StageStart();
    }

    public void Load_Stage()
    {

        LoadMap.transform.position = new Vector3(15f, LoadMap.transform.position.y, LoadMap.transform.position.z);
        LoadMap.SetActive(true);  //로드맵 열기.

    }

    void StageStart()  //스테이지 시작.
    {
        for (int temp = 1; temp <= StageMap.Length; temp++)
        {
            if (temp == DataManager.Instance.stage)
            {
                StageMap[temp - 1].transform.position = new Vector3(15f, StageMap[temp - 1].transform.position.y, StageMap[temp - 1].transform.position.z);
                StageMap[temp - 1].SetActive(true);
            }
            else
            {
                StageMap[temp - 1].SetActive(false);
            }
        }
    }

}
