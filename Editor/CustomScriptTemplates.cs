#if UNITY_EDITOR﻿
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace UnityBaseCode.Editor
{
    public static class CustomScriptTemplates
    {
        private static string _templatePathBehaviourScript =
            "Packages/com.rodrigoueda.unitybasecode/Editor/NewScriptBehaviour.cs.txt";

        private static string _templatePathSingletonScript =
            "Packages/com.rodrigoueda.unitybasecode/Editor/NewSingletonScript.cs.txt";

        [MenuItem("Assets/Create/UnityBaseCode/C# Script", priority = 80)]
        public static void CreateNewScriptBehaviour()
        {
             ProjectWindowUtil.CreateScriptAssetFromTemplateFile(
                _templatePathBehaviourScript, "NewBehaviourScript.cs"
            );
        }

        [MenuItem("Assets/Create/UnityBaseCode/Singleton", priority = 80)]
        public static void CreateNewSingletonScript()
        {
             ProjectWindowUtil.CreateScriptAssetFromTemplateFile(
                _templatePathSingletonScript, "NewSingletonScript.cs"
            );
        }
    }
}
#endif
