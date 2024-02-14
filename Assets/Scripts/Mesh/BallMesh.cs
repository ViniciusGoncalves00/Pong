using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BallMesh : MonoBehaviour
{   
    List<Vector3> circleVerteices = new List<Vector3>();
    List<Vector2> uvs = new List<Vector2>();
    List<int> triangles = new List<int>();
    
    private Mesh _mesh;
    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;

    [SerializeField] private float _radius = 1f;
    [SerializeField] private Material _material;

    [SerializeField] private Ball Ball;
    
    void Start()
    {
        _meshRenderer = gameObject.AddComponent<MeshRenderer>();
        _meshRenderer.material = _material;
        
        _meshFilter = gameObject.AddComponent<MeshFilter>();
        _mesh = new Mesh();
        _meshFilter.mesh = _mesh;
        
        DrawCircle();
    }

    private void Update()
    {
        DrawCircle();
        _material.color += new Color(0.05f, 0.01f, 0.01f) * Time.deltaTime;
    }
    
    void DrawCircle()
    {
        circleVerteices.Clear();
        uvs.Clear();
        triangles.Clear();
        
        float val = 3.14285f / 180f;//one degree = val radians
        int deltaAngle = 15;

        Vector3 center = Ball.transform.position;
        transform.position = center;
        circleVerteices.Add(center);
        uvs.Add(new Vector2(0.5f, 0.5f));
        int triangleCount = 0;

        float x1 = _radius * Mathf.Cos(0);
        float y1 = _radius * Mathf.Sin(0);
        float z1 = 0;
        Vector3 point1 = new Vector3(x1, y1, z1);
        circleVerteices.Add(point1);
        uvs.Add(new Vector2((x1 + _radius) / 2 * _radius, (y1 + _radius) / 2 * _radius));

        for (int i = 0; i < 359; i = i + deltaAngle)
        {
            float x2 = _radius * Mathf.Cos((i + deltaAngle) * val);
            float y2 = _radius * Mathf.Sin((i + deltaAngle) * val);
            float z2 = 0;
            Vector3 point2 = new Vector3(x2, y2, z2);
            
            circleVerteices.Add(point2);
           
            uvs.Add(new Vector2((x2 + _radius)/ 2 * _radius, (y2 +_radius)/ 2 * _radius));

            triangles.Add(0);
            triangles.Add(triangleCount  + 2);
            triangles.Add(triangleCount  + 1);

            triangleCount++;
            point1 = point2;
        }

        _mesh.vertices = circleVerteices.ToArray();
        _mesh.triangles = triangles.ToArray();
        _mesh.uv = uvs.ToArray();
    }
}
