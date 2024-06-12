using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir esto para trabajar con UI

public class AudioGuideController : MonoBehaviour
{
    public GameObject audioControlButtons; // Referencia al contenedor de botones de control
    public AudioSource audioSource; // Referencia al componente AudioSource
    public AudioClip audioClip; // Referencia al archivo de audio laexposicion.mp3
    private bool isAudioGuideActivated = false; // Bandera para desactivar el botón después del primer clic

    public Button playPauseButton; // Referencia al botón de Play/Pause
    public Sprite playSprite; // Imagen para el estado de play
    public Sprite pauseSprite; // Imagen para el estado de pause

    void Start()
    {
        audioControlButtons.SetActive(false); // Asegúrate de que los botones de control estén desactivados inicialmente
        playPauseButton.image.sprite = pauseSprite; // Inicialmente, el botón muestra la imagen de pausa
    }

    public void OnAudioGuideButtonClick()
    {
        // Verificar si el botón ya ha sido activado
        if (isAudioGuideActivated) return;

        // Activar los botones de control
        audioControlButtons.SetActive(true);

        // Reproducir el audio desde el principio
        audioSource.clip = audioClip;

        // Detener el audio si ya se está reproduciendo
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Reproducir el audio
        audioSource.Play();

        // Establecer la bandera para desactivar el botón
        isAudioGuideActivated = true;
    }

    public void TogglePlayPause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            playPauseButton.image.sprite = playSprite; // Cambiar a la imagen de play
        }
        else
        {
            audioSource.Play();
            playPauseButton.image.sprite = pauseSprite; // Cambiar a la imagen de pausa
        }


    }

    public void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioControlButtons.SetActive(false); // Desactivar los botones de control
        isAudioGuideActivated = false; // Permitir que el botón "Audioguía" se pueda volver a activar
    }

    public void RestartAudio()
    {
        audioSource.Stop();
        audioSource.Play();
        playPauseButton.image.sprite = pauseSprite; // Asegurarse de que el botón muestra la imagen de pausa
    }

    public void DecreaseVolume()
    {
        audioSource.volume = Mathf.Max(audioSource.volume - 0.1f, 0.0f);
    }

    public void IncreaseVolume()
    {
        audioSource.volume = Mathf.Min(audioSource.volume + 0.1f, 1.0f);
    }
}

   

