using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private InteractableObject interactableObject;
   /* private void Update()
    {
        if(interactableObject != null)
            SetText(interactableObject.GetText().text.Split('\n')[0].Split(' ')[1]); 
    }*/
    public void SetText(string str)
    { 
        text.text = str;
    }
}
