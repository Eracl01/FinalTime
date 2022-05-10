using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterLife : MonoBehaviour
{
    public GameObject Doner;
    public int GGHP;
    // Start is called before the first frame update
    void Start()
    {
        GGHP = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GGHP++;
            Destroy(Doner);
        }
    }
}
