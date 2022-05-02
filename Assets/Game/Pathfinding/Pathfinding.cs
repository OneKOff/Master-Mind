using System.Collections.Generic;
using UnityEngine;

//public class Pathfinding
//{
//    public static List<Node> GetNodesWithSearchType(SearchType searchType, Node sourceNode, int minRange, int maxRange)
//    {
//        switch (searchType)
//        {
//            case SearchType.Absolute:
//                GetNodesInAbsoluteSearch(sourceNode, minRange, maxRange);
//                break;
//            case SearchType.Impulse:
//                GetNodesInImpulseSearch(sourceNode, minRange, maxRange);
//                break;
//            case SearchType.Pathfinding:
//                GetNodesInPathfindingSearch(sourceNode, minRange, maxRange);
//                break;
//        }

//        return null;
//    }

//    enum Direction
//    {
//        LeftUp, Up, RightUp,
//        Left, None, Right,
//        LeftDown, Down, RightDown
//    }

//    public static List<PathNode> GetNodesInPathfindingSearch(Node sourceNode, int minRange, int maxRange)
//    {
//        var maskCenter = new Vector2Int(maxRange, maxRange);
//        PathNode centerNode;

//        var area = new List<PathNode>();
//        var offset = sourceNode.Coords - new Vector2Int(maxRange, maxRange);
//        var mask = new PathNode[2 * maxRange + 1, 2 * maxRange + 1];

//        for (int i = 0; i < 2 * maxRange + 1; i++)
//        {
//            for (int j = 0; j < 2 * maxRange + 1; j++)
//            {
//                if (offset.x + i >= 0 && offset.x + i < GridManager.Instance.SizeX &&
//                    offset.y + j >= 0 && offset.y + j < GridManager.Instance.SizeY)
//                {
//                    mask[i, j] = new PathNode(GridManager.Instance.nodeList[offset.x + i, offset.y + j], int.MaxValue);
//                }
//            }
//        }

//        centerNode = mask[maskCenter.x, maskCenter.y];
//        centerNode.SetLength(0);
//        area.Add(centerNode);

//        if (maxRange > 0)
//        {
//            if (GridManager.Instance.NodeExists(sourceNode.Coords + Vector2Int.left))
//            {
//                mask[maskCenter.x - 1, maskCenter.y].SetLength(1);
//                mask[maskCenter.x - 1, maskCenter.y].SetPrevious(centerNode);
//                area.Add(mask[maskCenter.x - 1, maskCenter.y]);

//                if (!GridManager.Instance.NodeOccupied(sourceNode.Coords + Vector2Int.left)) // offset + maskCenter
//                {
//                    RecPathfinding(mask[maskCenter.x - 1, maskCenter.y], maxRange, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(sourceNode.Coords + Vector2Int.right))
//            {
//                mask[maskCenter.x + 1, maskCenter.y].SetLength(1);
//                mask[maskCenter.x + 1, maskCenter.y].SetPrevious(centerNode);
//                area.Add(mask[maskCenter.x + 1, maskCenter.y]);

//                if (!GridManager.Instance.NodeOccupied(sourceNode.Coords + Vector2Int.right))
//                {
//                    RecPathfinding(mask[maskCenter.x + 1, maskCenter.y], maxRange, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(sourceNode.Coords + Vector2Int.up))
//            {
//                mask[maskCenter.x, maskCenter.y + 1].SetLength(1);
//                mask[maskCenter.x, maskCenter.y + 1].SetPrevious(centerNode);
//                area.Add(mask[maskCenter.x, maskCenter.y + 1]);

//                if (!GridManager.Instance.NodeOccupied(sourceNode.Coords + Vector2Int.up))
//                {
//                    RecPathfinding(mask[maskCenter.x, maskCenter.y + 1], maxRange, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(sourceNode.Coords + Vector2Int.down))
//            {
//                mask[maskCenter.x, maskCenter.y - 1].SetLength(1);
//                mask[maskCenter.x, maskCenter.y - 1].SetPrevious(centerNode);
//                area.Add(mask[maskCenter.x, maskCenter.y - 1]);

//                if (!GridManager.Instance.NodeOccupied(sourceNode.Coords + Vector2Int.down))
//                {
//                    RecPathfinding(mask[maskCenter.x, maskCenter.y - 1], maxRange, area, offset, mask);
//                }
//            }
//        }

