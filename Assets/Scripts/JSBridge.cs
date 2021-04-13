using UnityEngine;
using System.Runtime.InteropServices;

public class JSBridge: MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void JSAlert(string str);

    void Start() {
        JSAlert("This is a string.");
    }
}