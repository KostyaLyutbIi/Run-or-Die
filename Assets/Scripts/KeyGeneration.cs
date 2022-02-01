using UnityEngine;

public class KeyGeneration : MonoBehaviour
{
    public float xSize = 2;
    public float zSize = 5;
    public Vector3 currentPosition;
    public GameObject keyPrefab;
    public GameObject currentKey;

    private void Start()
    {
        AddNewKey();
    }

    private void AddNewKey()
    {
        RandomPosition();
        currentKey = GameObject.Instantiate(keyPrefab, currentPosition, Quaternion.identity) as GameObject;
    }

    private void RandomPosition()
    {
        currentPosition = new Vector3(Random.Range(xSize * -1, xSize), 0.25f, Random.Range(zSize * -1, zSize));
    }
}
