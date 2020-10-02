# Unity Base Code

## Installation

<https://docs.unity3d.com/Packages/com.unity.package-manager-ui@2.1/manual/index.html>

```json
{
    "dependencies": {
        "com.rodrigoueda.unitybasecode": "https://github.com/rodrigoueda/com.rodrigoueda.unitybasecode.git#0.2.0"
    }
}
```

## Unique identifier for every MonoBehaviour

Use ``` BaseBehaviour ``` instead of the usual ``` MonoBehaviour ```.

```C#
using UnityEngine;
using UnityBaseCode;

public class TestScript : BaseBehaviour
{
    protected override void Awake()
    {
        base.Awake();

        print(guid);
    }
}
```

## Singleton usage

```C#
using UnityEngine;
using UnityBaseCode;

public class TestSingleton : Singleton<TestSingleton>
{
    public void PrintTest()
    {
        print("Test");
    }
}
```

```C#
using UnityEngine;
using UnityBaseCode;

public class TestScript : BaseBehaviour
{
    private void Start()
    {
        TestSingleton.Instance.PrintTest();
    }
}
```

## Hierarchy Header

You can create custom Headers for your hierarchy through **Project Settings** menu.

![Hierarchy Header](https://gist.githubusercontent.com/rodrigoueda/c6a714d7cbbdc58641b89679e06d5efb/raw/a3886fde8d0fbc17824012f5809701487fae8f6f/HierarchyHeader.png)

By default, any GameObject with the name starting with "**---**" will be filter as a header.
You can create additional filters each with a custom style.

**Filter Query** and **Replace Query** uses [Regex](https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=netcore-3.1)
