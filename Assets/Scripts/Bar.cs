using System;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] private Frame _frame;
    [SerializeField] private Rectangle _rectangle;

    [SerializeField] private float DistanceFromCenter = 2;
    
    private float _halfWidth;
    private float _halfHeight;
    
    public Rect Rect { get; private set; }
    
    private float _minY;
    private float _maxY;

    public float _increment = 0.1f;

    private void Start()
    {
        _minY = _frame.Rect.y;
        _maxY = _frame.Rect.height;

        _halfWidth = _rectangle._width / 2;
        _halfHeight = _rectangle._height / 2;

        var transformPosition = transform.position;
        
        transformPosition.x = DistanceFromCenter;
        transform.position = transformPosition;
    }

    private void Update()
    {
        var pos = transform.position;
        var x = pos.x - _halfWidth;
        var y = pos.y - _halfHeight;
        var width = pos.x + _halfWidth;
        var height = pos.y + _halfHeight;
        Rect = new Rect(x, y, width, height);

        // if (Input.GetKey(KeyCode.W))
        // {
        //     Move(_increment);
        // }
        //
        // if (Input.GetKey(KeyCode.S))
        // {
        //     Move(-_increment);
        // }
    }

    public void Move(float increment)
    {
        var transformPosition = transform.position;

        transformPosition += new Vector3(0, increment * Time.deltaTime, 0);
        _minY = _frame.Rect.y;
        _maxY = _frame.Rect.height;
        var min = _minY + _halfHeight;
        var max = _maxY - _halfHeight;
        transformPosition.y = Math.Clamp(transformPosition.y, min, max);
        transformPosition.x = DistanceFromCenter;

        transform.position = transformPosition;
    }
}