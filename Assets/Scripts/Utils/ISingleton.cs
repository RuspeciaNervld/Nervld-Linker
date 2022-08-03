using UnityEngine;

public abstract class ISingleton<T> : MonoBehaviour
    where T : Component {
    private static T _instance;

    public static T Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType(typeof(T)) as T;
                if (_instance == null) {
                    GameObject obj = new GameObject();
                    //obj.hideFlags = HideFlags.HideAndDontSave; //! ����ʵ��������,Ҳ�����޷�����
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    public virtual void Awake() {//! ����Ϊ��������,����Ѿ�ѡ�����ؿɲ����ش˷���
        DontDestroyOnLoad(this.gameObject);
        if (_instance == null) {
            _instance = this as T;
        } else {
            GameObject.Destroy(this.gameObject);
        }
    }
}
