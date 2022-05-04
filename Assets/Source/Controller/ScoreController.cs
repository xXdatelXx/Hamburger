using UnityEngine;
using Zenject;

public class ScoreController : MonoBehaviour
{
    [Inject] private Score _score;

    public void IncreaseScore()
    {
        _score.IncreaseScore();
    }
}
