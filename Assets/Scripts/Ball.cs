using System;
using System.Buffers;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private Pong _pong;
    
    [Header("Mesh Settings")]
    [SerializeField] private float _radius = 0.1f;
    [SerializeField] private int _segments = 24;
    
    [Header("Velocity Settings")]
    [SerializeField] private float _initialVelocity = 0.1f;
    [SerializeField] private float _minVelocity = 0.1f;
    [SerializeField] private float _maxVelocity = 1.0f;
    
    [Tooltip("Value must be greater than one.")]
    [SerializeField] private float _accelerateRate = 1.1f;
    [Tooltip("Value must be greater than zero and lesser than one.")]
    [SerializeField] private float _decelerateRate = 0.9f;

    #endregion
    
    private BallMesh _ballMesh;
    
    public Vector2 Direction { get; private set; }
    private float _velocity;

    private Vector2 hitPoint;
    private RaycastHit2D HitInfo;
    
    
    public Material Material;



    private void Start()
    {
        _ballMesh = new BallMesh(gameObject, _radius, _segments, Material)
        {
            MeshRenderer =
            {
                material = Material
            }
        };

        SetDirection();

        _velocity = _initialVelocity;
    }

    private void Update()
    {
        _ballMesh.Draw();
        Move();
    }

    private void SetDirection()
    {
        var direction = Random.Range(-1, 2);

        if (direction == 0)
        {
            SetDirection();
            return;
        }

        Direction = new Vector2(1f, 0.1f);
    }

    private void Move()
    {
        var actualPosition = transform.position;
        
        var desiredPosition = (Vector2) actualPosition + Direction * (_velocity * Time.deltaTime);
        
        var hitInfo = Physics2D.CircleCast(actualPosition, _radius, Direction, _velocity * Time.deltaTime);
        
        if (hitInfo.collider != null)
        {
            switch (hitInfo.collider.tag)
            {
                case "Bar":
                    ChangeSpeed(_accelerateRate);
                    break;
                case "Back":
                    GainPoint();
                    break;
                case "Side":
                    break;
            }
            
            var wallDir = new Vector2(-hitInfo.normal.y, hitInfo.normal.x);
            
            var degreesBetweenBallAndSurfaceNormal = Vector2.Angle(Direction, wallDir);
            
            Func<float, float> func = hitInfo.normal.y != 0 ? Mathf.Cos : Mathf.Sin; 
            var n = 1f / func.Invoke(degreesBetweenBallAndSurfaceNormal * Mathf.Rad2Deg);
            
            desiredPosition = (Vector2) transform.position + Direction * (_radius * n);
            ChangeDirection(hitInfo.normal);
        }
        
        transform.position = desiredPosition;
    }

    private void ChangeDirection(Vector2 normal)
    {
        var direction = Vector2.Reflect(Direction, normal);
        Direction = direction.normalized;
    }
    
    private void ChangeSpeed(float velocityModifier)
    {
        _velocity *= velocityModifier;
        
        _velocity = Mathf.Clamp(_velocity, _minVelocity, _maxVelocity);
    }

    private void GainPoint()
    {
        switch (Direction.x)
        {
            case > 0:
                _pong.UpdatePoints(1,0);
                break;
            case < 0:
                _pong.UpdatePoints(0,1);
                break;
        }

        ChangeSpeed(_decelerateRate);
        transform.position = Vector3.zero;
    }
}