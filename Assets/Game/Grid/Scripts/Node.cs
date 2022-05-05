using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Node : Entity
{
    private MeshRenderer _mr;

    protected override void Start()
    {
        TryGetComponent(out _mr);
    }

    public void ChangeMaterial(Material newMaterial)
    {
        _mr.material = newMaterial;
    }
}
