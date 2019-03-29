using UnityEditor;
using UnityEngine;

namespace Events.Editor
{
    [CustomEditor(typeof(GameEvent))]
    public class EventEditor : global :: UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameEvent e = target as GameEvent;

            if (!GUILayout.Button("Raise")) return;
            if (e != null)
                e.Raise();
        }
    }
}