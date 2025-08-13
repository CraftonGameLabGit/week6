using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    [SerializeField] private float wheelRadius = 0.5f; // 바퀴 반지름 (유니티 단위 기준)
    private TruckMove truckMove; // 부모 오브젝트의 TruckMove 스크립트
    private float rotationSpeed; // 회전 속도 (도/초)

    void Start()
    {
        // 부모 오브젝트(Truck)에서 TruckMove 스크립트 가져오기
        truckMove = GetComponentInParent<TruckMove>();
        if (truckMove == null)
        {
            Debug.LogError("TruckMove 스크립트를 부모 오브젝트에서 찾을 수 없습니다!");
        }
    }

    void Update()
    {
        if (truckMove != null && truckMove.IsMoving())
        {
            float moveSpeed = truckMove.GetMoveSpeed();
            float angularSpeed = moveSpeed / wheelRadius;
            rotationSpeed = angularSpeed * Mathf.Rad2Deg;
        }
        else
        {
            rotationSpeed = 0f; // 트럭이 멈추면 회전도 멈춤
        }

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}