using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float eatCount;
    [SerializeField] private GameObject wings;
    [SerializeField] private int type;
    private StrenghtScript ss;
    // Start is called before the first frame update
    void Start()
    {
        ss = GameObject.Find("StrenghtIndicator").GetComponent<StrenghtScript>(); 
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bird")
        {
            ss.addStrenght(eatCount,type);
            GameObject newWings =  GameObject.Instantiate(wings, transform.position, Quaternion.identity);
            Destroy(newWings, 3);
        }
        Destroy(gameObject);
    }
}
