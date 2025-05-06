using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private Person_character enemyCharacter;
    [SerializeField] private Enemy_Move enemyMove;
    [SerializeField] private Person_attack enemyAttack;
    [SerializeField] private AnimationControl enemyAnimationControl;
    [SerializeField] private Transform player;
    [SerializeField] private float attackCd;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ChatBubbleFollow chatBubbleFollow;
    [SerializeField] private float dieCd;
    [SerializeField] private bool canAttack;
    [SerializeField] private int id;
    private int dir;
    private bool isAttack;
    private void Awake()
    {
        enemyMove.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        chatBubbleFollow = GetComponent<ChatBubbleFollow>();
    }
    private void Update()
    {
        UpdateDir();
        UpdateEnemyAnimation();
        if (enemyCharacter.IsMonster() == false)
            return;
        else
        {
            chatBubbleFollow.recTransform.GetComponent<InteractableObject>().nowText = chatBubbleFollow.recTransform.GetComponent<InteractableObject>().affectedText;
            chatBubbleFollow.recTransform.GetComponent<Button>().enabled = false;
        }
        if (enemyCharacter.IsDead())
        {
            StartCoroutine(Die());   
            return;
        }
        if (enemyCharacter.IsAffected() == false)
        {
            if(isAttack == false)
                enemyMove.enabled = true;
            if(canAttack)
                Attack();
        }
        else 
        {
            enemyMove.enabled = false;
        }
        
    }
    private IEnumerator Die()
    { 
        enemyMove.enabled=false;
        yield return new WaitForSeconds(dieCd);
        Destroy(gameObject);
    }
    private void Attack()
    {
        if ((transform.position - player.position).magnitude <= 1 && isAttack == false)
        {
            isAttack = true;
            enemyMove.enabled = false;
            if(enemyCharacter.IsAffected() == false)
                enemyAttack.Attack();
            StartCoroutine(CancelAttack());
        }
    }
    private IEnumerator CancelAttack()
    {
        enemyAnimationControl.SetParameter("isAttack");
        yield return new WaitForSeconds(attackCd);
        isAttack = false;
        enemyMove.enabled = true;
    }
    private void UpdateDir()
    { 
        Vector2 dir = enemyMove.GetDir();
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0)
            {
                this.dir = 2;
                enemyAttack.SetOffset(new Vector2(0.5f, 0));
            }
            else
            { 
                this.dir = 3;
                enemyAttack.SetOffset(new Vector2(-0.5f, 0));
            }
        }
        else
        {
            if (dir.y > 0)
            {
                this.dir = 1;
                enemyAttack.SetOffset(new Vector2(0, 0.5f));
            }
            else
            { 
                this.dir = 0;
                enemyAttack.SetOffset(new Vector2(0, -0.5f));
            }
        }
    }
    private void UpdateEnemyAnimation()
    {
        if (enemyCharacter.IsMonster() == false)
            return;
        if (enemyCharacter.IsDead())
        {
            enemyAnimationControl.SetParameter("isDie", true);
            print(gameObject.name + "À¿Õˆ");
            return;
        }
        /*if (isAttack)
        { 
            enemyAnimationControl.SetParameter("isAttack");
            return;
        }*/
        enemyAnimationControl.SetParameter("isWalk", true);
        enemyAnimationControl.SetParameter("dir", dir);

    }
    private void OnDisable()
    {
        enemyMove.enabled = false;
        enemyAttack.enabled = false;
        enemyMove.enabled = false;
        enemyAnimationControl.enabled = false;
    }
    public int GetId()
    {
        return id;
    }

}
