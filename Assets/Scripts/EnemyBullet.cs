using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool isReady;

    void Awake()
    {
        speed = 5f;
        isReady = false;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }

    void Update()
    {
        if (isReady)
        {
            // Get the bullet's current position
            Vector2 position = transform.position;

            // Compute the bullet's new position
            position += _direction * speed * Time.deltaTime;

            // Update the bullet's position
            transform.position = position;

            // Get the bottom-left point of the screen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            // Get the top-right point of the screen
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            // If the bullet goes outside the screen, then destroy it
            if (transform.position.x < min.x || transform.position.x > max.x ||
                transform.position.y < min.y || transform.position.y > max.y)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Detect collision of the enemy's bullet with the player ship
        if (col.CompareTag("PlayerShipTag"))
        {
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
