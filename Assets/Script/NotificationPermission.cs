using UnityEngine;

public class NotificationPermission : MonoBehaviour
{
    void Start()
    {
        RequestNotificationPermission();
    }

    void RequestNotificationPermission()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (var version = new AndroidJavaClass("android.os.Build$VERSION"))
        {
            if (version.GetStatic<int>("SDK_INT") >= 33)
            {
                using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                    using (var contextCompat = new AndroidJavaClass("androidx.core.content.ContextCompat"))
                    {
                        var permissionCheck = contextCompat.CallStatic<int>("checkSelfPermission", activity, "android.permission.POST_NOTIFICATIONS");
                        if (permissionCheck != 0) // PackageManager.PERMISSION_GRANTED is 0
                        {
                            using (var activityCompat = new AndroidJavaClass("androidx.core.app.ActivityCompat"))
                            {
                                activityCompat.CallStatic("requestPermissions", activity, new string[] { "android.permission.POST_NOTIFICATIONS" }, 101);
                            }
                        }
                    }
                }
            }
        }
#endif
    }
}
