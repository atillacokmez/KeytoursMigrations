using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MigrationForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {		

			using (KeyConNew db = new KeyConNew())
			{
				var customer = db.Customs.SqlQuery(@"SELECT DISTINCT 
                         TOP (100) PERCENT dbo.Custom.*
                        FROM            dbo.Custom INNER JOIN
                                                 dbo.WebUser ON dbo.Custom.Cust_ID = dbo.WebUser.Cust_ID
                        WHERE        (dbo.Custom.Clnt_Type <> 'Individual') AND (dbo.Custom.isMigrated = 0) AND (dbo.Custom.Company IS NOT NULL)
                        ORDER BY dbo.Custom.Cust_ID DESC")
											.ToList();






				foreach (var iCustomer in customer)
				{



					Company oCompany = new Company();

					oCompany.CompanyID = iCustomer.Cust_ID;
					oCompany.ApiUserId = 1;
					oCompany.Name = iCustomer.Company;
					oCompany.ContactPerson = iCustomer.First + " " + iCustomer.Last;
					oCompany.ContactPersonTitle = iCustomer.Title;
					oCompany.CreateDate = iCustomer.Created_Da ?? DateTime.Now;
					oCompany.Email = iCustomer.E_Mail;
					oCompany.WebSite = iCustomer.WebSite;
					oCompany.LogoUrl = iCustomer.CustomLogo;
					oCompany.CompanyAccountTypeID = 1;
					oCompany.IsActive = true;



					//Min Comm
					if (iCustomer.MinTotalCommission.HasValue)
					{
						oCompany.MinimumTotalCommissionRate = Convert.ToInt32(iCustomer.MinTotalCommission);
					}

					oCompany.MinimumTotalCommissionActiveDate = iCustomer.MinTotalCommissionDate;



					///SawUs
					int idParser = 0;
					if (string.IsNullOrEmpty(iCustomer.Saw_Us))
					{
						oCompany.SawUsID = db.SawUs.FirstOrDefault(x => x.SawUs_Desc == "Unknown").SawUs_ID;
					}
					else if (int.TryParse(iCustomer.Saw_Us, out idParser))
					{
						var su = db.SawUs.Where(x => x.SawUs_ID == idParser).FirstOrDefault();
						if (su == null)
						{
							oCompany.SawUsID = db.SawUs.FirstOrDefault(x => x.SawUs_Desc == "Unknown").SawUs_ID;
						}
						else
						{
							oCompany.SawUsID = su.SawUs_ID;
						}
					}
					else
					{
						var su = db.SawUs.Where(x => x.SawUs_Desc == iCustomer.Saw_Us).FirstOrDefault();
						if (su == null)
						{
							oCompany.SawUsID = db.SawUs.FirstOrDefault(x => x.SawUs_Desc == "Unknown").SawUs_ID;
						}
						else
						{
							oCompany.SawUsID = su.SawUs_ID;
						}
					}



					/// Customer Type
					if (iCustomer.AccountTypeID == 3)
					{
						oCompany.CompanyAccountTypeID = db.CompanyAccountTypes.Where(x => x.Name == "Gold Club").FirstOrDefault().CompanyAccountTypeID;
					}
					else
					{
						oCompany.CompanyAccountTypeID = db.CompanyAccountTypes.Where(x => x.Name == "Base").FirstOrDefault().CompanyAccountTypeID;
					}

					db.Companies.Add(oCompany);

					db.SaveChanges();

					iCustomer.isMigrated = true;
					db.SaveChanges();

					// Phone
					if (!string.IsNullOrEmpty(iCustomer.Phone))
					{
						string clearPhone = RemoveSpecialCharacters(iCustomer.Phone);

						Phone phoneNum = new Phone();
						if (clearPhone.Length > 10)
						{
							phoneNum.CountryCode = "+" + clearPhone.Substring(0, clearPhone.Length - 10).TrimStart('0');
							phoneNum.Number = clearPhone.Substring(clearPhone.Length - 10);
							phoneNum.PhoneTypeID = db.PhoneTypes.Where(x => x.Name == "Work").FirstOrDefault().PhoneTypeID;
						}
						else if (clearPhone.Length == 10)
						{
							phoneNum.CountryCode = "+1";
							phoneNum.Number = clearPhone;
							phoneNum.PhoneTypeID = db.PhoneTypes.Where(x => x.Name == "Work").FirstOrDefault().PhoneTypeID;
						}
						else
						{

						}

						if (clearPhone.Length >= 10)
						{
							Phone dbPhone = db.Phones.Where(x => x.CountryCode == phoneNum.CountryCode && x.Number == phoneNum.Number && x.PhoneTypeID == phoneNum.PhoneTypeID).FirstOrDefault();

							if (dbPhone == null)
							{
								db.Phones.Add(phoneNum);
								db.SaveChanges();

								string ext = null;
								if (!string.IsNullOrEmpty(iCustomer.Ext) && iCustomer.Ext.Length < 6)
								{
									ext = iCustomer.Ext;
								}

								db.CompanyPhones.Add(new CompanyPhone
								{
									CompanyID = oCompany.CompanyID,
									PhoneID = phoneNum.PhoneID,
									Extention = ext
								});
								db.SaveChanges();
							}
							else
							{
								string ext = null;
								if (!string.IsNullOrEmpty(iCustomer.Ext) && iCustomer.Ext.Length < 6)
								{
									ext = iCustomer.Ext;
								}

								db.CompanyPhones.Add(new CompanyPhone
								{
									CompanyID = oCompany.CompanyID,
									PhoneID = dbPhone.PhoneID,
									Extention = ext
								});
								db.SaveChanges();
							}
						}
					}


					// FAX
					if (!string.IsNullOrEmpty(iCustomer.Fax))
					{

						string clearFax = RemoveSpecialCharacters(iCustomer.Fax);

						Phone faxNum = new Phone();
						if (clearFax.Length > 10)
						{
							faxNum.CountryCode = "+" + clearFax.Substring(0, clearFax.Length - 10).TrimStart('0');
							faxNum.Number = clearFax.Substring(clearFax.Length - 10);
							faxNum.PhoneTypeID = db.PhoneTypes.Where(x => x.Name == "Fax").FirstOrDefault().PhoneTypeID;
						}
						else if (clearFax.Length == 10)
						{
							faxNum.CountryCode = "+1";
							faxNum.Number = clearFax;
							faxNum.PhoneTypeID = db.PhoneTypes.Where(x => x.Name == "Fax").FirstOrDefault().PhoneTypeID;
						}
						else
						{

						}

						if (clearFax.Length >= 10)
						{

							Phone dbPhone = db.Phones.Where(x => x.CountryCode == faxNum.CountryCode && x.Number == faxNum.Number && x.PhoneTypeID == faxNum.PhoneTypeID).FirstOrDefault();

							if (dbPhone == null)
							{
								db.Phones.Add(faxNum);
								db.SaveChanges();

								db.CompanyPhones.Add(new CompanyPhone
								{
									CompanyID = oCompany.CompanyID,
									PhoneID = faxNum.PhoneID,

								});
								db.SaveChanges();
							}
							else
							{


								db.CompanyPhones.Add(new CompanyPhone
								{
									CompanyID = oCompany.CompanyID,
									PhoneID = dbPhone.PhoneID,

								});
								db.SaveChanges();
							}
						}
					}




					// Address
					Address ca = new Address();

					//ca.IsMain = true;
					ca.Street = iCustomer.Address1;
					ca.Suite = iCustomer.Address2;
					ca.City = iCustomer.City;
					ca.Province = iCustomer.Province;

					if (!string.IsNullOrEmpty(iCustomer.Zip))
					{
						ca.ZipCode = (iCustomer.Zip.Length < 10) ? iCustomer.Zip : iCustomer.Zip.Substring(0, 10);
					}

					var st = db.States.Where(x => x.State1 == iCustomer.State).FirstOrDefault();
					if (st != null)
					{
						ca.StateID = st.State_ID;
					}

					var co = db.Countries.Where(x => x.CountryName == iCustomer.Country).FirstOrDefault();
					if (co != null)
					{
						ca.CountryID = co.CountryID;
					}
					else
					{
						ca.CountryID = 867;
					}

					db.Addresses.Add(ca);
					db.SaveChanges();

					db.CompanyAddresses.Add(new CompanyAddress
					{
						CompanyID = oCompany.CompanyID,
						AddressID = ca.AddressID,
						AddressTypeID = db.AddressTypes.FirstOrDefault(x => x.Name == "Billing Address").AddressTypeID
					});

					db.SaveChanges();

					#region CompnayAccreditationCode


					AccreditationCode ac = new AccreditationCode();
					if (!string.IsNullOrEmpty(iCustomer.Arc_No))
					{

						ac = new AccreditationCode
						{
							CompanyID = oCompany.CompanyID,
							Code = iCustomer.Arc_No,
							AccreditationCodeTypeID = db.AccreditationCodeTypes.Where(x => x.Name == "Arc No").FirstOrDefault().AccreditationCodeTypeID

						};
						db.AccreditationCodes.Add(ac);
					}

					if (!string.IsNullOrEmpty(iCustomer.IATAN))
					{
						ac = new AccreditationCode
						{
							CompanyID = oCompany.CompanyID,
							Code = iCustomer.IATAN,
							AccreditationCodeTypeID = db.AccreditationCodeTypes.Where(x => x.Name == "Iatan No").FirstOrDefault().AccreditationCodeTypeID

						};
						db.AccreditationCodes.Add(ac);
					}

					if (!string.IsNullOrEmpty(iCustomer.CLA))
					{
						ac = new AccreditationCode
						{
							CompanyID = oCompany.CompanyID,
							Code = iCustomer.CLA,
							AccreditationCodeTypeID = db.AccreditationCodeTypes.Where(x => x.Name == "Cla No").FirstOrDefault().AccreditationCodeTypeID

						};
						db.AccreditationCodes.Add(ac);
					}

					if (iCustomer.Tax_ID != null && iCustomer.Tax_ID > 0)
					{
						ac = new AccreditationCode
						{
							CompanyID = oCompany.CompanyID,
							Code = iCustomer.Tax_ID.ToString(),
							AccreditationCodeTypeID = db.AccreditationCodeTypes.Where(x => x.Name == "Tax Id").FirstOrDefault().AccreditationCodeTypeID

						};
						db.AccreditationCodes.Add(ac);
					}
					db.SaveChanges();
					#endregion


					db.SaveChanges();

					label1.Text = (Convert.ToInt32(label1.Text) + 1).ToString();

				}
				MessageBox.Show("Done");
			}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (KeyConNew db = new KeyConNew())
            {
                #region YanTablolar

                if (!db.AccreditationCodeTypes.Any())
                {
                    AccreditationCodeType ac = new AccreditationCodeType();
                    ac.Name = "Arc No";
                    db.AccreditationCodeTypes.Add(ac);

                    ac = new AccreditationCodeType();
                    ac.Name = "Iatan No";
                    db.AccreditationCodeTypes.Add(ac);

                    ac = new AccreditationCodeType();
                    ac.Name = "Cla No";
                    db.AccreditationCodeTypes.Add(ac);

                    ac = new AccreditationCodeType();
                    ac.Name = "Tax Id";
                    db.AccreditationCodeTypes.Add(ac);

                    db.SaveChanges();

                }

                if (!db.CompanyAccountTypes.Any())
                {
                    CompanyAccountType cat = new CompanyAccountType();

                    cat.Name = "Base";

                    cat.InsuraceCommissionRate = 10;
                    cat.SightseeingCommissionRate = 10;
                    cat.CarRentalCommissionRate = 10;
                    cat.TransportCommissionRate = 10;
                    cat.TourCommissionRate = 10;
                    cat.FlightCommissionRate = 10;
                    cat.AuxiliaryComissionRate = 10;
                    cat.CruiseCommissionRate = 10;
                    cat.HotelsCommissionRate = 10;
                    cat.LowCostCommissionRate = 10;
                    cat.TransferCommissionRate = 10;
                    cat.TicketsCommissionRate = 10;

                    cat.GroupAirCommissionRate = 10;
                    cat.GroupTourCommissionRate = 10;
                    cat.MaximumAddonCommisionRate = 20;

                    db.CompanyAccountTypes.Add(cat);


                    cat = new CompanyAccountType();

                    cat.Name = "Gold Club";

                    cat.InsuraceCommissionRate = 15;
                    cat.SightseeingCommissionRate = 15;
                    cat.CarRentalCommissionRate = 15;
                    cat.TransportCommissionRate = 15;
                    cat.TourCommissionRate = 15;
                    cat.FlightCommissionRate = 15;
                    cat.AuxiliaryComissionRate = 15;
                    cat.CruiseCommissionRate = 15;
                    cat.HotelsCommissionRate = 15;
                    cat.LowCostCommissionRate = 15;
                    cat.TransferCommissionRate = 15;
                    cat.TicketsCommissionRate = 15;

                    cat.GroupAirCommissionRate = 15;
                    cat.GroupTourCommissionRate = 15;

                    cat.MaximumAddonCommisionRate = 25;
                    db.CompanyAccountTypes.Add(cat);

                    db.SaveChanges();
                }

                if (!db.SawUs.Any(x => x.SawUs_Desc == "Unknown"))
                {
                    SawU su = new SawU();
                    su.SawUs_Desc = "Unknown";
                    su.SawUs_Visible = true;

                    db.SawUs.Add(su);
                    db.SaveChanges();
                }

                if (!db.PhoneTypes.Any())
                {

                    db.PhoneTypes.Add(new PhoneType { Name = "Home" });
                    db.PhoneTypes.Add(new PhoneType { Name = "Work" });
                    db.PhoneTypes.Add(new PhoneType { Name = "Cell Phone" });
                    db.PhoneTypes.Add(new PhoneType { Name = "Fax" });
                    db.SaveChanges();
                }

                if (!db.AddressTypes.Any())
                {
                    db.AddressTypes.Add(new AddressType { Name = "Shipping Address" });
                    db.AddressTypes.Add(new AddressType { Name = "Billing Address" });
                    db.SaveChanges();
                }


                if (!db.PolicyTypes.Any())
                {
                    db.PolicyTypes.Add(new PolicyType
                    {
                        Name = "Travel Agent Policies",
                    });
                    db.SaveChanges();
                }

                if (!db.MemberTypes.Any())
                {
                    db.MemberTypes.Add(new MemberType { Name = "Booking Agent", Descripton = "" });
                    db.MemberTypes.Add(new MemberType { Name = "Travel Agent", Descripton = "" });
                    db.MemberTypes.Add(new MemberType { Name = "Individual", Descripton = "" });
                    db.MemberTypes.Add(new MemberType { Name = "Consortium Agent", Descripton = "" });
                    db.SaveChanges();
                }

                if (!db.Policies.Any())
                {
                    db.Policies.Add(new Policy
                    {
                        Name = "Super admin rights for travel agents",
                        Description = "User can do anything",
                        Code = "TAA001",
                        TagetMemberTypeID = db.MemberTypes.FirstOrDefault(x => x.Name == "Travel Agent").MemberTypeID,
                        PolicyTypeID = db.PolicyTypes.FirstOrDefault(x => x.Name == "Travel Agent Policies").PolicyTypeID,
                    });
                    db.SaveChanges();
                }
                #endregion
                #region MemberYanTablolar
                if (!db.MemberTypes.Any())
                {
                    MemberType mt = new MemberType();
                    mt.Name = "Booking Agent";
                    db.MemberTypes.Add(mt);

                    mt = new MemberType();
                    mt.Name = "Travel Agent";
                    db.MemberTypes.Add(mt);

                    mt = new MemberType();
                    mt.Name = "Individual";
                    db.MemberTypes.Add(mt);

                    mt = new MemberType();
                    mt.Name = "Consortium User";
                    db.MemberTypes.Add(mt);

                    db.SaveChanges();

                }
                #endregion
            }
            MessageBox.Show("Done");
        }

        //Methood to clear all alfanumeric characters from a string
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (KeyConNew db = new KeyConNew())
            {
                var oWebUser = db.WebUsers.Where(x => x.isMigrated == false && x.WebUser_UserType.Contains("Travel")).ToList();

                foreach (var iWebUser in oWebUser)
                {
                    if (db.Companies.Any(x => x.CompanyID == iWebUser.Cust_ID) && !string.IsNullOrEmpty(iWebUser.WebUser_Email))
                    {


                        Member oMember = new Member();
                        oMember.ApiUserId = 1;
                        oMember.Email = iWebUser.WebUser_Email;
                        oMember.FacebookID = iWebUser.FacebookID;
                        oMember.FirstName = iWebUser.WebUser_FirstName ?? "";
                        oMember.GoogleID = iWebUser.GoogleID;
                        oMember.IsActive = iWebUser.isActivated;
                        oMember.isSendNewsLetter = iWebUser.WebUser_SendNewsLetters;
                        oMember.LastName = iWebUser.WebUser_LastName ?? "";
                        oMember.MemberID = iWebUser.Web_User_ID;
                        oMember.Password = iWebUser.WebUser_Password ?? "Best2023";

                        db.Members.Add(oMember);
                        iWebUser.isMigrated = true;
                        db.SaveChanges();

                        CompanyMember cm = new CompanyMember();
                        cm.MemberID = oMember.MemberID;
                        cm.CompanyID = iWebUser.Cust_ID;
                        cm.MemberTypeID = db.MemberTypes.Where(x => x.Name == "Travel Agent").FirstOrDefault().MemberTypeID;

                        db.CompanyMembers.Add(cm);
                        db.SaveChanges();

                        AuthorityGroup ag = new AuthorityGroup();
                        ag.CompanyID = iWebUser.Cust_ID;
                        ag.Name = "Default Admin";
                        ag.Description = "Default settings for travel agent admin";
                        ag.TargetMemberTypeID = db.MemberTypes.Where(x => x.Name == "Travel Agent").FirstOrDefault().MemberTypeID;

                        db.AuthorityGroups.Add(ag);
                        db.SaveChanges();

                        AuthorityGroupPolicy ap = new AuthorityGroupPolicy();
                        ap.AuthorityGroupID = ag.AuthorityGroupID;
                        ap.PolicyID = 1;
                        db.AuthorityGroupPolicies.Add(ap);
                        db.SaveChanges();

                        // Phone
                        if (!string.IsNullOrEmpty(iWebUser.WebUser_PhoneNumber))
                        {
                            string clearPhone = RemoveSpecialCharacters(iWebUser.WebUser_PhoneNumber);

                            Phone phoneNum = new Phone();
                            if (clearPhone.Length > 10)
                            {
                                phoneNum.CountryCode = "+" + clearPhone.Substring(0, clearPhone.Length - 10).TrimStart('0');
                                phoneNum.Number = clearPhone.Substring(clearPhone.Length - 10);
                                phoneNum.PhoneTypeID = db.PhoneTypes.Where(x => x.Name == "Work").FirstOrDefault().PhoneTypeID;
                            }
                            else if (clearPhone.Length == 10)
                            {
                                phoneNum.CountryCode = "+1";
                                phoneNum.Number = clearPhone;
                                phoneNum.PhoneTypeID = db.PhoneTypes.Where(x => x.Name == "Work").FirstOrDefault().PhoneTypeID;
                            }
                            else
                            {

                            }

                            if (clearPhone.Length >= 10)
                            {
                                Phone dbPhone = db.Phones.Where(x => x.CountryCode == phoneNum.CountryCode && x.Number == phoneNum.Number && x.PhoneTypeID == phoneNum.PhoneTypeID).FirstOrDefault();

                                if (dbPhone == null)
                                {
                                    db.Phones.Add(phoneNum);
                                    db.SaveChanges();

                                    string ext = null;
                                    if (!string.IsNullOrEmpty(iWebUser.WebUser_Extention) && iWebUser.WebUser_Extention.Length < 6)
                                    {
                                        ext = iWebUser.WebUser_Extention;
                                    }

                                    db.MemberPhones.Add(new MemberPhone
                                    {
                                        MemberID = oMember.MemberID,
                                        PhoneID = phoneNum.PhoneID,
                                        Extention = ext
                                    });
                                    db.SaveChanges();
                                }
                                else
                                {
                                    string ext = null;
                                    if (!string.IsNullOrEmpty(iWebUser.WebUser_Extention) && iWebUser.WebUser_Extention.Length < 6)
                                    {
                                        ext = iWebUser.WebUser_Extention;
                                    }

                                    db.MemberPhones.Add(new MemberPhone
                                    {
                                        MemberID = oMember.MemberID,
                                        PhoneID = dbPhone.PhoneID,
                                        Extention = ext
                                    });
                                    db.SaveChanges();
                                }
                            }
                        }

                        // Billing Address
                        Address ca = new Address();

                        //ca.IsMain = true;
                        ca.Street = iWebUser.WebUser_Address1;
                        ca.Suite = iWebUser.WebUser_Address2;
                        ca.City = iWebUser.WebUser_City;
                        ca.Province = iWebUser.WebUser_Province;

                        if (!string.IsNullOrEmpty(iWebUser.WebUser_ZipCode))
                        {
                            ca.ZipCode = (iWebUser.WebUser_ZipCode.Length < 10) ? iWebUser.WebUser_ZipCode : iWebUser.WebUser_ZipCode.Substring(0, 10);
                        }

                        var st = db.States.Where(x => x.State1 == iWebUser.WebUser_State).FirstOrDefault();
                        if (st != null)
                        {
                            ca.StateID = st.State_ID;
                        }

                        var co = db.Countries.Where(x => x.CountryName == iWebUser.WebUser_Country).FirstOrDefault();
                        if (co != null)
                        {
                            ca.CountryID = co.CountryID;
                        }
                        else
                        {
                            ca.CountryID = 867;
                        }

                        db.Addresses.Add(ca);
                        db.SaveChanges();

                        db.MemberAddresses.Add(new MemberAddress
                        {
                            MemberID = oMember.MemberID,
                            AddressID = ca.AddressID,
                            AddressTypeID = db.AddressTypes.FirstOrDefault(x => x.Name == "Billing Address").AddressTypeID
                        });
                        db.SaveChanges();

                        // Shiping Address
                        ca = new Address();

                        //ca.IsMain = true;
                        ca.Street = iWebUser.WebUser_ShippingAddress1;
                        ca.Suite = iWebUser.WebUser_ShippingAddress2;
                        ca.City = iWebUser.WebUser_ShippingCity;
                        ca.Province = iWebUser.WebUser_ShippingProvince;

                        if (!string.IsNullOrEmpty(iWebUser.WebUser_ShippingZipCode))
                        {
                            ca.ZipCode = (iWebUser.WebUser_ShippingZipCode.Length < 10) ? iWebUser.WebUser_ShippingZipCode : iWebUser.WebUser_ShippingZipCode.Substring(0, 10);
                        }

                        st = db.States.Where(x => x.State1 == iWebUser.WebUser_ShippingState).FirstOrDefault();
                        if (st != null)
                        {
                            ca.StateID = st.State_ID;
                        }

                        co = db.Countries.Where(x => x.CountryName == iWebUser.WebUser_ShippingCountry).FirstOrDefault();
                        if (co != null)
                        {
                            ca.CountryID = co.CountryID;
                        }
                        else
                        {
                            ca.CountryID = 867;
                        }

                        db.Addresses.Add(ca);
                        db.SaveChanges();

                        db.MemberAddresses.Add(new MemberAddress
                        {
                            MemberID = oMember.MemberID,
                            AddressID = ca.AddressID,
                            AddressTypeID = db.AddressTypes.FirstOrDefault(x => x.Name == "Shipping Address").AddressTypeID
                        });
                        db.SaveChanges();

                    }

                }

            }
            MessageBox.Show("Done");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QuoteMigration quoteMigration = new QuoteMigration();
            quoteMigration.UpdateStatusChangeQuote_oldToQuote();

        }
    }
}
