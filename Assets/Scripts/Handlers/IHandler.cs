using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//ָ����������
public abstract class IHandler : MonoBehaviour {
    public string handlerName;
    public List<GameObject> myObjects;
    public SerializableDictionary<string[],UnityEvent> keyToEvent;

    public bool Handle(string msg) {
        Debug.Log($"���Խ�����{msg}�����ҵ�����Ҫ���Ŀ��ִ�в���");
        foreach (string[] keyWords in keyToEvent.Keys) {
            foreach (string keyWord in keyWords) {
                if (msg.ToLower().Contains(keyWord)) {
                    keyToEvent[keyWords].Invoke();
                    return true;
                }
            }
        }
        LogManager.Instance.SendMessage($"��{handlerName}��ָ��{msg}��Ч��Ч,�볢��{getInstruction()}");
        return false;
    }

    private string getInstruction() {
        string res = "��ʹ�õĲ���ָ��Ϊ:";
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
