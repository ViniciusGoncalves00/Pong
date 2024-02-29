using System.Collections.Generic;
using UnityEngine;

public class BallMesh : DrawMesh
{
    List<Vector3> circleVertices = new List<Vector3>();
    List<Vector2> uvs = new List<Vector2>();
    List<int> triangles = new List<int>();
    
    private readonly float _radius;
    private readonly int _angle;
    
    public Material Material;
    
    private readonly Color[] _colors =
    {
        Color.red,
        Color.magenta,
        Color.blue,
        Color.cyan,
        Color.green,
        Color.yellow
    };
    
    private int _currentColorIndex;
    private int _targetColorIndex = 1;
    private float _targetPoint;
    private const float _time = 1.0f;

    public BallMesh(GameObject gameObject, float radius, int segments, Material material) : base(gameObject)
    {
        _radius = radius;
        Material = material;
        _angle = 360/segments;
    }

    public void Draw()
    {
        DrawCircle();
        Transition();
    }

    private void DrawCircle()
    {
        circleVertices.Clear();
        uvs.Clear();
        triangles.Clear();
        
        var triangleCount = 0;
        
        var lastTriangle = 360 / _angle;
    
        var center = Vector3.zero;
        
        var firstPointX = _radius * Mathf.Sin(0f);
        var firstPointY = _radius * Mathf.Cos(0f);
    
        var firstPoint = new Vector3(firstPointX, firstPointY, 0f);
    
        circleVertices.Add(center);
        circleVertices.Add(firstPoint);

        for (int i = 0; i < 360; i += _angle)
        {
            var rad = (i + _angle) * Mathf.Deg2Rad;
            
            var x = _radius * Mathf.Sin(rad);
            var y = _radius * Mathf.Cos(rad);
    
            var currentPoint = new Vector3(x, y, 0f);
            
            if (triangleCount != lastTriangle)
            {   
                circleVertices.Add(currentPoint);
                triangles.Add(0);
                triangles.Add(triangleCount + 1);
                triangles.Add(triangleCount + 2);
            }
            else
            {
                triangles.Add(0);
                triangles.Add(triangleCount + 1);
                triangles.Add(1);
            }
            
            triangleCount++;
        }
    
        Mesh.vertices = circleVertices.ToArray();
        Mesh.triangles = triangles.ToArray();
    }
    
    private void Transition()
    {
        _targetPoint += Time.deltaTime / _time;
        Material.color = Color.Lerp(_colors[_currentColorIndex], _colors[_targetColorIndex], _targetPoint);

        if (_targetPoint >= 1)
        {
            _targetPoint = 0;
            _currentColorIndex = _targetColorIndex;
            _targetColorIndex++;

            if (_targetColorIndex == _colors.Length)
            {
                _targetColorIndex = 0;
            }
        }
    }
}