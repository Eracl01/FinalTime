using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spike : MonoBehaviour
{
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
            check = true;
            StartCoroutine(ExampleCoroutine());
            Debug.Log(GameObject.Find("GameManager").GetComponent<GameManager>().DonerHp);
            

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
            yield return new WaitForSeconds(0.5f);
            PlayerDamageCollider.isTrigger = true;
            playerspeed.enabled = true;
            check = false;
        }
    }


}
