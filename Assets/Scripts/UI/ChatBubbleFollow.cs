using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBubbleFollow : MonoBehaviour
{
    public float xOffset;
    public float yOffset = 145f;
    public RectTransform recTransform;
    private void OnDisable()
    {
        recTransform.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        recTransform.gameObject.SetActive(true);
        
    }

    void Update()
    {
        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(transform.position);
        recTransform.position = player2DPosition + new Vector2(xOffset, yOffset);

        /*//Ѫ��������Ļ�Ͳ���ʾ
        if (player2DPosition.x > Screen.width || player2DPosition.x < 0 || player2DPosition.y > Screen.height || player2DPosition.y < 0)
        {
            recTransform.gameObject.SetActive(false);
        }
        else
        {
            recTransform.gameObject.SetActive(true);
        }
*/
    }
}
