using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameStarted = false; // Tracks whether the game has started

    public void StartGame()
    {
        gameStarted = true; // Set the game as started
        Debug.Log("Game Started!"); // Log to console for debugging
    }
}
