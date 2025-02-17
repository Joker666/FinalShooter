using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
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
                break;
            case GameState.Gameplay:
                playButton.SetActive(false);
                playerShip.SetActive(true);
                break;
            case GameState.GameOver:
                playButton.SetActive(true);
                playerShip.SetActive(false);
                break;
        }
    }

    public void startGame()
    {
        updateGameState(GameState.Gameplay);
    }
}
