using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class h_key : IHandler
{


    public void use() {
    }

    public void get() {
        GameObject obj = findInCamera();
        if (obj != null){
            obj.GetComponent<o_key>().get();
            
        } else {
            LogManager.Instance.SaySomething($"我没看到{handlerName}啊");
        }

    }

    
}
