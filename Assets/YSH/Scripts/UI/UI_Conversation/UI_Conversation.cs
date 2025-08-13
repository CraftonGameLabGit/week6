using UnityEngine;

public class UI_Conversation : MonoBehaviour
{
    public int sceneID;
    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        SceneChangeManager.ButtonClick.OnSceneStartConversationEvent += ConversationStart;
    }

    void ConversationStart(int stageID)
    {
        if (sceneID == stageID)
            _animator.Play("ConversationStart");
        else
            return;
    }
}
