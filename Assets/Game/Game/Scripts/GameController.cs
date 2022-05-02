using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public TurnManager TurnManager;
    public List<PlayerManager> Players = new List<PlayerManager>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    //private void Update()
    //{
    //    CheckNodeHovering();
    //    CheckNodeSelecting();
    //}

    //private bool GetCameraRaycastHitInfo(out RaycastHit hitInfo)
    //{
    //    Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    return Physics.Raycast(_ray, out hitInfo);
    //}

    //private void CheckNodeHovering()
    //{
    //    if (IsMouseOverUI() || !GetCameraRaycastHitInfo(out RaycastHit _hitInfo)) { return; }

    //    if (_hitInfo.collider.gameObject.TryGetComponent(out Node _hoveredNode))
    //    {
    //        if (HoveredEntity is Node) { ((Node)HoveredEntity).ChangeState(Node.SelectionState.Default); }

    //        Debug.Log("Hovered: " + _hoveredNode.Coords.x + ", " + _hoveredNode.Coords.y);
    //        _hoveredNode.ChangeState(Node.SelectionState.Hovered);

    //        HoveredEntity = _hoveredNode;

    //        if (SelectedEntity is Node) { ((Node)SelectedEntity).ChangeState(Node.SelectionState.Selected); }
    //    }
    //}

    //private void CheckNodeSelecting()
    //{
    //    if (IsMouseOverUI() || !GetCameraRaycastHitInfo(out RaycastHit _hitInfo)) { return; }

    //    if (Input.GetMouseButtonDown(0) && _hitInfo.collider.gameObject.TryGetComponent(out Node _hoveredNode))
    //    {
    //        if (SelectedEntity is Node) { ((Node)SelectedEntity).ChangeState(Node.SelectionState.Default); }

    //        Debug.Log("Selected: " + _hoveredNode.Coords.x + ", " + _hoveredNode.Coords.y);
    //        _hoveredNode.ChangeState(Node.SelectionState.Selected);

    //        SelectedEntity = _hoveredNode;
    //    }
    //}
}
