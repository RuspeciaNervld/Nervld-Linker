using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyzeManager : ISingleton<AnalyzeManager>
{
    public SerializableDictionary<string[], IHandler> keyToHandler;

    public bool Analyze(string msg) {
        foreach(string[] keyWords in keyToHandler.Keys) {
            foreach(string keyWord in keyWords) {
                if (msg.ToLower().Contains(keyWord)) {
                    if (keyToHandler[keyWords].Handle(msg)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
