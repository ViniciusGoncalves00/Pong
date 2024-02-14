using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class FrameMesh : DrawMesh
{
    private readonly Vector3[] _vertices = new Vector3[8];
    private readonly int[] _triangles = new int[24];
    
    public FrameMesh(GameObject gameObject) : base(gameObject)
    {
    }

    public Rect Draw(float sizeX, float sizeY, float thickness)
    {
        var rect = Rect(sizeX, sizeY);
        Thickness(thickness);
        return rect;
    }
    
    private Rect Rect(float sizeX, float sizeY)
    {
        var rect = new Rect(0, 0, 0,0);
        
        var halfWidth = sizeX / 2;
        var halfHeight = sizeY / 2;
        
        var leftBottom = new Vector2(-halfWidth, -halfHeight);
        var leftTop = new Vector2(-halfWidth, +halfHeight);
        var rightTop = new Vector2(+halfWidth, +halfHeight);
        var rightBottom = new Vector2(+halfWidth, -halfHeight);
        
        rect.x = leftBottom.x;
        rect.y = leftBottom.y;
        rect.width = rightTop.x;
        rect.height = rightTop.y;

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

        return rect;
    }
    
    private void Thickness(float thickness)
    {
        var thicknessLeftDown = new Vector2(
            _vertices[0].x - thickness,
            _vertices[0].y - thickness);
        var thicknessLeftUp = new Vector2(
            _vertices[1].x - thickness,
            _vertices[1].y + thickness);
        var thicknessRightUp = new Vector2(
            _vertices[2].x + thickness,
            _vertices[2].y + thickness);
        var thicknessRightDown = new Vector2(
            _vertices[3].x + thickness,
            _vertices[3].y - thickness);

        _vertices[4] = thicknessLeftDown;
        _vertices[5] = thicknessLeftUp;
        _vertices[6] = thicknessRightUp;
        _vertices[7] = thicknessRightDown;

        var index = 0;

        for (int i = 0; i < 4; i++)
        {
            if (i != 3)
            {
                _triangles[index] = i;
                index++;
                _triangles[index] = i + 4;
                index++;
                _triangles[index] = i + 5;
                index++;
                _triangles[index] = i;
                index++;
                _triangles[index] = i + 5;
                index++;
                _triangles[index] = i + 1;
                index++;
            }
            else
            {
                _triangles[index] = i;
                index++;
                _triangles[index] = i + 4;
                index++;
                _triangles[index] = i + 1;
                index++;
                _triangles[index] = i;
                index++;
                _triangles[index] = i + 1;
                index++;
                _triangles[index] = 0;
                index++;
            }
        }
        
        Mesh.vertices = _vertices;
        Mesh.triangles = _triangles;
    }
}