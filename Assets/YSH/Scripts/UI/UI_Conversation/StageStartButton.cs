using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageStartButton : MonoBehaviour
{
    public int stageStartID;

    UI_Conversation _uiParent;
    Animator _ani;
    Button _button;

    void Start()
    {
        _uiParent = transform.parent.parent.GetComponent<UI_Conversation>();
        _ani = _uiParent.GetComponent<Animator>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(StageStartButtonClick);
    }

    void StageStartButtonClick()
    {
        if (stageStartID == _uiParent.sceneID)
        {
            _ani.Play("UnConversation");
            SceneManager.LoadScene(stageStartID + 1);
        }
        else return;
    }

}
