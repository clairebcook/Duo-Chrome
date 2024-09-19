using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Camera cam;
    public Color[] colors;

    private int currentColor = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam.backgroundColor = colors[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentColor = (currentColor + 1) % colors.Length;
            cam.backgroundColor = colors[currentColor];
        }
    }
}
