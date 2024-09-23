using MigrationForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MigrationForm
{
    public class BookingAgentMigration
    {
        public void MigrateAgent()
        {            
            using (KeyConNew db = new KeyConNew())
            {
                var BookingAgentList = db.BookingAgents.ToList();

                foreach (var agent in BookingAgentList.OrderBy(b => b.Booking_Agent_ID))
                {
                    var memberAddressList = db.MemberAddresses.Where(m => m.MemberID == agent.Booking_Agent_ID).ToList();
                    db.MemberAddresses.RemoveRange(memberAddressList);

                    var companyMemberList = db.CompanyMembers.Where(c => c.MemberID == agent.Booking_Agent_ID).ToList();
                    db.CompanyMembers.RemoveRange(companyMemberList);

                    var memberPhoneList = db.MemberPhones.Where(m => m.MemberID == agent.Booking_Agent_ID).ToList();
                    db.MemberPhones.RemoveRange(memberPhoneList);

                    var memberExist = db.Members.Where(m => m.MemberID == agent.Booking_Agent_ID).FirstOrDefault();
                    if (memberExist != null) 
                        db.Members.Remove(memberExist);

                    var member = db.Members.Add(new Member
                    {
                        MemberID = agent.Booking_Agent_ID,
                        ApiUserId = 1,
                        FirstName = agent.BookingAgent_FirstName,
                        LastName = String.IsNullOrEmpty(agent.BookingAgent_LastName) ? "" :agent.BookingAgent_LastName,
                        Email = String.IsNullOrEmpty(agent.BookingAgent_Email) ? "" : agent.BookingAgent_Email,
                        Password = String.IsNullOrEmpty(agent.BookingAgent_Password) ? "" : agent.BookingAgent_Password,
                        IsActive = agent.BookingAgentIsActive,
                        isSendNewsLetter = null,
                        FacebookID = null,
                        GoogleID = null,
                        IsDeleted = false
                    });
                    db.SaveChanges();

                    if (member.MemberID > 0)
                    {
                        db.CompanyMembers.Add(new CompanyMember
                        {
                            CompanyID = 29588,
                            MemberID = member.MemberID,
                            MemberTypeID = 1
                        });

                        db.SaveChanges();

                        if (!String.IsNullOrEmpty(agent.BookingAgent_PhoneNumber))
                        {
                            var phone = Form1.RemoveSpecialCharacters(agent.BookingAgent_PhoneNumber);

                            string countryCode = null;
                            int phoneType;

                            if (phone.StartsWith("9"))
                            {
                                countryCode = "+90";
                                phone = phone.Remove(0, 2);
                                phoneType = 3;
                            }
                            else
                            {
                                countryCode = "+1";
                                phoneType = 2;
                            }

                            var _phone = db.Phones.Add(new Phone
                            {
                                CountryCode = countryCode,
                                Number = phone,
                                PhoneTypeID = phoneType
                            });
                            db.SaveChanges();
                            if (_phone.PhoneID > 0)
                            {
                                db.MemberPhones.Add(new MemberPhone
                                {
                                    MemberID = member.MemberID,
                                    PhoneID = _phone.PhoneID,
                                    Extention = agent.BookingAgent_PhoneExtension != null ? Convert.ToString(agent.BookingAgent_PhoneExtension) : null,
                                });
                            }
                            db.SaveChanges();
                        }
                    }
                }
            }  
             
        }

    }
}
