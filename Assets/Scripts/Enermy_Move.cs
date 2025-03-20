using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Enermy_Move : MonoBehaviour
{   public float speed = 1;
    public GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.position += (player.transform.position - gameObject.transform.position).normalized*speed*Time.deltaTime;
    }
}
