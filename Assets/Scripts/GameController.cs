using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController player;

    public GameObject wonScreen;
    public GameObject lossScreen;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; set; }
    public static object PhysicsSceneExtensions { get; set; }

    public void ThePlayerWon()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        //controller.enabled = false; 
    }

    public void ThePlayerLoss()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        //player.enabled = false;
    }

    public void ShowWonScreen()
    {
        wonScreen.SetActive(true); 
    }

    public void ShowLossScreen()
    {
        lossScreen.SetActive(true);
    }
}
