using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float m_Speed;
    Rigidbody2D m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.velocity = transform.right * m_Speed;

    }


}
