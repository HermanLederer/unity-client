using Cysharp.Threading.Tasks;
using Odyssey;
using UnityEngine;
using Odyssey.Networking;

public interface IDiscoveryPageDriver
{

}

public class DiscoveryPageDriver : MonoBehaviour, IRequiresContext, IDiscoveryPageDriver
{
    [Header("References")]
    [SerializeField]
    DiscoveryPage discoveryPage;
    ITeleportSystem teleport;

    void OnEnable()
    {
        discoveryPage.Driver = this;
        teleport = _c.Get<ITeleportSystem>();

        _c.Get<IReactBridge>().OpenCloseDiscoveryPage_Event += OnOpenCloseDiscoveryPage;
        _c.Get<IReactBridge>().SetDiscoveryPageScroll_Event += OnSetDiscoveryPageScroll;
        _c.Get<IReactBridge>().TeleportToDiscoveryPost_Event += OnTeleportToDiscoveryPost;
    }


    void OnDisable()
    {
        discoveryPage.Driver = null;
        teleport = null;

        _c.Get<IReactBridge>().OpenCloseDiscoveryPage_Event -= OnOpenCloseDiscoveryPage;
        _c.Get<IReactBridge>().SetDiscoveryPageScroll_Event -= OnSetDiscoveryPageScroll;
        _c.Get<IReactBridge>().TeleportToDiscoveryPost_Event -= OnTeleportToDiscoveryPost;

    }

    public void Init(IMomentumContext context)
    {
        _c = context;
    }

    #region Event Handlers

    private void OnOpenCloseDiscoveryPage(bool open)
    {
        if (open) discoveryPage.OpenDiscoveryMode();
        else discoveryPage.CloseDiscoveryMode();
    }

    private void OnSetDiscoveryPageScroll(float scroll)
    {
        discoveryPage.camRig.scroll = scroll;
    }

    private void OnTeleportToDiscoveryPost(int index)
    {
       teleport.TeleportToPosition(discoveryPage.postLocations[index].position, null);
    }

    #endregion

    IMomentumContext _c;
}
