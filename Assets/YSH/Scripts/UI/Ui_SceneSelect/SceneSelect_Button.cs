using UnityEngine;
using UnityEngine.UI;

public class SceneSelect_Button : MonoBehaviour
{
    public int sceneID; // � ������ �Ѿ���� ���� ID
    Button _button;
    
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        Debug.Log("��ư ����");
        SceneChangeManager.ButtonClick.SceneStartConversation(sceneID);
    }
}
