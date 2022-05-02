using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    [HideInInspector] public Selectable HoveredEntity;
    [HideInInspector] public Selectable SelectedEntity;

    [HideInInspector] public AbilityType HoveredAbility;
    [HideInInspector] public AbilityType SelectedAbility;

    [HideInInspector] public Material UsageAreaNodeMaterial;
    [HideInInspector] public Material EffectAreaNodeMaterial;
    [HideInInspector] public List<Node> UsageArea;
    [HideInInspector] public List<Node> EffectArea;

    private SelectionStage _selectionStage = SelectionStage.None;

    protected virtual void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hitInfo;

        if (!Input.GetMouseButtonDown(0) || IsMouseOverUI()) { return; }
        if (!Physics.Raycast(_ray, out _hitInfo)) { return; }

        if (_hitInfo.collider.TryGetComponent(out Selectable s))
        {
            SelectEntityStageOne(s);
        }
        
    }

    public static bool IsMouseOverUI() { return EventSystem.current.IsPointerOverGameObject(); }
    public void ResetSelections(SelectionStage selection)
    {
        if (selection < SelectionStage.Target)
        {
            // Clear material
            UsageArea = null;
            EffectArea = null;
        }

        if (selection < SelectionStage.Ability)
        {
            HoveredAbility = AbilityType.None;
            SelectedAbility = AbilityType.None;
        }

        if (selection < SelectionStage.Entity)
        {
            HoveredEntity = null;
            SelectedEntity = null;
        }
    }
    private bool GetCameraRaycastHitInfo(out RaycastHit hitInfo)
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        return Physics.Raycast(_ray, out hitInfo);
    }

    private void SelectEntityStageOne(Selectable entity)
    {
        ResetSelections(SelectionStage.Entity);

        _selectionStage = SelectionStage.Entity;
        SelectedEntity = entity;

        Debug.Log($"Selectable {entity.name}; Coords: {entity.Coords.x}, {entity.Coords.y}.");

        if (entity is Unit)
        {
            SelectAbilityStageTwo(AbilityType.BasicMove);
        }
    }
    private void HoverEntityStageOne(Selectable entity)
    {
        if (_selectionStage < SelectionStage.Entity) { return; }


    }

    private void SelectAbilityStageTwo(AbilityType ability)
    {
        ResetSelections(SelectionStage.Ability);

        _selectionStage = SelectionStage.Ability;
        SelectedAbility = ability;

        Debug.Log($"Ability {nameof(ability)} selected.");

        var abilityPrefab = AbilityManager.Instance.GetAbility(ability);
        var abilityData = abilityPrefab.Data;

        UsageArea = new List<Node>();
        // UsageArea = Pathfinding.GetNodesInArea(abilityPrefab.SearchType, abilityPrefab.)
    }
    private void HoverAbilityStageTwo(BaseAbilityUI abilityUI)
    {
        if (_selectionStage < SelectionStage.Ability) { return; }


    }

    private void SelectTargetStageThree(Selectable target)
    {
        var targetCoords = target.Coords;

        UsageArea = new List<Node>();
        // UsageArea = Pathfinding.GetNodesInArea(abilityPrefab.UsageSearchType, abilityPrefab.minRange, abilityPrefab.maxRange)
    }
    private void HoverTargetStageThree(Selectable target)
    {
        if (_selectionStage < SelectionStage.Target) { return; }
        var targetCoords = target.Coords;

        EffectArea = new List<Node>();
        // EffectArea = Pathfinding.GetNodesInArea(abilityPrefab.EffectSearchType, abilityPrefab.minRange, abilityPrefab.maxRange)
    }
}
