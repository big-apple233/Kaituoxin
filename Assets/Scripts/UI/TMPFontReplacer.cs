// 文件名：TMPFontReplacer.cs
using UnityEditor;
using UnityEngine;
using TMPro;

public class TMPFontReplacer : MonoBehaviour
{
    public TMP_FontAsset newFont;

    [MenuItem("Tools/更换TMP字体")]
    /*public static void ShowWindow()
    {
        GetWindow<TMPFontReplacer>("字体更换器");
    }*/
    private void Awake()
    {
        ReplaceAllFonts();
    }
    /*private void OnGUI()
    {
        GUILayout.Label("批量更换TextMeshPro字体", EditorStyles.boldLabel);

        newFont = (TMP_FontAsset)EditorGUILayout.ObjectField(
            "新字体",
            newFont,
            typeof(TMP_FontAsset),
            false
        );

        if (GUILayout.Button("开始替换"))
        {
            ReplaceAllFonts();
        }
    }*/

    private void ReplaceAllFonts()
    {
        if (newFont == null)
        {
            Debug.LogError("请先选择要替换的新字体！");
            return;
        }

        TMP_Text[] allTexts = Resources.FindObjectsOfTypeAll<TMP_Text>();
        int count = 0;

        foreach (TMP_Text text in allTexts)
        {
            // 跳过预制体中的对象（如果需要处理预制体可移除这个判断）
            if (PrefabUtility.IsPartOfPrefabAsset(text)) continue;

            Undo.RecordObject(text, "Change TMP Font");
            text.font = newFont;
            count++;

            // 如果需要同时修改字体样式
            // text.fontStyle = FontStyles.Normal;
            // text.color = Color.white;
        }

        Debug.Log($"成功替换了 {count} 个TextMeshPro组件的字体");
    }
}