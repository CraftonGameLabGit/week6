using UnityEngine;

public class GameClearTester : MonoBehaviour
{
    [SerializeField]
    private float GoalScore = 10;
    private bool isGameCleared = false; // ���� Ŭ���� ���� �÷���


    private void Start()
    {
        isGameCleared = false;
    }

    void Update()
    {
        // �̹� Ŭ���������� �� �̻� üũ���� ����
        if (isGameCleared) return;

        // ���� �������°� ��� �־�? // ���̶� ���� �ΰ��� �� 
        if (GoalLine_forest.score >= GoalScore || GoalLine_City.score >= GoalScore)
        {
            Managers.GameClearEvent.GameClear();
            isGameCleared = true; // Ŭ���� ���·� ����
        }
    }
}
