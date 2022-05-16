using UnityEngine;
using System.Collections.Generic;

public class EntityGameManager : MonoBehaviour
{
    public List<Entity> Entities = new List<Entity>();
    public List<Selectable> Selectables = new List<Selectable>();
    public List<Unit> Units = new List<Unit>();

    private void Start()
    {
        var entities = FindObjectsOfType<Entity>();

        foreach (var entity in entities)
        {
            AddEntity(entity);
        }
    }

    public void AddEntity(Entity entity)
    {
        Entities.Add(entity);

        if (entity is Selectable)
        {
            Selectables.Add((Selectable)entity);
        }

        if (entity is Unit)
        {
            Units.Add((Unit)entity);
        }
    }

    public void RemoveEntity(Entity entity)
    {
        Entities.Remove(entity);

        if (entity is Selectable)
        {
            Selectables.Remove((Selectable)entity);
        }

        if (entity is Unit)
        {
            Units.Remove((Unit)entity);
        }
    }
}
