#if UNITY_IOS

using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

public static class ATTPostProcessBuild
{
    [PostProcessBuild]
    private static void OnPostProcessBuild
    (
        BuildTarget buildTarget,
        string      pathToBuiltProject
    )
    {
        if ( buildTarget != BuildTarget.iOS ) return;

        var path          = pathToBuiltProject + "/Info.plist";
        var plistDocument = new PlistDocument();

        plistDocument.ReadFromFile( path );
        plistDocument.root.SetString
        (
            key: "NSUserTrackingUsageDescription",
            val: "【App Tracking Transparency 承認ダイアログに表示されるメッセージ】"
        );
        plistDocument.WriteToFile( path );
    }
}

#endif