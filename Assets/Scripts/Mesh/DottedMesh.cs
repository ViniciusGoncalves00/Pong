using UnityEngine;

public class DottedMesh : DrawMesh
{
    private int _verticesArraySize;
    private int _trianglesArraySize;
    
    private Vector3[] _vertices;
    private int[] _triangles;
    
    public DottedMesh(GameObject gameObject) : base(gameObject)
    {
    }
    
    public void Draw(Vector2 center, Vector2 size, int amount, float spacing)
    {
        Dotted(center, size, amount, spacing);
    }
    
    public void Draw(Vector2 center, Vector2 size, float height)
    {
        DottedDistributed(center, size, height);
    }
    
    private void Dotted(Vector2 center, Vector2 size, int amount, float spacing)
    {
        _verticesArraySize = 4 * amount;
        _trianglesArraySize = 6 * amount;
        
        _vertices = new Vector3[_verticesArraySize];
        _triangles = new int[_trianglesArraySize];
        
        var halfWidth = size.x / 2;
        var halfHeight = size.y / 2;
        var distanceBetweenDotsCenter = size.y + spacing;
        var dotPosition = amount / 2f;
        dotPosition -= 0.5f;    
    
        var verticeIndex = 0;
        var triangleIndex = 0;
        
        for (int i = 0; i < amount; i++)
        {
            var position = dotPosition * distanceBetweenDotsCenter;
            
            var leftBottom = new Vector2(-halfWidth + center.x, -halfHeight + position + center.y);
            var leftTop = new Vector2(-halfWidth + center.x, +halfHeight + position + center.y);
            var rightTop = new Vector2(+halfWidth + center.x, +halfHeight + position + center.y);
            var rightBottom = new Vector2(+halfWidth + center.x, -halfHeight + position + center.y);
            
            _vertices[verticeIndex + 0] = leftBottom;
            _vertices[verticeIndex + 1] = leftTop;
            _vertices[verticeIndex + 2] = rightTop;
            _vertices[verticeIndex + 3] = rightBottom;
    
            _triangles[triangleIndex + 0] = verticeIndex + 0;
            _triangles[triangleIndex + 1] = verticeIndex + 1;
            _triangles[triangleIndex + 2] = verticeIndex + 2;
            _triangles[triangleIndex + 3] = verticeIndex + 0;
            _triangles[triangleIndex + 4] = verticeIndex + 2;
            _triangles[triangleIndex + 5] = verticeIndex + 3;
    
            dotPosition--;
            verticeIndex += 4;
            triangleIndex += 6;
        }
        
        Mesh.vertices = _vertices;
        Mesh.triangles = _triangles;
    }
    
    private void DottedDistributed(Vector2 center, Vector2 size, float height)
    {
        var spaces = height / size.y;
        var dotsAmount = (int)spaces / 2;
        
        _verticesArraySize = (int)spaces * 4;
        _trianglesArraySize = (int)spaces * 6;
        
        _vertices = new Vector3[_verticesArraySize];
        _triangles = new int[_trianglesArraySize];
        
        var halfWidth = size.x / 2;
        var halfHeight = size.y / 2;
        var distanceBetweenDotsCenter = size.y * 2;
        var dotPosition = dotsAmount - 0.5f;    

        var verticeIndex = 0;
        var triangleIndex = 0;
        
        for (int i = 0; i < spaces; i++)
        {
            var position = dotPosition * distanceBetweenDotsCenter;
            
            var leftBottom = new Vector2(-halfWidth + center.x, -halfHeight + position + center.y);
            var leftTop = new Vector2(-halfWidth + center.x, +halfHeight + position + center.y);
            var rightTop = new Vector2(+halfWidth + center.x, +halfHeight + position + center.y);
            var rightBottom = new Vector2(+halfWidth + center.x, -halfHeight + position + center.y);
            
            _vertices[verticeIndex + 0] = leftBottom;
            _vertices[verticeIndex + 1] = leftTop;
            _vertices[verticeIndex + 2] = rightTop;
            _vertices[verticeIndex + 3] = rightBottom;

            _triangles[triangleIndex + 0] = verticeIndex + 0;
            _triangles[triangleIndex + 1] = verticeIndex + 1;
            _triangles[triangleIndex + 2] = verticeIndex + 2;
            _triangles[triangleIndex + 3] = verticeIndex + 0;
            _triangles[triangleIndex + 4] = verticeIndex + 2;
            _triangles[triangleIndex + 5] = verticeIndex + 3;

            dotPosition--;
            verticeIndex += 4;
            triangleIndex += 6;
        }
        
        Mesh.vertices = _vertices;
        Mesh.triangles = _triangles;
    }
}