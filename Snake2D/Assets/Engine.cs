using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Enable Spawner
        this.transform.Find("Pick-Up").gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
