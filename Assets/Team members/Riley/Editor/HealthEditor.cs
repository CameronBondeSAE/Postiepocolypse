using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
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
        if (GUILayout.Button("Reset Max Health"))
        {
            (target as RileyMcGowan.Health)?.ResetMaxHealth();
        }
        if (GUILayout.Button("Reset Starting Health"))
        {
            (target as RileyMcGowan.Health)?.ResetStartingHealth();
        }
        if (GUILayout.Button("Damage Object by 10"))
        {
            (target as RileyMcGowan.Health)?.DoDamage(10, Health.DamageType.Normal);
        }
        if (GUILayout.Button("Heal Object by 10"))
        {
            (target as RileyMcGowan.Health)?.DoHeal(10);
        }
    }
}
