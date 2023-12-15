using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _deathParticlesPrefab;
        [SerializeField] private float _minMovingDuration;
        [SerializeField] private float _maxMovingDuration;

        private SpriteRenderer _enemySprite;
        private float _minPointX;
        private float _maxPointX;
        private float _delayBetweenMovements;
        private Sequence _moveSequence;
        

        public void Initialize(float minPointX, float maxPointX, float delayBetweenMovements)
        {
            _enemySprite = GetComponent<SpriteRenderer>();
            var offsetX = _enemySprite.bounds.size.x / 2;

            _minPointX = minPointX;
            _maxPointX = maxPointX;
            _delayBetweenMovements = delayBetweenMovements;

            Move();
        }

        //вызывается по событию уничтожения врага.
        [UsedImplicitly]
        public void Destroy()
        {
            Instantiate(_deathParticlesPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


        private void OnDestroy()
        {
            _moveSequence.Kill();
        }

        private void Move()
        {
            var randomMovementDuration = GetRandomMovementDuration();
            var nextPosition = GetNextRandomMovementDuration();

            _moveSequence = DOTween.Sequence();
            _moveSequence.Append(transform.DOMoveX(nextPosition, randomMovementDuration));
            _moveSequence.AppendInterval(_delayBetweenMovements);
            _moveSequence.OnComplete(Move);
        }

        private float GetRandomMovementDuration() => Random.Range(_minMovingDuration, _maxMovingDuration);

        private float GetNextRandomMovementDuration() => Random.Range(_minPointX, _maxPointX);
    }
}