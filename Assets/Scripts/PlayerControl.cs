using UnityEngine;

using System.Collections;

public class PlayerControl : MonoBehaviour
{

    public GameObject playerBullet; // this is our prefab
    public GameObject bulletPosition1; // this is the position where the bullet 1 will be instantiated
    public GameObject bulletPosition2; // this is the position where the bullet 2 will be instantiated
    public float bulletSpeed;


    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Fire bullet when the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the first bullet
            GameObject bullet01 = Instantiate(playerBullet);
            bullet01.transform.position = bulletPosition1.transform.position; // set the bullet initial position

            // Instantiate the second bullet
            GameObject bullet02 = Instantiate(playerBullet);
            bullet02.transform.position = bulletPosition2.transform.position; // set the bullet initial position
        }

        float x = Input.GetAxisRaw("Horizontal");//the value will be -1, 0 or 1 (for left, no input, and right)
        float y = Input.GetAxisRaw("Vertical");//the value will be -1, 0 or 1 (for down, no input, and up)

        // Now based on the input we compute a direction vector, and we normalize it to get a unit vector
        Vector2 direction = new Vector2(x, y).normalized;

        // Now we call the function that computes and sets the player's position
        Move(direction);
    }

    void Move(Vector2 direction)
    {
        // Find the screen limits to the player's movement (left, right, top and bottom edges of the screen)
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // this is the bottom-left point (corner) of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // this is the top-right point (corner) of the screen

        max.x = max.x - 0.225f; // subtract the player sprite half width
        min.x = min.x + 0.225f; // add the player sprite half width

        max.y = max.y - 0.285f; // subtract the player sprite half height
        min.y = min.y + 0.285f; // add the player sprite half height

        // Get the player's current position
        Vector2 pos = transform.position;

        // Calculate the new position
        pos += direction * speed * Time.deltaTime;

        // Make sure the new position is outside the screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // Update the player's position
        transform.position = pos;
    }
}
