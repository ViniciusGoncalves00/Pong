using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private Pong Pong;
    [SerializeField] private Frame _frame;
    [SerializeField] private Bar LeftBar;
    [SerializeField] private Bar RightBar;

    [SerializeField] private float MinVariationInX = 0.0f;
    [SerializeField] private float MaxVariationInX = 1.0f;
    [SerializeField] private float MinVariationInY = 0.0f;
    [SerializeField] private float MaxVariationInY = 1.0f;

    private Vector3 _direction = new Vector3();
    private Vector3 _variation = new Vector3();
    
    [SerializeField] private float _initialVelocity = 0.1f;
    [SerializeField] private float _minVelocity = 0.1f;
    [SerializeField] private float _maxVelocity = 0.1f;
    [SerializeField] private float _velocityGainRate = 0.1f;
    [SerializeField] private float _slowdown = 2;
    
    private float _extraLimitMultiplier = 1.01f;

    private float _velocity;

    void Start()
    {
        SetDirection();

        _velocity = _initialVelocity;

        var vector = new Vector2(1, 1);
        vector.Normalize();
    }

    void Update()
    {
        Move();

        VerifyCollision();
    }

    private void SetDirection()
    {
        var direction = Random.Range(-1, 2);

        if (direction == 0)
        {
            SetDirection();
            return;
        }

        var x = Random.Range(0.0f, 1.0f * direction);
        var y = Random.Range(-0.5f, 0.5f);
        var vectorDirection = new Vector2(x, y);
        _direction = vectorDirection;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + _direction, _velocity * Time.deltaTime);
    }

    private void VerifyCollision()
    {
        if (OutsideOfTable())
        {
            transform.position = new Vector3(0, 0, 0);
            return;
        }
        
        if (transform.position.y > _frame.Rect.height)
        {
            ChangeDirection(Vector2.down);
        }
        
        else if (transform.position.y < _frame.Rect.y)
        {
            ChangeDirection(Vector2.up);
        }
        
        else if (TouchBar(LeftBar))
        {
            _velocity += _velocityGainRate;
            if (_velocity > _maxVelocity)
            {
                _velocity = _maxVelocity;
            }
            
            ChangeDirectionWithDeviation(Vector2.right);
        }
        
        else if (TouchBar(RightBar))
        {
            _velocity += _velocityGainRate;
            if (_velocity > _maxVelocity)
            {
                _velocity = _maxVelocity;
            }
            
            ChangeDirectionWithDeviation(Vector2.left);
        }

        else if (transform.position.x > _frame.Rect.width)
        {
            Pong.UpdatePoints(1,0);
            
            _velocity /= _slowdown;
            if (_velocity < _minVelocity)
            {
                _velocity = _minVelocity;
            }
            
            transform.position = Vector2.zero;
            ChangeDirection(Vector2.left);
        }
        
        else if (transform.position.x < _frame.Rect.x)
        {
            Pong.UpdatePoints(0,1);
            
            _velocity /= _slowdown;
            if (_velocity < _minVelocity)
            {
                _velocity = _minVelocity;
            }
            
            transform.position = Vector2.zero;
            ChangeDirection(Vector2.right);
        }
    }

    private void ChangeDirection(Vector2 normal)
    {
        var direction = Vector2.Reflect(_direction, normal);
        direction.Normalize();
        _direction = direction;
    }

    private void ChangeDirectionWithDeviation(Vector2 normal)
    {
        var variation = Variation(normal);
        var direction = Vector2.Reflect(_direction, normal);
        direction += variation;
        _direction = direction.normalized;
    }

    private Vector2 Variation(Vector2 normal)
    {
        _variation.x = Random.Range(MinVariationInX * normal.x, MaxVariationInX * normal.x);
        _variation.y = Random.Range(MinVariationInY, MaxVariationInY);
        return new Vector2(_variation.x, _variation.y);
    }

    private bool TouchBar(Bar bar)
    {
        var pos = transform.position;

        return pos.x > bar.Rect.x &&
               pos.x < bar.Rect.width &&
               pos.y > bar.Rect.y &&
               pos.y < bar.Rect.height;
    }

    private bool OutsideOfTable()
    {
        var pos = transform.position;
        
        return pos.x > _frame.Rect.width * _extraLimitMultiplier &&
               pos.x < _frame.Rect.x * _extraLimitMultiplier &&
               pos.y > _frame.Rect.height * _extraLimitMultiplier &&
               pos.y < _frame.Rect.y * _extraLimitMultiplier;
    }
}