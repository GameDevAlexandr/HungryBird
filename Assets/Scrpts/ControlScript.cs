using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlScript : MonoBehaviour
{
    public static UnityEvent flapWingsEvent = new UnityEvent();
    public static UnityEvent startMenuEvent = new UnityEvent();
    private float betweenFlapTime = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&Time.timeScale!=0)
        {
            if (Time.time - betweenFlapTime > 0.2f)  
            {
                flapWingsEvent.Invoke();
                betweenFlapTime = Time.time;
            }            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            startMenuEvent.Invoke();
        }
    }
}
