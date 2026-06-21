using Assets.Scripts.Interfaces;
using UnityEditor;
using UnityEngine;

public class FireplaceController : MonoBehaviour, IInteractable
{
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite FireOnSprite;
    [SerializeField] private Sprite FireOffSprite;

    public void Interact()
    {
        Debug.Log("You did it!!");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        
    }
}
