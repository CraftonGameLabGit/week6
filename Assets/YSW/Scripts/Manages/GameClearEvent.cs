using System;

public class GameClearEvent 
{
    public Action OnGameClearEvent;
    
    public void GameClear()
    {
        OnGameClearEvent?.Invoke();
        //? -> null 이 아닐때만 실행
    }
}
