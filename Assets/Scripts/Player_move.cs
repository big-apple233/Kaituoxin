using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{ public float speed;
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.position -= new Vector3(speed*Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.W))
            gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.S))
            gameObject.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }
}
