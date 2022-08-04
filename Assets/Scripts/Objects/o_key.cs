using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class o_key : IObject
{
    public void get() {
        StartCoroutine(Player.Instance.goToAndGetSomething(gameObject));
    }
}
