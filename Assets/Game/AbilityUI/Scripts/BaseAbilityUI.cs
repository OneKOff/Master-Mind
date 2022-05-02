using UnityEngine;
using UnityEngine.UI;

public abstract class BaseAbilityUI : MonoBehaviour
{
    public AbilityType HeldAbility;

    public GameObject AbilityDataPopup;

    [SerializeField] private Text titleText;
    [SerializeField] protected Image iconSlot;
    [SerializeField] private Text infoText;
    [SerializeField] private Text epCostText;
    [SerializeField] private Text tpCostText;
    [SerializeField] private Text rangeText;
    [SerializeField] private Text usageSearchTypeText;
    [SerializeField] private Text areaText;
    [SerializeField] private Text effectSearchTypeText;
    [SerializeField] private AspectCircleIcon aspectCircle;

    public virtual void SetAbilitySlotData(BaseAbilityData data)
    {
        AbilityDataPopup.SetActive(true);

        titleText.text = $"{data.Title}";
        iconSlot.sprite = data.Icon;
        infoText.text = $"{data.Info}";
        epCostText.text = $"{data.EPCost}";
        tpCostText.text = $"{data.TPCost}";
        rangeText.text = $"{data.Range}";
        usageSearchTypeText.text = $"{nameof(data.UsageSearchType)}";
        areaText.text = $"{data.Area}";
        effectSearchTypeText.text = $"{nameof(data.EffectSearchType)}";
        aspectCircle.UpdateCircleIcon(data.Aspects);

        AbilityDataPopup.SetActive(false);
    }
}
