using System.Collections;
using System.Collections.Generic;
//using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{   public float speed = 1;
    public GameObject player;
    [SerializeField] private float distance;
    private Vector3 dir;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        dir = (player.transform.position - gameObject.transform.position).normalized;
        Move();   
    }
    public void Move()
    {
        if ((transform.position - player.transform.position).magnitude <= distance)
            return;
        transform.position += dir * speed * Time.deltaTime;
    }
    public Vector2 GetDir()
    { 
        return new Vector2(dir.x, dir.y);
    }
}
