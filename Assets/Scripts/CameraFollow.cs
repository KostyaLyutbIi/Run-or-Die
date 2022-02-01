using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private Vector3 _position;

    void Start()
    {
        // Переводим координаты камеры в локальные координаты цели
        _position = target.InverseTransformPoint(transform.position);
    }

    void Update()
    {
        // Возвращаем камеру в мировые координаты
        var currentPosition = target.TransformPoint(_position);
        transform.position = currentPosition;
        transform.LookAt(target);
    }
}