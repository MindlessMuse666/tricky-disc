using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class UserMoveTimeLimiter : MonoBehaviour
    {
        [SerializeField] private float _timeLimiterDuration;
        [SerializeField] private float _finishTimeLimiterScale;
        [SerializeField] private UnityEvent _timeIsOver;
        
        private Sequence _timeLimiterSequence;
        private Vector3 _startTimeLimiterScale;
        
        private void Start()
        {
            _startTimeLimiterScale = transform.localScale;
            
            StartTimeLimiterSequence();
        }

        private void StartTimeLimiterSequence()
        {

            _timeLimiterSequence = DOTween.Sequence();
            _timeLimiterSequence.SetAutoKill(false);
            _timeLimiterSequence.Append(transform.DOScale(_startTimeLimiterScale, 0f));
            _timeLimiterSequence.Append(transform.DOScale(_finishTimeLimiterScale, _timeLimiterDuration));
            _timeLimiterSequence.OnComplete(() => _timeIsOver.Invoke());
        }
        
        public void RestartTimeLimiter()
        {
            _timeLimiterSequence.Restart();
        }
        
        public void StopTimeLimiter()
        {
            _timeLimiterSequence.Pause();
            transform.localScale = Vector3.zero;
        }

        private void OnDestroy()
        {
            _timeLimiterSequence.Kill();
        }
    }
}