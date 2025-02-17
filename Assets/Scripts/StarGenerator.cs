using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject starGO;
    public int maxStars;

    // Array of colors
    Color[] colors = {
        new(0.5f, 0.5f, 1f), // light blue
        new(0f, 1f, 1f), // turquoise
        new(1f, 1f, 0f), // yellow
        new(1f, 0f, 1f), // pink
        new(1f, 1f, 1f) // white
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Bottom left
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // Top right
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Loop to create stars
        for (int i = 0; i < maxStars; i++)
        {
            GameObject star = Instantiate(starGO);

            // Set the star color
            star.GetComponent<SpriteRenderer>().color = colors[i % colors.Length];

            // Set the position of the star (random x and y)
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            // Set a random speed for the star
            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

            // Make the star a child of the StarGenerator
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
