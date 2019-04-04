using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class SpeechRecognition : MonoBehaviour {

    public GameObject Prefab;
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {
        
        keywords.Add("go", () =>
        {
            GoCalled();
        });
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnphraseRecognized;
        keywordRecognizer.Start();
    }
    
    void KeywordRecognizerOnphraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        if(keywords.TryGetValue(args.text,out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    void GoCalled()
    {
        GameObject gen;
        gen = Instantiate(Prefab) as GameObject;
        gen.transform.position = new Vector2(0,0);
    }
}
