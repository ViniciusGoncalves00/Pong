using UnityEngine;

public abstract class DrawMesh
{
    private protected readonly Mesh Mesh;
    private protected readonly MeshFilter MeshFilter;
    private protected readonly MeshRenderer MeshRenderer;
    
    private protected DrawMesh(GameObject gameObject)
    {
        Mesh = new Mesh();
        
        MeshRenderer = gameObject.TryGetComponent<MeshRenderer>(out var meshRenderer) ? meshRenderer : gameObject.AddComponent<MeshRenderer>();
        
        MeshRenderer.material = default;
        
        MeshFilter = gameObject.TryGetComponent<MeshFilter>(out var meshFilter) ? meshFilter : gameObject.AddComponent<MeshFilter>();
        
        MeshFilter.mesh = Mesh;
    }
}