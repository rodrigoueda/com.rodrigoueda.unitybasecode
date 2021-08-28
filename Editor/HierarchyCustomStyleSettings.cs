#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityBaseCode.Editor
{
    public static class HierarchyCustomStyleSettings
    {
        private const string _settingsPath =
            "Assets/Packages/com.rodrigoueda.unitybasecode/HierarchyCustomStyleSettings.asset";

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            return new SettingsProvider("Project/Hierarchy Header", SettingsScope.Project)
            {
                guiHandler = (searchContext) =>
                {
                    HierarchyCustomStyleData settings = Load();
                    SerializedObject serialized = new SerializedObject(settings);

                    EditorGUI.BeginChangeCheck();

                    EditorGUILayout.PropertyField(serialized.FindProperty("headerStyle"), new GUIContent("Entity"));

                    if (EditorGUI.EndChangeCheck())
                    {
                        serialized.ApplyModifiedProperties();
                        HierarchyCustomStyleData.Refresh(settings);
                    }
                },

                keywords = new HashSet<string>(new[] { "Entity log enabled", "Notifications log enabled" })
            };
        }

        public static HierarchyCustomStyleData Load()
        {
            HierarchyCustomStyleData settings = AssetDatabase.LoadAssetAtPath<HierarchyCustomStyleData>(_settingsPath);

            if (settings == null) {
                if (!AssetDatabase.IsValidFolder("Assets/Packages/com.rodrigoueda.unitybasecode")) {
                    if (!AssetDatabase.IsValidFolder("Assets/Packages")) {
                        AssetDatabase.CreateFolder("Assets", "Packages");
                    }
                    AssetDatabase.CreateFolder("Assets/Packages", "com.rodrigoueda.unitybasecode");
                }

                settings = ScriptableObject.CreateInstance<HierarchyCustomStyleData>();

                settings.headerStyle = new HierarchyCustomStyleData.FilterStyleData[1] {
                    new HierarchyCustomStyleData.FilterStyleData() {
                        name = "Default header",
                        filterQuery = "^---(.*)$",
                        replaceQuery = "$1",
                        fontColor = Color.white,
                        backgroundColor = Color.grey,
                        alignment = TextAnchor.MiddleCenter,
                        fontStyle = FontStyle.Bold,
                        upperCase = true,
                        dropShadow = true
                    }
                };

                AssetDatabase.CreateAsset(settings, _settingsPath);
                AssetDatabase.SaveAssets();

                HierarchyCustomStyleData.Refresh(settings);
            }

            return settings;
        }
    }
}
#endif