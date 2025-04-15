using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerAnimationControl playerAnimationControl;
    private Vector2 dir;
    private RaycastHit2D hit;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log("按下鼠标左键");
            if (hit.collider == null)
            {
                Debug.LogWarning("没有检测到物体");
                return;
            }
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (hit.transform.CompareTag("InteractableObject"))
                {
                    Debug.Log("检测到可互动物体");
                    ClickDialog();
                }
            }
           
            
        }
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");
        UpdatePlayerAnimation(dir);
    }
    public void ClickDialog()
    {       
        InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
        DialogUI.Instance.SetText(interactableObject.GetText());
        DialogUI.Instance.Show();
    }
    public void UpdatePlayerAnimation(Vector2 dir)
    {
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
