using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehav : MonoBehaviour
{
    public float Speed;
    public GameObject Player;
    public GameObject Camera;
    public float walls1;
    public float walls2;



    void FixedUpdate()
    {
        Vector3 target = new Vector3()
        {
            x = Player.transform.position.x,
            y = Player.transform.position.y ,
            z = Player.transform.position.z - 10,
        };
        Vector3 pos = Vector3.Lerp(Camera.transform.position, target, Speed * Time.fixedDeltaTime);

        Camera.transform.position = pos;
    }
}
