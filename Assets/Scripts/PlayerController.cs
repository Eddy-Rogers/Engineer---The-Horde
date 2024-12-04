using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerController : MonoBehaviour {

    public ItemData FertilizerBomb;
    public ItemData Diesel;
    public ItemData Fertilizer;
    public GameObject FertilizerBombPrefab;
    Character charRef;
    public InventoryHandler inventory;

    SceneSwitcher switcher;
    SaveScene saver;

    GameObject bombCount;

    List<ParticleSystem> hitEffect;

    void Start()
    {
        charRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        inventory = GameObject.FindGameObjectWithTag("GameManager").GetComponent<InventoryHandler>();
        bombCount = GameObject.FindGameObjectWithTag("BombCount");
        saver = GameObject.FindGameObjectWithTag("Save Manager").GetComponent<SaveScene>();
        switcher = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SceneSwitcher>();
        hitEffect = new List<ParticleSystem>();
        hitEffect.AddRange(GetComponentsInChildren<ParticleSystem>());
        foreach (ParticleSystem p in hitEffect)
        {
            ParticleSystem.MainModule temp = p.main;
            temp.loop = false;
            temp.playOnAwake = false;
            //p.main = temp;
        }
        Initialize();
    }

    void Initialize()
    {
        GameObject loader = GameObject.FindGameObjectWithTag("Loader");

        if(loader != null)
        {
            loader.transform.parent = new GameObject("Temp").transform;
            loader.transform.parent = null;

            Loader loaderComponent = loader.GetComponent<Loader>();

            if (loaderComponent.isLoad && File.Exists(Application.persistentDataPath + "/save.txt"))
            {
                string jString = null;
                SaveDataContainer saveData;

                //Read Data
                using (StreamReader r = File.OpenText(Application.persistentDataPath + "/save.txt"))
                {
                    jString = r.ReadToEnd();
                    saveData = JsonUtility.FromJson<SaveDataContainer>(jString);
                }

                inventory.AddItem(FertilizerBomb, saveData.player.bombNumber);
                inventory.AddItem(Diesel, saveData.player.dieselNumber);
                inventory.AddItem(Fertilizer, saveData.player.fertilizerNumber);

                inventory.UpdateUI();

                transform.position = new Vector3(saveData.player.transform[0], saveData.player.transform[1], 0);
            }
        }

        
    }

    // Update is called once per frame
    void Update () {
        HandleInputs();
    }

    public void PlayHitEffect()
    {
        foreach(ParticleSystem p in hitEffect)
        {
            p.transform.position = transform.position;
            p.Play();
        }
    }

    void HandleInputs()
    {
        Vector2 returnValue = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        charRef.PlayerMovement(returnValue);

        if(Input.GetKeyDown(KeyCode.Space) && inventory.HasItem(FertilizerBomb))
        {
            Instantiate(FertilizerBombPrefab, charRef.transform.position, Quaternion.identity);
            inventory.RemoveItem(FertilizerBomb);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            saver.Save();
            switcher.SwitchScene("Menu");
            Application.Quit();
        }
    }
}
