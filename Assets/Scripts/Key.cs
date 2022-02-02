using UnityEngine;

public class Key : MonoBehaviour
{
    private Rigidbody _doorRigidbody;

    private float _openDoor = -120;
    private float _speed = 40;

    private void Start()
    {
        _doorRigidbody = GameObject.FindGameObjectWithTag("Door").GetComponent<Rigidbody>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        OpenDoor();
    }

    public void OpenDoor()
    {
        _doorRigidbody.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, _openDoor, transform.rotation.z), _speed * Time.deltaTime);
    }
}