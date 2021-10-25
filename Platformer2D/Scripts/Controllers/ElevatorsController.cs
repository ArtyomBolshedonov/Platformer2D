using UnityEngine;
using System.Collections.Generic;
using System.Linq;


namespace Platformer2D
{
    internal sealed class ElevatorsController : IExecute
    {
        private readonly List<ObjectView> _elevators;
        private List<ContactsPoller> _contactsPoller;

        public ElevatorsController(List<ObjectView> elevators)
        {
            _elevators = elevators;
            _contactsPoller = new List<ContactsPoller>();
            foreach (var elevator in _elevators)
            {
                var elevatorContactPoller = new ContactsPoller(elevator.Collider2D);
                _contactsPoller.Add(elevatorContactPoller);
            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var elevatorContactPoller in _contactsPoller)
            {
                elevatorContactPoller.CheckContacts();
                if (elevatorContactPoller.UnderPressure)
                {
                    var index = _contactsPoller.FindIndex(i => i.UnderPressure == true);
                    _elevators.ElementAt(index).GetComponent<SliderJoint2D>().useMotor = elevatorContactPoller.UnderPressure;
                }
                else
                {
                    foreach (var item in _elevators)
                    {
                        item.GetComponent<SliderJoint2D>().useMotor = false;
                        item.Rigidbody2D.velocity = item.Rigidbody2D.velocity.Change(x: 0.0f);
                    }
                }
            }
        }
    }
}
