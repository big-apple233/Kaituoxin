using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    [SerializeField] private float dis;
    [SerializeField] private float speed = 5f;
    private bool isMove = false;
    private float nowDis;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        //StartBusMove(1000);
    }
    private void Update()
    {
        if (isMove == true)
        { 
            if(dis >=0)
                BusMove();
            else
                BusBack();
        }
    }
    private void BusMove()
    {
        if (nowDis >= dis)
        {
            isMove = false;
            nowDis = 0;
            animator.SetBool("isMove", false);
        }
        transform.Translate(new Vector2(-1 * speed * Time.deltaTime, 0));
        nowDis += speed * Time.deltaTime;
    }
    private void BusBack()
    {
        if (nowDis <= dis)
        {
            isMove = false;
            nowDis = 0;
            animator.SetBool("isMove", false);
        }
        transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        nowDis -= speed * Time.deltaTime;
    }
    public void StartBusMove(float dis)
    {
        this.dis = dis;
        isMove = true;
        nowDis = 0;
        animator.SetBool("isMove", true);
    }
}
