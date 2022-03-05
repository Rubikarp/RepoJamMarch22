using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof (EnnemyPoolManager))]
public class EnnemyPoolEditor : Editor
{
    private EnnemyPoolManager myTarget;
    private void OnEnable()
    {
        myTarget = target as EnnemyPoolManager;
        if (myTarget.ennemies == null)
            myTarget.ennemies = new List<ennemiesPool>();
    }
    public override void OnInspectorGUI()
    {
        myTarget.sushiPos = (Transform) EditorGUILayout.ObjectField(myTarget.sushiPos, typeof(Transform), true);
        for (int i = 0; i < myTarget.ennemies.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            myTarget.ennemies[i].type = (GameObject)EditorGUILayout.ObjectField(myTarget.ennemies[i].type, typeof(GameObject), true);
            myTarget.ennemies[i].maxNumber = EditorGUILayout.IntField("MaxNumber", myTarget.ennemies[i].maxNumber);
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("+")) myTarget.ennemies.Add(new ennemiesPool());
        if (myTarget.ennemies.Count > 0)
            if (GUILayout.Button("-")) myTarget.ennemies.RemoveAt(myTarget.ennemies.Count - 1);
        EditorGUILayout.EndHorizontal();

        EditorUtility.SetDirty(myTarget);
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }
}
