using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private AnimationControl playerAnimationControl;
    [SerializeField] private Player_move playerMove;
    [SerializeField] private Person_attack playerAttack;
    [SerializeField] UIManager uiManager;
    [SerializeField] private DialogUI dialogUI;
    [SerializeField] private float dialogDistance;
    [SerializeField] private LayerMask layerMask;
    private Vector2 dir;
    private RaycastHit2D hit;
    private void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
           
            StartDialog();
            //print(dialogUI.isDialog);
            if(!dialogUI.isDialog)
                playerAttack.Attack();
        }
        if (dialogUI.isDialog)
        { 
            playerAnimationControl.SetParameter("isWalk", false);
            return;
        }
        UpdateDir();
        UpdatePlayerAnimation(dir);
        UpdatePlayerAttackPosition();
        
        
        
    }
    private void FixedUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!dialogUI.isDialog)
            playerMove.Move();
    }
    private void UpdatePlayerAttackPosition()
    {
        if (dir == Vector2.zero || dialogUI.isDialog)
            return;
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0)
                playerAttack.SetOffset(new Vector2(0.5f, 0));
            else
                playerAttack.SetOffset(new Vector2(-0.5f, 0));
        }
        else
        {
            if (dir.y > 0)
                playerAttack.SetOffset(new Vector2(0, 0.5f));
            else
                playerAttack.SetOffset(new Vector2(0, -0.5f));
        }

    }
    private void StartDialog()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);
        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero, layerMask);

        if (hit)
            if (hit.collider.GetComponent<InteractableObject>() != null && (hit.transform.position - playerMove.transform.position).magnitude <= dialogDistance)
            {
                if (dialogUI.isDialog)
                    return;
                print(hit.collider.name);
                dialogUI.SetText(hit.collider.GetComponent<InteractableObject>());
                dialogUI.Show();
            }

    }
    private void UpdatePlayerAnimation(Vector2 dir)
    {

        if (Input.GetMouseButtonDown(0) && dialogUI.isDialog == false)
        {
            playerAnimationControl.SetParameter("isAttack");
        }
        if (dir == Vector2.zero)
        {
            playerAnimationControl.SetParameter("isWalk", false);
            return;
        }
           
        
        playerAnimationControl.SetParameter("x", dir.x);
        playerAnimationControl.SetParameter("y", dir.y);
        playerAnimationControl.SetParameter("isWalk", true);


    }
    private void UpdateDir()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");

    }
    

}
