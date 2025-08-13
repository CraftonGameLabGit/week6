using System;

public class ButtonClickEvent 
{
    public Action<int> OnLeftButtonClickEvent; // ���� Ŭ�� �������� ������ Action;
    public Action<int> OnRightButtonClickEvent; // ������ Ŭ�� �������� ������ Action;

    public Action<int> OnSceneStartConversationEvent; // ���� �Ѱ� ������ ������ ��ȭâ�� ����°�

    // ���� ��ư Ŭ������ �� 
    public void LeftButtonClick(int stageID)
    {
        OnLeftButtonClickEvent?.Invoke(stageID);
    }

    // ������ ��ư Ŭ������ �� 
    public void RightButtonClick(int stageID)
    {
        OnRightButtonClickEvent?.Invoke(stageID);
    }

    // �ش� ���� ������ �� 
    public void SceneStartConversation(int stageID)
    {
        OnSceneStartConversationEvent?.Invoke(stageID);
    }
}
