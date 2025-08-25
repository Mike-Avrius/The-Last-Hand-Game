using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditPanelMovement : MonoBehaviour
{
    private bool panelMoving = false;
    public GameObject creditsPanel;
    public GameObject finalCreditsPanel;
    private float timer = 25.8f;
    private float creditPanelSpeed = 100f;
    
    //diactivate credit panel
    private void Start()
    {
        creditsPanel.gameObject.SetActive(false);
        finalCreditsPanel.gameObject.SetActive(false); 
    }
    
    
    
    //make panel move until timer isnot out
    void FixedUpdate()
    {
        if (panelMoving)
        {
            Vector2 creditPanelDirection = Vector2.up;
            creditsPanel.gameObject.transform.Translate(creditPanelDirection * (creditPanelSpeed * Time.fixedDeltaTime));
            
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                creditPanelSpeed = 0f;
                panelMoving = false; 
                creditsPanel.gameObject.SetActive(false);
                PlayFinalCreditsPanel();
            }
        }
    }
    
    //activate final thanks credit
    public void PlayFinalCreditsPanel()
    {
        panelMoving = false;
        finalCreditsPanel.gameObject.SetActive(true);
    }


    //activate credit panel and make bool for miving - true
    public void CreditsPanel()
    {
        creditsPanel.gameObject.SetActive(true);
        panelMoving = true;
    }
    
    // exit to main menu - via button
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
