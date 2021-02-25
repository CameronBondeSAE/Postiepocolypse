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
    }
}
