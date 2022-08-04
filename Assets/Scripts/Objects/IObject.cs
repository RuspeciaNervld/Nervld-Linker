using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IObject : MonoBehaviour
{
    public bool seen;
    public bool visible;


    private void OnBecameVisible() {
        seen = true;
        visible = true;
    }

    private void OnBecameInvisible() {
        visible = false;
    }
}
