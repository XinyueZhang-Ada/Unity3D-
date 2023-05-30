using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    //游戏胜利时，图片淡入淡出的时间
    public float fadeDuration = 1f;
    //游戏胜利时，显示的时间
    public float displayDuration = 1f;
    //游戏人物
    public GameObject Player;
    //游戏胜利时的画布背景
    public CanvasGroup ExitBK;
    //游戏失败时的画布背景
    public CanvasGroup FailBK;

    //游戏胜利时的bool值
    bool IsExit=false;
    //游戏失败时的bool值
    bool IsFail=false;
    //定义计时器用于图片的渐变与完全显示
    public float timer = 0f;

    //音频组件
    public AudioSource winaudio;
    public AudioSource failaudio;

    //bool值，控制音效只播放一次
    bool IsPlay=false;


    // Start is called before the first frame update
    //void Start()
    //{

    //}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            //检测到玩家
            //游戏胜利
            IsExit = true;
        }
    }

    //游戏失败时的控制函数
    public void Caught()
    {
        IsFail = true;
    }

    // Update is called once per frame
    void Update()
    {
        //游戏胜利
        if (IsExit)
        {
            EndLevel(ExitBK, false,winaudio);
        }
        //游戏失败
        else if (IsFail)
        {
            EndLevel(FailBK, true,failaudio);
        }
    }

    //游戏胜利或失败时的方法
    void EndLevel(CanvasGroup igCanvasGroup, bool doRestart,AudioSource playaudio)
    {
        //游戏胜利或失败的音效播放
        if (!IsPlay)
        {
            playaudio.Play();
            IsPlay = true;
        }

        //玩家触碰到触发器时，计时器开始计时
        timer += Time.deltaTime;
        //控制CanvasGroup的不透明度
        igCanvasGroup.alpha = timer / fadeDuration;

        //游戏胜利或失败图片渐变了1秒，显示了1秒，游戏结束
        if (timer > fadeDuration + displayDuration)
        {
            //游戏失败，重启游戏
            if (doRestart)
            {
                SceneManager.LoadScene("Main");
            }
            //游戏胜利，退出游戏
            else if (!doRestart)
            {
                Application.Quit();
            }
        }
    }
}
