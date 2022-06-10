using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AchievemntsCount : MonoBehaviour
{
    [SerializeField] private List<Achievement> _achievements;
    public int AllCount => _achievements.Count;
    public int CompletedCount => _achievements.Where(a => a.Achieve == true).ToList().Count;
}
