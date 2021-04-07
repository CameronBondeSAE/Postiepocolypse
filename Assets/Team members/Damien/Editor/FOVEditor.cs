using Damien;
using UnityEditor;
using UnityEngine;
using System.Collections;
using TPUModelerEditor;

[CustomEditor(typeof(FOV))]
public class FOVEditor : Editor
{
    void OnSceneGUI()
    {
        FOV fov = (FOV) target;

        Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
        Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);


        Handles.color = Color.gray;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);
        Handles.color = Color.blue;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);

        foreach (Transform playerTarget in fov.playerTargets)
        {
            Handles.color = Color.red;
            Handles.DrawLine(fov.transform.position, playerTarget.position);
        }
    }
}