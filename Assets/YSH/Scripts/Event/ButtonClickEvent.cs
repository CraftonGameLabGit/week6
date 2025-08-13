using System;

public class ButtonClickEvent 
{
    public Action<int> OnLeftButtonClickEvent; // 왼쪽 클릭 눌렀을때 반응할 Action;
    public Action<int> OnRightButtonClickEvent; // 오른쪽 클릭 눌렀을때 반응할 Action;

    public Action<int> OnSceneStartConversationEvent; // 씬이 넘겨 졌을때 나오는 대화창을 만드는거

    // 왼쪽 버튼 클릭했을 때 
    public void LeftButtonClick(int stageID)
    {
        OnLeftButtonClickEvent?.Invoke(stageID);
    }

    // 오른쪽 버튼 클릭했을 때 
    public void RightButtonClick(int stageID)
    {
        OnRightButtonClickEvent?.Invoke(stageID);
    }

    // 해당 씬을 눌렀을 때 
    public void SceneStartConversation(int stageID)
    {
        OnSceneStartConversationEvent?.Invoke(stageID);
    }
}
