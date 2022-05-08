public class PathNode
{
    public Node Node { get; private set; }
    public int Range { get; private set; }
    public PathNode Previous { get; private set; }

    public PathNode(Node node, int pathLength)
    {
        this.Node = node;
        this.Range = pathLength;
    }

    public PathNode(Node node, int pathLength, PathNode prevNode)
    {
        this.Node = node;
        this.Range = pathLength;
        this.Previous = prevNode;
    }

    public void SetRange(int range) { this.Range = range; }
    public void SetPrevious(PathNode prev) { this.Previous = prev; }
}
