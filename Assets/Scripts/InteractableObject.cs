using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private TextAsset[] texts;
    [SerializeField] public TextAsset affectedText;
    [SerializeField] private Id_det id_det;
    [SerializeField] private bool isCharacter;
    public TextAsset nowText;
    private int index;
    private void Awake()
    {
        id_det = GetComponent<Id_det>();
    }
    private void Start()
    {
        index = 0;
        nowText = texts[0];
        //Lock_manager.instance.Unlock(isCharacter, id_det.chara_id, id_det.conmu_id);
    }
    public TextAsset GetText()
    { 
        return nowText;
    }

    public void NextText()
    {
        if (index + 1 < texts.Length)
        { 
            nowText = texts[++index];
            id_det.chara_id++;
            Lock_manager.instance.Unlock(isCharacter, id_det.chara_id, id_det.conmu_id);
        }
        
    }
    public virtual void OnInteractEnd()
    { 
        
    }
}
