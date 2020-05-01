using ReadyTech.Axis.Service.Models;
using System;
using System.Collections.Generic;

namespace ReadyTech.Axis.Service
{
    public interface IReadyTechService
    {
        bool CancelEvent(Guid eventUuid);
        bool CancelSeat(Guid seatUuid);
        Event CreateEvent(Event newEvent);
        List<EventResponse> GetAllEvents();
        Event GetEvent(Guid eventUuid);
        Seat GetSeat(Guid seatUuid);
        List<Seat> GetSeatsForEvent(Guid eventUuid);
        List<Event> SearchEvent(SearchEvent searchEvent);
        Event UpdateEvent(Event eventToUpdate);
        Seat UpdateSeat(Seat seatToUpdate);
    }
}