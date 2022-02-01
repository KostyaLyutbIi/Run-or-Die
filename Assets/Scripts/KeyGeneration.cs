using UnityEngine;

public class KeyGeneration : MonoBehaviour
{
    private float _xSize = 2;
    private float _zSize = 5;
    private GameObject _currentKey;

    public Vector3 currentPosition;
    public GameObject keyPrefab;
    
    private void Awake()
    {
        AddNewKey();
    }

    private void AddNewKey()
    {
        RandomPosition();
        _currentKey = GameObject.Instantiate(keyPrefab, currentPosition, Quaternion.identity) as GameObject;
    }

    private void RandomPosition()
    {
        currentPosition = new Vector3(Random.Range(_xSize * -1, _xSize), 0, Random.Range(_zSize * -1, _zSize));
    }
}
