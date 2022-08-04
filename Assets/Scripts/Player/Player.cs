using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : ISingleton<Player>
{
    public bool isActng;

    public float rotateSpeed;

    public GameObject cameraRoot;
    public List<GameObject> bag;
    public NavMeshAgent ai;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void CameraRotateToLookAt(Vector3 target, float rotateSpeed) {
    //    //ȡ��Ŀ���������������ķ�����
    //    Vector3 normalize = Vector3.Cross(cameraRoot.transform.forward, target - cameraRoot.transform.position);
    //    float angles = Vector3.Angle(cameraRoot.transform.position, target);

    //    //�Ը÷�����Ϊ�������ת
    //    cameraRoot.transform.Rotate(normalize, Time.deltaTime * rotateSpeed, Space.Self);
    //    Debug.Log(angles);
    //    if (angles == 0) {
    //        rotateSpeed = 0;
    //    }
    //}

    public IEnumerator goToTarget(Vector3 target) {
        isActng = true;
        ai.isStopped = false;
        ai.SetDestination(target);
        
        while ((transform.position - target).magnitude > 1) {
            Quaternion lookat = Quaternion.LookRotation(target - cameraRoot.transform.position);
            cameraRoot.transform.rotation = Quaternion.Slerp(cameraRoot.transform.rotation, lookat, rotateSpeed * Time.deltaTime);
            yield return null;
        }
        
        yield return new WaitForSeconds(1);
        ai.isStopped = true;
        isActng = false;
    }

    public IEnumerator getSomething(GameObject target) {
        Debug.Log("����ʰȡ����");
        bag.Add(target);
        target.SetActive(false);
        yield return null;
    }

    public IEnumerator goToAndGetSomething(GameObject target) {
        yield return StartCoroutine(goToTarget(target.transform.position));
        yield return StartCoroutine(getSomething(target));
    }
}
