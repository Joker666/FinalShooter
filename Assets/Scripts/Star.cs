using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the current position of the star
        Vector2 position = transform.position;

        // Compute the new position of the star
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        // Update the position of the star
        transform.position = position;

        // Bottom left
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // Top right
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // If the star goes outside the screen, then position it at the top
        if (transform.position.y < min.y)
        {
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
    }
}
