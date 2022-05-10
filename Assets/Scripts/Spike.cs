using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spike : MonoBehaviour
{
    public GameObject player;
    public GameObject spike;
    public Rigidbody2D rb;
    public Collider2D PlayerDamageCollider;
    private bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            GameObject.Find("GameManager").GetComponent<GameManager>().Damage();
            //Vector3 dir = (player.transform.position - spike.transform.position).normalized;
            //rb.AddForce(dir * 3.0F, ForceMode2D.Impulse);
            check = true;
            StartCoroutine(ExampleCoroutine());


        }
    }
    IEnumerator ExampleCoroutine()
    {
        while (check)
        {
            PlayerDamageCollider.isTrigger = false;
            GameObject player = GameObject.Find("Player");
            Movement playerspeed = player.GetComponent<Movement>();
            playerspeed.enabled = false;
            yield return new WaitForSeconds(2);
            PlayerDamageCollider.isTrigger = true;
            playerspeed.enabled = true;
            check = false;
        }
    }


}
