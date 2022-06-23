using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Odyssey
{
    /// <summary>
    /// I know we stopped doing this, however it is extremely inconveniet to
    /// learn how to make this work on Android (which would also) most likely
    /// force me to fork the ReactNative package that I use to embed Unity.
    /// 
    /// I temporarily brought this class back with methods that are needed in
    /// the multi-client.
    /// </summary>
    public class UnityManager : MonoBehaviour, IRequiresContext
    {
        private IMomentumContext _c;

        public void Init(IMomentumContext context)
        {
            _c = context;
        }

        #region Methods for embedding applications

        public void setToken(string token)
        {
            _c.Get<IUnityJSAPI>().Token_Event?.Invoke(token);
        }

        public void showHideMinimap(string show)
        {
            _c.Get<IUnityJSAPI>().ShowHideMinimap_Event?.Invoke(show == "show");
        }

        public void showHideTouchscreenUI(string show)
        {
            _c.Get<IUnityJSAPI>().ShowHideTouchscreenUI_Event?.Invoke(show == "show");
        }

        public void openCloseDiscoveryPage(string open)
        {
            _c.Get<IUnityJSAPI>().OpenCloseDiscoveryPage_Event?.Invoke(open == "open");
        }

        public void setDiscoveryPageScroll(string scroll)
        {
            _c.Get<IUnityJSAPI>().SetDiscoveryPageScroll_Event?.Invoke(float.Parse(scroll));
        }

        public void teleportToDiscoveryPost(string index)
        {
            _c.Get<IUnityJSAPI>().TeleportToDiscoveryPost_Event?.Invoke(int.Parse(index));
        }

        #endregion
    }

}