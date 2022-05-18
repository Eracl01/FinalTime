using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSpike : MonoBehaviour
{
    public float speed;
    public GameObject flyingspike;

    public bool rotationright;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        if (gameObject.activeSelf == true)
        {
            if (rotationright)
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Hit");
            Destroy(flyingspike);
        }
    }



}
