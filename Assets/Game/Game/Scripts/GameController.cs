using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : Controller
{
    public static GameController Instance;
    public Selectable HoveredEntity { get; set; }
    public Selectable SelectedEntity { get; set; }

    public Action<Selectable> OnEntityHovered;
    public Action<Selectable> OnEntitySelected;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        //CheckNodeHovering();
        CheckNodeHovering();
        CheckNodeSelecting();
    }



    private bool GetCameraRaycastHitInfo(out RaycastHit hitInfo)
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        return Physics.Raycast(_ray, out hitInfo);
    }

    private bool CheckRaycastHit()
    {
        if (IsMouseOverUI() || !GetCameraRaycastHitInfo(out RaycastHit _hitInfo)) { return false; }

        return true;
    }

    private void CheckNodeHovering()
    {
        if (IsMouseOverUI() || !GetCameraRaycastHitInfo(out RaycastHit _hitInfo)) { return; }

        if (_hitInfo.collider.gameObject.TryGetComponent(out Node _hoveredNode))
        {
            if (HoveredEntity is Node) { ((Node)HoveredEntity).ChangeState(Node.SelectionState.Default); }

            Debug.Log("Hovered: " + _hoveredNode.CoordX + ", " + _hoveredNode.CoordZ);
            _hoveredNode.ChangeState(Node.SelectionState.Hovered);

            HoveredEntity = _hoveredNode;

            if (SelectedEntity is Node) { ((Node)SelectedEntity).ChangeState(Node.SelectionState.Selected); }
        }
    }

    private void CheckNodeSelecting()
    {
        if (IsMouseOverUI() || !GetCameraRaycastHitInfo(out RaycastHit _hitInfo)) { return; }

        if (Input.GetMouseButtonDown(0) && _hitInfo.collider.gameObject.TryGetComponent(out Node _hoveredNode))
        {
            if (SelectedEntity is Node) { ((Node)SelectedEntity).ChangeState(Node.SelectionState.Default); }

            Debug.Log("Selected: " + _hoveredNode.CoordX + ", " + _hoveredNode.CoordZ);
            _hoveredNode.ChangeState(Node.SelectionState.Selected);

            SelectedEntity = _hoveredNode;
        }
    }

    public static bool IsMouseOverUI() { return EventSystem.current.IsPointerOverGameObject(); }
}
