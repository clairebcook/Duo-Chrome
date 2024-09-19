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
            DisableObstacles();
            currentColor = (currentColor + 1) % colors.Length;
            cam.backgroundColor = colors[currentColor];
        }
    }

    void DisableObstacles()
    {
        Player1[] players = Object.FindObjectsByType<Player1>(FindObjectsSortMode.None);
        string toDisable = "Color" + currentColor;
        string toEnable = "Color" + (currentColor + 1) % colors.Length;
        foreach (Player1 player in players)
        {
            if (player.gameObject.tag==toDisable) player.gameObject.SetActive(false);
            else if (player.gameObject.tag == toEnable) player.gameObject.SetActive(true);
        }
    }
}