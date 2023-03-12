using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _panel;
    [SerializeField] private GameMoves _gameMoves;
    [SerializeField] private LayerMask _layerMask;

    private Player _player;
    private Monster _monster;
    private bool _isLockedMovement;

    private void OnEnable()
    {
        _gameMoves.Ended += OnGameMovesEnded;
    }

    private void OnDisable()
    {
        _gameMoves.Ended -= OnGameMovesEnded;
    }

    private void TryMoveMonster()
    {
        if (_player == null || _monster == null || CheckContentsMonster(_player, _monster) == false)
            return;

        _player.Movement.MoveToMonster(_monster.transform.position);
        _panel.raycastTarget = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (TrytGetComponentFromRay(out Player player) && _isLockedMovement == false)
            _player = player;
    }

    public void OnDrag(PointerEventData eventData) { }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (TrytGetComponentFromRay(out Monster monster) && _isLockedMovement == false)
        {
            _monster = monster;
            TryMoveMonster();
        }
    }

    private bool TrytGetComponentFromRay<T>(out T component) where T : MonoBehaviour
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100, _layerMask))
        {
            if (hit.collider.TryGetComponent(out T t))
            {
                component = t;
                return true;
            }
        }

        component = default;
        return false;
    }

    private bool CheckContentsMonster(Player checker, Monster wanted)
    {
        if (checker == null || wanted == null)
            return false;

        foreach (Monster monster in checker.Observer.Monsters)
            if (monster == wanted)
                return true;

        return false;
    }

    private void OnGameMovesEnded()
    {
        _isLockedMovement = true;
        _panel.raycastTarget = false;
    }
}