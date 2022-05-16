using System.Collections.Generic;
using UnityEngine;

public class GameMainManager : MonoBehaviour
{
    public static GameMainManager Instance;

    public UIManager UIManager;
    public GridManager GridManager;
    public SelectionManager SelectionManager;
    public TurnManager TurnManager;
    public AbilityDataManager AbilityManager;
    public EntityGameManager EntityManager;
    public CameraManager CameraManager;
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
}
