using UnityEngine;
using UnityEngine.Tilemaps;

public class SwapColorMap : MonoBehaviour
{
    private TilemapRenderer tileRender; // Reference to the SpriteRenderer component
    private bool isMaterial1 = true;  // Track the current material state

    public Material material1; // Assign this in the Inspector (e.g., black material)
    public Material material2; // Assign this in the Inspector (e.g., white material)

    // Start is called before the first frame update
    void Start()
    {
        // Get the SpriteRenderer component attached to the GameObject
        tileRender = GetComponent<TilemapRenderer>();

        // Initially set the material to material1
        tileRender.material = material1;
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

    // Swap the material between material1 and material2
    public void toggleBg()
    {
        if (isMaterial1)
        {
            // Change to material2
            tileRender.material = material2;
        }
        else
        {
            // Change back to material1
            tileRender.material = material1;
        }

        // Toggle the state
        isMaterial1 = !isMaterial1;
    }
}
