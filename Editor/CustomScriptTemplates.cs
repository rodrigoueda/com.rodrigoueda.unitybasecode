using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace UnityBaseCode.Editor
{
    public static class CustomScriptTemplates
    {
        private static string TemplatePathBehaviourScript
        {
            get {
                return Path.GetFullPath("Packages/UnityBaseCode/Editor/NewScriptBehaviour.cs.txt");
            }
        }

        private static string TemplatePathSingletonScript
        {
            get {
                return Path.GetFullPath("Packages/UnityBaseCode/Editor/NewSingletonScript.cs.txt");
            }
        }

        [MenuItem("Assets/Create/UnityBaseCode/C# Script", priority = 80)]
        public static void CreateNewScriptBehaviour()
        {
             ProjectWindowUtil.CreateScriptAssetFromTemplateFile(
                TemplatePathBehaviourScript, "NewBehaviourScript.cs"
            );
        }

        [MenuItem("Assets/Create/UnityBaseCode/Singleton", priority = 80)]
        public static void CreateNewSingletonScript()
        {
             ProjectWindowUtil.CreateScriptAssetFromTemplateFile(
                TemplatePathSingletonScript, "NewSingletonScript.cs"
            );
        }
    }
}