using System;
using UnityEngine;

public class Frame : MonoBehaviour
{
    private FrameMesh _frameMesh;
    
    [SerializeField] private float _thickness = 1;

    public Rect Rect { get; private set; }
    [SerializeField] private float _width = 1;
    [SerializeField] private float _height = 1;

    private void Awake()
    {
        _frameMesh = new FrameMesh(gameObject);
    }

    private void Start()
    {
        Rect = _frameMesh.Draw(_width, _height, _thickness);
    }
}
