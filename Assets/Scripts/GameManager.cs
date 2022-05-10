using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     
    public GameObject playersprite;
    public Collider2D PlayerDamageCollider;
    public GameObject spike;
    public GameObject donerTest;
    public ParticleSystem blood;
    public float otbros = 2;
    public int DonerHp;
    public GameObject Donerimg1;
    public GameObject Donerimg2;
    public GameObject Donerimg3;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        DonerHp = 1;
        donerTest = GameObject.FindGameObjectWithTag("doner");
    }

    public void Dead()
    {
        
            GameObject player = GameObject.Find("Player");
            Movement playerspeed = player.GetComponent<Movement>();
            playerspeed.speed = 0f;
            playerspeed.jumpforce = 0f;
            Object.Destroy(playersprite);
            ParticleBlood();
    }
    public void Damage()
    {
        DonerHp--;
        //Vector3 dir = (playersprite.transform.position - spike.transform.position).normalized;
        //rb.AddForce(dir * 5.0F, ForceMode2D.Impulse);
        rb.velocity = new Vector2(-transform.localScale.x, 0) * otbros;

        //GetComponent<Movement>().enabled = false;
                
        if (DonerHp == 2)
        {
            Donerimg1.SetActive(true);
            Donerimg2.SetActive(true);
            Donerimg3.SetActive(false);
        }
        else if (DonerHp == 3)
        {
            Donerimg1.SetActive(true);
            Donerimg2.SetActive(true);
            Donerimg3.SetActive(true);
        }
        else if(DonerHp == 1)
        {
            Donerimg1.SetActive(true);
            Donerimg2.SetActive(false);
            Donerimg3.SetActive(false);
        }
        else
        {
            Donerimg1.SetActive(false);
            Donerimg2.SetActive(false);
            Donerimg3.SetActive(false);
        }

        if (DonerHp >= 4)
        {
            DonerHp = 3;
        }
        if (DonerHp == 0)
        {
            Dead();
        }
    }

    
    public void Restart()
    {   
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HP()
    {
        
        
        DonerHp++;
        Debug.Log(DonerHp);
        if (DonerHp == 2)
        {
            Donerimg1.SetActive(true);
            Donerimg2.SetActive(true);
            Donerimg3.SetActive(false);
        }
        else if (DonerHp == 3)
        {
            Donerimg1.SetActive(true);
            Donerimg2.SetActive(true);
            Donerimg3.SetActive(true);
        }
        else
        {
            Donerimg1.SetActive(true);
            Donerimg2.SetActive(false);
            Donerimg3.SetActive(false);
        }

        if (DonerHp >= 4)
        {
            DonerHp = 3;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void ParticleBlood()
    {
        blood.Play();

    }
}
