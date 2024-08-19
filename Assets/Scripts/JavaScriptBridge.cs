using UnityEngine;
using System.Runtime.InteropServices;

public class JavaScriptBridge : MonoBehaviour
{
    // WebGL에서 JavaScript 함수를 호출하기 위해 DllImport 사용
    #if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void UnityEvent(string message);
    #endif

    // Unity 시작 시 호출되는 함수
    void Start()
    {
        SendMessageToVue("Hello from Unity!");
    }

    // JavaScript 함수를 호출하는 메서드
    public void SendMessageToVue(string message)
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
        try
        {
            UnityEvent(message); // JavaScript에서 정의된 함수를 호출
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to call UnityEvent: " + e.Message);
        }
        #else
        Debug.Log("Sending to Vue: " + message);
        #endif
    }

    // JavaScript에서 호출할 수 있는 Unity 메서드
    public void MethodName(string message)
    {
        Debug.Log("Message received from JavaScript: " + message);
    }
}
