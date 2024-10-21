using UnityEngine;
using UnityEngine.Tilemaps;

public class SwapColorMap : MonoBehaviour
{
    private TilemapRenderer tileRender; 
    private bool isMaterial1 = true;  

    public Material material1; 
    public Material material2;

    void Start()
    {
        tileRender = GetComponent<TilemapRenderer>();
        tileRender.material = material1;
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
            tileRender.material = material2;
        }
        else
        {
            tileRender.material = material1;
        }

        isMaterial1 = !isMaterial1;
    }
}
