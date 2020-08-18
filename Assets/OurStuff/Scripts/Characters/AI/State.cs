using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Combat()
    {
        yield break;
    }

    public virtual IEnumerator Sandbox()
    {
        yield break;
    }
}
