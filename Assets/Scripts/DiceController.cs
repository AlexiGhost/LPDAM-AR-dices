using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DiceController : MonoBehaviour, ITrackableEventHandler {
    private TrackableBehaviour mTrackableBehaviour;
    public Rigidbody[] rigibodies;

    // Use this for initialization
    void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            //Target found
            foreach(Rigidbody r in rigibodies)
            {
                r.isKinematic = false;
            }
        }
        else
        {
            //Target lost
            foreach (Rigidbody r in rigibodies)
            {
                r.isKinematic = true;
            }
        }
    }
}
