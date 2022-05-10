using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingWoodAnimTrigger : MonoBehaviour
{
    public GameObject objWood;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Break", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            StartCoroutine(Timer());
            
        }
    }

    IEnumerator Timer()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        anim.SetBool("Break", true);
        yield return new WaitForSeconds(1);
        Destroy(objWood);


    }
}
