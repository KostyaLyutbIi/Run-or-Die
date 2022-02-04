using UnityEngine;

public class Finish : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter(Collider collider)
    {
        player.PlayerFinish();
    }
}