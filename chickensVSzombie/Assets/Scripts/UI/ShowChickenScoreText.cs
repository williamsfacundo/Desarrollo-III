using UnityEngine;
using TMPro;
using ChickenVSZombies.Characters.Chicken;

public class ShowChickenScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private ChickenScore _chickenScore;

    private void Awake()
    {
        _chickenScore = FindObjectOfType<ChickenScore>();
    }

    void OnEnable()
    {
        ChickenScore.OnChickenScoreChanged += UpdateScoreText;                
    }

    void OnDisable()
    {
        ChickenScore.OnChickenScoreChanged -= UpdateScoreText;
    }

    private void UpdateScoreText() 
    {
        _scoreText.text = "Chicken score: " + _chickenScore.Score;
    }
}
