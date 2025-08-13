using UnityEngine;

public class RemoveAcorn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            Destroy(other.gameObject); // 도토리 삭제
        }
    }
}