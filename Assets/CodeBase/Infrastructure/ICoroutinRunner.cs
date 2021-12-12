using System.Collections;
using UnityEngine;

public interface ICoroutinRunner
{
    Coroutine StartCoroutine(IEnumerator routine);
}