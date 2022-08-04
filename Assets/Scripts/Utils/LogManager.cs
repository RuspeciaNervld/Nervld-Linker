using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : ISingleton<LogManager>
{
    public void SendMessage(string msg) {
        Debug.Log("log" + msg);
    }

    public void SaySomething(string msg) {
        Debug.Log("say" + msg);
    }
}
