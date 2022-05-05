using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridGenerator : MonoBehaviour
{
    public Node NodePrefab;

    [Range(5, 200)]
    public int SizeX, SizeY;
    public bool useNativeNodeSize = false;
    public float NodeSize = 1f;

    public bool Generate = false;

    private void Update()
    {
        if (Generate) { return; }
        DeleteGridNodes();
        CreateGridNodes();
        Generate = true;
    }

    private void DeleteGridNodes()
    {
        Node[] nodes = GetComponentsInChildren<Node>();
        foreach (Node node in nodes) { DestroyImmediate(node.gameObject); }
    }
    private void CreateGridNodes()
    {
        for (var x = 0; x < SizeX; x++)
        {
            for (var y = 0; y < SizeY; y++)
            {
                CreateNode(x, y);
            }
        }
    }
    private void CreateNode(int x, int y)
    {
        var node = Instantiate(NodePrefab, transform);
        var usedNodeSizeX = useNativeNodeSize ? node.transform.localScale.x : NodeSize;
        var usedNodeSizeY = useNativeNodeSize ? node.transform.localScale.y : NodeSize;

        node.transform.position += new Vector3(x * usedNodeSizeX, 0, y * usedNodeSizeY);
        node.CoordX = x; node.CoordY = y;
    }
}
