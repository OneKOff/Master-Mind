using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGrid : MonoBehaviour
{
    public static GGrid Instance;

    [HideInInspector] [Range(5, 200)] public int SizeX, SizeZ;
    [HideInInspector] public float NodeSize { get; set; } = 1f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        if (!TryGetComponent(out GenerateGrid generate)) { return; }

        SizeX = generate.SizeX; SizeZ = generate.SizeZ;
        NodeSize = generate.NodeSize;
        Instance = this;
    }
}
