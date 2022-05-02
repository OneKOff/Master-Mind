using UnityEngine;
using System.Collections.Generic;

public class Unit : Damageable
{
    [SerializeField] protected UnitData data;
    public UnitData Data => data;
    [SerializeField] protected List<Ability> abilities;
    public List<Ability> Abilities => abilities;
    public List<Effect> Effects;

    protected int _energy;
    protected int _time;

    public int Energy { get { return _energy; } private set { _energy = value; } }
    public int Time { get { return _time; } private set { _time = value; } }

    public int TeamId;

    protected override void Start()
    {
        base.Start(); // _health = data.MaxHealth;
        _energy = data.MaxEnergy;
        _time = data.MaxTime;    

        /*if (transform.position.x >= -GGrid.Instance.sizeX * GGrid.Instance.NodeSize / 2f && transform.position.x <= GGrid.Instance.sizeX * GGrid.Instance.NodeSize / 2f &&
            transform.position.z >= -GGrid.Instance.sizeZ * GGrid.Instance.NodeSize / 2f && transform.position.z <= GGrid.Instance.sizeZ * GGrid.Instance.NodeSize / 2f)*/
        Coords.x = Mathf.Clamp(Coords.x, 0, GridManager.Instance.SizeX - 1);
        Coords.y = Mathf.Clamp(Coords.y, 0, GridManager.Instance.SizeY - 1);
        transform.position = new Vector3(GridManager.Instance.transform.position.x + Coords.x * GridManager.Instance.NodeSize, GridManager.Instance.transform.position.y,
            GridManager.Instance.transform.position.z + Coords.y * GridManager.Instance.NodeSize);        
    }

    public void SetTeamId(int teamId)
    {
        TeamId = teamId;
    }
    public virtual bool ChangeEnergy(int _value)
    {
        if (_energy + _value < 0)
        {
            return false;
        }
        _energy = Mathf.Clamp(_energy + _value, 0, data.MaxEnergy);

        return true;
    }
    public virtual bool ChangeTime(int _value)
    {
        if (_time + _value < 0)
        {
            return false;
        }
        _time = Mathf.Clamp(_time + _value, 0, data.MaxTime);

        return true;
    }
    /*public IEnumerator MoveTo(int _coordX, int _coordZ)
    {
        WaitForSeconds delay = new WaitForSeconds(0.1f);

        transform.Translate(new Vector2(Mathf.Abs(CoordX - _coordX), Mathf.Abs(CoordZ - _coordZ)) * GGrid.Instance.NodeSize * moveToSpeed);
        yield return delay;
    }*/
}