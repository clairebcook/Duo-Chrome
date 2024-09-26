using UnityEngine;

public class Block_Script : MonoBehaviour
{
    [Header("Sprite Settings")]
    private SpriteRenderer SR;
    private BoxCollider2D box;
    public Sprite[] Swatches;

    private int currentSpriteIndex = 0;

    void Start()
    {
        // Get the SpriteRenderer component
        SR = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();

        // Initialize the sprite to the first one in the array, if available
        if (Swatches != null && Swatches.Length > 0)
        {
            SR.sprite = Swatches[0];
        }
        else
        {
            Debug.LogWarning("Swatches array is empty or null.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // For testing purposes, you can call toggleBox when a key is pressed
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
        toggleBox();
        }
    }

    // Change displayed sprite
    public void toggleBox()
    {
        if (Swatches != null && Swatches.Length > 0)
        {
            // Toggle between sprites in the Swatches array
            currentSpriteIndex = (currentSpriteIndex + 1) % Swatches.Length;
            SR.sprite = Swatches[currentSpriteIndex];
        }
        else
        {
            Debug.LogWarning("Swatches array is empty or null.");
        }

        // toggle the box collider on or off
        if (box.enabled == true) {
            box.enabled = false;
        } else {
            box.enabled = true;
        }
    }
}
