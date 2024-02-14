using System;
using UnityEngine;

public class Dotted : MonoBehaviour
{
    [SerializeField] private Frame _frame;
    private DottedMesh _dottedMesh;
    
    private readonly Vector2 _center = new Vector2(0, 0);
    
    [SerializeField] private Vector2 _dotSize;
    [SerializeField] private int _dotsAmount;
    [SerializeField] private float _dotsSpacing;

    private void Awake()
    {
        _dottedMesh = new DottedMesh(gameObject);
    }
    
    private void Start()
    {
        //_dottedMesh.Draw(_center, _dotSize, _dotsAmount, _dotsSpacing);
        _dottedMesh.Draw(_center, _dotSize, _frame.Rect.height);
    }
}
