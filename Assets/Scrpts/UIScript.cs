using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private Text ScoreInPanel;
    [SerializeField] private Text eatinText;
    [SerializeField] private Text comboText;
    [SerializeField] private Image stranghtImage;
    [SerializeField] private SaveDataScript saveData;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Image[] butters;
    [SerializeField] private Text[] ratingText;
    [HideInInspector] public float score = 0;
    private int[] butterTypes = new int[3];
    private bool isStartedMenu;
    // Start is called before the first frame update
    void Start()
    {
        if(scoreText)
        scoreText.text = "0";
        BirdMovemenScript.birdDownEvent.AddListener(Finish);
        StrenghtScript.addButterEvent.AddListener(addButter);
        ControlScript.startMenuEvent.AddListener(StartMenu);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        score+=0.05f;
        if(scoreText)
        scoreText.text = ((int)score).ToString();
    }
    private void Finish() 
    {
        Time.timeScale = 0;
        GameData.score = (int)score;
        ScoreInPanel.text = GameData.score.ToString();
        eatinText.text = GameData.butterflyCount.ToString();
        comboText.text = GameData.comboCount.ToString();
        GameData.SaveData(); 
        for (int i = 0; i < 3; i++)
        {
            ratingText[i].text = saveData.scores[i].ToString();
        }
        finishPanel.SetActive(true);
    }
    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }
    public void Pause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    private void addButter(int type)
    {
        if (butterTypes[0] == 0)
        {
            butterTypes[0] = type;
            ButterForUI(0, type);
        }
        else
        {
            for (int i = 1; i < 3; i++)
            {
                if (butterTypes[i] == 0 && butterTypes[i - 1] == type)
                {
                    butterTypes[i] = type;
                    ButterForUI(i, type);
                    if (i == 2)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            butterTypes[k] = 0;
                            ButterForUI(k, 0);
                        }
                        stranghtImage.fillAmount += 0.3f;
                        GameData.comboCount++;
                    }
                    break;
                }
                if (butterTypes[i - 1] != type)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == 0)
                        {
                            butterTypes[0] = type;
                        }
                        else
                        {
                            type = 0;
                            butterTypes[j] = 0;
                        }
                        ButterForUI(j, type);
                    }
                    break;
                }
            }
        }
    }
    private void ButterForUI(int index, int type)
    {
        if (type == 0)
        {
            butters[index].gameObject.SetActive(false);
        }
        else
        {
            butters[index].gameObject.SetActive(true);
        }
        switch (type)
        {
            case 1: butters[index].color = Color.blue;
                break;
            case 2: butters[index].color = Color.green;
                break;
            case 3: butters[index].color = Color.yellow;
                break;
        }
    }
    private void StartMenu()
    {
        isStartedMenu = !isStartedMenu;
        menuPanel.SetActive(isStartedMenu);
        Pause(isStartedMenu);
        GetComponent<AudioSource>().Play();
    }


}
