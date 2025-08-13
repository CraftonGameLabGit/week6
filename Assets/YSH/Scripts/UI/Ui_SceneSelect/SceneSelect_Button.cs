using UnityEngine;
using UnityEngine.UI;

public class SceneSelect_Button : MonoBehaviour
{
    public int sceneID; // 어떤 씬으로 넘어갈지에 대한 ID
    Button _button;
    
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        Debug.Log("버튼 눌림");
        SceneChangeManager.ButtonClick.SceneStartConversation(sceneID);
    }
}
