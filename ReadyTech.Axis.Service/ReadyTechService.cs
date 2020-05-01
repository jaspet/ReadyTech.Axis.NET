using Newtonsoft.Json;
using ReadyTech.Axis.Service.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadyTech.Axis.Service
{
    public class ReadyTechService : IReadyTechService
    {
        private readonly IRestClient _Client;
        private const string BaseUrl = "https://axis-api.readytech.com/v1";

        public ReadyTechService(string accessToken, string secretToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("message", nameof(accessToken));
            }

            if (string.IsNullOrWhiteSpace(secretToken))
            {
                throw new ArgumentException("message", nameof(secretToken));
            }

            _Client = new RestClient(BaseUrl)
            {
                Authenticator = new ReadyTechAuthenticator(accessToken, secretToken)
            };
        }

        public Event CreateEvent(Event newEvent)
        {
            if (newEvent is null)
            {
                throw new ArgumentNullException(nameof(newEvent));
            }

            IRestRequest request = new RestRequest($"events/", Method.POST, DataFormat.Json);
            request.AddBody(JsonConvert.SerializeObject(newEvent, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "yyyy-MM-dd"
            }));
            IRestResponse response = _Client.Post(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Event>(response.Content);
            }
            return null;
        }

        public Event UpdateEvent(Event eventToUpdate)
        {
            if (eventToUpdate is null)
            {
                throw new ArgumentNullException(nameof(eventToUpdate));
            }

            IRestRequest request = new RestRequest($"events/{eventToUpdate.Uuid}", Method.PUT, DataFormat.Json);

            IOrderedEnumerable<DateTimeOffset> dates = eventToUpdate.Schedule.Select(x => DateTimeOffset.Parse(x.Day)).OrderBy(y => y.Ticks);

            UpdateEvent updateEvent = new UpdateEvent
            {
                StartDate = dates.First(),
                EndDate = dates.Last(),
                ProviderRegion = eventToUpdate.ProviderRegion,
                Name = eventToUpdate.Name,
                ExternalId = eventToUpdate.ExternalId,
                Schedule = eventToUpdate.Schedule,
                Description = eventToUpdate.Description,
                Template = eventToUpdate.Template
            };
            request.AddBody(JsonConvert.SerializeObject(updateEvent, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "yyyy-MM-dd"
            }));
            IRestResponse response = _Client.Put(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Event>(response.Content);
            }
            return null;
        }

        public Event GetEvent(Guid eventUuid)
        {
            IRestRequest request = new RestRequest($"events/{eventUuid}", Method.GET, DataFormat.Json);
            IRestResponse response = _Client.Get(request);
            return JsonConvert.DeserializeObject<Event>(response.Content);
        }

        public List<EventResponse> GetAllEvents()
        {
            IRestRequest request = new RestRequest($"events", Method.GET, DataFormat.Json);
            IRestResponse response = _Client.Get(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<EventResponse>>(response.Content);
            }
            return null;
        }

        public List<Event> SearchEvent(SearchEvent searchEvent)
        {
            IRestRequest request = new RestRequest($"events/search", Method.POST, DataFormat.Json);
            request.AddBody(JsonConvert.SerializeObject(searchEvent, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }));
            IRestResponse response = _Client.Post(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Event>>(response.Content);
            }
            return null;
        }

        public bool CancelEvent(Guid eventUuid)
        {
            IRestRequest request = new RestRequest($"events/{eventUuid}/cancel", Method.POST, DataFormat.Json);
            IRestResponse response = _Client.Post(request);
            return response.IsSuccessful;
        }

        public List<Seat> GetSeatsForEvent(Guid eventUuid)
        {
            IRestRequest request = new RestRequest($"events/{eventUuid}/seats", Method.GET, DataFormat.Json);
            IRestResponse response = _Client.Get(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Seat>>(response.Content);
            }
            return null;
        }

        public Seat GetSeat(Guid seatUuid)
        {
            IRestRequest request = new RestRequest($"seats/{seatUuid}", Method.GET, DataFormat.Json);
            IRestResponse response = _Client.Get(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Seat>(response.Content);
            }
            return null;
        }

        public Seat UpdateSeat(Seat seatToUpdate)
        {
            if (seatToUpdate is null)
            {
                throw new ArgumentNullException(nameof(seatToUpdate));
            }

            UpdateSeat updateSeat = new UpdateSeat
            {
                Email = seatToUpdate.AssignedEmail,
                FirstName = seatToUpdate.AssignedFirstName,
                LastName = seatToUpdate.AssignedLastName,
                ExternalId = seatToUpdate.ExternalId ?? string.Empty
            };

            IRestRequest request = new RestRequest($"seats/{seatToUpdate.Uuid}", Method.PUT, DataFormat.Json);
            request.AddBody(JsonConvert.SerializeObject(updateSeat));
            IRestResponse response = _Client.Put(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Seat>(response.Content);
            }
            return null;
        }

        public bool CancelSeat(Guid seatUuid)
        {
            IRestRequest request = new RestRequest($"seats/{seatUuid}/cancel", Method.POST, DataFormat.Json);
            IRestResponse response = _Client.Post(request);
            return response.IsSuccessful;
        }
    }
}
