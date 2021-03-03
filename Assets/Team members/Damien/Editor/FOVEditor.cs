using System;
using System.Collections;
using System.Collections.Generic;
using Damien;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

[CustomEditor(typeof(FOV))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        FOV fov = (FOV)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);
    }
}
