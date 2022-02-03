using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameController controller;

    private void OnTriggerEnter(Collider collider)
    {
        controller.ThePlayerWon();
    }
}