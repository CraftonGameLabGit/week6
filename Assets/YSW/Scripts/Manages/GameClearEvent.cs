using System;

public class GameClearEvent 
{
    public Action OnGameClearEvent;
    
    public void GameClear()
    {
        OnGameClearEvent?.Invoke();
        //? -> null �� �ƴҶ��� ����
    }
}
