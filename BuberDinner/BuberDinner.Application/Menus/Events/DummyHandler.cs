using BuberDinner.Domain.Menu.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Menus.Events
{
    public class DummyHandler : INotificationHandler<MenuCreated>
    {
        public async Task Handle(MenuCreated notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
