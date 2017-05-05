using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour {
    public static DialogSystem Instance { get; set; }
    public string name;
    public GameObject panel;
    public List<string> lines = new List<string>();

    Button continueButton;
    Text dialogText, nameText;
    int dialogIndex;

    private void Awake()
    {
        continueButton = panel.transform.FindChild("Continue").GetComponent<Button>();
        dialogText = panel.transform.FindChild("Text").GetComponent<Text>();
        nameText = panel.transform.FindChild("Name").GetChild(0).GetComponent<Text>();
        continueButton.onClick.AddListener(delegate { ContinueDialog(); });
        panel.SetActive(false);



        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialog(string[] lines, string npcName)
    {
        dialogIndex = 0;
        this.lines = new List<string>(lines.Length);
        this.lines.AddRange(lines);
        this.name = npcName;
        CreateDialog();

    }
    public void CreateDialog()
    {
        dialogText.text = lines[dialogIndex];
        nameText.text = name;
        panel.SetActive(true);
    }
    public void ContinueDialog()
    {
        if(dialogIndex < lines.Count - 1)
        {
            dialogIndex++;
            dialogText.text = lines[dialogIndex];
        }
        else
        {
            panel.SetActive(false);
        }
    }                            
}
