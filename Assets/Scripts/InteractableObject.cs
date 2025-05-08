using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private TextAsset[] texts;
    [SerializeField] public TextAsset affectedText;
    [SerializeField] private id ID;
    [SerializeField] private bool isCharacter;
    public TextAsset nowText;
    private int index;
    private void Awake()
    {
        if(GetComponent<id>() != null)
            ID = GetComponent<id>();
    }
    private void Start()
    {
        index = 0;
        nowText = texts[0];
        //Lock_manager.instance.Unlock(isCharacter, id_det.chara_id, id_det.conmu_id);
    }
    public TextAsset GetText()
    {
        if(ID != null)
            Lock_manager.instance.Unlock(isCharacter, ID.index, ID.objectId);
        
        return nowText;
    }

    public void NextText()
    {
        if (index + 1 < texts.Length)
        { 
            nowText = texts[++index];
            ID.objectId++;
            
        }
        
    }
    public virtual void OnInteractEnd()
    { 
        
    }
}
