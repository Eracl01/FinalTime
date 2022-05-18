using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearTextures : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject trap;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            trap.SetActive(true);

        }
    }
}
