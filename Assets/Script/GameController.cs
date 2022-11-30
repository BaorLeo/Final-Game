using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StoryScene;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;

    private State state = State.IDLE;

    private enum State
    {
        IDLE , ANIMATE
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GAME CONTROL PLAY");
        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (state == State.IDLE && bottomBar.IsCompleted())
            {
                if(bottomBar.IsLastSentence())
                {
                    PlayScene(currentScene.nextScene);
                }
                else
                {
                    Debug.Log("enter here");
                    bottomBar.PlayNextSentence(); 
                }
                
            }
        }
    }

    private void PlayScene(StoryScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(StoryScene scene)
    {
        state = State.ANIMATE;
        currentScene = scene;
        bottomBar.Hide();
        yield return new WaitForSeconds(0.05f);
        backgroundController.SwitchImage(scene.background);
        yield return new WaitForSeconds(5f);
        bottomBar.ClearText();
        bottomBar.Show();
        yield return new WaitForSeconds(0.01f);
         bottomBar.PlayScene(scene);
        state = State.IDLE;
    }
}
