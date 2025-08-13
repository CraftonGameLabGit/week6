using System;
using UnityEngine;

public class ChainSpawner : MonoBehaviour
{
    [SerializeField]
    private int chainCount = 20;
    //[SerializeField]
    private HingeJoint2D _chainUp;
    //[SerializeField]
    private HingeJoint2D _chainDown;
    //[SerializeField]
    private GameObject[] _chains;

    public void Start()
    {
        Init();
        ChainSpawn();
    }

    public void Init()
    {
        _chainUp = transform.GetChild(0).GetComponent<HingeJoint2D>();
        _chainDown = transform.GetChild(1).GetComponent<HingeJoint2D>();
        _chains = new GameObject[2];
        _chains[0] = Resources.Load<GameObject>("KYH/Chain0");
        _chains[1] = Resources.Load<GameObject>("KYH/Chain1");
    }


    public void ChainSpawn()
    {
        Rigidbody2D up = _chainUp.GetComponent<Rigidbody2D>();
        GameObject chain;
        for (int i = 0; i < chainCount; i++)
        {
            chain = Instantiate(_chains[i%2], transform.position, Quaternion.identity);
            chain.transform.parent = transform;
            chain.transform.localPosition = new Vector3(0, -i * 0.5f, 0);
            HingeJoint2D hingeJoint2D = chain.GetComponent<HingeJoint2D>();
            hingeJoint2D.connectedBody = up;
            up = hingeJoint2D.GetComponent<Rigidbody2D>();
        }
        _chainDown.connectedBody = up;
    }
    
    
}
