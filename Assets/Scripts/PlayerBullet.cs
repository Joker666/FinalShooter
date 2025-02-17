using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the bullet's current position
        Vector2 position = transform.position;

        // Compute the bullet's new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        // Update the bullet's position
        transform.position = position;

        // This is the top-right point (corner) of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }
}
