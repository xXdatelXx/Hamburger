using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioView : GameStateView
{
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    protected override void View(GameState.States state)
    {
        _audio.Play();
    }
}
