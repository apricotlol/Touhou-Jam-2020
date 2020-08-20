using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    Sprite[] avatars;
    [SerializeField]
    GameObject avatarDisplay;
    [SerializeField]
    GameObject avatarText;

    int currentAvatar;

    //SoundFX for button
    void Start()
    {
        currentAvatar = 0;
        updateAvatarDisplay();
        updateAvatarText();
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public int selectedAvatar()
    {
        return currentAvatar;
    }

    //SoundFX for button
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //gameObject.SetActive(false);
        //The player script will deactivate the object once it's gotten the character
    }

    //SoundFX for button
    public void Quit()
    {
        Application.Quit();
    }

    //SoundFX for button
    public void nextAvatar()
    {
        currentAvatar = (currentAvatar + avatars.Length - 1) % avatars.Length;
        updateAvatarDisplay();
        updateAvatarText();
    }

    //SoundFX for button
    public void prevAvatar()
    {
        currentAvatar = (currentAvatar + 1) % avatars.Length;
        updateAvatarDisplay();
        updateAvatarText();
    }

    void updateAvatarDisplay()
    {
        avatarDisplay.GetComponent<Image>().sprite = avatars[currentAvatar];
    }

    void updateAvatarText()
    {
        switch (currentAvatar)
        {
            case 0:
                avatarText.GetComponent<Text>().text = "Lilly \'Startaker\' Fusion: \n She is a powerful witch who agreed with Dr. Singularity to try to move the black hole at specific locations in exchange for the opportunity of empowering her abilities.";
                break;
            case 1:
                avatarText.GetComponent<Text>().text = "Professor Jim \'Singularity\' Darkness: \n He is the owner of a major space particle accelerator and “accidentally” created a black hole for his research.";
                break;
        }
    }
}
