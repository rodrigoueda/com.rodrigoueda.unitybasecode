# Unity Base Code

## Unique identifier for every MonoBehaviour

Use ``` BaseBehaviour ``` instead of the usual ``` MonoBehaviour ```.

```C#
using UnityEngine;
using UnityBaseCode;

[ExecuteInEditMode]
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