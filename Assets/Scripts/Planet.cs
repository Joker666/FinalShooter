using System;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed;
    public bool isMoving;

    Vector2 min;
    Vector2 max;

    void Awake()
    {
        isMoving = false;

        // Bottom left
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // Top right
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Add the planet sprite renderer half height to the max y
        max.y += GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

        // Substract the planet sprite renderer half height to the min y
        min.y -= GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            return;
        }

        // Get the current position of the planet
        Vector2 position = transform.position;

        // Compute the new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        // Update the position of the planet
        transform.position = position;

        // If the planet gets to the minimum y position, then stop moving
        if (transform.position.y < min.y)
        {
            isMoving = false;
        }
    }

    public void ResetPosition()
    {
        // Set the position of the planet
        transform.position = new Vector2(UnityEngine.Random.Range(min.x, max.x), max.y);
    }
}