//        // Убираем слишком близкие ячейки (на расстоянии меньше минимального)
//        List<PathNode> newArea = new List<PathNode>();
//        foreach (PathNode pathNode in area)
//        {
//            if (pathNode.length >= minRange)
//            {
//                newArea.Add(pathNode);
//            }
//        }

//        return newArea;
//    }
//    private static void RecPathfinding(PathNode pathNode, int maxRange, List<PathNode> area, Vector2Int offset, PathNode[,] mask)
//    {
//        if (pathNode.length < maxRange)
//        {
//            if (GridManager.Instance.NodeExists(pathNode.node.Coords + Vector2Int.left) &&
//                    mask[pathNode.node.Coords.x - offset.x - 1, pathNode.node.Coords.y - offset.y].length > pathNode.length + 1)
//            {
//                mask[pathNode.node.Coords.x - offset.x - 1, pathNode.node.Coords.y - offset.y].SetLength(pathNode.length + 1);
//                mask[pathNode.node.Coords.x - offset.x - 1, pathNode.node.Coords.y - offset.y].SetPrevious(pathNode);
//                area.Add(mask[pathNode.node.Coords.x - offset.x - 1, pathNode.node.Coords.y - offset.y]);

//                if (!GridManager.Instance.NodeOccupied(pathNode.node.Coords + Vector2Int.left))
//                {
//                    RecPathfinding(mask[pathNode.node.Coords.x - offset.x - 1, pathNode.node.Coords.y - offset.y], maxRange, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(pathNode.node.Coords + Vector2Int.right) &&
//                    mask[pathNode.node.Coords.x - offset.x + 1, pathNode.node.Coords.y - offset.y].length > pathNode.length + 1)
//            {
//                mask[pathNode.node.Coords.x - offset.x + 1, pathNode.node.Coords.y - offset.y].SetLength(pathNode.length + 1);
//                mask[pathNode.node.Coords.x - offset.x + 1, pathNode.node.Coords.y - offset.y].SetPrevious(pathNode);
//                area.Add(mask[pathNode.node.Coords.x - offset.x + 1, pathNode.node.Coords.y - offset.y]);

//                if (!GridManager.Instance.NodeOccupied(pathNode.node.Coords + Vector2Int.right))
//                {
//                    RecPathfinding(mask[pathNode.node.Coords.x - offset.x + 1, pathNode.node.Coords.y - offset.y], maxRange, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(pathNode.node.Coords + Vector2Int.up) &&
//                    mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y + 1].length > pathNode.length + 1)
//            {
//                mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y + 1].SetLength(pathNode.length + 1);
//                mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y + 1].SetPrevious(pathNode);
//                area.Add(mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y + 1]);

//                if (!GridManager.Instance.NodeOccupied(pathNode.node.Coords + Vector2Int.up))
//                {
//                    RecPathfinding(mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y + 1], maxRange, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(pathNode.node.Coords + Vector2Int.down) &&
//                    mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y - 1].length > pathNode.length + 1)
//            {
//                mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y - 1].SetLength(pathNode.length + 1);
//                mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y - 1].SetPrevious(pathNode);
//                area.Add(mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y - 1]);

//                if (!GridManager.Instance.NodeOccupied(pathNode.node.Coords + Vector2Int.down))
//                {
//                    RecPathfinding(mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y - 1], maxRange, area, offset, mask);
//                }
//            }
//        }
//    }

//    public static List<PathNode> GetNodesInImpulseSearch(Node sourceNode, int minRange, int maxRange)
//    {
//        var maskCenter = new Vector2Int(maxRange, maxRange);
//        PathNode centerNode;

//        var area = new List<PathNode>();
//        var offset = sourceNode.Coords - new Vector2Int(maxRange, maxRange);
//        var mask = new PathNode[2 * maxRange + 1, 2 * maxRange + 1];

//        for (int i = 0; i < 2 * maxRange + 1; i++)
//        {
//            for (int j = 0; j < 2 * maxRange + 1; j++)
//            {
//                if (offset.x + i >= 0 && offset.x + i < GridManager.Instance.SizeX &&
//                    offset.y + j >= 0 && offset.y + j < GridManager.Instance.SizeY)
//                {
//                    mask[i, j] = new PathNode(GridManager.Instance.nodeList[offset.x + i, offset.y + j], int.MaxValue);
//                }
//            }
//        }

