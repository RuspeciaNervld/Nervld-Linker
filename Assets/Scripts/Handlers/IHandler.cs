using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//指定化操作，
public abstract class IHandler : MonoBehaviour {
    public string handlerName;
    public List<GameObject> myObjects;
    public SerializableDictionary<string[],UnityEvent> keyToEvent;

    public bool Handle(string msg) {
        Debug.Log($"尝试解析“{msg}”并找到符合要求的目标执行操作");
        foreach (string[] keyWords in keyToEvent.Keys) {
            foreach (string keyWord in keyWords) {
                if (msg.ToLower().Contains(keyWord)) {
                    keyToEvent[keyWords].Invoke();
                    return true;
                }
            }
        }
        LogManager.Instance.SendMessage($"对{handlerName}的指令{msg}无效无效,请尝试{getInstruction()}");
        return false;
    }

    private string getInstruction() {
        string res = "可使用的部分指令为:";
        foreach (string[] strings in keyToEvent.Keys) {
            res += strings[0].ToString() + "/";
        }
        return res;
    }

    public GameObject findNearest() {
        float distance = 999999;
        GameObject nearest = null;
        foreach(GameObject obj in myObjects) {
            if((obj.transform.position - Player.Instance.transform.position).magnitude < distance) {
                nearest = obj;
            }
        }
        return nearest;
    }

    public GameObject findInCamera() {
        GameObject res = null;
        foreach (GameObject obj in myObjects) {
            if (obj.GetComponent<IObject>().visible) {
                res = obj;
                return res;
            }
        }
        return null;
    }
}
