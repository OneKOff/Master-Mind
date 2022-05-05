using UnityEngine;

[RequireComponent(typeof(GridGenerator))]
public class GridManager : MonoBehaviour
{
    [HideInInspector]
    [Range(5, 200)]
    public int SizeX, SizeY;
    [HideInInspector]
    public float NodeSize { get; set; } = 1f;
    [HideInInspector]
    public Node[,] NodesGrid;

    private void Awake()
    {
        GetGeneratedGridData();
    }

    private void GetGeneratedGridData()
    {
        if (!TryGetComponent(out GridGenerator generator)) { return; }

        SizeX = generator.SizeX;
        SizeY = generator.SizeY;
        NodeSize = generator.NodeSize;

        NodesGrid = new Node[SizeX, SizeY];

        var nodes = GetComponentsInChildren<Node>();
        foreach (var node in nodes)
        {
            NodesGrid[node.CoordX, node.CoordY] = node;
        }
    }
}
