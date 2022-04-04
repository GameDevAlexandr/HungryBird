using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StrenghtScript : MonoBehaviour
{
    public static UnityEvent<int> addButterEvent = new UnityEvent<int>();
    private Image strenghtIndicator;
    private BirdMovemenScript bms;
    [SerializeField] private Animator beakAnimation;
    [SerializeField] AudioSource omnom;
    void Start()
    {
        strenghtIndicator = GetComponent<Image>();
        ControlScript.flapWingsEvent.AddListener(Flap);
        BirdMovemenScript.birdDownEvent.AddListener(BirdDown);
        bms = GameObject.Find("Bird").GetComponent<BirdMovemenScript>();
    }
    private void Flap()
    {
        strenghtIndicator.fillAmount -= GameData.oneFlapStrenght;
        if (strenghtIndicator.fillAmount <= 0)
        {
            bms.strenghtOver = true;
        }
        if (strenghtIndicator.fillAmount < 0.7f)
        {
            strenghtIndicator.color = Color.yellow;
        }
        if (strenghtIndicator.fillAmount < 0.35f)
        {
            strenghtIndicator.color = Color.red;
        }
    }
    public void addStrenght(float strenght, int type)
    {
        if (strenghtIndicator.fillAmount >= 0.35f)
        {
            strenghtIndicator.color = Color.yellow;
        }
        if (strenghtIndicator.fillAmount >= 0.7f)
        {
            strenghtIndicator.color = Color.green;
        }
        strenghtIndicator.fillAmount += strenght;
        beakAnimation.Play("BirdBeakAnimation");
        bms.strenghtOver = false;
        GameData.butterflyCount++;
        omnom.Play();
        addButterEvent.Invoke(type);
    }
    private void BirdDown()
    {
        strenghtIndicator.fillAmount = 0;
    }
}
