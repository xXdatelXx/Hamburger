using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Balance/Level", fileName = "LevelBalance")]
public class LevelBalance : ScriptableObject
{
    [SerializeField, Range(0, 30)] private int _ingredientsInFirstLevel = 0;
    public int IngredientsInFirstLevel => _ingredientsInFirstLevel;

    [SerializeField, Range(0, 30)] private int _ingredientsInSecondLevel = 0;
    public int IngredientsInSecondLevel => _ingredientsInSecondLevel;

    [SerializeField, Range(0, 30)] private int _ingredientsInThirdtLevel = 0;
    public int IngredientsInThirdLevel => _ingredientsInThirdtLevel;

    [SerializeField, Range(0, 30)] private int _ingredientsInFourthLevel = 0;
    public int IngredientsInFourthtLevel => _ingredientsInFourthLevel;

    private void OnValidate()
    {
        var validate = new BalanceValidate();

        validate.ValidateValue(ref _ingredientsInFirstLevel, 0);
        validate.ValidateValue(ref _ingredientsInSecondLevel, _ingredientsInFirstLevel);
        validate.ValidateValue(ref _ingredientsInThirdtLevel, _ingredientsInSecondLevel);
        validate.ValidateValue(ref _ingredientsInFourthLevel, _ingredientsInThirdtLevel);
    }
}
