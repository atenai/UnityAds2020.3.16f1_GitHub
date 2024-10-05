using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

public abstract class OverrideEditor : Editor
{
    readonly static BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

    readonly MethodInfo methodInfo = typeof(Editor).GetMethod("OnHeaderGUI", flags);

    private Editor m_BaseEditor;

    protected Editor baseEditor
    {
        get { return m_BaseEditor ?? (m_BaseEditor = GetBaseEditor()); }
        set { m_BaseEditor = value; }
    }

    protected abstract Editor GetBaseEditor();

    public override void OnInspectorGUI()
    {
        baseEditor.OnInspectorGUI();
    }

    //...以下GetInfoString,OnPreviewSettingsというようにカスタムエディターで使用できるメソッド群が列挙する
    //ただし、DrawPreview,OnPreviewGUI,OnInteractivePreviewGUIをすべてオーバーライドしてしまうと挙動が変更されてしまうので注意すること
}
