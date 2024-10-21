using UnityEngine;

public class SwapColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; 
    private bool isMaterial1 = true; 

    public Material material1; 
    public Material material2; 

    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material = material1;
    }

    void Update()
    {
        // For testing purposes, you can call toggleBg when the space key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            toggleBg();
        }
    }

    public void toggleBg()
    {
        if (isMaterial1)
        {
            spriteRenderer.material = material2;
        }
        else
        {
            spriteRenderer.material = material1;
        }

        isMaterial1 = !isMaterial1;
    }
}
