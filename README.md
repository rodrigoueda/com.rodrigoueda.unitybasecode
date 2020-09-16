# Unity Base Code

## Installation

<https://docs.unity3d.com/Packages/com.unity.package-manager-ui@2.1/manual/index.html>

```json
{
    "dependencies": {
        "com.rodrigoueda.unitybasecode": "https://github.com/rodrigoueda/com.rodrigoueda.unitybasecode.git#0.1.1"
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
