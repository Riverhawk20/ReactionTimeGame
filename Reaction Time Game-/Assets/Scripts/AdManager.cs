using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdManager : MonoBehaviour
{
    // Start is called before the first frame update
    private string store_id = "3429496";
    private string banner_ad = "BannerAds";
    private string video_ad = "rewardedVideo";
    bool test= true;
    void Start()
    {
        Advertisement.Initialize(store_id, test);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        StartCoroutine(ShowBanner());
    }

    // Update is called once per frame
    IEnumerator ShowBanner(){
        while(!Advertisement.IsReady (banner_ad)){
            yield return new WaitForSeconds(0.5f);
        }
        print("HI");
        Advertisement.Banner.Show(banner_ad);
    }
}
