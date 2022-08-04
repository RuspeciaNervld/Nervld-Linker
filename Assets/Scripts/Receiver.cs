using Liluo.BiliBiliLive;
using UnityEngine;
using UnityEngine.UI;

//ֻ���ڴ�ֱ����������ݲ�ֱ�ӵ�����Ӧ�Ĵ�������
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
        Debug.Log($"<color=#ff00aa>����</color> {obj.username} {obj.giftName} {obj.total_coin}");
    }

    private void OnDanmu(BiliBiliLiveDanmuData obj) {
        Debug.Log($"<color=#00aaff>��Ļ</color> {obj.username} {obj.content} {obj.guardLevel}");

        if (AnalyzeManager.Instance.Analyze(obj.content)) {
            //��Ļ���ɹ�ִ����
            //todo ����Ļͨ������չʾ����Ϸ�У������з����ߵ�ͷ�񣬸ù��ڲ�����Ϸ�Ĵ����ȵ�չʾ���������Ը������������ͷ���ʲô��
            Debug.Log("���Ǹ��ɽ���ָ��");
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
