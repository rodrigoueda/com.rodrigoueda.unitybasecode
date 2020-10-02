using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBaseCode.Editor
{
    public class HierarchyCustomStyleData : ScriptableObject
    {
        [System.Serializable]
        public class FilterStyleData
        {
            public string name;
            public string filterQuery;
            public string replaceQuery;
            public Color fontColor;
            public Color backgroundColor;
            public TextAnchor alignment;
            public FontStyle fontStyle;
            public bool dropShadow;
            public bool upperCase;
        }

        [SerializeField]
        public FilterStyleData[] headerStyle;

        public static FilterStyleData[] HeaderStyle { get; private set; }

        private void OnEnable()
        {
            Refresh(this);
        }

        public static void Refresh(HierarchyCustomStyleData instance)
        {
            HeaderStyle = instance.headerStyle;
        }
    }
}