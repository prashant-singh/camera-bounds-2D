using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraBounds2D))]
public class CameraBounds2DEditor : Editor
{
    CameraBounds2D _bounds;

    public void OnSceneGUI()
    {
        _bounds = (CameraBounds2D)target;

        Vector3[] verts = new Vector3[] {
            new Vector3(_bounds.transform.position.x+_bounds.boundX,_bounds.transform.position.y+_bounds.boundY),
            new Vector3(_bounds.transform.position.x-_bounds.boundX,_bounds.transform.position.y+_bounds.boundY),
            new Vector3(_bounds.transform.position.x-_bounds.boundX,_bounds.transform.position.y-_bounds.boundY),
            new Vector3(_bounds.transform.position.x+_bounds.boundX,_bounds.transform.position.y-_bounds.boundY)
        };

        Handles.DrawSolidRectangleWithOutline(verts, new Color(1, 1, 1, 0.1f), Color.yellow);

        _bounds.boundX = Handles.ScaleValueHandle(_bounds.boundX, new Vector3(verts[0].x, _bounds.transform.position.y, _bounds.transform.position.z), Quaternion.identity, 3, Handles.CubeCap, 0.1f);
        _bounds.boundX = Handles.ScaleValueHandle(-_bounds.boundX, new Vector3(verts[1].x, _bounds.transform.position.y, _bounds.transform.position.z), Quaternion.identity, 3, Handles.CubeCap, 0.1f);
        _bounds.boundY = Handles.ScaleValueHandle(_bounds.boundY, new Vector3(_bounds.transform.position.x, verts[0].y, _bounds.transform.position.z), Quaternion.identity, 3, Handles.CubeCap, 0.1f);
        _bounds.boundY = Handles.ScaleValueHandle(-_bounds.boundY, new Vector3(_bounds.transform.position.x, verts[2].y, _bounds.transform.position.z), Quaternion.identity, 3, Handles.CubeCap, 0.1f);


    }
}
