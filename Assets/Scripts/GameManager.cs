using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    private GameState gameState;

    public enum GameState
    {
        Opening,
        Gameplay,
        GameOver
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateGameState(GameState.Opening);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateGameState(GameState gameState)
    {
        this.gameState = gameState;
        switch (gameState)
        {
            case GameState.Opening:
                playButton.SetActive(true);
                playerShip.SetActive(false);
                GameOverGO.SetActive(false);
                break;
            case GameState.Gameplay:
                playButton.SetActive(false);
                playerShip.SetActive(true);
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                break;
            case GameState.GameOver:
                playerShip.SetActive(false);
                GameOverGO.SetActive(true);
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

                // Chaneg to opening state after 5 seconds
                Invoke("changeToOpeningState", 5f);
                break;
        }
    }

    public void startGame()
    {
        updateGameState(GameState.Gameplay);
    }

    public void changeToOpeningState()
    {
        updateGameState(GameState.Opening);
    }
}
