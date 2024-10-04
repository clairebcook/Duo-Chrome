using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Camera cam;
    public Color[] colors;
    public Player1 player;

    private int currentColor = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam.backgroundColor = colors[0];
        DisableObstacles(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            int nextColor = (currentColor + 1) % colors.Length;
            DisableObstacles(currentColor, nextColor);
            currentColor = nextColor;
            cam.backgroundColor = colors[currentColor];
        }
    }

    void DisableObstacles(int current, int next)
    {
        Obstacle[] obstacles = Object.FindObjectsByType<Obstacle>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        //Debug.Log("Obstacles: " + obstacles.Length);
        string toDisable = "Color" + next;
        Debug.Log("toDis: " + toDisable);
        string toEnable = "Color" + current;
        Debug.Log("toEnable: " + toEnable);
        foreach (Obstacle obstacle in obstacles)
        {
            if (obstacle.gameObject.tag==toDisable) obstacle.gameObject.SetActive(false);
            else if (obstacle.gameObject.tag == toEnable) obstacle.gameObject.SetActive(true);
        }
        CheckDeath(toEnable);
    }

    void CheckDeath(string killColor)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(player.transform.position, 0);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == killColor)
            {
                player.Die();
                Debug.Log("Player is dead");
            }
        }
    }
}