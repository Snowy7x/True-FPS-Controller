using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    
}


[CustomEditor(typeof(Test))]
public class TestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        
        // Horizontal int field and tick box
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Test");
        EditorGUILayout.IntField(0);
        EditorGUILayout.Toggle(false);
        EditorGUILayout.EndHorizontal();
        
        base.OnInspectorGUI();
    }
}
