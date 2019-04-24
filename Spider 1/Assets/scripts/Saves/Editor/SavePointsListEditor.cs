using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Saves.Editor
{
    [CustomEditor(typeof(SavePointsList))]
    public class EventEditor : global :: UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            SavePointsList e = target as SavePointsList;
            if (e == null) return;
            GUILayout.Label(e.savePoints.Count.ToString());
            foreach (var line in e.savePoints.Select(kvp => kvp.Key + ": " + kvp.Value.ToString()))
            {
                GUILayout.Label(line);
            }
        }
    }
}