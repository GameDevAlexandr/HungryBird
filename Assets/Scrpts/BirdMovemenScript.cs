using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BirdMovemenScript : MonoBehaviour
{
    public static UnityEvent birdDownEvent = new UnityEvent();
    private float flapPower;
    private Rigidbody2D birdBody;
    private Animator animatorBird;
    [SerializeField] private ParticleSystem downEffect;
    [SerializeField] private AudioSource wingsAudio;
    public bool strenghtOver;

    void Start()
    {
        flapPower = GameData.flapPower;
        birdBody = GetComponent<Rigidbody2D>();
        ControlScript.flapWingsEvent.AddListener(FlapWings);
        Physics.gravity = new Vector3(0, 0.3f, 0);
        animatorBird = GetComponent<Animator>();
        
    }
    private void FlapWings()
    {
        if (!strenghtOver)
        {
            birdBody.AddForce(Vector2.up * (flapPower + flapPower * BreathScript.breathPower*1.5f), ForceMode2D.Impulse);
            animatorBird.Play("BirdFlyAnimation");
            wingsAudio.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animatorBird.Play("DownAnimation");
            downEffect.Play();
            collision.gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(AfterDown());
        }
    }
    IEnumerator AfterDown()
    {
        yield return new WaitForSeconds(2);
        birdDownEvent.Invoke();
    }

}
