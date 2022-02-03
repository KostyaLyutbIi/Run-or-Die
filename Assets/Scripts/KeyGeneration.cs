using UnityEngine;

public class KeyGeneration : MonoBehaviour
{
    public GameObject keyPrefab;
    public GameObject _currentKey;

    private float _xSize = -40;
    private float _zSize = 40;
    private Vector3 _currentPosition;
    
    private void Awake()
    {
        AddNewKey();
        _currentKey.transform.rotation = keyPrefab.transform.rotation = Quaternion.Euler(90f, 0, 90f);
    }

    private void AddNewKey()
    {
        RandomPosition();
        _currentKey = GameObject.Instantiate(keyPrefab, _currentPosition, Quaternion.identity) as GameObject;
    }

    private void RandomPosition()
    {
        _currentPosition = new Vector3(Random.Range(_xSize * -1f, _xSize), 1f, Random.Range(_zSize * -1f, _zSize));
    }
}