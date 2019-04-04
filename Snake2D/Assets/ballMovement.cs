using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    const float speed = 0.06f;
    const float rotateSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime), 3);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime), -3);
        }
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name.Contains("Border"))
        {
            Destroy(gameObject);
        }
    }
}
