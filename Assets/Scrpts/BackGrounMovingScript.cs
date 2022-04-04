using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrounMovingScript : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
