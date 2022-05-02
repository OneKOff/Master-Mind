using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridGenerator : MonoBehaviour
{
    public Node NodePrefab;

    [Range(5, 200)]
    public int SizeX, SizeY;
    public float NodeSize { get; set; } = 1f;

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
        //transform.position = new Vector3(-(GGrid.Instance.SizeX - 1) * GGrid.Instance.NodeSize / 2f, transform.position.y, -(GGrid.Instance.SizeZ - 1) * GGrid.Instance.NodeSize / 2f);
        //transform.position = new Vector3(NodeSize / 2f, transform.position.y, NodeSize / 2f);
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
        Node node = Instantiate(NodePrefab, transform);
        node.transform.position += new Vector3(x * NodeSize, 0, y * NodeSize);
        node.Coords.x = x; node.Coords.y = y;
    }
}
