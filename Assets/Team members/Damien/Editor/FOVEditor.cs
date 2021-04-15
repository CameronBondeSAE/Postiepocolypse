using Damien;
using UnityEditor;
using UnityEngine;

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

        foreach (GameObject playerTarget in fov.listOfTargets)
        {
            Handles.color = Color.red;
            Handles.DrawLine(fov.transform.position, playerTarget.transform.position);
        }
    }
}