using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    [SerializeField] private float wheelRadius = 0.5f; // ���� ������ (����Ƽ ���� ����)
    private TruckMove truckMove; // �θ� ������Ʈ�� TruckMove ��ũ��Ʈ
    private float rotationSpeed; // ȸ�� �ӵ� (��/��)

    void Start()
    {
        // �θ� ������Ʈ(Truck)���� TruckMove ��ũ��Ʈ ��������
        truckMove = GetComponentInParent<TruckMove>();
        if (truckMove == null)
        {
            Debug.LogError("TruckMove ��ũ��Ʈ�� �θ� ������Ʈ���� ã�� �� �����ϴ�!");
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
            rotationSpeed = 0f; // Ʈ���� ���߸� ȸ���� ����
        }

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}