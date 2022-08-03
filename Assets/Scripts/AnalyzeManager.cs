using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyzeManager : MonoBehaviour
{
    public SerializableDictionary<string, IHandler> keyToHandler;

    public bool Analyze(string msg) {
        foreach(string keyWord in keyToHandler.Keys) {
            if (msg.Contains(keyWord)) {
                keyToHandler[keyWord].Handle();
            }
        }

        return false;
    }
}
