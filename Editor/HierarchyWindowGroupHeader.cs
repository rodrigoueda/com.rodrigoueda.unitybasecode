#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;
using System;

namespace UnityBaseCode.Editor
{
    [InitializeOnLoad]
    public static class HierarchyWindowGroupHeader
    {
        static HierarchyWindowGroupHeader()
        {
            HierarchyCustomStyleSettings.Load();
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        }

        static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObject == null || HierarchyCustomStyleData.HeaderStyle == null) {
                return;
            }

            string name = gameObject.name;
            GUIStyle style = new GUIStyle(EditorStyles.label);
            Match match;

            for (int i = 0; i < HierarchyCustomStyleData.HeaderStyle.Length; i++) {
                if (String.IsNullOrEmpty(HierarchyCustomStyleData.HeaderStyle[i].filterQuery)) {
                    continue;
                }

                match = Regex.Match(
                    name, HierarchyCustomStyleData.HeaderStyle[i].filterQuery
                );

                if (match.Success) {
                    style.normal.textColor = HierarchyCustomStyleData.HeaderStyle[i].fontColor;

                    EditorGUI.DrawRect(
                        selectionRect, HierarchyCustomStyleData.HeaderStyle[i].backgroundColor
                    );

                    if (!String.IsNullOrEmpty(HierarchyCustomStyleData.HeaderStyle[i].replaceQuery)) {
                        name = Regex.Replace(
                            name,
                            HierarchyCustomStyleData.HeaderStyle[i].filterQuery,
                            HierarchyCustomStyleData.HeaderStyle[i].replaceQuery
                        );
                    }

                    if (HierarchyCustomStyleData.HeaderStyle[i].upperCase) {
                        name = name.ToUpperInvariant();
                    }

                    style.alignment = HierarchyCustomStyleData.HeaderStyle[i].alignment;
                    style.fontStyle = HierarchyCustomStyleData.HeaderStyle[i].fontStyle;

                    if (HierarchyCustomStyleData.HeaderStyle[i].dropShadow) {
                        EditorGUI.DropShadowLabel(selectionRect, name, style);
                    } else {
                        EditorGUI.LabelField(selectionRect, name, style);
                    }

                    return;
                }
            }
        }
    }
}
#endif