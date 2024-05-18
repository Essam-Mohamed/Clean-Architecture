using BuberDinner.Domain.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BuberDinner.Infrastructure.Persistence.Interceptors
{
    public class PublishDomainEventsInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _mediatr;

        public PublishDomainEventsInterceptor(IPublisher mediatr)
        {
            _mediatr = mediatr;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await PublishDomainEvents(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }


        private async Task PublishDomainEvents(DbContext? dbContext)
        {
            if (dbContext is null)
            {
                return;
            }

            //Get hold all the various entites
            var entitesWithDomainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(entry => entry.Entity.DomainEvents.Any())
                .Select(entry => entry.Entity)
                .ToList();

            //Get hold of all the various domain events
            var domainEvents = entitesWithDomainEvents.SelectMany(entity => entity.DomainEvents).ToList();

            //Clear domain events
            entitesWithDomainEvents.ForEach(entity => entity.ClearDomainEvents());

            //Publish domain events
            foreach (var domainEvent in domainEvents)
            {
                await _mediatr.Publish(domainEvent);
            };
        }
    }
}
