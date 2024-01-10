using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUSS.DOM.Bookings
{
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string countryOrRegion { get; set; }
        public string postalCode { get; set; }
    }
    public class Coordinates
    {
        public double altitude { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double accuracy { get; set; }
        public double altitudeAccuracy { get; set; }
    }

    public class Customer
    {
        [JsonProperty("@odata.type")]
        public string odatatype { get; set; }
        public string customerId { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public string phone { get; set; }
        public string timeZone { get; set; }
        public string notes { get; set; }
        public Location location { get; set; }
        public List<object> customQuestionAnswers { get; set; }
    }

    public class EndDateTime
    {
        public DateTime dateTime { get; set; }
        public string timeZone { get; set; }
    }

    public class Location
    {
        public string displayName { get; set; }
        public string locationEmailAddress { get; set; }
        public string locationUri { get; set; }
        public string locationType { get; set; }
        public object uniqueId { get; set; }
        public object uniqueIdType { get; set; }
        public Address address { get; set; }
        public Coordinates coordinates { get; set; }
    }
    public class MeetingData
    {
        [JsonProperty("@odata.context")]
        public string odatacontext { get; set; }
        public List<Value> value { get; set; }
    }

    public class ServiceLocation
    {
        public string displayName { get; set; }
        public string locationEmailAddress { get; set; }
        public string locationUri { get; set; }
        public string locationType { get; set; }
        public object uniqueId { get; set; }
        public object uniqueIdType { get; set; }
        public Address address { get; set; }
        public Coordinates coordinates { get; set; }
    }

    public class StartDateTime
    {
        public DateTime dateTime { get; set; }
        public string timeZone { get; set; }
    }

    public class Value
    {
        public string id { get; set; }
        public string selfServiceAppointmentId { get; set; }
        public string additionalInformation { get; set; }
        public bool isLocationOnline { get; set; }
        public string joinWebUrl { get; set; }
        public string customerTimeZone { get; set; }
        public string serviceId { get; set; }
        public string serviceName { get; set; }
        public string duration { get; set; }
        public string preBuffer { get; set; }
        public string postBuffer { get; set; }
        public string priceType { get; set; }
        public double price { get; set; }
        public string serviceNotes { get; set; }
        public bool optOutOfCustomerEmail { get; set; }
        public List<string> staffMemberIds { get; set; }
        public bool smsNotificationsEnabled { get; set; }
        public string anonymousJoinWebUrl { get; set; }
        public int maximumAttendeesCount { get; set; }
        public int filledAttendeesCount { get; set; }
        public StartDateTime startDateTime { get; set; }
        public EndDateTime endDateTime { get; set; }
        public ServiceLocation serviceLocation { get; set; }
        public List<object> reminders { get; set; }
        public List<Customer> customers { get; set; }
    }
}
