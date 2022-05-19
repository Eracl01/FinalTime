using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     
    public GameObject playersprite;
    public GameObject donerTest;
    public ParticleSystem blood;
    public float otbros = 2;
    public int DonerHp;
    public GameObject Donerimg1;
    public GameObject Donerimg2;
    public GameObject Donerimg3;
    public Rigidbody2D rb;
    public GameObject PauseMenu;
    public GameObject WinMenu;
    public GameObject DeadMenu;
    public GameObject UI;


    private bool start = false;
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
            DeadMenu.SetActive(true);
            UI.SetActive(false);
    }
    public void Damage()
    {
        DonerHp--;

        rb.velocity = new Vector2(-transform.localScale.x, 0) * otbros;

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

    public void DeathFromEnemy()
    {
        DonerHp = 0;
        Donerimg1.SetActive(false);
        Donerimg2.SetActive(false);
        Donerimg3.SetActive(false);

        GameObject player = GameObject.Find("Player");
        Movement playerspeed = player.GetComponent<Movement>();
        playerspeed.enabled = false;

        GameObject enemy = GameObject.Find("Enemy");
        EnemyMovement enemySpeed = enemy.GetComponent<EnemyMovement>();
        Animator enemyAnimator = enemy.GetComponent<Animator>();

        start = true;
        if (DonerHp == 0)
        {

            enemySpeed.m_Speed = 0;
            
            StartCoroutine(CoroutineAnim());

            
            
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
        if (Input.GetKeyDown("r"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Restart();
        }
    }

    void ParticleBlood()
    {
        blood.Play();

    }
    IEnumerator CoroutineAnim()
    {
        GameObject enemy = GameObject.Find("Enemy");
        Animator enemyAnimator = enemy.GetComponent<Animator>();
        while (start)
        {
            enemyAnimator.SetBool("RetakeKill", true);
            yield return new WaitForSeconds(0.3f);
            Dead();
            start = false;
        }
    }


    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        UI.SetActive(false);
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        DeadMenu.SetActive(false);
        UI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void NextLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
       
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Win()
    {
        WinMenu.SetActive(true);
        Time.timeScale = 0f;
        UI.SetActive(false);
    }

}
