using UnityEngine;

public class RectMesh : DrawMesh
{
    private readonly Vector3[] _vertices = new Vector3[4];
    private readonly int[] _triangles = new int[6];
    
    public RectMesh(GameObject gameObject) : base(gameObject)
    {
    }

    public void Draw(float sizeX, float sizeY)
    {
        Rect(sizeX, sizeY);
    }

    private void Rect(float sizeX, float sizeY)
    {
        var halfWidth = sizeX / 2;
        var halfHeight = sizeY / 2;

        var leftBottom = new Vector2(-halfWidth, -halfHeight);
        var leftTop = new Vector2(-halfWidth, +halfHeight);
        var rightTop = new Vector2(+halfWidth, +halfHeight);
        var rightBottom = new Vector2(+halfWidth, -halfHeight);

        // rect.x = leftBottom.x;
        // rect.y = leftBottom.y;
        // rect.width = rightTop.x;
        // rect.height = rightTop.y;

        _vertices[0] = leftBottom;
        _vertices[1] = leftTop;
        _vertices[2] = rightTop;
        _vertices[3] = rightBottom;

        _triangles[0] = 0;
        _triangles[1] = 1;
        _triangles[2] = 2;
        _triangles[3] = 0;
        _triangles[4] = 2;
        _triangles[5] = 3;

        Mesh.vertices = _vertices;
        Mesh.triangles = _triangles;
    }
}