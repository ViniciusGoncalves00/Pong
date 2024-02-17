using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private Pong Pong;
    [SerializeField] private Frame _frame;
    [SerializeField] private Bar _leftBar;
    [SerializeField] private Bar _rightBar;

    [SerializeField] private float _minVariationInX = 0.0f;
    [SerializeField] private float _maxVariationInX = 1.0f;
    [SerializeField] private float _minVariationInY = 0.0f;
    [SerializeField] private float _maxVariationInY = 1.0f;

    private Vector3 _variation = new Vector3();
    public Vector3 Direction { get; private set; }
    
    
    [SerializeField] private float _initialVelocity = 0.1f;
    [SerializeField] private float _minVelocity = 0.1f;
    [SerializeField] private float _maxVelocity = 0.1f;
    [SerializeField] private float _velocityGainRate = 0.1f;
    [SerializeField] private float _slowdown = 2;

    private const float ExtraLimitMultiplier = 1.1f;
    private const float NoLimitMultiplier = 1f;

    private float _velocity;

    private void Start()
    {
        SetDirection();

        _velocity = _initialVelocity;

        var vector = new Vector2(1, 1);
        vector.Normalize();
    }

    private void Update()
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
        Direction = vectorDirection;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + Direction, _velocity * Time.deltaTime);
    }

    private void VerifyCollision()
    {
        if (!Inside(_frame.Rect, ExtraLimitMultiplier))
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
        
        else if (Inside(_leftBar.Rect, NoLimitMultiplier))
        {
            _velocity += _velocityGainRate;
            if (_velocity > _maxVelocity)
            {
                _velocity = _maxVelocity;
            }
            
            ChangeDirectionWithDeviation(Vector2.right);
        }
        
        else if (Inside(_rightBar.Rect, NoLimitMultiplier))
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
        var direction = Vector2.Reflect(Direction, normal);
        direction.Normalize();
        Direction = direction;
    }

    private void ChangeDirectionWithDeviation(Vector2 normal)
    {
        var variation = Variation(normal);
        var direction = Vector2.Reflect(Direction, normal);
        direction += variation;
        Direction = direction.normalized;
    }

    private Vector2 Variation(Vector2 normal)
    {
        _variation.x = Random.Range(_minVariationInX * normal.x, _maxVariationInX * normal.x);
        _variation.y = Random.Range(_minVariationInY, _maxVariationInY);
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
        
        return pos.x > _frame.Rect.width * ExtraLimitMultiplier &&
               pos.x < _frame.Rect.x * ExtraLimitMultiplier &&
               pos.y > _frame.Rect.height * ExtraLimitMultiplier &&
               pos.y < _frame.Rect.y * ExtraLimitMultiplier;
    }

    private bool Inside(Rect rect, float extra)
    {
        var pos = transform.position;

        return pos.x > rect.x * extra &&
               pos.x < rect.width * extra &&
               pos.y > rect.y * extra &&
               pos.y < rect.height* extra;
    }
}