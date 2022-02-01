using UnityEngine;

public class Key : MonoBehaviour
{
    public Rigidbody door;

    private float _openDoor = -120;
    private float _speed = 40;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        OpenDoor();
    }

    public void OpenDoor()
    {
        door.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, _openDoor, transform.rotation.z), _speed * Time.deltaTime);
    }
}
