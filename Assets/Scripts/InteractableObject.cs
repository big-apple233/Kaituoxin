using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private TextAsset[] texts;
    [SerializeField] public TextAsset affectedText;
    public TextAsset nowText;
    private int index;
    private void Start()
    {
        index = 0;
        nowText = texts[0];
    }
    public TextAsset GetText()
    { 
        return nowText;
    }

    public void NextText()
    {
        if(index + 1 < texts.Length)
            nowText = texts[++index];
    }
    public virtual void OnInteractEnd()
    { 
        
    }
}