//        centerNode = mask[maskCenter.x, maskCenter.y];
//        centerNode.SetLength(0);
//        area.Add(centerNode);

//        if (maxRange > 0)
//        {
//            if (GridManager.Instance.NodeExists(sourceNode.Coords + Vector2Int.left))
//            {
//                mask[maskCenter.x - 1, maskCenter.y].SetLength(1);
//                mask[maskCenter.x - 1, maskCenter.y].SetPrevious(centerNode);
//                area.Add(mask[maskCenter.x - 1, maskCenter.y]);

//                if (!GridManager.Instance.NodeOccupied(sourceNode.Coords + Vector2Int.left))
//                {
//                    RecImpulse(mask[maskCenter.x - 1, maskCenter.y], maxRange, Direction.Left, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(sourceNode.Coords + Vector2Int.right))
//            {
//                mask[maskCenter.x + 1, maskCenter.y].SetLength(1);
//                mask[maskCenter.x + 1, maskCenter.y].SetPrevious(centerNode);
//                area.Add(mask[maskCenter.x + 1, maskCenter.y]);

//                if (!GridManager.Instance.NodeOccupied(sourceNode.Coords + Vector2Int.right))
//                {
//                    RecImpulse(mask[maskCenter.x + 1, maskCenter.y], maxRange, Direction.Right, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(sourceNode.Coords + Vector2Int.up))
//            {
//                mask[maskCenter.x, maskCenter.y + 1].SetLength(1);
//                mask[maskCenter.x, maskCenter.y + 1].SetPrevious(centerNode);
//                area.Add(mask[maskCenter.x, maskCenter.y + 1]);

//                if (!GridManager.Instance.NodeOccupied(sourceNode.Coords + Vector2Int.up))
//                {
//                    RecImpulse(mask[maskCenter.x, maskCenter.y + 1], maxRange, Direction.Up, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(sourceNode.Coords + Vector2Int.down))
//            {
//                mask[maskCenter.x, maskCenter.y - 1].SetLength(1);
//                mask[maskCenter.x, maskCenter.y - 1].SetPrevious(centerNode);
//                area.Add(mask[maskCenter.x, maskCenter.y - 1]);

//                if (!GridManager.Instance.NodeOccupied(sourceNode.Coords + Vector2Int.down))
//                {
//                    RecImpulse(mask[maskCenter.x, maskCenter.y - 1], maxRange, Direction.Down, area, offset, mask);
//                }
//            }
//        }
//        if (maxRange > 1)
//        {
//            if (GridManager.Instance.NodeExists(sourceNode.Coords + Vector2Int.left + Vector2Int.down))
//            {
//                mask[maskCenter.x - 1, maskCenter.y - 1].SetLength(2);
//                mask[maskCenter.x - 1, maskCenter.y - 1].SetPrevious(centerNode);
//                area.Add(mask[maskCenter.x - 1, maskCenter.y - 1]);

//                if (!GridManager.Instance.NodeOccupied(sourceNode.Coords + Vector2Int.left + Vector2Int.down))
//                {
//                    RecImpulse(mask[maskCenter.x - 1, maskCenter.y - 1], maxRange, Direction.LeftDown, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(sourceNode.Coords + Vector2Int.right + Vector2Int.down))
//            {
//                mask[maskCenter.x + 1, maskCenter.y - 1].SetLength(2);
//                mask[maskCenter.x + 1, maskCenter.y - 1].SetPrevious(centerNode);
//                area.Add(mask[maskCenter.x + 1, maskCenter.y - 1]);

//                if (!GridManager.Instance.NodeOccupied(sourceNode.Coords + Vector2Int.right + Vector2Int.down))
//                {
//                    RecImpulse(mask[maskCenter.x + 1, maskCenter.y - 1], maxRange, Direction.RightDown, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(sourceNode.Coords + Vector2Int.left + Vector2Int.up))
//            {
//                mask[maskCenter.x - 1, maskCenter.y + 1].SetLength(2);
//                mask[maskCenter.x - 1, maskCenter.y + 1].SetPrevious(centerNode);
//                area.Add(mask[maskCenter.x - 1, maskCenter.y + 1]);

