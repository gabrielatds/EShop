﻿using EShop.Core.Domain;
using EShop.Infrastructure.DataAcess.UoW;
using MediatR;

namespace EShop.Application
{
    public abstract class CommandHandler
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;

        public CommandHandler(IUnitOfWork uow, IMediator mediator)
        {
            this._mediator = mediator;
            _uow = uow;
        }

        public bool Commit()
        {
            if (_uow.Commit()) return true;

            return false;
        }

        public void PublishEvents(IList<Event> events)
        {
            events.ToList().ForEach(e => _mediator.Publish(e));
        }
    }
}