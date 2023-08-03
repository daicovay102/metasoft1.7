using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ADSPRoject.Data;

namespace Data;

[Serializable]
public class FBEntity
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<GroupItem, bool> _003C_003E9__458_0;

		public static Func<GroupItem, bool> _003C_003E9__460_0;

		public static Func<GroupItem, bool> _003C_003E9__462_0;

		public static Func<GroupItem, bool> _003C_003E9__464_0;

		internal T0 _003Cget_GroupLive_003Eb__458_0<T0>(GroupItem a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(a.Status == 0);
		}

		internal T0 _003Cget_GroupPending_003Eb__460_0<T0>(GroupItem a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(a.Status == 3);
		}

		internal T0 _003Cget_GroupUnpending_003Eb__462_0<T0>(GroupItem a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(a.Status == 2);
		}

		internal T0 _003Cget_GroupLock_003Eb__464_0<T0>(GroupItem a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(a.Status == 1);
		}
	}

	public string Folder_Id;

	public List<FBFlow> Flow = (List<FBFlow>)Activator.CreateInstance(typeof(List<FBFlow>));

	public CheckInfo fullAdsInfo = new CheckInfo();

	public int intThreadReceiptBM;

	public string Error = "";

	public List<CreditCardEntity> listCard = (List<CreditCardEntity>)Activator.CreateInstance(typeof(List<CreditCardEntity>));

	public List<GroupShared> GroupShared = (List<GroupShared>)Activator.CreateInstance(typeof(List<GroupShared>));

	public bool Select { get; set; }

	public int Row { get; set; }

	public string Note { get; set; }

	public string Name { get; set; }

	public int Friends { get; set; }

	public string GroupUId { get; set; }

	public int Group { get; set; }

	public string UID { get; set; }

	public string Password { get; set; }

	public string Code2FA { get; set; }

	public string Cookie { get; set; }

	public string fb_dtsg { get; set; }

	public string async_get_token { get; set; }

	public string __spin_r { get; set; }

	public string __spin_t { get; set; }

	public string hsi { get; set; }

	public string jazoest { get; set; }

	public string Socks { get; set; }

	public string UserAgent { get; set; }

	public string Step { get; set; }

	public string Message { get; set; }

	public string Status { get; set; }

	public string RivalLink { get; set; }

	public string Shopee_UserName { get; set; }

	public string Shopee_Password { get; set; }

	public string Shopee_Status { get; set; }

	public string Hastag { get; set; }

	public string Page { get; set; }

	public List<page_with_default_viewer> listPageByToolCreate { get; set; }

	public string PageByTool { get; set; }

	public string FullInfo { get; set; }

	public string TokenEAAG { get; set; }

	public string TokenEAAB { get; set; }

	public string LinkBM { get; set; }

	public CreatePageEntity CreatePageEntity { get; set; }

	public string txtBMIDTQCKInBM { get; set; }

	public int numThread { get; set; }

	public int numDelay { get; set; }

	public int numDelayApproved2 { get; set; }

	public int numThreadPage { get; set; }

	public string BM_ID_Partner_Page { get; set; }

	public string strCatePage { get; set; }

	public string strRemovePageFromBM { get; set; }

	public string strSpamGroup { get; set; }

	public int DelaySpam { get; set; }

	public string txtTargetCamp { get; set; }

	public string txtTargetAdset { get; set; }

	public string txtTargetAd { get; set; }

	public string txtCampFilter { get; set; }

	public int intThreadBM { get; set; }

	public int intDelayReceiptBM { get; set; }

	public string txtBMPartner { get; set; }

	public string txtMailDomain { get; set; }

	public string txtBMName { get; set; }

	public int intDelayBM { get; set; }

	public bool boolOneBmOneMail { get; set; }

	public string txtNameAdsBM { get; set; }

	public string txtCountryAdsBM { get; set; }

	public string txtTimeZoneAdsBM { get; set; }

	public string txtCurrencyAdsBM { get; set; }

	public string txtAddressAdsBM { get; set; }

	public string txtStateAdsBM { get; set; }

	public string txtZipAdsBM { get; set; }

	public string txtCityAdsBM { get; set; }

	public string txtCountryBM { get; set; }

	public string txtCurrencyBM { get; set; }

	public string txtActByBM10 { get; set; }

	public int ccbActSort { get; set; }

	public string txtSearchByKeyword { get; set; }

	public int lbCountLoadAct { get; set; }

	public int numMaxAct { get; set; }

	public int ccbActFillter { get; set; }

	public string txtSearch { get; set; }

	public string txtChangeNameAds { get; set; }

	public string txtLimit { get; set; }

	public string txtBMID { get; set; }

	public string txtTextCamp { get; set; }

	public string Email { get; set; }

	public string EmailPassword { get; set; }

	public string txtAddress { get; set; }

	public string txtCity { get; set; }

	public string txtState { get; set; }

	public string txtZip { get; set; }

	public string txtCountry { get; set; }

	public string txtCurrency { get; set; }

	public string txtTimeZone { get; set; }

	public string txtPayBalance { get; set; }

	public string txtRemoveCardByName { get; set; }

	public string BugetCamp { get; set; }

	public string txtCardCountry { get; set; }

	public bool cbAddBinGen { get; set; }

	public string txtBinGen { get; set; }

	public string txtNameCard { get; set; }

	public string txtIdPixel { get; set; }

	public string txtBM_Pixel { get; set; }

	public string txtPushCardPrimary { get; set; }

	public bool cbRemoveCamp { get; set; }

	public string txtPro5List { get; set; }

	public int numAddActOnPage { get; set; }

	public bool cbRollingMatThread { get; set; }

	public int numDelayRemoveCard { get; set; }

	public int numLifeCycle { get; set; }

	public int numDelayLifeCycle { get; set; }

	public bool cbPutPrimary { get; set; }

	public string txtBMID_Page_Location { get; set; }

	public string txtPageId_Page_Location { get; set; }

	public int numQuantity_Page_Location { get; set; }

	public string txtCatePage_Page_Location { get; set; }

	public string txtPhone_Page_Location { get; set; }

	public int numDelay_Page_Location { get; set; }

	public addraft_fragments_2 addraft_fragments_2 { get; set; }

	public int CountGroupShared => GroupShared.Count;

	public List<GroupItem> ListGroup { get; set; }

	public int GroupLive
	{
		get
		{
			if (ListGroup != null)
			{
				return ListGroup.Where(_003C_003Ec._003C_003E9._003Cget_GroupLive_003Eb__458_0<bool>).Count();
			}
			return 0;
		}
	}

	public int GroupPending
	{
		get
		{
			if (ListGroup == null)
			{
				return 0;
			}
			return ListGroup.Where(_003C_003Ec._003C_003E9._003Cget_GroupPending_003Eb__460_0<bool>).Count();
		}
	}

	public int GroupUnpending
	{
		get
		{
			if (ListGroup != null)
			{
				return ListGroup.Where(_003C_003Ec._003C_003E9._003Cget_GroupUnpending_003Eb__462_0<bool>).Count();
			}
			return 0;
		}
	}

	public int GroupLock
	{
		get
		{
			if (ListGroup != null)
			{
				return ListGroup.Where(_003C_003Ec._003C_003E9._003Cget_GroupLock_003Eb__464_0<bool>).Count();
			}
			return 0;
		}
	}
}
