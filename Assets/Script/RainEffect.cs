using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem _rainEffect;
    [SerializeField] RainController _controller;
    private float timer = 0f;
    private bool isEffectPlaying = false;
    private bool isCooldown = false;
    [SerializeField] private float rainTime = 20f;
    [SerializeField] private float coldDownTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // Augmenter le timer à chaque frame
        timer += Time.deltaTime;

        // Si l'effet est en cours de refroidissement, attendez 10 secondes avant de pouvoir le redémarrer
        if (isCooldown)
        {
            if (timer >= coldDownTime)
            {
                timer = 0f;
                isCooldown = false;
            }
            return;
        }

        // Vérifier si l'effet doit être joué ou arrêté
        if (isEffectPlaying)
        {
            // Vérifier si 20 secondes se sont écoulées depuis que l'effet a commencé
            if (timer >= rainTime)
            {
                // Arrêter l'effet de particules
                _controller.StopAllAudio();
                _rainEffect.Stop();
                isEffectPlaying = false;
                isCooldown = true; // Activer le cooldown de 10 secondes
                timer = 0f;
            }
        }
        else
        {
            // Si l'effet n'est pas en cours de lecture, démarrez-le
            _controller.PlayRainHeavy();
            _rainEffect.Play();
            isEffectPlaying = true;
            timer = 0f;
        }
    }


}
