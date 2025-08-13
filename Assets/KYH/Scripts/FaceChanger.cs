using UnityEngine;

public class FaceChanger : MonoBehaviour
{
    private Sprite[] faces;
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        faces = Resources.LoadAll<Sprite>("KYH/Face");
        ChangeFace();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int randomIndex = Random.Range(0, faces.Length);
            spriteRenderer.sprite = faces[randomIndex];
        }
    }
    private void ChangeFace()
    {
        int randomIndex = Random.Range(0, faces.Length);
        spriteRenderer.sprite = faces[randomIndex];
        Invoke("ChangeFace", 5f); // 1초 후에 다시 호출
    }
    
    
    
}
