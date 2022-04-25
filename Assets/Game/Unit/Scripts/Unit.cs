using UnityEngine;
using System.Collections.Generic;

public class Unit : Damageable
{
    // Replace data with Unit Data component

    // Health data inherited from Damageable component
    [SerializeField] protected int maxEnergy, maxTime;
    [SerializeField] protected List<Ability> abilities;

    protected int _energy;
    protected int _time;
    public int Energy { get { return _energy; } private set { _energy = value; } }
    public int Time { get { return _time; } private set { _time = value; } }

    protected List<UPosition> uPositions;
    protected List<UAction> uActions;
    protected List<UEffect> uEffects;


    protected override void Start()
    {
        base.Start();

        GameController.Instance.OnEntitySelected += SendUnitData;

        _energy = maxEnergy;
        _time = maxTime;    

        /*if (transform.position.x >= -GGrid.Instance.sizeX * GGrid.Instance.NodeSize / 2f && transform.position.x <= GGrid.Instance.sizeX * GGrid.Instance.NodeSize / 2f &&
            transform.position.z >= -GGrid.Instance.sizeZ * GGrid.Instance.NodeSize / 2f && transform.position.z <= GGrid.Instance.sizeZ * GGrid.Instance.NodeSize / 2f)*/
        CoordX = Mathf.Clamp(CoordX, 0, GGrid.Instance.SizeX - 1);
        CoordZ = Mathf.Clamp(CoordZ, 0, GGrid.Instance.SizeZ - 1);
        transform.position = new Vector3(GGrid.Instance.transform.position.x + CoordX * GGrid.Instance.NodeSize, GGrid.Instance.transform.position.y,
            GGrid.Instance.transform.position.z + CoordZ * GGrid.Instance.NodeSize);        
    }

    protected override void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hitInfo;

        if (!Input.GetMouseButtonDown(0) || IsMouseOverUI()) { return; }
        if (!Physics.Raycast(_ray, out _hitInfo)) { return; }
        if (!_hitInfo.collider.TryGetComponent(out Unit u)) { return; }

        Debug.Log("Unit " + u.name + ". Coords: " + u.CoordX + ", " + u.CoordZ);
        GameController.Instance.SelectedEntity = this;
    }

    protected virtual void OnDestroy()
    {
        GameController.Instance.OnEntitySelected -= SendUnitData;
    }


    protected void SendUnitData(Selectable selectable)
    {
        if ((Unit)selectable == this)
        {
            GameController.Instance.SelectedEntity = this;
        }
    }

    public virtual bool ChangeEnergy(int _value)
    {
        if (_energy + _value < 0)
        {
            return false;
        }
        _energy = Mathf.Clamp(_energy + _value, 0, maxEnergy);

        return true;
    }
    public virtual bool ChangeTime(int _value)
    {
        if (_time + _value < 0)
        {
            return false;
        }
        _time = Mathf.Clamp(_time + _value, 0, maxTime);

        return true;
    }

    /*public IEnumerator MoveTo(int _coordX, int _coordZ)
    {
        WaitForSeconds delay = new WaitForSeconds(0.1f);

        transform.Translate(new Vector2(Mathf.Abs(CoordX - _coordX), Mathf.Abs(CoordZ - _coordZ)) * GGrid.Instance.NodeSize * moveToSpeed);
        yield return delay;
    }*/

}

public class UPosition
{
    public int time { get; set; }
    public Vector2Int coords { get; set; }
}

public class UAction
{
    public int time { get; set; }
    public Ability usedAbility { get; set; }
}

public class UEffect : MonoBehaviour
{
    protected int time;
    //protected Effect effect;
}