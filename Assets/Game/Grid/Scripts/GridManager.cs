using UnityEngine;

[RequireComponent(typeof(GridGenerator))]
public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    [HideInInspector]
    [Range(5, 200)]
    public int SizeX, SizeY;

    [HideInInspector]
    public float NodeSize { get; set; } = 1f;

    public Node[,] NodesGrid;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }

    private void Start()
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
            NodesGrid[node.Coords.x, node.Coords.y] = node;
        }
    }
}
