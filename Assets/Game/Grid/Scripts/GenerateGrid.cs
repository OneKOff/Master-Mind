using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GenerateGrid : MonoBehaviour
{
    public Node NodePrefab;

    [Range(5, 200)]
    public int SizeX, SizeZ;
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
        for (int x = 0; x < SizeX; x++) {
            for (int z = 0; z < SizeZ; z++) {
                CreateNode(x, z);
            }
        }
    }
    private void CreateNode(int x, int z)
    {
        Node node = Instantiate(NodePrefab, transform);
        node.transform.position += new Vector3(x * NodeSize, 0, z * NodeSize);
        node.CoordX = x; node.CoordZ = z;
    }
}
