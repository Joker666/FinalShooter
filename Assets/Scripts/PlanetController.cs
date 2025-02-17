using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] planets;

    // Queue of planets
    private Queue<GameObject> availablePlanets = new Queue<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Add all the planets to the queue
        foreach (GameObject planet in planets)
        {
            availablePlanets.Enqueue(planet);
        }

        // Call the MovePlanetDown function every 20 seconds
        InvokeRepeating(nameof(MovePlanetDown), 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MovePlanetDown()
    {
        EnqueuePlanets();

        if (availablePlanets.Count == 0)
        {
            return;
        }

        // Get the first planet in the queue
        GameObject planet = availablePlanets.Dequeue();

        // Set the planet isMoving to true
        planet.GetComponent<Planet>().isMoving = true;
    }

    void EnqueuePlanets()
    {
        foreach (GameObject planet in planets)
        {
            // if the planet is below the screen, and the planet is not moving
            if (planet.transform.position.y < 0 && !planet.GetComponent<Planet>().isMoving)
            {
                // Reset the planet position
                planet.GetComponent<Planet>().ResetPosition();

                // Add the planet to the queue
                availablePlanets.Enqueue(planet);
            }
        }
    }
}
