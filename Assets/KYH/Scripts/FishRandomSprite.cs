using UnityEngine;

public class FishRandomSprite : MonoBehaviour
{
    private Sprite[] fish;
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fish = Resources.LoadAll<Sprite>("KYH/FISH");
        ChangeSprite();
    }
    
    private void ChangeSprite()
    {
        int randomIndex = Random.Range(0, fish.Length);
        spriteRenderer.sprite = fish[randomIndex];
    }
}
