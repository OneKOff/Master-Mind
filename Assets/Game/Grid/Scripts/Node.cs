using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Node : Selectable
{
    private MeshRenderer _mr;

    private void Start()
    {
        TryGetComponent(out _mr);
    }

    public void ChangeMaterial(Material newMaterial)
    {
        _mr.material = newMaterial;
    }
}