//                if (!GridManager.Instance.NodeOccupied(sourceNode.Coords + Vector2Int.left + Vector2Int.up))
//                {
//                    RecImpulse(mask[maskCenter.x - 1, maskCenter.y + 1], maxRange, Direction.LeftUp, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(sourceNode.Coords + Vector2Int.right + Vector2Int.up))
//            {
//                mask[maskCenter.x + 1, maskCenter.y + 1].SetLength(2);
//                mask[maskCenter.x + 1, maskCenter.y + 1].SetPrevious(centerNode);
//                area.Add(mask[maskCenter.x + 1, maskCenter.y + 1]);

//                if (!GridManager.Instance.NodeOccupied(sourceNode.Coords + Vector2Int.right + Vector2Int.up))
//                {
//                    RecImpulse(mask[maskCenter.x + 1, maskCenter.y + 1], maxRange, Direction.RightUp, area, offset, mask);
//                }
//            }
//        }

//        // Убираем слишком близкие ячейки (на расстоянии меньше минимального)
//        var newArea = new List<PathNode>();
//        foreach (PathNode pathNode in area)
//        {
//            if (pathNode.length >= minRange)
//            {
//                newArea.Add(pathNode);
//            }
//        }

//        return newArea;
//    }
//    private static void RecImpulse(PathNode pathNode, int maxRange, Direction direction, List<PathNode> area, Vector2Int offset, PathNode[,] mask)
//    {
//        if (pathNode.length < maxRange)
        
//            if (GridManager.Instance.NodeExists(pathNode.node.Coords + Vector2Int.left) &&
//                    mask[pathNode.node.Coords.x - offset.x - 1, pathNode.node.Coords.y - offset.y].length > pathNode.length + 1)
//            {
//                mask[pathNode.node.Coords.x - offset.x - 1, pathNode.node.Coords.y - offset.y].SetLength(pathNode.length + 1);
//                mask[pathNode.node.Coords.x - offset.x - 1, pathNode.node.Coords.y - offset.y].SetPrevious(pathNode);
//                area.Add(mask[pathNode.node.Coords.x - offset.x - 1, pathNode.node.Coords.y - offset.y]);

//                if ((direction == Direction.LeftDown || direction == Direction.Left || direction == Direction.LeftUp) &&
//                    !GridManager.Instance.NodeOccupied(pathNode.node.Coords + Vector2Int.left))
//                {
//                    RecImpulse(mask[pathNode.node.Coords.x - offset.x - 1, pathNode.node.Coords.y - offset.y], maxRange, direction, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(pathNode.node.Coords + Vector2Int.right) &&
//                    mask[pathNode.node.Coords.x - offset.x + 1, pathNode.node.Coords.y - offset.y].length > pathNode.length + 1)
//            {
//                mask[pathNode.node.Coords.x - offset.x + 1, pathNode.node.Coords.y - offset.y].SetLength(pathNode.length + 1);
//                mask[pathNode.node.Coords.x - offset.x + 1, pathNode.node.Coords.y - offset.y].SetPrevious(pathNode);
//                area.Add(mask[pathNode.node.Coords.x - offset.x + 1, pathNode.node.Coords.y - offset.y]);

//                if ((direction == Direction.RightDown || direction == Direction.Right || direction == Direction.RightUp) &&
//                    !GridManager.Instance.NodeOccupied(pathNode.node.Coords + Vector2Int.right))
//                {
//                    RecImpulse(mask[pathNode.node.Coords.x - offset.x + 1, pathNode.node.Coords.y - offset.y], maxRange, direction, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(pathNode.node.Coords + Vector2Int.up) &&
//                    mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y + 1].length > pathNode.length + 1)
//            {
//                mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y + 1].SetLength(pathNode.length + 1);
//                mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y + 1].SetPrevious(pathNode);
//                area.Add(mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y + 1]);

//                if ((direction == Direction.LeftUp || direction == Direction.Up || direction == Direction.RightUp) &&
//                    !GridManager.Instance.NodeOccupied(pathNode.node.Coords + Vector2Int.up))
//                {
//                    RecImpulse(mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y + 1], maxRange, direction, area, offset, mask);
//                }
//            }

