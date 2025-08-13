using System;
using UnityEngine;

public class GameStartBtn : MonoBehaviour
{
    private void OnMouseEnter()
    {
        // Change the color of the button when the mouse enters
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }
    
    private void OnMouseExit()
    {
        // Reset the color of the button when the mouse exits
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
