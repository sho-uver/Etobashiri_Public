#if UNITY_IOS

using System.Collections;
using Unity.Advertisement.IosSupport;
using UnityEngine;
using UnityEngine.iOS;

public sealed class IDFAGetter : MonoBehaviour
{
    private IEnumerator Start()
    {
        // まだ許可ダイアログを表示したことがない場合
        if ( ATTrackingStatusBinding.GetAuthorizationTrackingStatus() ==
            ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED )
        {
            // 許可ダイアログを表示します
            ATTrackingStatusBinding.RequestAuthorizationTracking();

            // 許可ダイアログで「App にトラッキングしないように要求」か
            // 「トラッキングを許可」のどちらかが選択されるまで待機します
            while ( ATTrackingStatusBinding.GetAuthorizationTrackingStatus() ==
                    ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED )
            {
                yield return null;
            }
        }

        // IDFA（広告 ID）をログ出力します
        // トラッキングが許可されている場合は IDFA が文字列で出力されます
        // 許可されていない場合は「00000000-0000-0000-0000-000000000000」が出力されます  
        Debug.Log( "IDFA" + Device.advertisingIdentifier );
    }
}

#endif