//            if (GridManager.Instance.NodeExists(pathNode.node.Coords + Vector2Int.down) &&
//                    mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y - 1].length > pathNode.length + 1)
//            {
//                mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y - 1].SetLength(pathNode.length + 1);
//                mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y - 1].SetPrevious(pathNode);
//                area.Add(mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y - 1]);

//                if ((direction == Direction.LeftDown || direction == Direction.Down || direction == Direction.RightDown) &&
//                    !GridManager.Instance.NodeOccupied(pathNode.node.Coords + Vector2Int.down))
//                {
//                    RecImpulse(mask[pathNode.node.Coords.x - offset.x, pathNode.node.Coords.y - offset.y - 1], maxRange, direction, area, offset, mask);
//                }
//            }
//        }

//    public static List<PathNode> GetPath(PathNode target)
//    {
//        var path = new List<PathNode>();

//        while (target.length > 0)
//        {
//            path.Add(target);
//            target = target.prev;
//        }

//        return path;
//    }

//    public static List<PathNode> GetNodesInAbsoluteSearch(Node start, int minRange, int maxRange)
//    {
//        var area = new List<PathNode>();

//        var startCoords = start.Coords;

//        for (int i = 0; i <= maxRange; i++)
//        {
//            for (int j = 0; j <= maxRange - i; j++)
//            {
//                //if (!SceneController.Instance.Grid.NodeOccupied(new Vector2Int(startCoords.x + i, startCoords.y + j)) && Mathf.Abs(i) + Mathf.Abs(j) >= minRange)
//                if (GridManager.Instance.NodeExists(new Vector2Int(startCoords.x + i, startCoords.y + j)) && Mathf.Abs(i) + Mathf.Abs(j) >= minRange)
//                    area.Add(new PathNode(GridManager.Instance.nodeList[startCoords.x + i, startCoords.y + j], Mathf.Abs(i) + Mathf.Abs(j)));
//            }
//        }
//        for (int i = -1; i >= -maxRange; i--)
//        {
//            for (int j = 0; j <= maxRange + i; j++)
//            {
//                if (GridManager.Instance.NodeExists(new Vector2Int(startCoords.x + i, startCoords.y + j)) && Mathf.Abs(i) + Mathf.Abs(j) >= minRange)
//                    area.Add(new PathNode(GridManager.Instance.nodeList[startCoords.x + i, startCoords.y + j], Mathf.Abs(i) + Mathf.Abs(j)));
//            }
//        }
//        for (int i = -1; i >= -maxRange; i--)
//        {
//            for (int j = -1; j >= -maxRange - i; j--)
//            {
//                if (GridManager.Instance.NodeExists(new Vector2Int(startCoords.x + i, startCoords.y + j)) && Mathf.Abs(i) + Mathf.Abs(j) >= minRange)
//                    area.Add(new PathNode(GridManager.Instance.nodeList[startCoords.x + i, startCoords.y + j], Mathf.Abs(i) + Mathf.Abs(j)));
//            }
//        }
//        for (int i = 0; i <= maxRange; i++)
//        {
//            for (int j = -1; j >= -maxRange + i; j--)
//            {
//                if (GridManager.Instance.NodeExists(new Vector2Int(startCoords.x + i, startCoords.y + j)) && Mathf.Abs(i) + Mathf.Abs(j) >= minRange)
//                    area.Add(new PathNode(GridManager.Instance.nodeList[startCoords.x + i, startCoords.y + j], Mathf.Abs(i) + Mathf.Abs(j)));
//            }
//        }

//        return area;
//    }

//    //private static List<Node> GetNodesWithAbsoluteSearch(Node sourceNode)
//    //{
//    //    var nodeArea = new List<Node>();

//    //    return nodeArea;
//    //}

//    //private static List<Node> GetNodesWithImpulseSearch(Node sourceNode)
//    //{
//    //    var nodeArea = new List<Node>();

//    //    return nodeArea;
//    //}

//    //private static List<Node> GetNodesWithPathfindingSearch(Node sourceNode)
//    //{
//    //    var nodeArea = new List<Node>();

//    //    return nodeArea;
//    //}
//}
