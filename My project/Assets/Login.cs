using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Login : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MessageText;

    [Header("Face ID")]
    [SerializeField] GameObject FaceID;

    [Header("Login")]
    [SerializeField] TMP_InputField EmailLoginInput;
    [SerializeField] TMP_InputField PasswordLoginInput;
    [SerializeField] GameObject LoginPage;

    [Header("SignUp")]
    [SerializeField] TMP_InputField UsernameSignUpInput;
    [SerializeField] TMP_InputField EmailSignUpInput;
    [SerializeField] TMP_InputField PasswordSignUpInput;
    [SerializeField] GameObject SignUpPage;

    [Header("SignUp")]
    [SerializeField] TMP_InputField EmailRecoveryInput;
    [SerializeField] GameObject RecoverPage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region ButtonFunc
    public void OpenLoginPage()
    {
        LoginPage.SetActive(true);
        SignUpPage.SetActive(false);
        RecoverPage.SetActive(false);
        FaceID.SetActive(false);
    }
    public void OpenSignUpPage()
    {
        LoginPage.SetActive(false);
        SignUpPage.SetActive(true);
        RecoverPage.SetActive(false);
        FaceID.SetActive(false);
    }
    public void OpenRecoveryPage()
    {
        LoginPage.SetActive(false);
        SignUpPage.SetActive(false);
        RecoverPage.SetActive(true);
        FaceID.SetActive(false);
    }
    public void OpenFaceIDPage()
    {
        LoginPage.SetActive(false);
        SignUpPage.SetActive(false);
        RecoverPage.SetActive(false);
        FaceID.SetActive(true);
    }
    #endregion
}
