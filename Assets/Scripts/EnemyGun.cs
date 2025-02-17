using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGO;

    void Start()
    {
        Invoke(nameof(FireEnemyBullet), 1f);
    }

    void Update()
    {
    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("PlayerGo");

        if (playerShip != null)
        {
            // Instantiate an enemy bullet
            GameObject bullet = Instantiate(EnemyBulletGO);

            // Set the bullet's initial position
            bullet.transform.position = transform.position;

            // Compute the bullet's direction towards the player's ship
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            // Set the bullet's direction
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
