using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerAnimationControl playerAnimationControl;
    [SerializeField] UIManager uiManager;
    [SerializeField] private DialogUI dialogUI;
    private Vector2 dir;
    private RaycastHit2D hit;
    private void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

            if(hit)
                if (hit.collider.CompareTag("InteractableObject"))
                {
                    if(dialogUI.isDialog)
                        return;
                    print(hit.collider.name);
                    dialogUI.SetText(hit.collider.GetComponent<InteractableObject>().GetText());
                    dialogUI.Show();
                    return;
                }
        }
        if (Input.GetKeyDown(KeyCode.M))
        { 
            uiManager.ShowAndHideDirectoryUI();
        }
        UpdateDir();
        UpdatePlayerAnimation(dir);
    }
    private void UpdateDir()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");
        
    }
    private void UpdatePlayerAnimation(Vector2 dir)
    {
        
       
        if (Input.GetMouseButtonDown(0))
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
    
}
