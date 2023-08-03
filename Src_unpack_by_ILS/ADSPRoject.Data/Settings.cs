using System;
using System.Collections.Generic;

namespace ADSPRoject.Data;

public class Settings
{
	public List<XProxy> XproxyList = (List<XProxy>)Activator.CreateInstance(typeof(List<XProxy>));

	public List<TokenEntity> List_TOKEN_PAGE = (List<TokenEntity>)Activator.CreateInstance(typeof(List<TokenEntity>));

	public List<TokenEntity> List_TOKEN_PIXEL = (List<TokenEntity>)Activator.CreateInstance(typeof(List<TokenEntity>));

	public List<TokenEntity> List_TOKEN_PAGE_PARTNER = (List<TokenEntity>)Activator.CreateInstance(typeof(List<TokenEntity>));

	public FormCard FormCard = new FormCard();

	public string txtBMManagerToken { get; set; }

	public string txtBMManagerBMID { get; set; }

	public int txtBMManagerLimit { get; set; }

	public string txtNameTKCN { get; set; }

	public string txtTokenBMRequest { get; set; }

	public string txtBMIdRequest { get; set; }

	public int ccbLocationTinsoft { get; set; }

	public string txtLinkLiveStream { get; set; }

	public bool cbUseNameVideo { get; set; }

	public int numDelayLiveStream { get; set; }

	public int ccbChromeSize { get; set; }

	public string txtFolder { get; set; }

	public string txtDay { get; set; }

	public string txtHour { get; set; }

	public string ccbTarget { get; set; }

	public int numTimeDelay { get; set; }

	public int numThread { get; set; }

	public bool cbCheckLive { get; set; }

	public int numFromDelay { get; set; }

	public int numToDelay { get; set; }

	public int numChromeWidth { get; set; }

	public int numChromeHeight { get; set; }

	public int ChromeSize { get; set; }

	public int numToChangeIP { get; set; }

	public int numProtonVPN { get; set; }

	public int rbTypeChangeIP { get; set; }

	public int ccbTypeTMProxy { get; set; }

	public string txtTinSoftSV { get; set; }

	public string txtTmProxy { get; set; }

	public int ccbLocationTmProxy { get; set; }

	public string txt922Url { get; set; }

	public string txtLinkGame { get; set; }

	public string txtKeyword { get; set; }

	public string XproxyIP { get; set; }

	public string Language { get; set; }

	public string ColumnDisplay { get; set; }

	public string Pixel_Id { get; set; }

	public string BM_Pixel_ID { get; set; }

	public string txtBMID_PagePartner { get; set; }

	public string txtPageID_Partner { get; set; }

	public string txtBMIDTestPagePartner { get; set; }

	public string txtProfile { get; set; }

	public bool cbSaveBackup { get; set; } = true;


	public bool isOnProfersional { get; set; } = true;


	public int TypeXProxy { get; set; }

	public string ReMarketing_Message { get; set; }

	public string ReMarketing_PageId { get; set; }

	public int ReMarketing_DelayFrom { get; set; }

	public int ReMarketing_DelayTo { get; set; }

	public PagePartner pagePartner { get; set; }

	public ActControlData actControl { get; set; }
}
