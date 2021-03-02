using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RileyMcGowan.Health))] //We are controlling the HealthComponent with this script
public class HealthEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Kill Object"))
        {
            (target as RileyMcGowan.Health)?.DestroyObject();
        }
        if (GUILayout.Button("Max Health"))
        {
            (target as RileyMcGowan.Health)?.MaxHealth();
        }
        if (GUILayout.Button("Starting Health"))
        {
            (target as RileyMcGowan.Health)?.StartingHealth();
        }
        if (GUILayout.Button("Damage Object by 10"))
        {
            (target as RileyMcGowan.Health)?.DoDamage(10);
        }
        if (GUILayout.Button("Heal Object by 10"))
        {
            (target as RileyMcGowan.Health)?.DoHeal(10);
        }
    }
}
