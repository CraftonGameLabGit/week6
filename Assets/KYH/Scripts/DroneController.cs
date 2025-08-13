using Unity.VisualScripting;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    private Rigidbody2D left;
    private Rigidbody2D right;
    [SerializeField]
    private float upPower = 15f;
    [SerializeField]
    private float verticalPower = 15f;

    private void Start()
    {
        GameObject drone = transform.GetChild(0).gameObject;
        left = drone.transform.GetChild(0).GetComponent<Rigidbody2D>();
        right = drone.transform.GetChild(1).GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //left.AddForce(transform.up*upPower,ForceMode2D.Impulse); // 수직 상승
            //right.AddForce(transform.up*upPower,ForceMode2D.Impulse); // 수직 상승
        }
        

        
        if (Input.GetKey(KeyCode.W))
        {
            left.AddForce(transform.up*upPower,ForceMode2D.Impulse); // 수직 상승
            //right.AddForce(transform.up*verticalPower,ForceMode2D.Impulse); // 수직 상승
        }
        if (Input.GetKey(KeyCode.A))
        {
            left.AddForce(-transform.right*verticalPower,ForceMode2D.Impulse); // 수직 상승
            //right.AddForce(-transform.right*upPower,ForceMode2D.Impulse); // 수직 상승
        }
        if (Input.GetKey(KeyCode.S))
        {
            left.AddForce(-transform.up*upPower,ForceMode2D.Impulse); // 수직 상승
            //right.AddForce(-transform.up*upPower,ForceMode2D.Impulse); // 수직 상승
        }
        if (Input.GetKey(KeyCode.D))
        {
            left.AddForce(transform.right*verticalPower,ForceMode2D.Impulse); // 수직 상승
            //right.AddForce(transform.right*upPower,ForceMode2D.Impulse); // 수직 상승
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //left.AddForce(transform.up*upPower,ForceMode2D.Impulse); // 수직 상승
            right.AddForce(transform.up*upPower,ForceMode2D.Impulse); // 수직 상승
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //left.AddForce(-transform.right*verticalPower,ForceMode2D.Impulse); // 수직 상승
            right.AddForce(-transform.right*verticalPower,ForceMode2D.Impulse); // 수직 상승
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //left.AddForce(-transform.up*upPower,ForceMode2D.Impulse); // 수직 상승
            right.AddForce(-transform.up*upPower,ForceMode2D.Impulse); // 수직 상승
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //left.AddForce(transform.right*verticalPower,ForceMode2D.Impulse); // 수직 상승
            right.AddForce(transform.right*verticalPower,ForceMode2D.Impulse); // 수직 상승
        }
        
        
        
        if(transform.rotation.z > 50f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 50f);
        }
        else if(transform.rotation.z < -50f)
        {
            transform.rotation = Quaternion.Euler(0, 0, -50f);
        }
    }
    
}
