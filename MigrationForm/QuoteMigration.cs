using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationForm
{
    public class QuoteMigration
    {
        public void MigrateQuoteTable()
        {
            int i = 0;
            using (KeyConNew saasDb = new KeyConNew())
            {                
                var quoteList = saasDb.Quote_Old/*.Where(x => x.Crt_Date.HasValue && x.Start.HasValue && x.End.HasValue && x.Start > new DateTime(2015, 1, 1) && x.Ref_ID == 107048)*/.ToList();
                int sysBookingAgentId = saasDb.BookingAgents.FirstOrDefault(x => x.BookingAgent_FirstName.ToLower().StartsWith("sysadmin")).Booking_Agent_ID;
                int fitTypeId = saasDb.QuoteTypes.FirstOrDefault(x => x.Name.StartsWith("F")).ID;
                int groupTypeId = saasDb.QuoteTypes.FirstOrDefault(x => x.Name.StartsWith("G")).ID;

                //var sasQuote =  saasDb.Quote.ToList();
                //saasDb.Quote.RemoveRange(sasQuote);

                //saasDb.SaveChanges();

                foreach (var quote in quoteList.OrderBy(q => q.Ref_ID))
                {
                    i++;
                    Quote2 newQuote = new Quote2();
                    newQuote.RefID = quote.Ref_ID;
                    newQuote.CompanyID = quote.Cust_ID.HasValue ? quote.Cust_ID.Value : 0;
                    newQuote.MemberID = quote.Web_User_ID.HasValue ? quote.Web_User_ID.Value : 0;
                    newQuote.BookingAgentID = quote.BookingAgent_ID.HasValue ? quote.BookingAgent_ID.Value : sysBookingAgentId;
                    newQuote.ConsumerID =  null;
                    newQuote.QuoteTypeID = !string.IsNullOrEmpty(quote.QuoteType) ? (quote.QuoteType.ToLower().Equals("g") ? groupTypeId : fitTypeId) : fitTypeId;
                    newQuote.ShippingID = Convert.ToInt32(quote.Shipping_ID);
                    newQuote.StartDateTime = quote.Start;
                    newQuote.EndDateTime = quote.End;
                    newQuote.Pax = quote.Pax ?? 0;
                    newQuote.CreationDate = quote.Crt_Date ?? quote.Start ?? DateTime.Now;
                    newQuote.StatusID = quote.Status ?? 0;
                    newQuote.ModificationDate = quote.Mdf_Date;
                    newQuote.ModifiedUserID = quote.Mdf_By_Booking_Agent_ID;
                    newQuote.CreatedUserID = quote.BookingAgent_ID ?? quote.Web_User_ID ?? 0;
                    newQuote.QuoteName = quote.Quote_Name;
                    newQuote.IsDeleted = quote.Quote_IsRowDeleted;
                    newQuote.TotalServicePrice = quote.Quote_TripCost.HasValue ? Convert.ToDecimal(quote.Quote_TripCost.Value) : (decimal?)null;
                    newQuote.DepositPrice = quote.Quote_TripDeposit.HasValue ? Convert.ToDecimal(quote.Quote_TripDeposit.Value) : (decimal?)null;
                    newQuote.DepositPaymentDueDate = quote.Quote_DepositDueDate;
                    newQuote.FullPaymentDueDate = quote.Quote_FullDueDate;
                    newQuote.InternalNotes = quote.Quote_InternalNotes;
                    newQuote.SupplierMemo = quote.Quote_SupplierMemo;
                    newQuote.UserNotes = quote.User_Notes;
                    newQuote.PaymentRuleProfileID = 1;
                    //newQuote.DepositTypeID = quote.Deposit_Updated.HasValue ? quote.Deposit_Updated.Value : 1;
                    newQuote.TripPrice = quote.TripCost;
                    newQuote.InsuranceAmount = quote.InsuranceAmount.HasValue ? Convert.ToDecimal(quote.InsuranceAmount.Value) : (decimal?)null;
                    newQuote.ServiceCommissionPrice = quote.CommissionService.HasValue ? Convert.ToDecimal(quote.CommissionService.Value) : (decimal?)null;
                    newQuote.InsuranceCommissionPrice = quote.CommissionInsurance.HasValue ? Convert.ToDecimal(quote.CommissionInsurance.Value) : (decimal?)null;
                    newQuote.IsInsuranceConfirmed = quote.InsuranceConfirm ?? false;
                    newQuote.IsInsurancePaid = quote.InsurancePaid ?? false;
                    newQuote.InsuranceConfirmDate = quote.InsConfirmDate;
                    newQuote.IsCommissionAppliedToPayment = quote.CommtoPayment.HasValue ? quote.CommtoPayment.Value : false;
                    newQuote.CommissionAppliedToPaymentDate = quote.CommtoPaymentDate;
                    newQuote.AddOnCommissionPrice = quote.AddOnCommission;
                    newQuote.StatusChangeDate = quote.StatusChangeDate;
                    newQuote.CancellationDate = quote.cancellationsdate;
                    newQuote.CancellationPrice = quote.cancellationsamount.HasValue ? Convert.ToDecimal(quote.cancellationsamount.Value) : (decimal?)null;
                    newQuote.CancellationDetail = quote.cancellationamountDesc;
                    newQuote.RevisionPrice = quote.revisionAmount.HasValue ? Convert.ToDecimal(quote.revisionAmount.Value) : (decimal?)null; ;
                    newQuote.RevisionDetail = quote.revisionAmountDesc;
                    newQuote.PromotionCode = quote.Quote_PromotionCode;
                    newQuote.IsCommissionPaymentDone = quote.CommPayDone.HasValue ? (quote.CommPayDone == 1) : false;
                    newQuote.TotalFlightPrice = quote.TotalAirPrice.HasValue ? Convert.ToDecimal(quote.TotalAirPrice.Value) : (decimal?)null;
                    newQuote.IsDisplayNetPriceToAgents = quote.isShowNetPrice ?? false;
                    newQuote.IsReferral = quote.isReferral;
                    newQuote.ReferralCompanyID = quote.referralCustID;
                    newQuote.IsPointApplied = quote.PointApplied;
                    newQuote.IsSentPostTrip = quote.isSentPostTrip;
                    newQuote.IsSentPaymentFull = quote.isSentPaymentFull;
                    newQuote.IsSentPaymentDeposit = quote.isSentPaymentDeposit;
                    newQuote.IsSentTravelDocument = quote.isSentTravelDocument;
                    newQuote.PromotionCommissionAdd = quote.PromCommissionAdd;
                    newQuote.IsShowPriceOnTripDetail = quote.isShowPriceOnTripDetail ?? true;
                    newQuote.IsShowCommisionOnTripDetail = quote.isShowCommisionOnTripDetail ?? true;
                    newQuote.IsBuyOnMiniWebSiteDisabled = quote.isBuyOnMiniWebSiteDisabled;
                    saasDb.Quote2.Add(newQuote);
                    if (i % 1000 == 0)
                    {
                        saasDb.SaveChanges();
                    }
                }
                saasDb.SaveChanges();
                
            }
        }


        public void UpdateStatusChangeQuote_oldToQuote()
        {
            using (KeyConNew saasDb = new KeyConNew())
            {
                var quotecount = saasDb.Quotes.Where(q => q.RefID > 102010).Count();
                //var quoteList = saasDb.Quote.ToList();
                int count = 0;

                int iterationCount = quotecount / 500;
                iterationCount++;

                for (int iteration = 0; iteration < iterationCount; iteration++)
                {
                    var quoteList = saasDb.Quotes.Where(q => q.RefID > 102010).ToList().Skip(iteration * 500).Take(500);

                    foreach (var quote in quoteList)
                    {
                        count++;

                        var oldQuote = saasDb.Quote_Old.Where(q => q.Ref_ID == quote.RefID).FirstOrDefault();
                        if (oldQuote != null)
                        {
                            quote.StatusChangeDate = oldQuote.StatusChangeDate;
                            Console.WriteLine("Count:" + count + " RefID: " + quote.RefID);
                            saasDb.Quotes.AddOrUpdate(quote);
                        }
                        else
                        {
                            Console.WriteLine("Missing RefID: " + quote.RefID);
                        }
                    }
                    saasDb.SaveChanges();
                }
                                
            }
        }
    }
}
