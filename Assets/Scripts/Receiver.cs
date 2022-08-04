using Liluo.BiliBiliLive;
using UnityEngine;
using UnityEngine.UI;

//只用于从直播间读入数据并直接调用相应的处理方法？
public class Receiver : MonoBehaviour {
    [SerializeField] private Image headImage = null;
    [SerializeField] private int roomID;
    private IBiliBiliLiveRequest req;

    private async void Start() {
        req = await BiliBiliLive.Connect(roomID);
        req.OnRoomViewer += OnRoomViewer;
        req.OnDanmuCallBack += OnDanmu;
        req.OnGiftCallBack += OnGift;
        req.OnSuperChatCallBack += OnSC;
        req.OnGuardCallBack += OnGaurd;
    }

    private void OnGaurd(BiliBiliLiveGuardData obj) {
        Debug.Log($"<color=#ff0000>SC</color> {obj.username} {obj.guardLevel} {obj.guardName}");
    }

    private async void OnSC(BiliBiliLiveSuperChatData obj) {
        Debug.Log($"<color=#ffaa00>SC</color> {obj.username} {obj.content} {obj.price}");
        headImage.overrideSprite = await BiliBiliLive.GetHeadSprite(obj.userId);
    }

    private void OnGift(BiliBiliLiveGiftData obj) {
        Debug.Log($"<color=#ff00aa>礼物</color> {obj.username} {obj.giftName} {obj.total_coin}");
    }

    private void OnDanmu(BiliBiliLiveDanmuData obj) {
        Debug.Log($"<color=#00aaff>弹幕</color> {obj.username} {obj.content} {obj.guardLevel}");

        if (AnalyzeManager.Instance.Analyze(obj.content)) {
            //弹幕被成功执行了
            //todo 将弹幕通过弹窗展示在游戏中，并且有发送者的头像，该观众参与游戏的次数等的展示，甚至可以根据礼物数获得头像框什么的
            Debug.Log("这是个可解析指令");
        }
    }

    private void OnRoomViewer(int obj) {
        Debug.Log(obj);
    }

    private void OnApplicationQuit() {
        req.DisConnect();
    }

    //private void OnDestroy() {
    //    OnApplicationQuit();
    //}
}
