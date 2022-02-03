using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerController controller;

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
}
