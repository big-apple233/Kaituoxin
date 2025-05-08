using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text contexlText;
    [SerializeField] private float time = 0.5f;
    [SerializeField] private Image imageLeft;
    [SerializeField] private Image imageRight;
    [SerializeField] private List<NameTextureSO> nameTextureSOList;
    private Dictionary<string, Sprite> nameTextureSODictionary;
    private string[] dialogs;
    private int index;
    private InteractableObject interactableObject;
    private bool isPrint;
    public bool isDialog = false;
    private void Awake()
    {
        nameTextureSODictionary = new Dictionary<string, Sprite>();
        foreach (NameTextureSO nameTextureSO in nameTextureSOList)
        { 
            nameTextureSODictionary.Add(nameTextureSO.objectName, nameTextureSO.sprite);
        
        }
    }
    private void Start()
    {
        parent.SetActive(false);
        index = 0;
        isDialog = false;
        isPrint = false;
    }

    public void UpdateDialog()
    {
        if (parent.activeSelf == false)
            return;
        if (index == dialogs.Length)
        {
            Hide();
            interactableObject.NextText();
            return;
        }
        string[] dialog = dialogs[index].Split('£º');
        nameText.text = dialog[0]+':';
        if (dialog[0] != "¼×" )
        {
            if(nameTextureSODictionary.ContainsKey(dialog[0]))
                imageRight.sprite = nameTextureSODictionary[dialog[0]];
            else
                imageRight.sprite = null;
        }
        contexlText.text = null;
        if (isPrint == true)
            return;
        StartCoroutine(Printer(dialog[1]));
        index++;
    }

    public void Show()
    {
        print("ÏÔÊ¾¶Ô»°¿ò");
        isDialog = true;
        index = 1;
        parent.SetActive(true);
        UpdateDialog();
    }
    public void Hide()
    {
        isDialog = false;
        parent.SetActive(false);
    }
    public void SetText(InteractableObject interactableObject)
    {         
        this.interactableObject = interactableObject;
        dialogs = this.interactableObject.GetText().text.Split('\n');
    }
    IEnumerator Printer(string str)
    {
        //isDialog = true;
        isPrint = true;
        for (int i = 0; i < str.Length; i++) 
        { 
            contexlText.text += str[i];
            yield return new WaitForSeconds(time);
        }
        isPrint = false;
        //isDialog = false;
    }
}
