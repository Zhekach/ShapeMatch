using UnityEngine;

public class ShapePhysics  : MonoBehaviour
{
    [SerializeField] private string _stickyTag = "ShapeSticky"; // тег объекта, к которому можно прилипнуть

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(_stickyTag))
            return;

        // Проверяем, есть ли уже FixedJoint2D
        if (TryGetComponent<FixedJoint2D>(out var existingJoint))
            return; // уже прилип

        // Создаём joint
        FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
        joint.connectedBody = collision.rigidbody;
        joint.breakForce = Mathf.Infinity;
        joint.breakTorque = Mathf.Infinity;
        joint.autoConfigureConnectedAnchor = true;

        // Отключаем коллизию только с этим объектом, но не со всеми остальными!
        Collider2D ownCollider = GetComponent<Collider2D>();
        Collider2D targetCollider = collision.collider;

        if (ownCollider != null && targetCollider != null)
        {
            Physics2D.IgnoreCollision(ownCollider, targetCollider, true);
        }
    }

}
