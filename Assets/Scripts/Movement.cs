using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public Animator anim;
    public ParticleSystem dust;
    public bool isGrounded;
    

    private Rigidbody2D rg;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D()
    {
        isGrounded = true;
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;


        if (Input.GetKeyDown("r"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Restart();
        }


        if (!Mathf.Approximately(0, movement))
        {
            
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
           

        }
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            isGrounded = false;
            rg.AddForce(new Vector3(0, jumpforce, 0), ForceMode2D.Impulse);
        }

        if (movement >= 0.1f || movement <= -0.1f)
        {
           
            anim.SetBool("Walk", true);
            ParticleDust();
            

        }

        else if (movement == 0f)
        {
            anim.SetBool("Walk", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "doner")
        {
            Destroy(other.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().HP();
        }

        if (other.tag == "enemy")
        {
            
            GameObject.Find("GameManager").GetComponent<GameManager>().DeathFromEnemy();
            
        }
    }


    void ParticleDust()
    {
        dust.Play();
    }
}
