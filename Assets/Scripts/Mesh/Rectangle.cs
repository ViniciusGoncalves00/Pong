using UnityEngine;

public class Rectangle : MonoBehaviour
{
    private RectMesh _rectMesh;
    
    [SerializeField] public float _width;
    [SerializeField] public float _height;

    private void Awake()
    {
        _rectMesh = new RectMesh(gameObject);
    }
    private void Start()
    {
        _rectMesh.Draw(_width, _height);
    }
}