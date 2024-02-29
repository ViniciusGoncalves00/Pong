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
    }

    public void Move(float velocity)
    {
        _minY = _frame.Rect.y;
        _maxY = _frame.Rect.height;
        var min = _minY + _halfHeight;
        var max = _maxY - _halfHeight;
        
        var transformPosition = transform.position;
        transformPosition += new Vector3(0, velocity * Time.deltaTime, 0);
        transformPosition.y = Math.Clamp(transformPosition.y, min, max);
        transformPosition.x = DistanceFromCenter;

        transform.position = transformPosition;
    }

    public void IAMove(Vector2 target, float speed)
    {
        _minY = _frame.Rect.y;
        _maxY = _frame.Rect.height;
        var min = _minY + _halfHeight;
        var max = _maxY - _halfHeight;
        
        var position = transform.position;
        position = Vector2.MoveTowards(position, target, speed * Time.deltaTime);
        position.y = Math.Clamp(position.y, min, max);
        position.x = DistanceFromCenter;

        transform.position = position;
    }
}