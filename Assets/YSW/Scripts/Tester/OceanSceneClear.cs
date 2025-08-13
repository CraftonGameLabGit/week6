using UnityEngine;

public class OceanSceneClear : MonoBehaviour
{
    GameSceneUI_Conversation _uiConversation;
    Animator _ani;

    // ���� �Ǵ� �κп��� Ȯ�� �ϰ� ���� �ؾ� �ϴµ� Action�� �ٲٸ� �� ��?
    private void Start()
    {
        _uiConversation = FindAnyObjectByType<GameSceneUI_Conversation>();
        _ani = _uiConversation.GetComponent<Animator>();
        OceanManager.Instance.OnFinishEvent += GameClearTest;

    }

    void GameClearTest()
    {
        //Todo : Action�� �̿��� ���� Ŭ���� ȭ�� Ŭ���� ���� �־��ָ� �� 
        _uiConversation.GetComponent<Canvas>().enabled = true;
        _ani.Play("ConversationStart");
        Debug.Log("���� Ŭ���� �Դϴ�");
    }
}
