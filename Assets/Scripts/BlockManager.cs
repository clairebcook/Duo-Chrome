using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [Header("Sprite Settings")]
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D box;
    public Sprite[] Swatches;

    private int currentSpriteIndex = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();

        if (Swatches != null && Swatches.Length > 0)
        {
            spriteRenderer.sprite = Swatches[0];
        }
        else
        {
            Debug.LogWarning("Swatches array is empty or null.");
        }
    }

    void Update()
    {
        // For testing purposes, you can call toggleBox when a key is pressed
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
        toggleBox();
        }
    }

    public void toggleBox()
    {
        if (Swatches != null && Swatches.Length > 0)
        {
            currentSpriteIndex = (currentSpriteIndex + 1) % Swatches.Length;
            spriteRenderer.sprite = Swatches[currentSpriteIndex];
        }
        else
        {
            Debug.LogWarning("Swatches array is empty or null.");
        }

        if (box.enabled == true) {
            box.enabled = false;
        } else {
            box.enabled = true;
        }
    }
}
