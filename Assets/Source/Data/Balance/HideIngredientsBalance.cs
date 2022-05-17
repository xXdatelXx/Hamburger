using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Balance/HideItems", fileName = "HideIngredientsBalance")]
public class HideIngredientsBalance : ScriptableObject
{
    [SerializeField, Range(0, 10)] private int _hideIngredientsInLevel1;
    public int HideIngredientsInLevel1 => _hideIngredientsInLevel1;

    [SerializeField, Range(0, 10)] private int _hideIngredientsInLeve2;
    public int HideIngredientsInLevel2 => _hideIngredientsInLeve2;
    [SerializeField, Range(0, 10)] private int _hideIngredientsInLeve3;
    public int HideIngredientsInLevel3 => _hideIngredientsInLeve3;
    [SerializeField, Range(0, 10)] private int _hideIngredientsInLeve4;
    public int HideIngredientsInLevel4 => _hideIngredientsInLeve4;
    [SerializeField, Range(0, 10)] private int _hideIngredientsInLeveMax;
    public int HideIngredientsInLevelMax => _hideIngredientsInLeveMax;
    [SerializeField, Range(0, 100)] private int _percentToHide;

    public int PercentToHide => _percentToHide;

    private void OnValidate()
    {
        var validate = new BalanceValidate();

        validate.ValidateValue(ref _hideIngredientsInLevel1, 0);
        validate.ValidateValue(ref _hideIngredientsInLeve2, _hideIngredientsInLevel1);
        validate.ValidateValue(ref _hideIngredientsInLeve3, _hideIngredientsInLeve2);
        validate.ValidateValue(ref _hideIngredientsInLeve4, _hideIngredientsInLeve3);
        validate.ValidateValue(ref _hideIngredientsInLeveMax, _hideIngredientsInLeve4);
    }
}
