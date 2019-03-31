using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Levels/LevelList")]
public class LevelsList : ScriptableObject
{
    [SerializeField] private List<string> levels;

    public IEnumerable<string> Levels => levels;

    public string GetNextLevel(string currentLevel)
    {
        var currentLevelId = levels.IndexOf(currentLevel);
        if (currentLevel == null) return null;

        var nextLevelId = currentLevelId + 1;
        return nextLevelId >= levels.Count ? null : levels[nextLevelId];
    }
}
