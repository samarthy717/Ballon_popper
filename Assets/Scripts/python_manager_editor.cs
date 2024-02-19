using UnityEditor;
using UnityEditor.Scripting.Python;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(python_manager))]
public class python_manager_editor : Editor
{
    private python_manager targetManager;

    private void OnEnable()
    {
        targetManager = (python_manager)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();

        if (GUILayout.Button("Launch Python Script", GUILayout.Height(35)))
        {
            string path = Application.dataPath + "/Python/GameRunner.py";
            PythonRunner.RunFile(path);
        }
    }

}