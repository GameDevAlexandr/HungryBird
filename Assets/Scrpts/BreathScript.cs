using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathScript : MonoBehaviour
{
   public static float breathPower = 0;
    private float speedBreath;
    private Image breathIndicator;
    private void Start()
    {
        breathIndicator = GetComponent<Image>();
        speedBreath = GameData.speedBreath;
    }

    private void FixedUpdate()
    {
        breathPower += speedBreath;
        if (breathPower >= 1||breathPower<=0)
        {
            speedBreath = -speedBreath;
        }
        breathIndicator.fillAmount = breathPower;
    }
}
