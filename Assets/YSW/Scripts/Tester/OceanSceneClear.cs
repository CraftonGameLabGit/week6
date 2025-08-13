using UnityEngine;

public class OceanSceneClear : MonoBehaviour
{
    GameSceneUI_Conversation _uiConversation;
    Animator _ani;

    // 실행 되는 부분에서 확인 하고 실행 해야 하는데 Action을 바꾸면 될 듯?
    private void Start()
    {
        _uiConversation = FindAnyObjectByType<GameSceneUI_Conversation>();
        _ani = _uiConversation.GetComponent<Animator>();
        OceanManager.Instance.OnFinishEvent += GameClearTest;

    }

    void GameClearTest()
    {
        //Todo : Action을 이용한 게임 클리어 화면 클리어 연출 넣어주면 됨 
        _uiConversation.GetComponent<Canvas>().enabled = true;
        _ani.Play("ConversationStart");
        Debug.Log("게임 클리어 입니다");
    }
}
