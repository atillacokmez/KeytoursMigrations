//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MigrationForm
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log_ServicePassenger
    {
        public int Log_Service_Passenger_ID { get; set; }
        public int Service_Passenger_ID { get; set; }
        public Nullable<int> Log_Ref_ID { get; set; }
        public Nullable<int> Log_Service_ID { get; set; }
        public int Service_ID { get; set; }
        public Nullable<int> ServicePassenger_PassengerID { get; set; }
        public Nullable<int> Quote_Passenger_ID { get; set; }
        public string ServicePassenger_FirstName { get; set; }
        public string ServicePassenger_LastName { get; set; }
        public string ServicePassenger_RoomType { get; set; }
        public string ServicePassenger_RoomNumber { get; set; }
        public Nullable<int> ServicePassenger_LandOnRequest { get; set; }
        public Nullable<int> ServicePassenger_FlightOnRequest { get; set; }
        public Nullable<int> Gateway_City_ID { get; set; }
        public Nullable<decimal> ServicePassenger_GatewayFlightPrice { get; set; }
        public Nullable<int> Connecting_City_ID { get; set; }
        public Nullable<decimal> ServicePassenger_ConnectingFlightPrice { get; set; }
        public Nullable<int> Cruise_Cabin_ID { get; set; }
        public Nullable<decimal> ServicePassenger_CruiseCabinUpgradePrice { get; set; }
        public string ServicePassenger_FlightNoOrCruiseLineIn { get; set; }
        public Nullable<System.DateTime> ServicePassenger_TransferInDate { get; set; }
        public Nullable<bool> ServicePassenger_IsRowDeleted { get; set; }
        public string ServicePassenger_FlightNoOrCruiseLineOut { get; set; }
        public Nullable<System.DateTime> ServicePassenger_TransferOutDate { get; set; }
        public Nullable<int> ServicePassenger_CruiseOnRequest { get; set; }
        public double ServicePassenger_PriceReduction { get; set; }
        public double ServicePassenger_HotelPromotion { get; set; }
        public string ServicePassenger_DoubleType { get; set; }
        public Nullable<int> ServicePassenger_NonSmoking { get; set; }
        public Nullable<decimal> ServicePassenger_GatewayNet { get; set; }
        public Nullable<int> ServicePassenger_CurIdGate { get; set; }
        public Nullable<decimal> ServicePassenger_ConnectNet { get; set; }
        public Nullable<int> ServicePassenger_CurIdConnet { get; set; }
        public Nullable<double> ServicePassenger_PricePerPerson { get; set; }
        public Nullable<bool> flagupdate { get; set; }
        public Nullable<double> ServicePassenger_PerPerson_Cancellationfee { get; set; }
        public Nullable<double> ServicePassenger_PerPerson_Revisionfee { get; set; }
        public string ServicePassenger_MiddleName { get; set; }
        public string TF_ProcessDetailsOptions { get; set; }
        public Nullable<decimal> TF_ServicePassengerAddOnNet { get; set; }
        public Nullable<decimal> TF_ServicePassengerAddOnGross { get; set; }
        public string ViatorAgeBand { get; set; }
    }
}