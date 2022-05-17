using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Balance/ItemsInLevel", fileName = "IngredientsInLevelBalance")]
public class IngredientsInLevelBalance : ScriptableObject
{
    [Header("Level 1")]
    [SerializeField, Range(0, 30)] private int _minIngredientsInFirstLevel = 0;
    [SerializeField, Range(0, 30)] private int _maxIngredientsInFirstLevel = 0;
    public (int, int) IngredientsInFirstLevel => (_minIngredientsInFirstLevel, _maxIngredientsInFirstLevel);

    [Header("Level 2")]
    [SerializeField, Range(0, 30)] private int _minIngredientsInSecondLevel = 0;
    [SerializeField, Range(0, 30)] private int _maxIngredientsInSecondLevel = 0;
    public (int, int) IngredientsInSecondLevel => (_minIngredientsInSecondLevel, _maxIngredientsInSecondLevel);

    [Header("Level 3")]
    [SerializeField, Range(0, 30)] private int _minIngredientsInThirdtLevel = 0;
    [SerializeField, Range(0, 30)] private int _maxIngredientsInThirdtLevel = 0;
    public (int, int) IngredientsInThirdLevel => (_minIngredientsInThirdtLevel, _maxIngredientsInThirdtLevel);

    [Header("Level 4")]
    [SerializeField, Range(0, 30)] private int _minIngredientsInFourthLevel = 0;
    [SerializeField, Range(0, 30)] private int _maxIngredientsInFourthLevel = 0;
    public (int, int) IngredientsInFourthtLevel => (_minIngredientsInFourthLevel, _maxIngredientsInFourthLevel);

    [Header("Max level")]
    [SerializeField, Range(0, 30)] private int _minIngredientsInMaxLevel = 0;
    [SerializeField, Range(0, 30)] private int _maxIngredientsInMaxLevel = 0;
    public (int, int) IngredientsInMaxLevel => (_minIngredientsInMaxLevel, _maxIngredientsInMaxLevel);

    private void OnValidate()
    {
        var validate = new BalanceValidate();

        validate.ValidateValue(ref _minIngredientsInFirstLevel, 0);
        validate.ValidateValue(ref _maxIngredientsInFirstLevel, _minIngredientsInFirstLevel);

        validate.ValidateValue(ref _minIngredientsInSecondLevel, _maxIngredientsInFirstLevel);
        validate.ValidateValue(ref _maxIngredientsInSecondLevel, _minIngredientsInSecondLevel);

        validate.ValidateValue(ref _minIngredientsInThirdtLevel, _maxIngredientsInSecondLevel);
        validate.ValidateValue(ref _maxIngredientsInThirdtLevel, _minIngredientsInThirdtLevel);

        validate.ValidateValue(ref _minIngredientsInFourthLevel, _maxIngredientsInThirdtLevel);
        validate.ValidateValue(ref _maxIngredientsInFourthLevel, _minIngredientsInFourthLevel);

        validate.ValidateValue(ref _minIngredientsInMaxLevel, _maxIngredientsInFourthLevel);
        validate.ValidateValue(ref _maxIngredientsInMaxLevel, _minIngredientsInMaxLevel);
    }
}
