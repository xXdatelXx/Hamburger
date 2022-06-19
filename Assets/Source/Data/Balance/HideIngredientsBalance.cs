using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "GameData/Balance/HideItems", fileName = "HideIngredientsBalance")]
public class HideIngredientsBalance : ScriptableObject
{
    [SerializeField, Range(0, 10)] private int _hideIngredientsInLevel1;
    public int HideIngredientsInLevel1 => _hideIngredientsInLevel1;
    [SerializeField, Range(0, 10)] private int _hideIngredientsInLevel2;
    public int HideIngredientsInLevel2 => _hideIngredientsInLevel2;
    [SerializeField, Range(0, 10)] private int _hideIngredientsInLevel3;
    public int HideIngredientsInLevel3 => _hideIngredientsInLevel3;
    [SerializeField, Range(0, 10)] private int _hideIngredientsInLevel4;
    public int HideIngredientsInLevel4 => _hideIngredientsInLevel4;
    [SerializeField, Range(0, 10)] private int _hideIngredientsInLevelMax;
    public int HideIngredientsInLevelMax => _hideIngredientsInLevelMax;
    [SerializeField, Range(0, 100)] private int _percentToHide;
    public int PercentToHide => _percentToHide;

    public List<int> List => new List<int>
    {
        _hideIngredientsInLevel1,
        _hideIngredientsInLevel2,
        _hideIngredientsInLevel3,
        _hideIngredientsInLevel4,
        _hideIngredientsInLevelMax,
    };

    private void OnValidate()
    {
        var validate = new BalanceValidate();

        validate.ValidateValue(ref _hideIngredientsInLevel1, 0);
        validate.ValidateValue(ref _hideIngredientsInLevel2, _hideIngredientsInLevel1);
        validate.ValidateValue(ref _hideIngredientsInLevel3, _hideIngredientsInLevel2);
        validate.ValidateValue(ref _hideIngredientsInLevel4, _hideIngredientsInLevel3);
        validate.ValidateValue(ref _hideIngredientsInLevelMax, _hideIngredientsInLevel4);
    }
}
