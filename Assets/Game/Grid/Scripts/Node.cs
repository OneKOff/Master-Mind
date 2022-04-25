using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MeshRenderer))]
public class Node : Selectable
{
    public enum SelectionState { Default = 0, Hovered = 1, Selected = 2 };

    [SerializeField] private Color colorDefault;
    [SerializeField] private Color colorHovered;
    [SerializeField] private Color colorSelected;


    private MeshRenderer _mr;
    private SelectionState _currentSelection = SelectionState.Default;


    private void Start()
    {
        if (!TryGetComponent(out _mr))
        {
            Debug.Log("Node " + CoordX + ", " + CoordZ + "doesn't have MeshRenderer component");
            return;
        }

        GameController.Instance.OnEntitySelected += SendNodeData;
    }

    protected virtual void OnDestroy()
    {
        GameController.Instance.OnEntitySelected -= SendNodeData;
    }

    public void ChangeState(SelectionState state) // 0 - def, 1 - hovered, 2 - selected
    {
        switch (state)
        {
            case SelectionState.Default:
                _mr.material.color = colorDefault;
                break;
            case SelectionState.Hovered:
                _mr.material.color = colorHovered;
                break;
            case SelectionState.Selected:
                _mr.material.color = colorSelected;
                break;
        }
    }

    protected void SendNodeData(Selectable selectable)
    {
        if ((Unit)selectable == this)
        {
            GameController.Instance.SelectedEntity = this;
        }
    }
}
