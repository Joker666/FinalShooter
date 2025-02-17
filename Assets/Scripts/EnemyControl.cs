using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    float speed;
    public GameObject explosion; // this is our prefab
    GameObject gameScore;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        gameScore = GameObject.FindGameObjectWithTag("ScoreTextTag");
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

    void OnTriggerEnter2D(Collider2D col)
    {
        // Detect collision of the enemy ship with the player ship, or with a player's bullet
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();

            // Add 100 points to the score
            gameScore.GetComponent<GameScore>().Score += 100;

            Destroy(gameObject); // Destroy this enemy ship
        }
    }

    void PlayExplosion()
    {
        GameObject explosionInstance = Instantiate(explosion);
        explosionInstance.transform.position = transform.position;
    }
}
