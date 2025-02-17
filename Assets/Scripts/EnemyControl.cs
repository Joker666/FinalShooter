using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the enemy's current position
        Vector2 position = transform.position;

        // Compute the enemy's new position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        // Update the enemy's position
        transform.position = position;

        // This is the bottom-left point (corner) of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
}
