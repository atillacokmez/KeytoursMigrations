
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationForm
{
    public class TravelerMigration
    {
		// tablolardaki tüm telefonların validate edilip migrate edilmesi, kesin değil
		// Phonecountrycode ve emergencycontactcountrycode eklendi. phone bunlara göre düzenlenmeli.

		// servicehotelroom yeni kolon baseprovidercode

		public static void MigrateQuotePassenger()
        {

            using (KeyConNew saasDb = new KeyConNew())
            {
                var quotePassListCount = saasDb.QuotePassenger_old.Where(x => !x.QuotePassenger_IsRowDeleted)
                    .OrderByDescending(x => x.Quote_Passenger_ID).Count();

                int iterationCount = quotePassListCount / 500;
                iterationCount++;

                for (int iteration = 0; iteration < iterationCount; iteration++)
                {
                    Console.WriteLine("iteration " + iteration);

                    var quotePassList = saasDb.QuotePassenger_old.Where(x => !x.QuotePassenger_IsRowDeleted)
                    .OrderByDescending(x => x.Quote_Passenger_ID)
                    .Skip(iteration * 500).Take(500)
                    .ToList();

                    foreach (var quotePass in quotePassList)
                    {
                        Console.WriteLine(quotePass.Quote_Passenger_ID);

                        QuotePassenger2 newQuotePass = new QuotePassenger2();
                        newQuotePass.QuotePassengerID = quotePass.Quote_Passenger_ID;
                        newQuotePass.ParentQuotePassengerID = quotePass.Parent_Quote_Passenger_ID;
                        newQuotePass.RefID = quotePass.Ref_ID;
                        newQuotePass.FirstName = quotePass.Passenger_FirstName;
                        newQuotePass.LastName = quotePass.Passenger_LastName;
                        newQuotePass.Title = quotePass.Passenger_Gender;
                        newQuotePass.SpecialRequest = quotePass.Passenger_SpecialRequest;
                        newQuotePass.TravelInsurance = quotePass.Passenger_TravelInsurance;
                        newQuotePass.Reduction = quotePass.Passenger_Reduction;
                        newQuotePass.RoomRequirement = quotePass.RoomRequirement;
                        newQuotePass.Smoking = quotePass.Smoking;
                        newQuotePass.Phone = quotePass.Phone;
                        newQuotePass.EmergencyContact = quotePass.EmergencyContact;
                        newQuotePass.VegeterianHealtRequirement = quotePass.VegeterianHealtRequirement;
                        newQuotePass.MemberID = quotePass.Web_User_ID;
                        newQuotePass.InsuranceDate = quotePass.Passenger_InsuranceDate;
                        newQuotePass.IsInsuranceConfirmed = quotePass.isInsuranceConfirmed;
                        newQuotePass.EmergencyContactNo = quotePass.EmergencyContactNo;
                        newQuotePass.PassportNo = quotePass.Passenger_PassPortNo;
                        DateTime dateTime;

                        if (!string.IsNullOrEmpty(quotePass.Passenger_PassPortIExpirationDate) && DateTime.TryParse(quotePass.Passenger_PassPortIExpirationDate, out dateTime))
                        {
                            newQuotePass.PassportExpirationDate = dateTime;
                        }
                        if (!string.IsNullOrEmpty(quotePass.Passenger_PassPortIssueDate) && DateTime.TryParse(quotePass.Passenger_PassPortIssueDate, out dateTime))
                        {
                            newQuotePass.PassportIssueDate = dateTime;
                        }

                        newQuotePass.BirthDate = quotePass.Passenger_BirthDate;
                        newQuotePass.Nationality = quotePass.Passenger_Citizenship;
                        newQuotePass.Email = quotePass.Passenger_Email;
                        newQuotePass.AddressLine1 = quotePass.Passenger_Address1;
                        newQuotePass.AddressLine2 = quotePass.Passenger_Address2;
                        newQuotePass.City = quotePass.Passenger_City;
                        newQuotePass.State = quotePass.Passenger_State;
                        newQuotePass.ZipCode = quotePass.Passenger_ZipCode;
                        newQuotePass.Country = quotePass.Passenger_Country;
                        newQuotePass.Province = quotePass.Passenger_Province;
                        newQuotePass.QuoteReduction = quotePass.Passenger_QuoteReduction;
                        newQuotePass.QuotePerPerson = quotePass.Passenger_QuotePerperson;
                        newQuotePass.IsChild = quotePass.Passenger_isChild;
                        newQuotePass.UpdateDate = quotePass.Passenger_Update_Date;
                        newQuotePass.IsContactPassenger = quotePass.isContactPassenger;
                        newQuotePass.MiddleName = quotePass.Passenger_MiddleName;
                        newQuotePass.MilageNumber = quotePass.MilageNumber;
                        newQuotePass.AirlineSeatPreferences = quotePass.AirlineSeatPreferences;
                        newQuotePass.IsSendNewsletter = quotePass.isSendNewsletter;
                        newQuotePass.IsLeedTraveler = quotePass.isLeedTraveler;
                        newQuotePass.Deposit = quotePass.Passenger_Deposit;
                        newQuotePass.FrequentFlyerProgramName = quotePass.FrequentFlyerProgramName;
                        newQuotePass.FrequentFlyerProgramNumber = quotePass.FrequentFlyerProgramNumber;
                        newQuotePass.KnownTravelerNumber = quotePass.KnownTravelerNumber;
                        newQuotePass.RedressNumber = quotePass.RedressNumber;
                        newQuotePass.CancelationPrice = quotePass.CancelationPrice;
                        newQuotePass.ReductionPrice = quotePass.ReductionPrice;
                        newQuotePass.ReductionDesc = quotePass.ReductionDesc;
                        newQuotePass.ShippingID = quotePass.Shipping_ID;
                        //newQuotePass.RedressIssuanceCountry = quotePass.RedressIssuanceCountry;
                        //newQuotePass.RedressValidityCountry = quotePass.RedressValidityCountry;
                        //newQuotePass.PassportIssuanceCountry = quotePass.PassportIssuanceCountry;
                        //newQuotePass.PassportIssuanceCity = quotePass.PassportIssuanceCity;
                        saasDb.QuotePassenger2.Add(newQuotePass);

                        //if (i % 1000 == 0)
                        //{
                        //    saasDb.SaveChanges();
                        //}
                    }
                    saasDb.SaveChanges();
                }               
                
            }
        }


		//service passengerda priceperperson kolonlarının hepsi boş kontrol et
        public static void MigrateServicePassenger()
        {
            using (KeyConNew saasDb = new KeyConNew())
            {
                List<int> passengerlessServiceList = new List<int>();
                List<int> roomlessServiceList = new List<int>();
                List<int> roomlessAdditionalServiceList = new List<int>();
                List<int> unmatchPaxCountServiceList = new List<int>();

                var serviceCount = saasDb.Service2
                    .Where(x => x.ServiceID < 182832)
                    .Count();

                int iterationCount = serviceCount / 500;
                iterationCount++;

                for (int iteration = 0; iteration < iterationCount; iteration++)
                {
                    Console.WriteLine("iteration " + iteration);

                    var serviceList = saasDb.Service2
                        .Where(x => x.ServiceID < 182832) //// <<<<<<------- used for test
                        .OrderByDescending(x => x.ServiceID)
                        .Skip(iteration * 500).Take(500)
                        .ToList();

                    foreach (var service in serviceList)
                    {
                        Console.WriteLine("ServiceID: " + service.ServiceID);

                        //if (service.ServiceID == 584594) 
                        //{ 
                        //}

                        var servicePassList = saasDb.ServicePassenger_old.Where(s => s.Service_ID == service.ServiceID).ToList();      

                        if((service.ServiceTypeID == 4 || service.ServiceTypeID == 3) && service.IsAdditionalService == false && servicePassList.Count > 0)
                        {
                            List<ServicePassenger_old> _servicePassList = new List<ServicePassenger_old>();

                            var hotelRoomList = saasDb.ServiceHotelRoom2.Where(s => s.ServiceID == service.ServiceID).ToList();

                            var singleRoom = hotelRoomList.Where(s => s.HotelRoomTypeID == 1).ToList();
                            var doubleRoom = hotelRoomList.Where(s => s.HotelRoomTypeID == 2).ToList();
                            var tripleRoom = hotelRoomList.Where(s => s.HotelRoomTypeID == 4).ToList();
                            var quadRoom = hotelRoomList.Where(s => s.HotelRoomTypeID == 5).ToList();

                            var roomPassengerCount = (singleRoom.Count * 1) + (doubleRoom.Count * 2) + (tripleRoom.Count * 3) + (quadRoom.Count * 4);

                            if (servicePassList.Count() == roomPassengerCount)
                            {
                                var singlePassengers = servicePassList.Where(s => s.ServicePassenger_RoomType?.ToLower() == "single" && s.ServicePassenger_RoomNumber.HasValue).ToList();
                                var doublePassengers = servicePassList.Where(s => s.ServicePassenger_RoomType?.ToLower() == "double" && s.ServicePassenger_RoomNumber.HasValue).ToList();
                                var triplePassengers = servicePassList.Where(s => s.ServicePassenger_RoomType?.ToLower() == "triple" && s.ServicePassenger_RoomNumber.HasValue).ToList();
                                var quadPassengers = servicePassList.Where(s => s.ServicePassenger_RoomType?.ToLower() == "quad" && s.ServicePassenger_RoomNumber.HasValue).ToList();

                                if((singleRoom.Count * 1) != singlePassengers.Count ||         // fixes passengers room type and number 
                                    (doubleRoom.Count * 2) != doublePassengers.Count ||
                                    (tripleRoom.Count * 3) != triplePassengers.Count ||
                                    (quadRoom.Count * 4) != quadPassengers.Count)
                                {
                                    service.hasMismatchedRoomTypes = true;

                                    saasDb.Service2.AddOrUpdate(service);

                                    int srn = 1, dc = 1, drn = 1, tc = 1, trn = 1, qc = 1, qrn = 1;
                                    for (int i = 0; i < servicePassList.Count(); i++)
                                    {
                                        if (i < singleRoom.Count * 1)
                                        {
                                            servicePassList[i].ServicePassenger_RoomType = "SINGLE";
                                            servicePassList[i].ServicePassenger_RoomNumber = srn;
                                            srn++;
                                        }
                                        else if (i < (singleRoom.Count * 1) + (doubleRoom.Count * 2))
                                        {
                                            servicePassList[i].ServicePassenger_RoomType = "DOUBLE";
                                            servicePassList[i].ServicePassenger_RoomNumber = drn;
                                            if (dc % 2 == 0)
                                                drn++;
                                            dc++;
                                        }
                                        else if (i < (singleRoom.Count * 1) + (doubleRoom.Count * 2) + (tripleRoom.Count * 3))
                                        {
                                            servicePassList[i].ServicePassenger_RoomType = "TRIPLE";
                                            servicePassList[i].ServicePassenger_RoomNumber = trn;
                                            if (tc % 3 == 0)
                                                trn++;
                                            tc++;
                                        }
                                        else if (i < (singleRoom.Count * 1) + (doubleRoom.Count * 2) + (tripleRoom.Count * 3) + (quadRoom.Count * 4))
                                        {
                                            servicePassList[i].ServicePassenger_RoomType = "QUAD";
                                            servicePassList[i].ServicePassenger_RoomNumber = qrn;
                                            if (qc % 4 == 0)
                                                qrn++;
                                            qc++;
                                        }
                                    }
                                }


                                for (int i = 1; i <= singleRoom.Count; i++)
                                {
                                    int roomIndex = i - 1;
                                    var singlePassenger = servicePassList.Where(s => s.ServicePassenger_RoomType.ToLower() == "single" && s.ServicePassenger_RoomNumber == i).FirstOrDefault();

                                    singlePassenger.ServicePassenger_PassengerID = singleRoom[roomIndex].ServiceHotelRoomID;

                                    _servicePassList.Add(singlePassenger);
                                }
                                for (int i = 1; i <= doubleRoom.Count; i++)
                                {
                                    int roomIndex = i - 1;
                                    var doublePassengerList = servicePassList.Where(s => s.ServicePassenger_RoomType.ToLower() == "double" && s.ServicePassenger_RoomNumber == i).ToList();

                                    doublePassengerList.ForEach(d => d.ServicePassenger_PassengerID = doubleRoom[roomIndex].ServiceHotelRoomID);

                                    _servicePassList.AddRange(doublePassengerList);
                                }
                                for (int i = 1; i <= tripleRoom.Count; i++)
                                {
                                    int roomIndex = i - 1;
                                    var triplePassengerList = servicePassList.Where(s => s.ServicePassenger_RoomType.ToLower() == "triple" && s.ServicePassenger_RoomNumber == i).ToList();

                                    triplePassengerList.ForEach(d => d.ServicePassenger_PassengerID = tripleRoom[roomIndex].ServiceHotelRoomID);

                                    _servicePassList.AddRange(triplePassengerList);
                                }
                                for (int i = 1; i <= quadRoom.Count; i++)
                                {
                                    int roomIndex = i - 1;
                                    var quadPassengerList = servicePassList.Where(s => s.ServicePassenger_RoomType.ToLower() == "quad" && s.ServicePassenger_RoomNumber == i).ToList();

                                    quadPassengerList.ForEach(d => d.ServicePassenger_PassengerID = quadRoom[roomIndex].ServiceHotelRoomID);

                                    _servicePassList.AddRange(quadPassengerList);
                                }

                                foreach (var servicePass in _servicePassList)
                                {
                                    Console.WriteLine("ServicePassengerID: " + servicePass.Service_Passenger_ID);

                                    ServicePassenger2 newServicePass = new ServicePassenger2();
                                    newServicePass.ServiceHotelRoomID = servicePass.ServicePassenger_PassengerID;
                                    newServicePass.QuotePassengerID = servicePass.Quote_Passenger_ID;
                                    newServicePass.ServicePassengerID = servicePass.Service_Passenger_ID;
                                    newServicePass.ServiceID = servicePass.Service_ID;
                                    newServicePass.RoomType = servicePass.ServicePassenger_RoomType;
                                    newServicePass.RoomNumber = servicePass.ServicePassenger_RoomNumber;
                                    newServicePass.CruiseCabinID = servicePass.Cruise_Cabin_ID;
                                    newServicePass.CruiseCabinUpgradePrice = servicePass.ServicePassenger_CruiseCabinUpgradePrice;
                                    newServicePass.FlightNoOrCruiseLineIn = servicePass.ServicePassenger_FlightNoOrCruiseLineIn;
                                    newServicePass.FlightNoOrCruiseLineOut = servicePass.ServicePassenger_FlightNoOrCruiseLineOut;
                                    newServicePass.CruiseOnRequest = servicePass.ServicePassenger_CruiseOnRequest;
                                    newServicePass.PricePerPerson = servicePass.ServicePassenger_PricePerPerson;
                                    newServicePass.ServiceOptions = servicePass.TF_ProcessDetailsOptions;
                                    newServicePass.ServiceOptionsAddOnNet = servicePass.TF_ServicePassengerAddOnNet;
                                    newServicePass.ServiceOptionsAddOnGross = servicePass.TF_ServicePassengerAddOnGross;
                                    newServicePass.AgeBand = servicePass.ViatorAgeBand;
                                    saasDb.ServicePassenger2.Add(newServicePass);
                                }

                            }
                            else
                            {
                                if (hotelRoomList.Count == 0)
                                    roomlessServiceList.Add(service.ServiceID);
                                else
                                    unmatchPaxCountServiceList.Add(service.ServiceID);

                                foreach (var servicePass in servicePassList)
                                {
                                    Console.WriteLine("ServicePassengerID: " + servicePass.Service_Passenger_ID);

                                    ServicePassenger2 newServicePass = new ServicePassenger2();
                                    newServicePass.QuotePassengerID = servicePass.Quote_Passenger_ID;
                                    newServicePass.ServicePassengerID = servicePass.Service_Passenger_ID;
                                    newServicePass.ServiceID = servicePass.Service_ID;
                                    newServicePass.RoomType = servicePass.ServicePassenger_RoomType;
                                    newServicePass.RoomNumber = servicePass.ServicePassenger_RoomNumber;
                                    newServicePass.CruiseCabinID = servicePass.Cruise_Cabin_ID;
                                    newServicePass.CruiseCabinUpgradePrice = servicePass.ServicePassenger_CruiseCabinUpgradePrice;
                                    newServicePass.FlightNoOrCruiseLineIn = servicePass.ServicePassenger_FlightNoOrCruiseLineIn;
                                    newServicePass.FlightNoOrCruiseLineOut = servicePass.ServicePassenger_FlightNoOrCruiseLineOut;
                                    newServicePass.CruiseOnRequest = servicePass.ServicePassenger_CruiseOnRequest;
                                    newServicePass.PricePerPerson = servicePass.ServicePassenger_PricePerPerson;
                                    newServicePass.ServiceOptions = servicePass.TF_ProcessDetailsOptions;
                                    newServicePass.ServiceOptionsAddOnNet = servicePass.TF_ServicePassengerAddOnNet;
                                    newServicePass.ServiceOptionsAddOnGross = servicePass.TF_ServicePassengerAddOnGross;
                                    newServicePass.AgeBand = servicePass.ViatorAgeBand;
                                    saasDb.ServicePassenger2.Add(newServicePass);
                                }

                            }
                        }
                        else if ((service.ServiceTypeID == 4 || service.ServiceTypeID == 3) && service.IsAdditionalService && servicePassList.Count > 0)
                        {
                            var additionalHotelRoom = saasDb.ServiceHotelRoom2.Where(s => s.ServiceID == service.ServiceID).FirstOrDefault();

                            if (additionalHotelRoom == null)
                            {
                                roomlessAdditionalServiceList.Add(service.ServiceID);
                            }

                            foreach (var servicePass in servicePassList)
                            {
                                Console.WriteLine("ServicePassengerID: " + servicePass.Service_Passenger_ID);

                                ServicePassenger2 newServicePass = new ServicePassenger2();
                                newServicePass.ServiceHotelRoomID = additionalHotelRoom?.ServiceHotelRoomID;
                                newServicePass.QuotePassengerID = servicePass.Quote_Passenger_ID;
                                newServicePass.ServicePassengerID = servicePass.Service_Passenger_ID;
                                newServicePass.ServiceID = servicePass.Service_ID;
                                newServicePass.RoomType = servicePass.ServicePassenger_RoomType;
                                newServicePass.RoomNumber = servicePass.ServicePassenger_RoomNumber;
                                newServicePass.CruiseCabinID = servicePass.Cruise_Cabin_ID;
                                newServicePass.CruiseCabinUpgradePrice = servicePass.ServicePassenger_CruiseCabinUpgradePrice;
                                newServicePass.FlightNoOrCruiseLineIn = servicePass.ServicePassenger_FlightNoOrCruiseLineIn;
                                newServicePass.FlightNoOrCruiseLineOut = servicePass.ServicePassenger_FlightNoOrCruiseLineOut;
                                newServicePass.CruiseOnRequest = servicePass.ServicePassenger_CruiseOnRequest;
                                newServicePass.PricePerPerson = servicePass.ServicePassenger_PricePerPerson;
                                newServicePass.ServiceOptions = servicePass.TF_ProcessDetailsOptions;
                                newServicePass.ServiceOptionsAddOnNet = servicePass.TF_ServicePassengerAddOnNet;
                                newServicePass.ServiceOptionsAddOnGross = servicePass.TF_ServicePassengerAddOnGross;
                                newServicePass.AgeBand = servicePass.ViatorAgeBand;
                                saasDb.ServicePassenger2.Add(newServicePass);
                            }

                            
                        }
                        else if (servicePassList.Count > 0)
                        {

                            foreach (var servicePass in servicePassList)
                            {
                                Console.WriteLine("ServicePassengerID: " + servicePass.Service_Passenger_ID);

                                ServicePassenger2 newServicePass = new ServicePassenger2();
                                newServicePass.QuotePassengerID = servicePass.Quote_Passenger_ID;
                                newServicePass.ServicePassengerID = servicePass.Service_Passenger_ID;
                                newServicePass.ServiceID = servicePass.Service_ID;
                                newServicePass.RoomType = servicePass.ServicePassenger_RoomType;
                                newServicePass.RoomNumber = servicePass.ServicePassenger_RoomNumber;
                                newServicePass.CruiseCabinID = servicePass.Cruise_Cabin_ID;
                                newServicePass.CruiseCabinUpgradePrice = servicePass.ServicePassenger_CruiseCabinUpgradePrice;
                                newServicePass.FlightNoOrCruiseLineIn = servicePass.ServicePassenger_FlightNoOrCruiseLineIn;
                                newServicePass.FlightNoOrCruiseLineOut = servicePass.ServicePassenger_FlightNoOrCruiseLineOut;
                                newServicePass.CruiseOnRequest = servicePass.ServicePassenger_CruiseOnRequest;
                                newServicePass.PricePerPerson = servicePass.ServicePassenger_PricePerPerson;
                                newServicePass.ServiceOptions = servicePass.TF_ProcessDetailsOptions;
                                newServicePass.ServiceOptionsAddOnNet = servicePass.TF_ServicePassengerAddOnNet;
                                newServicePass.ServiceOptionsAddOnGross = servicePass.TF_ServicePassengerAddOnGross;
                                newServicePass.AgeBand = servicePass.ViatorAgeBand;
                                saasDb.ServicePassenger2.Add(newServicePass);
                            }
                        }
                        else
                        {
                            passengerlessServiceList.Add(service.ServiceID);
                        }               

                    }
                    Console.WriteLine("passengerlessServiceList");
                    Console.WriteLine(string.Join(", ", passengerlessServiceList));

                    Console.WriteLine("unmatchPaxCountServiceList");
                    Console.WriteLine(string.Join(", ", unmatchPaxCountServiceList));

                    Console.WriteLine("roomlessServiceList");
                    Console.WriteLine(string.Join(", ", roomlessServiceList));

                    Console.WriteLine("roomlessAdditionalServiceList");
                    Console.WriteLine(string.Join(", ", roomlessAdditionalServiceList));

                    saasDb.SaveChanges();

                }


            }



        }

    }
}
