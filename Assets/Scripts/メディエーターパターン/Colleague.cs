using UnityEngine;

namespace Mediator
{
    public abstract class Colleague : MonoBehaviour
    {
        protected IMediator mediator;

        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}