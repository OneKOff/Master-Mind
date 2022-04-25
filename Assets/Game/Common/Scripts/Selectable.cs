using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour
{
    [Range(0, 199)]
    public int CoordX, CoordZ;

    protected virtual void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hitInfo;

        if (!Input.GetMouseButtonDown(0) || IsMouseOverUI()) { return; }
        if (!Physics.Raycast(_ray, out _hitInfo)) { return; }
        if (!_hitInfo.collider.TryGetComponent(out Selectable s)) { return; }

        Debug.Log("Selectable " + s.name + ". Coords: " + s.CoordX + ", " + s.CoordZ);
        //GameSystem.Instance.Selected = this;
    }

    public static bool IsMouseOverUI() { return EventSystem.current.IsPointerOverGameObject(); }
}
