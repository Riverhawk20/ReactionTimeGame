using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ReactionGameScript : MonoBehaviour
{
    public GameObject target;
    float timer;
    float spawnTime;
    float gameTime;
    public bool alive;
    public int fails;
    public int score;
    public int misClicks=0;
    public Text scoreText;
    public Text livesText;
    public GameObject ReactionMenuPanel;
    public Text scoreSummary;
    public Text AccuracyText;
    public Text HighScoreText;
    public bool game;
    public Button Easy;
    public Button Medium;
    public Button Hard;
    int difficulty;
    public double highScoreE;
    public double highScoreM;
    public double highScoreH;

    public void save(){
        SaveSystem.Save(this);
    }
    public void load(){
        SaveData data = SaveSystem.Load();
        print(data.highScoreE);
        if(data != null){
            highScoreE = data.highScoreE;
            highScoreM = data.highScoreM;
            highScoreH = data.highScoreH;
            HighScoreText.text= "Easy High Score: " + highScoreE + "\nMedium High Score: " + highScoreM + "\nHard High Score: " + highScoreH;
        }
    }
    void Start()
    {
        ReactionMenuPanel.SetActive(true);
        game=false;
        MediumClick();
        load();
    }

    // Update is called once per frame
    void Update()
    {
    if(game){
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + (3 - fails);
        if(fails>=3){
            reactionFail();
        }
        timer+= Time.deltaTime;
        gameTime += Time.deltaTime;
        if(timer >= spawnTime && alive){
            timer -= spawnTime;
           //random position (0,0) is bottom left while (1,1) is top right
           Vector2 randomPos = Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(0.15f,0.85f), Random.Range(0.1f,0.9f))); 
           Instantiate(target, randomPos, Quaternion.identity);
    }

        }
    }
    public void reactionFail(){
        alive=false;
        game=false;
        ReactionMenuPanel.SetActive(true);
        scoreSummary.text="You Pressed \n"+ score + " Targets \nand Lasted "+gameTime.ToString("F2")+" seconds";
        if((score+misClicks)==0){
            AccuracyText.text="";
        }
        else{
            AccuracyText.text="Accuracy: " + (100.0f*(score)/(score+misClicks)).ToString("F1") +"%";
        }
        if(spawnTime==.65f && score > highScoreE){
            highScoreE=score;
        }
        else if(spawnTime==.4f && score > highScoreM){
            highScoreM=score;
        }
        else if(spawnTime== .3f && score > highScoreH){
            highScoreH=score;
        }
        HighScoreText.text= "Easy High Score: " + highScoreE + "\nMedium High Score: " + highScoreM + "\nHard High Score: " + highScoreH;
        save();
    }
    public void restartGame (){
        ReactionMenuPanel.SetActive(false);
        timer = 0.0f;
        gameTime=0.0f;
        alive=true;
        score = 0;
        fails=0;
        misClicks=0;
        game=true;
        Vector2 randomPos = Camera.main.ViewportToWorldPoint(new Vector2(UnityEngine.Random.Range(0.15f,0.85f), UnityEngine.Random.Range(0.1f,0.8f))); 
        Instantiate(target, randomPos, Quaternion.identity);
        scoreText.text = "Score: 0";
        livesText.text = "Lives: 3"; 
    }
    public void EasyClick(){
        spawnTime = .65f;
        Easy.GetComponent<Image>().color = new Color32(7,255,0,255);
        Medium.GetComponent<Image>().color = new Color32(0,255,235,80);
        Hard.GetComponent<Image>().color = new Color32(250,79,63,80);
    }
    public void MediumClick(){
        spawnTime= .4f;
        Easy.GetComponent<Image>().color = new Color32(7,255,0,80);
        Medium.GetComponent<Image>().color = new Color32(0,255,235,255);
        Hard.GetComponent<Image>().color = new Color32(250,79,63,80);
    }
    public void HardClick(){
        spawnTime = .3f;
        Easy.GetComponent<Image>().color = new Color32(7,255,0,80);
        Medium.GetComponent<Image>().color = new Color32(0,255,235,80);
        Hard.GetComponent<Image>().color = new Color32(250,79,63,255);
    }

}
