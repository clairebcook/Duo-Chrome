using UnityEngine;

public class background_script : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    private bool isBlack = true;  // Track the current color state

    // Start is called before the first frame update
    void Start()
    {
        // Get the SpriteRenderer component attached to the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Initially set the sprite color to black
        spriteRenderer.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        // For testing purposes, you can call toggleBg when the space key is pressed
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            toggleBg();
        }
    }

    // Change the sprite color from black to white or vice versa
    public void toggleBg()
    {
        if (isBlack)
        {
            // Change sprite color to white
            spriteRenderer.color = Color.white;
        }
        else
        {
            // Change sprite color back to black
            spriteRenderer.color = Color.black;
        }

        // Toggle the state
        isBlack = !isBlack;
    }
}
