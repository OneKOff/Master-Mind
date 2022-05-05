using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [Header("Unit Data")]
    [SerializeField] private UnitDataPanel unitDataPanel;
    [SerializeField] private AbilityPanel abilityPanel;
    [SerializeField] private CardHandPanel cardHandPanel;
    [SerializeField] private CardPilesUI cardPilesUI;
    [Header("Player")]
    [SerializeField] private PlayerDataPanel playerDataPanel;
    [Header("Game")]
    [SerializeField] private GameDataPanel gameDataPanel;
    [Header("World Space")]
    [SerializeField] private WorldSpaceBarsUI worldSpaceBars;
    [SerializeField] private WorldSpaceHoveringTextUI worldSpaceHoveringText;
    [SerializeField] private TooltipPopup tooltipPopup;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
