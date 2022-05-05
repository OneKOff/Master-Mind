using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
    [Range(0, 199)] public int CoordX;
    [Range(0, 199)] public int CoordY;

    protected virtual void Start()
    {
        CoordX = Mathf.Clamp(CoordX, 0, GameMainManager.Instance.GridManager.SizeX - 1);
        CoordY = Mathf.Clamp(CoordY, 0, GameMainManager.Instance.GridManager.SizeY - 1);
        transform.position = new Vector3(GameMainManager.Instance.GridManager.transform.position.x + CoordX *
            GameMainManager.Instance.GridManager.NodeSize, GameMainManager.Instance.GridManager.transform.position.y,
            GameMainManager.Instance.GridManager.transform.position.z + CoordY * GameMainManager.Instance.GridManager.NodeSize);
        /*if (transform.position.x >= -GGrid.Instance.sizeX * GGrid.Instance.NodeSize / 2f && transform.position.x <= GGrid.Instance.sizeX * GGrid.Instance.NodeSize / 2f &&
            transform.position.z >= -GGrid.Instance.sizeZ * GGrid.Instance.NodeSize / 2f && transform.position.z <= GGrid.Instance.sizeZ * GGrid.Instance.NodeSize / 2f)*/
    }
}
