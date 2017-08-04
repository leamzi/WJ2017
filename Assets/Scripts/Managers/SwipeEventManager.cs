using UnityEngine;

/// <summary>
/// Autor: Leamzi
/// Class that manage the methods for swipe cast 
/// </summary>
[RequireComponent (typeof(SwipeControl))]
public class SwipeEventManager : SingletonMonoBehaviour<SwipeEventManager> {

    //public static SwipeEventManager instance = null; //Instance to make singleton of this manager

    public delegate void OnSwipeUp();
    public event OnSwipeUp notifySwipeUp; //Delegate to suscribe any class to swipe UP events.

    public delegate void OnSwipeDown();
    public event OnSwipeDown notifySwipeDown; //Delegate to suscribe any class to swipe DOWN events.

    public delegate void OnSwipeLeft();
    public event OnSwipeLeft notifySwipeLeft; //Delegate to suscribe any class to swipe LEFT events.

    public delegate void OnSwipeRight();
    public event OnSwipeRight notifySwipeRight; //Delegate to suscribe any class to swipe RIGHT events.

    public bool CancelSwipe
    {
        get { return _cancelSwipe; }
    }

    private bool _cancelSwipe = true;

    #region Monobehaviour Methods
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        this.GetComponent<SwipeControl>().SetMethodToCall(SwipeCallBack);
    }

    #endregion

    private void SwipeCallBack(SwipeControl.SWIPE_DIRECTION iDirection)
    {
        if (CancelSwipe) return;

        switch (iDirection)
        {
            case SwipeControl.SWIPE_DIRECTION.SD_UP: //This is a swipe up
                print("Swipe Up");
                if(notifySwipeUp != null) notifySwipeUp();
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_DOWN:
                print("Swipe Down");
                if (notifySwipeDown != null) notifySwipeDown();
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_LEFT:
                print("Swipe Left");
                if (notifySwipeLeft != null) notifySwipeLeft();
                break;
            case SwipeControl.SWIPE_DIRECTION.SD_RIGHT:
                print("Swipe Right");
                if (notifySwipeRight != null) notifySwipeRight();
                break;

            //case SwipeControl.SWIPE_DIRECTION.SD_UP_RIGHT:
            //    break;
            //case SwipeControl.SWIPE_DIRECTION.SD_DOWN_RIGHT:
            //    break;
            //case SwipeControl.SWIPE_DIRECTION.SD_DOWN_LEFT:
            //    break;
            //case SwipeControl.SWIPE_DIRECTION.SD_UP_LEFT:
            //    break;
            case SwipeControl.SWIPE_DIRECTION.SD_TOUCH:
                print("Hice Tap");
                break;
        }
    }

    /// <summary>
    /// Set swipe to status behavior
    /// </summary>
    /// <param name="status"></param>
    public void setCancelSwipe (bool status)
    {
        _cancelSwipe = status;
    }
}
