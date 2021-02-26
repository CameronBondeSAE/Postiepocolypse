using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HealthComponent.HealthComponent))] //We are controlling the HealthComponent with this script
public class HealthEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Kill Object"))
        {
            (target as HealthComponent.HealthComponent)?.DestroyObject();
        }
        if (GUILayout.Button("Max Health"))
        {
            (target as HealthComponent.HealthComponent)?.MaxHealth();
        }
        if (GUILayout.Button("Starting Health"))
        {
            (target as HealthComponent.HealthComponent)?.StartingHealth();
        }
        if (GUILayout.Button("Damage Object by 10"))
        {
            (target as HealthComponent.HealthComponent)?.DoDamage(10);
        }
        if (GUILayout.Button("Heal Object by 10"))
        {
            (target as HealthComponent.HealthComponent)?.DoHeal(10);
        }
    }
}
