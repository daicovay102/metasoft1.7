using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ADSPRoject.Chrome;
using ADSPRoject.Data;
using ADSPRoject.Data.tmproxy;
using ADSPRoject.HttpRequestApi;
using ADSPRoject.License;
using ADSPRoject.Properties;
using ADSPRoject.Server;
using ADSPRoject.Tasking;
using Data;
using Newtonsoft.Json;
using xNet;

namespace ADSPRoject;

public class frmMain : Form
{
	public enum STATUS
	{
		Checkpoint,
		Ready,
		NoLimit,
		Working,
		Done,
		lỗi,
		Waiting,
		Requested,
		Accepted,
		Processing,
		Used,
		Declined,
		Clear,
		Shared,
		Live,
		VHH,
		Die,
		Không_đủ_tiền,
		Bình_thường,
		Hoạt_động,
		Không_thẻ
	}

	public enum ChromeSize
	{
		Maxium,
		AutoSort,
		CustomSize
	}

	public enum EMouseKey
	{
		LEFT,
		RIGHT,
		DOUBLE_LEFT,
		DOUBLE_RIGHT
	}

	public struct RECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<DataGridViewRow, bool> _003C_003E9__55_0;

		public static Func<DataGridViewRow, int> _003C_003E9__55_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__56_0;

		public static Func<DataGridViewRow, int> _003C_003E9__56_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__57_0;

		public static Func<DataGridViewRow, int> _003C_003E9__57_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__59_0;

		public static Func<DataGridViewRow, int> _003C_003E9__59_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__60_0;

		public static Func<DataGridViewRow, int> _003C_003E9__60_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__61_0;

		public static Func<DataGridViewRow, int> _003C_003E9__61_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__62_0;

		public static Func<DataGridViewRow, int> _003C_003E9__62_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__63_0;

		public static Func<DataGridViewRow, int> _003C_003E9__63_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__64_0;

		public static Func<DataGridViewRow, int> _003C_003E9__64_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__65_0;

		public static Func<DataGridViewRow, int> _003C_003E9__65_1;

		public static Func<FBEntity, int> _003C_003E9__67_0;

		public static Func<FBEntity, string> _003C_003E9__67_1;

		public static Func<FBEntity, string> _003C_003E9__67_2;

		public static Func<FBEntity, int> _003C_003E9__67_3;

		public static Func<FBEntity, int> _003C_003E9__67_4;

		public static Func<FBEntity, string> _003C_003E9__67_5;

		public static Func<FBEntity, string> _003C_003E9__67_6;

		public static Func<FBEntity, string> _003C_003E9__67_7;

		public static Func<FBEntity, int> _003C_003E9__67_8;

		public static Func<FBEntity, string> _003C_003E9__67_9;

		public static Func<FBEntity, string> _003C_003E9__67_10;

		public static Func<FBEntity, int> _003C_003E9__67_11;

		public static Func<FBEntity, int> _003C_003E9__67_12;

		public static Func<FBEntity, string> _003C_003E9__67_13;

		public static Func<FBEntity, string> _003C_003E9__67_14;

		public static Func<FBEntity, string> _003C_003E9__67_15;

		public static Func<DataGridViewRow, bool> _003C_003E9__68_0;

		public static Func<DataGridViewRow, int> _003C_003E9__68_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__69_0;

		public static Func<DataGridViewRow, int> _003C_003E9__69_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__70_0;

		public static Func<DataGridViewRow, int> _003C_003E9__70_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__72_0;

		public static Func<DataGridViewRow, int> _003C_003E9__72_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__73_0;

		public static Func<DataGridViewRow, int> _003C_003E9__73_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__75_0;

		public static Func<DataGridViewRow, int> _003C_003E9__75_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__76_0;

		public static Func<DataGridViewRow, int> _003C_003E9__76_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__77_0;

		public static Func<DataGridViewRow, int> _003C_003E9__77_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__78_0;

		public static Func<DataGridViewRow, int> _003C_003E9__78_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__79_0;

		public static Func<DataGridViewRow, int> _003C_003E9__79_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__80_0;

		public static Func<DataGridViewRow, int> _003C_003E9__80_1;

		public static Func<string, char> _003C_003E9__90_0;

		public static Func<FBEntity, bool> _003C_003E9__91_0;

		public static Func<FBEntity, bool> _003C_003E9__93_0;

		public static Func<FBEntity, bool> _003C_003E9__94_0;

		public static Func<DataGridViewRow, bool> _003C_003E9__95_0;

		public static Func<DataGridViewRow, int> _003C_003E9__95_1;

		public static Func<FBEntity, bool> _003C_003E9__95_2;

		public static Func<DataGridViewRow, bool> _003C_003E9__96_0;

		public static Func<DataGridViewRow, int> _003C_003E9__96_1;

		public static Func<FBEntity, bool> _003C_003E9__96_2;

		public static Func<FBEntity, bool> _003C_003E9__134_0;

		public static Func<FBEntity, bool> _003C_003E9__134_1;

		public static Func<FBEntity, bool> _003C_003E9__134_2;

		public static Func<DataGridViewRow, bool> _003C_003E9__136_0;

		public static Func<DataGridViewRow, int> _003C_003E9__136_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__137_0;

		public static Func<DataGridViewRow, int> _003C_003E9__137_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__138_0;

		public static Func<DataGridViewRow, int> _003C_003E9__138_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__141_0;

		public static Func<DataGridViewRow, int> _003C_003E9__141_1;

		public static Func<XProxy, bool> _003C_003E9__142_0;

		public static Func<DataGridViewRow, bool> _003C_003E9__143_0;

		public static Func<DataGridViewRow, int> _003C_003E9__143_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__144_0;

		public static Func<DataGridViewRow, int> _003C_003E9__144_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__145_0;

		public static Func<DataGridViewRow, int> _003C_003E9__145_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__146_0;

		public static Func<DataGridViewRow, int> _003C_003E9__146_1;

		public static Func<XProxy, bool> _003C_003E9__147_0;

		public static Func<DataGridViewRow, bool> _003C_003E9__148_0;

		public static Func<DataGridViewRow, int> _003C_003E9__148_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__149_0;

		public static Func<DataGridViewRow, int> _003C_003E9__149_1;

		public static Func<XProxy, bool> _003C_003E9__150_0;

		public static Func<DataGridViewRow, bool> _003C_003E9__151_0;

		public static Func<DataGridViewRow, int> _003C_003E9__151_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__152_0;

		public static Func<DataGridViewRow, int> _003C_003E9__152_1;

		public static Func<XProxy, bool> _003C_003E9__153_0;

		public static Func<DataGridViewRow, bool> _003C_003E9__154_0;

		public static Func<DataGridViewRow, int> _003C_003E9__154_1;

		public static Func<XProxy, bool> _003C_003E9__155_0;

		public static Func<DataGridViewRow, bool> _003C_003E9__156_0;

		public static Func<DataGridViewRow, int> _003C_003E9__156_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__158_0;

		public static Func<DataGridViewRow, int> _003C_003E9__158_1;

		public static Func<DataGridViewRow, bool> _003C_003E9__159_0;

		public static Func<DataGridViewRow, int> _003C_003E9__159_1;

		public static Func<XProxy, bool> _003C_003E9__160_0;

		public static Func<XProxy, bool> _003C_003E9__161_0;

		public static Func<XProxy, bool> _003C_003E9__162_0;

		public static Func<XProxy, bool> _003C_003E9__163_0;

		public static Func<XProxy, bool> _003C_003E9__164_0;

		public static Func<XProxy, bool> _003C_003E9__165_0;

		public static Func<FBEntity, bool> _003C_003E9__173_0;

		public static Func<FBEntity, bool> _003C_003E9__173_1;

		public static Func<Process, bool> _003C_003E9__202_0;

		public static EnumWindowProc _003C_003E9__207_0;

		internal T0 _003CpasteProxyEvent_003Eb__55_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CpasteProxyEvent_003Eb__55_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CpasteUseragentEvent_003Eb__56_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CpasteUseragentEvent_003Eb__56_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CmoveEvent_003Eb__57_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CmoveEvent_003Eb__57_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CclearProxyEvent_003Eb__59_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CclearProxyEvent_003Eb__59_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CclearGroupLockedEvent_003Eb__60_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CclearGroupLockedEvent_003Eb__60_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CclearGroupEvent_003Eb__61_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CclearGroupEvent_003Eb__61_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CclearProfileEvent_003Eb__62_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CclearProfileEvent_003Eb__62_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CclearNameEvent_003Eb__63_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CclearNameEvent_003Eb__63_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CclearEvent_003Eb__64_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CclearEvent_003Eb__64_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CremoveSelectedKeepProfileEvent_003Eb__65_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CremoveSelectedKeepProfileEvent_003Eb__65_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CsortEvent_003Eb__67_0<T0>(FBEntity a)
		{
			//IL_0007: Expected O, but got I4
			return (T0)a.Row;
		}

		internal T0 _003CsortEvent_003Eb__67_1<T0>(FBEntity a)
		{
			return (T0)a.Name;
		}

		internal T0 _003CsortEvent_003Eb__67_2<T0>(FBEntity a)
		{
			return (T0)a.UID;
		}

		internal T0 _003CsortEvent_003Eb__67_3<T0>(FBEntity a)
		{
			//IL_0007: Expected O, but got I4
			return (T0)a.Friends;
		}

		internal T0 _003CsortEvent_003Eb__67_4<T0>(FBEntity a)
		{
			//IL_0007: Expected O, but got I4
			return (T0)a.Group;
		}

		internal T0 _003CsortEvent_003Eb__67_5<T0>(FBEntity a)
		{
			return (T0)a.Page;
		}

		internal T0 _003CsortEvent_003Eb__67_6<T0>(FBEntity a)
		{
			return (T0)a.Status;
		}

		internal T0 _003CsortEvent_003Eb__67_7<T0>(FBEntity a)
		{
			return (T0)a.Message;
		}

		internal T0 _003CsortEvent_003Eb__67_8<T0>(FBEntity a)
		{
			//IL_0007: Expected O, but got I4
			return (T0)a.Row;
		}

		internal T0 _003CsortEvent_003Eb__67_9<T0>(FBEntity a)
		{
			return (T0)a.Name;
		}

		internal T0 _003CsortEvent_003Eb__67_10<T0>(FBEntity a)
		{
			return (T0)a.UID;
		}

		internal T0 _003CsortEvent_003Eb__67_11<T0>(FBEntity a)
		{
			//IL_0007: Expected O, but got I4
			return (T0)a.Friends;
		}

		internal T0 _003CsortEvent_003Eb__67_12<T0>(FBEntity a)
		{
			//IL_0007: Expected O, but got I4
			return (T0)a.Group;
		}

		internal T0 _003CsortEvent_003Eb__67_13<T0>(FBEntity a)
		{
			return (T0)a.Page;
		}

		internal T0 _003CsortEvent_003Eb__67_14<T0>(FBEntity a)
		{
			return (T0)a.Status;
		}

		internal T0 _003CsortEvent_003Eb__67_15<T0>(FBEntity a)
		{
			return (T0)a.Message;
		}

		internal T0 _003CstatusReadyEvent_003Eb__68_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CstatusReadyEvent_003Eb__68_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CstatusDoneEvent_003Eb__69_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CstatusDoneEvent_003Eb__69_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CstatuslỗiEvent_003Eb__70_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CstatuslỗiEvent_003Eb__70_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CconfigFlowEvent_003Eb__72_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CconfigFlowEvent_003Eb__72_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CremoveSelectedEvent_003Eb__73_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CremoveSelectedEvent_003Eb__73_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CcopyErrorEvent_003Eb__75_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CcopyErrorEvent_003Eb__75_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CcopyUIDEvent_003Eb__76_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CcopyUIDEvent_003Eb__76_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CcopyTokenEvent_003Eb__77_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CcopyTokenEvent_003Eb__77_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CcopySelectedEvent_003Eb__78_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CcopySelectedEvent_003Eb__78_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CcopySelectedJsonEvent_003Eb__79_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CcopySelectedJsonEvent_003Eb__79_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CcopySelectedLinkRivalEvent_003Eb__80_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CcopySelectedLinkRivalEvent_003Eb__80_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CRandomString_003Eb__90_0<T0, T1>(T1 s)
		{
			//IL_0017: Expected O, but got I4
			return (T0)((string)s)[rnd.Next(((string)s).Length)];
		}

		internal T0 _003CloadData_003Eb__91_0<T0>(FBEntity a)
		{
			//IL_0007: Expected O, but got I4
			return (T0)a.Select;
		}

		internal T0 _003CcheckedAllSelectEvent_003Eb__93_0<T0>(FBEntity a)
		{
			//IL_0007: Expected O, but got I4
			return (T0)a.Select;
		}

		internal T0 _003CuncheckAllSelectEvent_003Eb__94_0<T0>(FBEntity a)
		{
			//IL_0007: Expected O, but got I4
			return (T0)a.Select;
		}

		internal T0 _003CcheckedSelectEvent_003Eb__95_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CcheckedSelectEvent_003Eb__95_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CcheckedSelectEvent_003Eb__95_2<T0>(FBEntity a)
		{
			//IL_0007: Expected O, but got I4
			return (T0)a.Select;
		}

		internal T0 _003CuncheckSelectEvent_003Eb__96_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CuncheckSelectEvent_003Eb__96_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CuncheckSelectEvent_003Eb__96_2<T0>(FBEntity a)
		{
			//IL_0007: Expected O, but got I4
			return (T0)a.Select;
		}

		internal T0 _003CautoOpenChrome_003Eb__134_0<T0>(FBEntity a)
		{
			//IL_0026: Expected O, but got I4
			return (T0)(a.Status.Equals(STATUS.Working.ToString()) && a.Select);
		}

		internal T0 _003CautoOpenChrome_003Eb__134_1<T0>(FBEntity a)
		{
			//IL_0026: Expected O, but got I4
			return (T0)(a.Select && a.Status.Equals(STATUS.Working.ToString()));
		}

		internal T0 _003CautoOpenChrome_003Eb__134_2<T0>(FBEntity a)
		{
			//IL_0026: Expected O, but got I4
			return (T0)(a.Select && a.Status.Equals(STATUS.Working.ToString()));
		}

		internal T0 _003CopenBrowserLoginShopeeEvent_003Eb__136_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CopenBrowserLoginShopeeEvent_003Eb__136_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CopenBrowserLoginFacebookByCookieEvent_003Eb__137_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CopenBrowserLoginFacebookByCookieEvent_003Eb__137_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CaddCardEvent_003Eb__138_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CaddCardEvent_003Eb__138_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CadsManagerEvent_003Eb__141_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CadsManagerEvent_003Eb__141_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CthrAdsManager_003Eb__142_0<T0>(XProxy a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!a.IsUsed);
		}

		internal T0 _003CopenBrowserLoginMFacebookEvent_003Eb__143_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CopenBrowserLoginMFacebookEvent_003Eb__143_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CopenBrowserLoginMBasicFacebookEvent_003Eb__144_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CopenBrowserLoginMBasicFacebookEvent_003Eb__144_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CopenBrowserLoginFacebookEvent_003Eb__145_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CopenBrowserLoginFacebookEvent_003Eb__145_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CverifyZohoMailModuleEvent_003Eb__146_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CverifyZohoMailModuleEvent_003Eb__146_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CthrChromeVerifyMailZoho_003Eb__147_0<T0>(XProxy a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!a.IsUsed);
		}

		internal T0 _003CopenBrowserEvent_003Eb__148_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CopenBrowserEvent_003Eb__148_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CstartModuleEvent_003Eb__149_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CstartModuleEvent_003Eb__149_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CthrStartModuleFlow_003Eb__150_0<T0>(XProxy a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!a.IsUsed);
		}

		internal T0 _003CcheckGroupFriendEvent_003Eb__151_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CcheckGroupFriendEvent_003Eb__151_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CseedingEvent_003Eb__152_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CseedingEvent_003Eb__152_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CthrSeeding_003Eb__153_0<T0>(XProxy a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!a.IsUsed);
		}

		internal T0 _003CremarketingEvent_003Eb__154_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CremarketingEvent_003Eb__154_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CthrReMarketing_003Eb__155_0<T0>(XProxy a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!a.IsUsed);
		}

		internal T0 _003CreceiptBMLinkEvent_003Eb__156_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CreceiptBMLinkEvent_003Eb__156_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CthrCheckLive_003Eb__158_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CthrCheckLive_003Eb__158_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CaddFriendByRivalEvent_003Eb__159_0<T0, T1>(T1 row)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!((DataGridViewRow)row).IsNewRow);
		}

		internal T0 _003CaddFriendByRivalEvent_003Eb__159_1<T0, T1>(T1 row)
		{
			//IL_0007: Expected O, but got I4
			return (T0)((DataGridViewBand)row).Index;
		}

		internal T0 _003CthrChromeLoginShopeeNoFlow_003Eb__160_0<T0>(XProxy a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!a.IsUsed);
		}

		internal T0 _003CthrChromeLoginFaceBookByCookieNoFlow_003Eb__161_0<T0>(XProxy a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!a.IsUsed);
		}

		internal T0 _003CthrChromeLoginMFacebookNoFlow_003Eb__162_0<T0>(XProxy a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!a.IsUsed);
		}

		internal T0 _003CthrChromeLoginMBasicNoFlow_003Eb__163_0<T0>(XProxy a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!a.IsUsed);
		}

		internal T0 _003CthrChromeLoginNoFlow_003Eb__164_0<T0>(XProxy a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!a.IsUsed);
		}

		internal T0 _003CthrChrome_003Eb__165_0<T0>(XProxy a)
		{
			//IL_000a: Expected O, but got I4
			return (T0)(!a.IsUsed);
		}

		internal T0 _003Ctimer_start_Tick_003Eb__173_0<T0>(FBEntity a)
		{
			//IL_0045: Expected O, but got I4
			return (T0)(a.Select && (a.Status.Equals(STATUS.Ready.ToString()) || a.Status.Equals(STATUS.Working.ToString())));
		}

		internal T0 _003Ctimer_start_Tick_003Eb__173_1<T0>(FBEntity a)
		{
			//IL_0007: Expected O, but got I4
			return (T0)a.Select;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal T0 _003CcountProcessByName_003Eb__202_0<T0, T1>(T1 a)
		{
			//IL_0027: Expected O, but got I4
			return (T0)(!string.IsNullOrEmpty(((Process)a).ProcessName) && ((Process)a).ProcessName.ToLower().Equals("vpn"));
		}

		internal unsafe T0 _003CGetChildHandle_003Eb__207_0<T0, T1, T2>(T2 hWnd, T2 lParam1)
		{
			//IL_0006: Expected I, but got O
			//IL_0012: Expected O, but got I4
			//IL_0017: Expected O, but got I4
			//IL_002b: Expected I, but got O
			//IL_002d: Expected O, but got I4
			T1 val = (T1)GCHandle.FromIntPtr((IntPtr)lParam1);
			T0 val2 = (T0)(((GCHandle*)(&val))->Target == null);
			if (val2 != null)
			{
				return (T0)0;
			}
			(((GCHandle*)(&val))->Target as List<IntPtr>).Add((IntPtr)hWnd);
			return (T0)1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass158_0
	{
		public frmMain _003C_003E4__this;

		public List<DataGridViewRow> rows;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass158_1
	{
		public int countThread;

		public _003C_003Ec__DisplayClass158_0 CS_0024_003C_003E8__locals1;

		public ParameterizedThreadStart _003C_003E9__2;

		internal unsafe void _003CthrCheckLive_003Eb__2<T0, T1, T2, T3, T4, T5>(T3 obj)
		{
			//IL_000c: Expected O, but got I4
			//IL_003e: Expected I4, but got O
			//IL_0079: Expected I4, but got O
			//IL_00ba: Expected I4, but got O
			//IL_00f9: Expected I4, but got O
			//IL_012e: Expected I4, but got O
			//IL_0146: Expected O, but got I4
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Expected I4, but got Unknown
			T0 val = (T0)int.Parse(obj.ToString());
			T1 message = (T1)"";
			T2 val2 = CS_0024_003C_003E8__locals1._003C_003E4__this.CheckUID<T2, T1, T4, T5>((T1)CS_0024_003C_003E8__locals1._003C_003E4__this.listFBEntity[CS_0024_003C_003E8__locals1.rows[(int)val].Index].UID, out *(string*)(&message));
			if (val2 == null)
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.listFBEntity[CS_0024_003C_003E8__locals1.rows[(int)val].Index].Status = STATUS.Checkpoint.ToString();
			}
			else
			{
				CS_0024_003C_003E8__locals1._003C_003E4__this.listFBEntity[CS_0024_003C_003E8__locals1.rows[(int)val].Index].Status = STATUS.Done.ToString();
			}
			CS_0024_003C_003E8__locals1._003C_003E4__this.listFBEntity[CS_0024_003C_003E8__locals1.rows[(int)val].Index].Step = "";
			CS_0024_003C_003E8__locals1._003C_003E4__this.listFBEntity[CS_0024_003C_003E8__locals1.rows[(int)val].Index].Message = (string)message;
			T0 val3 = (T0)countThread;
			countThread = val3 - 1;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass205_0
	{
		public string className;

		public string text;

		internal T0 _003CFindHandlesWithText_003Eb__0<T0, T1, T2, T3>(T1 ptr)
		{
			//IL_0006: Expected I, but got O
			//IL_0028: Expected O, but got I4
			return (T0)(GetClassName((IntPtr)ptr) == className || (string)GetText<T2, T3, T1>(ptr) == text);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass220_0
	{
		public string className;

		public string text;

		internal T0 _003CFindHandleWithText_003Eb__0<T0, T1, T2, T3>(T1 ptr)
		{
			//IL_0006: Expected I, but got O
			//IL_0028: Expected O, but got I4
			return (T0)(GetClassName((IntPtr)ptr) == className || (string)GetText<T2, T3, T1>(ptr) == text);
		}
	}

	public static bool ADS_MANAGER = true;

	public static bool BM_MANAGER = true;

	public static bool PAGE_MANAGER = true;

	public static bool GROUP_MANAGER = true;

	public string FORM_TITLE;

	public static string VIA_UID = "";

	public static string VIA_NAME = "";

	public string PROFILE_CHROME_UID = "D:\\BROWSER_PROFILE\\";

	public string RESOUCE_SHOPEE_HOME = "https://www.shopee.vn";

	public static bool isRunning = false;

	public static bool isRunningVia = false;

	public List<FriendEntity> listFriendEntity = (List<FriendEntity>)Activator.CreateInstance(typeof(List<FriendEntity>));

	public List<CampEntity> listCampEntity = (List<CampEntity>)Activator.CreateInstance(typeof(List<CampEntity>));

	public List<FBEntity> listFBEntity = (List<FBEntity>)Activator.CreateInstance(typeof(List<FBEntity>));

	public List<CountryLanguage> listCountry = (List<CountryLanguage>)Activator.CreateInstance(typeof(List<CountryLanguage>));

	public List<UserAgentEntity> listUserAgent = (List<UserAgentEntity>)Activator.CreateInstance(typeof(List<UserAgentEntity>));

	public static List<CategoryComment> listCommentStroll = (List<CategoryComment>)Activator.CreateInstance(typeof(List<CategoryComment>));

	public static List<string> listPro5Used = (List<string>)Activator.CreateInstance(typeof(List<string>));

	private int THREAD_SLEEP_IBAN = 60000;

	public string CAMPAIGNS;

	public static bool BOOL_IS_ME = false;

	public static ADSPRoject.Data.Settings setting = new ADSPRoject.Data.Settings();

	public List<Folder> listFolder = (List<Folder>)Activator.CreateInstance(typeof(List<Folder>));

	public int folderCheckedIndex = 0;

	public string FileNameFBList = "";

	public List<ChromeSizeEntity> chromeSize = (List<ChromeSizeEntity>)Activator.CreateInstance(typeof(List<ChromeSizeEntity>));

	public List<ListGroupEntity> listGroupEntity = (List<ListGroupEntity>)Activator.CreateInstance(typeof(List<ListGroupEntity>));

	public static List<GroupCreditCard> groupCreditCard = (List<GroupCreditCard>)Activator.CreateInstance(typeof(List<GroupCreditCard>));

	public LocationTinsoft listLocationTinsoft = new LocationTinsoft();

	public location listLocationTmProxy = new location();

	public List<MailBM> listMailVerify = (List<MailBM>)Activator.CreateInstance(typeof(List<MailBM>));

	public static List<TKCNEntity> listTKCN = (List<TKCNEntity>)Activator.CreateInstance(typeof(List<TKCNEntity>));

	public FacebookNoLimitApi nolimitApi = null;

	public FacebookApiPage apiPage = null;

	public FacebookApiPixel apiPixel = null;

	public TokenPagePartner tokenPagePartner = null;

	public TokenNolimit TokenNolimit = new TokenNolimit();

	public ListProxySetting proxySetting = new ListProxySetting();

	public static bool isLogined = true;

	private DateTime? fbDatetime = null;

	private DateTime? folderDateTime = null;

	private List<string> listClipboard = (List<string>)Activator.CreateInstance(typeof(List<string>));

	private bool isDesc = false;

	private string strClipboard = "";

	public List<FBFlow> moduleFacebook = (List<FBFlow>)Activator.CreateInstance(typeof(List<FBFlow>));

	public List<FBFlow> moduleTiktok = (List<FBFlow>)Activator.CreateInstance(typeof(List<FBFlow>));

	public List<FBFlow> moduleShopee = (List<FBFlow>)Activator.CreateInstance(typeof(List<FBFlow>));

	public List<FBFlow> moduleFacebookApi = (List<FBFlow>)Activator.CreateInstance(typeof(List<FBFlow>));

	private int type = 0;

	public int countChrome = 0;

	private int flagAdsManager = 0;

	private int countUseProxy = 0;

	private string proxy;

	private static Random rnd = (Random)Activator.CreateInstance(typeof(Random));

	public int isNeedCopyCamp = 0;

	private const uint SWP_NOSIZE = 1u;

	private const uint SWP_NOZORDER = 4u;

	private IntPtr hwnd;

	private string classNameHMA = "Chrome_RenderWidgetHostHWND";

	private Process procesHMA;

	private IntPtr radioHMA = IntPtr.Zero;

	private RECT rectRadioHMA;

	private RECT newRectRadioHMA;

	private bool isGvRefesh = false;

	private bool isAscending = false;

	private int GvData_Row_Selected = 0;

	public static List<ActControl> actList = (List<ActControl>)Activator.CreateInstance(typeof(List<ActControl>));

	private IContainer components = null;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel lbSelected;

	private ToolStripStatusLabel toolStripStatusLabel2;

	private ToolStripStatusLabel lbTotalFB;

	private ToolStripStatusLabel toolStripStatusLabel1;

	private Label label1;

	private NumericUpDown numThread;

	private TextBox txtTinSoftSV;

	private RadioButton rbNotChangeIP;

	private RadioButton rbTinSoftVN;

	private NumericUpDown numToChangeIP;

	private Label label4;

	private NumericUpDown numFromDelay;

	private Label label5;

	private NumericUpDown numToDelay;

	private RadioButton rbHMA;

	private Button button2;

	private GroupBox groupBox1;

	private GroupBox groupBox3;

	private TabControl tabControl1;

	private TabPage tabPage1;

	private Button button5;

	private TextBox txtSearch;

	private Button btnStart;

	private TabPage tabPage3;

	private DataGridView gvUserAgent;

	private Button btnConfig;

	private Label label10;

	private NumericUpDown numTimeDelay;

	private RadioButton rbUseXproxy;

	private Button btnConfigXproxy;

	private DataGridView gvData;

	private LinkLabel lbLanguage;

	private RadioButton rbCustomSizeChrome;

	private RadioButton rbAutoSortSizeChrome;

	private RadioButton rbMaximumChrome;

	private NumericUpDown numChromeCustomSizeWidth;

	private NumericUpDown numChromeCustomSizeHeigth;

	private MenuStrip menuStrip1;

	private ToolStripMenuItem càiĐặtToolStripMenuItem;

	private ToolStripMenuItem hiệnThịCộtDữLiệuToolStripMenuItem;

	private SplitContainer splitContainer1;

	private Button button1;

	private CheckedListBox cbListFolder;

	private GroupBox groupFolder;

	private Button button3;

	private Button btnUp;

	private Button btnDown;

	private Button button6;

	private Button button4;

	private ComboBox ccbTarget;

	private ToolStripMenuItem cấuHìnhCommentDạoToolStripMenuItem;

	private ComboBox ccbSizeChrome;

	private ToolStripMenuItem côngCụToolStripMenuItem;

	private ToolStripMenuItem seddingLiveStreamToolStripMenuItem;

	private System.Windows.Forms.Timer timer_gv_refesh;

	private ToolStripMenuItem cấuHìnhGroupToolStripMenuItem1;

	private ToolStripMenuItem groupĐãThamGiaToolStripMenuItem;

	private ToolStripMenuItem danhSáchNhómToolStripMenuItem;

	private Button button7;

	private ToolStripMenuItem thẻẢoToolStripMenuItem;

	private Button button8;

	private ComboBox ccbLocationTinsoft;

	private ToolStripMenuItem mailToolStripMenuItem;

	private Button button9;

	private ComboBox ccbLocationTmProxy;

	private TextBox txtTmProxy;

	private RadioButton rbTMProxy;

	private ComboBox ccbTypeTMProxy;

	private ToolStripMenuItem quảnLýTKTrongBMToolStripMenuItem;

	private Button button10;

	private GroupBox groupBox2;

	private Panel panel1;

	private RadioButton rbProtonVPN;

	private NumericUpDown numProtonVPN;

	private RadioButton rb922;

	private TextBox txt922Url;

	private Label label2;

	private ImageList imageList1;

	private CheckBox cbCheckLive;

	private Label lbRowSelected;

	private ToolStripMenuItem hỗTrợToolStripMenuItem;

	private ToolStripMenuItem liênHệToolStripMenuItem;

	private ToolStripMenuItem updateToolStripMenuItem;

	private Button btnSaveData;

	private ToolStripMenuItem danhSáchTKQCToolStripMenuItem;

	private ToolStripMenuItem quảnLýPageĐốiTácToolStripMenuItem;

	public static T2 listCreditCardEntity<T0, T1, T2, T3>(T3 Name)
	{
		//IL_0007: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_002d: Expected I4, but got O
		//IL_003a: Expected O, but got I4
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0051: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_0072: Expected I4, but got O
		T1 val = (T1)string.IsNullOrWhiteSpace((string)Name);
		if (val != null)
		{
			return (T2)groupCreditCard.First().listCreditCardEntity;
		}
		T0 val2 = (T0)(-1);
		T0 val3 = (T0)0;
		while (true)
		{
			T1 val4 = (T1)((nint)val3 < groupCreditCard.Count);
			if (val4 == null)
			{
				break;
			}
			T1 val5 = (T1)groupCreditCard[(int)val3].Name.Equals((string)Name);
			if (val5 == null)
			{
				val3 = (T0)(val3 + 1);
				continue;
			}
			val2 = val3;
			break;
		}
		T1 val6 = (T1)((nint)val2 == -1);
		if (val6 != null)
		{
			return (T2)null;
		}
		return (T2)groupCreditCard[(int)val2].listCreditCardEntity;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmMain()
	{
		if (!isLogined)
		{
			AppExit();
			return;
		}
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
		Control.CheckForIllegalCrossThreadCalls = false;
		InitializeComponent<ComponentResourceManager, Container, StatusStrip, ToolStripStatusLabel, TabControl, TabPage, Panel, GroupBox, CheckBox, Button, NumericUpDown, Label, ComboBox, TextBox, RadioButton, SplitContainer, CheckedListBox, DataGridView, LinkLabel, MenuStrip, ToolStripMenuItem, ToolStripItem, object, EventArgs, int, bool, List<Process>, Process, List<int>, decimal, List<ChromeSizeEntity>.Enumerator, Exception, List<ChromeSizeEntity>, string, List<location_data_locations>.Enumerator, List<LocationTinsoftData>.Enumerator, List<FBEntity>.Enumerator, List<CreditCardEntity>, Thread, TimeSpan, DateTime, DateTime?, TimeSpan?, List<Folder>.Enumerator, List<Folder>, CheckState, ItemCheckEventArgs, List<FBEntity>, char, DataGridViewCellEventArgs, DataGridViewCellMouseEventArgs, DataGridViewColumnEventArgs, DataGridViewRowStateChangedEventArgs, ContextMenu, MenuItem, MouseEventArgs, KeyEventArgs, ImageListStreamer, LinkLabelLinkClickedEventArgs, ToolStripItemClickedEventArgs, Icon, CancelEventArgs, FormClosingEventArgs, StringBuilder, DataGridViewCheckBoxColumn, DataGridViewTextBoxColumn, List<UserAgentEntity>, List<GroupCreditCard>, List<CountryLanguage>>();
		if (!File.Exists("setting.json"))
		{
			setting = new ADSPRoject.Data.Settings();
		}
		else
		{
			setting = JsonConvert.DeserializeObject<ADSPRoject.Data.Settings>(File.ReadAllText("setting.json"));
		}
		if (!File.Exists("act_list.json"))
		{
			actList = (List<ActControl>)Activator.CreateInstance(typeof(List<ActControl>));
		}
		else
		{
			actList = JsonConvert.DeserializeObject<List<ActControl>>(File.ReadAllText("act_list.json"));
		}
		if (string.IsNullOrWhiteSpace(setting.txtProfile))
		{
			PROFILE_CHROME_UID = Application.StartupPath + "\\BROWSER_PROFILE\\";
		}
		else
		{
			PROFILE_CHROME_UID = setting.txtProfile;
		}
		if (File.Exists("proxysockssetting.json"))
		{
			proxySetting = JsonConvert.DeserializeObject<ListProxySetting>(File.ReadAllText("proxysockssetting.json"));
		}
		if (proxySetting == null)
		{
			proxySetting = new ListProxySetting();
			proxySetting.listProxy = (List<ProxySocksEntity>)Activator.CreateInstance(typeof(List<ProxySocksEntity>));
		}
		gvData.AutoGenerateColumns = false;
		apiPage = new FacebookApiPage(this);
		apiPixel = new FacebookApiPixel(this);
		tokenPagePartner = new TokenPagePartner(this);
		Text = Text + " - " + User.UserText;
	}

	public void AppExit()
	{
		Application.Exit();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void actListSaving()
	{
		try
		{
			File.WriteAllText("act_list.json", JsonConvert.SerializeObject((object)actList));
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void settingSaving()
	{
		try
		{
			File.WriteAllText("setting.json", JsonConvert.SerializeObject((object)setting));
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void cartSaving()
	{
		try
		{
			File.WriteAllText("cartgen.json", JsonConvert.SerializeObject((object)groupCreditCard));
		}
		catch
		{
		}
	}

	public void fblistSaving<T0, T1, T2>(T1 isNeedCheckTime)
	{
		//IL_0024: Expected O, but got I4
		//IL_0037: Expected O, but got I4
		try
		{
			T0 val = (T0)new Thread(_003CfblistSaving_003Eb__48_0<T1, TimeSpan, DateTime, DateTime?, TimeSpan?, string, T2, object>);
			((Thread)val).Start((object)isNeedCheckTime);
			T1 val2 = (T1)(isNeedCheckTime == null);
			if (val2 != null)
			{
				((Thread)val).Join();
			}
		}
		catch (Exception ex)
		{
			btnSavedStatus((T1)0);
			Console.WriteLine(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void btnSavedStatus<T0>(T0 isOk)
	{
		if (isOk != null)
		{
			btnSaveData.Text = "Đã lưu";
			btnSaveData.Enabled = false;
			btnSaveData.BackColor = Color.DodgerBlue;
			btnSaveData.ForeColor = Color.White;
		}
		else
		{
			btnSaveData.Text = "Lưu lỗi=>Clear cache";
			btnSaveData.Enabled = true;
			btnSaveData.BackColor = Color.Red;
			btnSaveData.ForeColor = Color.White;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe void listFolderSaving<T0, T1, T2, T3, T4, T5>()
	{
		//IL_000b: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		//IL_011c: Expected O, but got I4
		//IL_0134: Expected O, but got I4
		try
		{
			T0 val = (T0)(listFolder != null);
			if (val == null)
			{
				return;
			}
			T1 val2 = (T1)"folder.json";
			T0 val3 = (T0)(!folderDateTime.HasValue);
			if (val3 != null)
			{
				folderDateTime = ((DateTime)(T3)DateTime.Now).AddSeconds(-5.0);
			}
			T3 now = (T3)DateTime.Now;
			T4 val4 = (T4)folderDateTime;
			TimeSpan? obj;
			T5 val5 = default(T5);
			if (!((DateTime?*)(&val4))->HasValue)
			{
				*(TimeSpan?*)(&val5) = null;
				obj = val5;
			}
			else
			{
				obj = (DateTime)now - ((DateTime?*)(&val4))->GetValueOrDefault();
			}
			val5 = (T5)obj;
			T0 val6 = (T0)(((TimeSpan)(T2)((TimeSpan?*)(&val5))->Value).Seconds >= 5 && setting.cbSaveBackup);
			if (val6 != null)
			{
				folderDateTime = DateTime.Now;
				T1 destFileName = (T1)string.Format("FolderBackup\\{0}-{1}.json", val2, ((DateTime)(T3)DateTime.Now).ToString().Replace("/", "-").Replace("\\", "-")
					.Replace(":", "-"));
				T0 val7 = (T0)(!Directory.Exists("FolderBackup"));
				if (val7 != null)
				{
					Directory.CreateDirectory("FolderBackup");
				}
				T0 val8 = (T0)File.Exists((string)val2);
				if (val8 != null)
				{
					File.Copy((string)val2, (string)destFileName);
				}
			}
			File.WriteAllText((string)val2, JsonConvert.SerializeObject((object)listFolder));
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void useragentSaving()
	{
		try
		{
			File.WriteAllText("useragent.json", JsonConvert.SerializeObject((object)listUserAgent));
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvData_MouseClick<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_000e: Expected O, but got I4
		//IL_0502: Expected O, but got I4
		//IL_081b: Expected O, but got I4
		//IL_082c: Expected O, but got I4
		//IL_083d: Expected I4, but got O
		//IL_0864: Unknown result type (might be due to invalid IL or missing references)
		//IL_0867: Expected O, but got Unknown
		//IL_0878: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val == null)
		{
			return;
		}
		listClipboard.Clear();
		strClipboard = Clipboard.GetText();
		listClipboard = (List<string>)(object)((IEnumerable<T6>)(object)strClipboard.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)).ToList();
		T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
		T2 val3 = (T2)new MenuItem("Chọn dòng");
		T2 item = (T2)new MenuItem("Tick toàn bộ", (EventHandler)checkedAllSelectEvent<List<FBEntity>.Enumerator, T3, T4, EventArgs, Thread, T0, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Bỏ tick toàn bộ", (EventHandler)uncheckAllSelectEvent<List<FBEntity>.Enumerator, T3, T4, EventArgs, Thread, T0, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("------------");
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Tick dòng", (EventHandler)checkedSelectEvent<List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Bỏ tick dòng", (EventHandler)uncheckSelectEvent<List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		((Menu)val2).MenuItems.Add((MenuItem)val3);
		val3 = (T2)new MenuItem("Sắp xếp");
		item = (T2)new MenuItem("Row", (EventHandler)sortEvent<T2, T0, T4, EventArgs, T3, T6, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Name", (EventHandler)sortEvent<T2, T0, T4, EventArgs, T3, T6, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("UID", (EventHandler)sortEvent<T2, T0, T4, EventArgs, T3, T6, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Friends", (EventHandler)sortEvent<T2, T0, T4, EventArgs, T3, T6, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Group", (EventHandler)sortEvent<T2, T0, T4, EventArgs, T3, T6, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Page", (EventHandler)sortEvent<T2, T0, T4, EventArgs, T3, T6, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Status", (EventHandler)sortEvent<T2, T0, T4, EventArgs, T3, T6, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Message", (EventHandler)sortEvent<T2, T0, T4, EventArgs, T3, T6, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		((Menu)val2).MenuItems.Add((MenuItem)val3);
		item = (T2)new MenuItem("------------");
		((Menu)val2).MenuItems.Add((MenuItem)item);
		val3 = (T2)new MenuItem("Trạng thái");
		item = (T2)new MenuItem(STATUS.Ready.ToString(), (EventHandler)statusReadyEvent<List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem(STATUS.Done.ToString(), (EventHandler)statusDoneEvent<List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem(STATUS.lỗi.ToString(), (EventHandler)statuslỗiEvent<List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		((Menu)val2).MenuItems.Add((MenuItem)val3);
		val3 = (T2)new MenuItem("Copy");
		item = (T2)new MenuItem("Copy toàn bộ", (EventHandler)copyAllEvent<T6, List<FBEntity>.Enumerator, T4, EventArgs>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Copy dòng đã chọn", (EventHandler)copySelectedEvent<T6, List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Copy Json dòng đã chọn", (EventHandler)copySelectedJsonEvent<List<FBEntity>, List<DataGridViewRow>, T6, T0, T3, Exception, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Copy UID", (EventHandler)copyUIDEvent<T2, T6, List<DataGridViewRow>, T0, T3, List<adaccountsData>.Enumerator, T4, EventArgs, DataGridViewRow, char>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Copy Tên", (EventHandler)copyUIDEvent<T2, T6, List<DataGridViewRow>, T0, T3, List<adaccountsData>.Enumerator, T4, EventArgs, DataGridViewRow, char>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Copy ID tài khoản quảng cáo", (EventHandler)copyUIDEvent<T2, T6, List<DataGridViewRow>, T0, T3, List<adaccountsData>.Enumerator, T4, EventArgs, DataGridViewRow, char>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Copy Token EAAB", (EventHandler)copyTokenEvent<T3, T2, T6, List<DataGridViewRow>, T0, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Copy Token EAAG", (EventHandler)copyTokenEvent<T3, T2, T6, List<DataGridViewRow>, T0, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Copy Cookie", (EventHandler)copyTokenEvent<T3, T2, T6, List<DataGridViewRow>, T0, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Copy Lỗi", (EventHandler)copyErrorEvent<T6, List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("------------");
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Copy 2fa", (EventHandler)copy2faEvent<T3, T0, T6, T4, EventArgs, Exception, byte, char>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		((Menu)val2).MenuItems.Add((MenuItem)val3);
		val3 = (T2)new MenuItem($"Paste ({(T3)listClipboard.Count}) items");
		item = (T2)new MenuItem("Facebook UID|PASS|2FA|Cookie", (EventHandler)pasteUIDEvent<T6, T0, List<FBFlow>, T3, float, List<FBFlow>.Enumerator, List<FBFlowField>.Enumerator, T4, EventArgs, char, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Facebook Cookie", (EventHandler)pasteFaceCookieEvent<T6, T0, List<FBFlow>, T3, List<FBFlow>.Enumerator, List<FBFlowField>.Enumerator, T4, EventArgs, char, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Json", (EventHandler)pasteJsonEvent<List<FBEntity>, T0, Exception, T4, EventArgs, Thread>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Useragent", (EventHandler)pasteUseragentEvent<List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		((Menu)val2).MenuItems.Add((MenuItem)val3);
		item = (T2)new MenuItem("------------");
		((Menu)val2).MenuItems.Add((MenuItem)item);
		val3 = (T2)new MenuItem("Task");
		item = (T2)new MenuItem("Mở trình duyệt", (EventHandler)openBrowserEvent<List<DataGridViewRow>, T0, T2, T3, T6, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Đăng nhập hotmail", (EventHandler)openBrowserEvent<List<DataGridViewRow>, T0, T2, T3, T6, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		((Menu)val2).MenuItems.Add((MenuItem)val3);
		val3 = (T2)new MenuItem("Socks/Proxy", (EventHandler)pasteProxyEvent<T0, T6, T3, List<DataGridViewRow>, T4, EventArgs, DataGridViewRow, Thread, Exception>);
		((Menu)val2).MenuItems.Add((MenuItem)val3);
		item = (T2)new MenuItem("------------");
		((Menu)val2).MenuItems.Add((MenuItem)item);
		val3 = (T2)new MenuItem("FACEBOOK");
		item = (T2)new MenuItem("Đăng nhập UID", (EventHandler)openBrowserLoginFacebookEvent<List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Đăng nhập M.Facebook", (EventHandler)openBrowserLoginMFacebookEvent<List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Đăng nhập Cookie", (EventHandler)openBrowserLoginFacebookByCookieEvent<List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Đăng nhập MBasic", (EventHandler)openBrowserLoginMBasicFacebookEvent<List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Check live", checkLiveEvent);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Nhận link BM", (EventHandler)receiptBMLinkEvent<List<DataGridViewRow>, List<int>, T3, T0, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Quản lý quảng cáo", (EventHandler)adsManagerEvent<T2, List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Quản lý quảng cáo + Cookie", (EventHandler)adsManagerEvent<T2, List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Quản lý quảng cáo + M.Facebook", (EventHandler)adsManagerEvent<T2, List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Quản lý quảng cáo + MBasic", (EventHandler)adsManagerEvent<T2, List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		((Menu)val2).MenuItems.Add((MenuItem)val3);
		item = (T2)new MenuItem("------------");
		((Menu)val2).MenuItems.Add((MenuItem)item);
		val3 = (T2)new MenuItem("Di chuyển thư mục");
		T3 val4 = (T3)0;
		while (true)
		{
			T0 val5 = (T0)((nint)val4 < listFolder.Count);
			if (val5 == null)
			{
				break;
			}
			T0 val6 = (T0)(folderCheckedIndex != (nint)val4);
			if (val6 != null)
			{
				item = (T2)new MenuItem(listFolder[(int)val4].Name, (EventHandler)moveEvent<T6, List<FBEntity>, T2, T3, List<DataGridViewRow>, T0, Exception, T4, EventArgs, DataGridViewRow, Thread>);
				((Menu)val3).MenuItems.Add((MenuItem)item);
			}
			val4 = (T3)(val4 + 1);
		}
		((Menu)val2).MenuItems.Add((MenuItem)val3);
		item = (T2)new MenuItem("------------");
		((Menu)val2).MenuItems.Add((MenuItem)item);
		val3 = (T2)new MenuItem("Xóa");
		item = (T2)new MenuItem("Xóa toàn bộ", (EventHandler)removeAllEvent<T0, List<FBEntity>.Enumerator, T6, DirectoryInfo, FileInfo, T3, Exception, T4, EventArgs, Thread>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Xóa dòng đã chọn", (EventHandler)removeSelectedEvent<T0, List<DataGridViewRow>, T3, T6, DirectoryInfo, FileInfo, Exception, T4, EventArgs, DataGridViewRow, Thread>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Xóa dòng và giữ lại profile", (EventHandler)removeSelectedKeepProfileEvent<T0, List<DataGridViewRow>, T3, T4, EventArgs, DataGridViewRow, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		((Menu)val2).MenuItems.Add((MenuItem)val3);
		val3 = (T2)new MenuItem("Clear");
		item = (T2)new MenuItem("UID trùng lặp", (EventHandler)clearUIDDuplicateEvent<List<string>, T3, T0, List<string>.Enumerator, List<FBEntity>, T4, EventArgs, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Proxy/Socks", (EventHandler)clearProxyEvent<List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Useragent", (EventHandler)clearEvent<T2, List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, List<CreditCardEntity>, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Name", (EventHandler)clearNameEvent<List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Nhóm", (EventHandler)clearGroupEvent<List<DataGridViewRow>, T0, T3, T6, Exception, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Khóa nhóm", (EventHandler)clearGroupLockedEvent<List<DataGridViewRow>, T0, T3, List<GroupItem>.Enumerator, Exception, T4, EventArgs, DataGridViewRow, Thread>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Profile", (EventHandler)clearProfileEvent<List<DataGridViewRow>, T0, T3, T6, DirectoryInfo, FileInfo, Exception, T4, EventArgs, DataGridViewRow>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Token FB", (EventHandler)clearEvent<T2, List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, List<CreditCardEntity>, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Cookie", (EventHandler)clearEvent<T2, List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, List<CreditCardEntity>, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		item = (T2)new MenuItem("Cache", (EventHandler)clearEvent<T2, List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, List<CreditCardEntity>, Thread, Exception>);
		((Menu)val3).MenuItems.Add((MenuItem)item);
		((Menu)val2).MenuItems.Add((MenuItem)val3);
		item = (T2)new MenuItem("------------");
		item = (T2)new MenuItem("Cấu hình Module", (EventHandler)configFlowEvent<List<int>, List<DataGridViewRow>, T0, T3, T4, EventArgs, DataGridViewRow, Thread, Exception>);
		((Menu)val2).MenuItems.Add((MenuItem)item);
		((ContextMenu)val2).Show((Control)gvData, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteProxyEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T4 sender, T5 e)
	{
		//IL_0011: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_0106: Expected O, but got I4
		//IL_010d: Expected O, but got I4
		//IL_011a: Expected O, but got I4
		//IL_012d: Expected I4, but got O
		//IL_0185: Expected I4, but got O
		//IL_01a2: Expected I4, but got O
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		//IL_01ca: Expected O, but got I4
		//IL_01e3: Expected O, but got I4
		frmProxyImport frmProxyImport2 = new frmProxyImport(this);
		T0 val = (T0)(frmProxyImport2.ShowDialog() == DialogResult.OK);
		if (val != null)
		{
			T0 val2 = (T0)(proxySetting != null && proxySetting.listProxy != null && proxySetting.listProxy.Count > 0);
			if (val2 != null)
			{
				T1 val3 = (T1)"";
				T0 val4 = (T0)proxySetting.isProxy;
				val3 = (T1)((val4 != null) ? "proxy:" : "socks5:");
				T2 val5 = (T2)0;
				T3 val6 = (T3)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T0)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T2>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T2)((DataGridViewBand)row).Index))
					.ToList();
				T0 val7 = (T0)(((List<DataGridViewRow>)val6).Count > 0);
				if (val7 != null)
				{
					T2 val8 = (T2)0;
					while (true)
					{
						T0 val9 = (T0)((nint)val8 < ((List<DataGridViewRow>)val6).Count);
						if (val9 == null)
						{
							break;
						}
						T0 val10 = (T0)((nint)val5 >= proxySetting.listProxy.Count);
						if (val10 != null)
						{
							val5 = (T2)0;
						}
						T0 val11 = (T0)proxySetting.isRandom;
						if (val11 != null)
						{
							listFBEntity[((List<DataGridViewRow>)val6)[(int)val8].Index].Socks = (string)val3 + (string)proxySetting.listProxy[rnd.Next(0, proxySetting.listProxy.Count - 1)].ToString<T0, T1>();
						}
						else
						{
							listFBEntity[((List<DataGridViewRow>)val6)[(int)val8].Index].Socks = (string)val3 + (string)proxySetting.listProxy[(int)val5].ToString<T0, T1>();
						}
						val5 = (T2)(val5 + 1);
						val8 = (T2)(val8 + 1);
					}
				}
			}
			gvData.Refresh();
			fblistSaving<T7, T0, T8>((T0)1);
		}
		try
		{
			File.WriteAllText("proxysockssetting.json", JsonConvert.SerializeObject((object)proxySetting));
		}
		catch
		{
		}
	}

	private void pasteUseragentEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_0091: Expected I4, but got O
		//IL_00a7: Expected I4, but got O
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00bb: Expected O, but got I4
		//IL_00d1: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 != null)
		{
			T2 val3 = (T2)0;
			while (true)
			{
				T1 val4 = (T1)((nint)val3 < ((List<DataGridViewRow>)val).Count);
				if (val4 == null)
				{
					break;
				}
				T1 val5 = (T1)((nint)val3 >= listClipboard.Count);
				if (val5 != null)
				{
					break;
				}
				listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].UserAgent = listClipboard[(int)val3];
				val3 = (T2)(val3 + 1);
			}
		}
		gvData.Refresh();
		fblistSaving<T6, T1, T7>((T1)1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void moveEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T7 sender, T8 e)
	{
		//IL_0023: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_0035: Expected I4, but got O
		//IL_0047: Expected O, but got I4
		//IL_0058: Expected I4, but got O
		//IL_0077: Expected O, but got I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_0092: Expected O, but got I4
		//IL_010f: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_0133: Expected I4, but got O
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_0152: Expected O, but got I4
		//IL_016f: Expected I4, but got O
		//IL_019a: Expected I4, but got O
		//IL_01aa: Expected O, but got I4
		//IL_01b4: Expected I4, but got O
		//IL_01bf: Expected O, but got I4
		//IL_01d0: Expected I4, but got O
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01ea: Expected O, but got I4
		//IL_0212: Expected O, but got I4
		try
		{
			T0 path = (T0)string.Empty;
			T1 val = (T1)Activator.CreateInstance(typeof(T1));
			T2 val2 = (T2)sender;
			Folder folder = null;
			T3 val3 = (T3)0;
			T3 val4 = (T3)0;
			while (true)
			{
				T5 val5 = (T5)((nint)val4 < listFolder.Count);
				if (val5 == null)
				{
					break;
				}
				T5 val6 = (T5)listFolder[(int)val4].Name.Equals(((MenuItem)val2).Text);
				if (val6 != null)
				{
					folder = listFolder[(int)val4];
					val3 = val4;
					path = (T0)$"Data\\{folder.ID}.json";
					T5 val7 = (T5)File.Exists((string)path);
					if (val7 != null)
					{
						val = JsonConvert.DeserializeObject<T1>(File.ReadAllText((string)path));
						break;
					}
				}
				val4 = (T3)(val4 + 1);
			}
			T4 val8 = (T4)gvData.SelectedRows.Cast<T9>().Where((Func<T9, bool>)(object)(Func<DataGridViewRow, bool>)((T9 row) => (T5)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T9, T3>)(object)(Func<DataGridViewRow, int>)((T9 row) => (T3)((DataGridViewBand)row).Index))
				.ToList();
			T5 val9 = (T5)(((List<DataGridViewRow>)val8).Count > 0);
			if (val9 == null)
			{
				return;
			}
			T3 val10 = (T3)(((List<DataGridViewRow>)val8).Count - 1);
			while (true)
			{
				T5 val11 = (T5)((nint)val10 >= 0);
				if (val11 == null)
				{
					break;
				}
				((List<FBEntity>)val).Add(listFBEntity[((List<DataGridViewRow>)val8)[(int)val10].Index]);
				val10 = (T3)(val10 - 1);
			}
			File.WriteAllText((string)path, JsonConvert.SerializeObject((object)val));
			listFolder[(int)val3].Quanity = ((List<FBEntity>)val).Count;
			cbListFolder.Items[(int)val3] = $"{listFolder[(int)val3].Name}({(T3)((List<FBEntity>)val).Count})";
			T3 val12 = (T3)(((List<DataGridViewRow>)val8).Count - 1);
			while (true)
			{
				T5 val13 = (T5)((nint)val12 >= 0);
				if (val13 == null)
				{
					break;
				}
				listFBEntity.RemoveAt(((List<DataGridViewRow>)val8)[(int)val12].Index);
				val12 = (T3)(val12 - 1);
			}
			gvData.DataSource = null;
			gvData.DataSource = listFBEntity;
			fblistSaving<T10, T5, T6>((T5)1);
			setQuantityFolder<T3, T5, T0, TimeSpan, DateTime, DateTime?, TimeSpan?>();
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void clearUIDDuplicateEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T5 sender, T6 e)
	{
		//IL_0012: Expected O, but got I4
		//IL_0021: Expected I4, but got O
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_003e: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		//IL_00c9: Expected I4, but got O
		//IL_00dc: Expected O, but got I4
		//IL_00eb: Expected O, but got I4
		//IL_00fa: Expected I4, but got O
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_010e: Expected O, but got I4
		//IL_0146: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)0;
		while (true)
		{
			T2 val3 = (T2)((nint)val2 < listFBEntity.Count);
			if (val3 == null)
			{
				break;
			}
			((List<string>)val).Add(listFBEntity[(int)val2].UID);
			val2 = (T1)(val2 + 1);
		}
		gvData.DataSource = null;
		T1 val4 = (T1)0;
		T3 enumerator = (T3)((List<string>)val).GetEnumerator();
		try
		{
			while (((List<string>.Enumerator*)(&enumerator))->MoveNext())
			{
				string item = ((List<string>.Enumerator*)(&enumerator))->Current;
				T4 val5 = (T4)((IEnumerable<FBEntity>)listFBEntity).Where((Func<FBEntity, bool>)((FBEntity a) => (T2)a.UID.Equals(item))).ToList();
				T2 val6 = (T2)(val5 != null && ((List<FBEntity>)val5).Count > 1);
				if (val6 == null)
				{
					continue;
				}
				T2 val7 = (T2)1;
				T1 val8 = (T1)(listFBEntity.Count - 1);
				while (true)
				{
					T2 val9 = (T2)((nint)val8 >= 0);
					if (val9 == null)
					{
						break;
					}
					T2 val10 = (T2)listFBEntity[(int)val8].UID.Equals(item);
					if (val10 != null)
					{
						T2 val11 = val7;
						if (val11 != null)
						{
							val7 = (T2)0;
						}
						else
						{
							listFBEntity.RemoveAt((int)val8);
							val4 = (T1)(val4 + 1);
						}
					}
					val8 = (T1)(val8 - 1);
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<string>.Enumerator*)(&enumerator))).Dispose();
		}
		gvData.DataSource = listFBEntity;
		fblistSaving<T7, T2, T8>((T2)1);
		setQuantityFolder<T1, T2, string, TimeSpan, DateTime, DateTime?, TimeSpan?>();
		infoMessage($"Remove {val4} duplicates");
	}

	private void clearProxyEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0083: Expected I4, but got O
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00a3: Expected O, but got I4
		//IL_00b8: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 == null)
			{
				break;
			}
			listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Socks = "";
			val3 = (T2)(val3 - 1);
		}
		gvData.Refresh();
		fblistSaving<T6, T1, T7>((T1)1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void clearGroupLockedEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T5 sender, T6 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_0092: Expected I4, but got O
		//IL_00bf: Expected O, but got I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0106: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T2>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 != null)
		{
			T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				try
				{
					T3 enumerator = (T3)listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].ListGroup.GetEnumerator();
					try
					{
						while (((List<GroupItem>.Enumerator*)(&enumerator))->MoveNext())
						{
							GroupItem current = ((List<GroupItem>.Enumerator*)(&enumerator))->Current;
							T1 val5 = (T1)(current.Status == 1);
							if (val5 != null)
							{
								current.Status = 0;
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<GroupItem>.Enumerator*)(&enumerator))).Dispose();
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				val3 = (T2)(val3 - 1);
			}
		}
		fblistSaving<T8, T1, T4>((T1)1);
		infoMessage("Done!");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void clearGroupEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_0095: Expected I4, but got O
		//IL_00bc: Expected O, but got I4
		//IL_00ca: Expected O, but got I4
		//IL_00d9: Expected I4, but got O
		//IL_00e6: Expected O, but got I4
		//IL_00f7: Expected I4, but got O
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_0123: Expected O, but got I4
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		T0 val = (T0)gvData.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T2>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 != null)
		{
			T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				try
				{
					T3 groupUId = (T3)listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].GroupUId;
					T3 path = (T3)$"GroupFB\\{groupUId}.json";
					T1 val5 = (T1)File.Exists((string)path);
					if (val5 != null)
					{
						File.Delete((string)path);
					}
					T2 val6 = (T2)0;
					while (true)
					{
						T1 val7 = (T1)((nint)val6 < listGroupEntity.Count);
						if (val7 != null)
						{
							T1 val8 = (T1)listGroupEntity[(int)val6].UID.Equals((string)groupUId);
							if (val8 != null)
							{
								listGroupEntity[(int)val6].Status = frmListGroupToJoin.STATUS.Ready.ToString();
							}
							val6 = (T2)(val6 + 1);
							continue;
						}
						break;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				val3 = (T2)(val3 - 1);
			}
		}
		saveListGroupId();
		infoMessage((T3)"Done!");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void clearProfileEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 sender, T8 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_009b: Expected I4, but got O
		//IL_00b8: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_00fa: Expected O, but got I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		T0 val = (T0)gvData.SelectedRows.Cast<T9>().Where((Func<T9, bool>)(object)(Func<DataGridViewRow, bool>)((T9 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T9, T2>)(object)(Func<DataGridViewRow, int>)((T9 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 != null)
		{
			T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				try
				{
					T3 path = (T3)(PROFILE_CHROME_UID + listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].UID);
					T1 val5 = (T1)Directory.Exists((string)path);
					if (val5 != null)
					{
						T4 val6 = (T4)new DirectoryInfo((string)path);
						T5[] files = (T5[])(object)((DirectoryInfo)val6).GetFiles();
						T2 val7 = (T2)0;
						while ((nint)val7 < files.Length)
						{
							T5 val8 = (T5)((object[])(object)files)[(object)val7];
							((FileSystemInfo)val8).Delete();
							val7 = (T2)(val7 + 1);
						}
						T4[] directories = (T4[])(object)((DirectoryInfo)val6).GetDirectories();
						T2 val9 = (T2)0;
						while ((nint)val9 < directories.Length)
						{
							T4 val10 = (T4)((object[])(object)directories)[(object)val9];
							((DirectoryInfo)val10).Delete(recursive: true);
							val9 = (T2)(val9 + 1);
						}
						((FileSystemInfo)val6).Delete();
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				val3 = (T2)(val3 - 1);
			}
		}
		infoMessage((T3)"Done!");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void clearNameEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0083: Expected I4, but got O
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00a3: Expected O, but got I4
		//IL_00b8: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 != null)
		{
			T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Name = "";
				val3 = (T2)(val3 - 1);
			}
			gvData.Refresh();
			fblistSaving<T6, T1, T7>((T1)1);
		}
		infoMessage("Done!");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void clearEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T4 sender, T5 e)
	{
		//IL_006f: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		//IL_00a7: Expected I4, but got O
		//IL_00d3: Expected O, but got I4
		//IL_00e4: Expected I4, but got O
		//IL_0105: Expected I4, but got O
		//IL_0131: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		//IL_015f: Expected I4, but got O
		//IL_0180: Expected I4, but got O
		//IL_01a1: Expected I4, but got O
		//IL_01ce: Expected I4, but got O
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		//IL_01ef: Expected O, but got I4
		//IL_0208: Expected O, but got I4
		T0 val = (T0)sender;
		T1 val2 = (T1)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
		if (val3 != null)
		{
			T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T2 val5 = (T2)((nint)val4 >= 0);
				if (val5 == null)
				{
					break;
				}
				T2 val6 = (T2)((MenuItem)val).Text.Equals("Useragent");
				if (val6 != null)
				{
					listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index].UserAgent = "";
				}
				else
				{
					T2 val7 = (T2)((MenuItem)val).Text.Equals("Token FB");
					if (val7 != null)
					{
						listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index].TokenEAAB = "";
						listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index].TokenEAAG = "";
					}
					else
					{
						T2 val8 = (T2)((MenuItem)val).Text.Equals("Cookie");
						if (val8 == null)
						{
							T2 val9 = (T2)((MenuItem)val).Text.Equals("Cache");
							if (val9 != null)
							{
								listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index].addraft_fragments_2 = new addraft_fragments_2();
								listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index].fullAdsInfo = new CheckInfo();
								listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index].listCard = (List<CreditCardEntity>)Activator.CreateInstance(typeof(T7));
							}
						}
						else
						{
							listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index].Cookie = "";
						}
					}
				}
				val4 = (T3)(val4 - 1);
			}
			gvData.Refresh();
			fblistSaving<T8, T2, T9>((T2)1);
		}
		infoMessage("Done!");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void removeSelectedKeepProfileEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T3 sender, T4 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_0098: Expected I4, but got O
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00af: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_0107: Expected O, but got I4
		//IL_013b: Expected O, but got I4
		T0 val = (T0)(questioniMessage<DialogResult, string>("Are you sure?") == DialogResult.Yes);
		if (val != null)
		{
			T1 val2 = (T1)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T0)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
				.ToList();
			T0 val3 = (T0)(((List<DataGridViewRow>)val2).Count > 0);
			if (val3 != null)
			{
				T2 val4 = (T2)(((List<DataGridViewRow>)val2).Count - 1);
				while (true)
				{
					T0 val5 = (T0)((nint)val4 >= 0);
					if (val5 == null)
					{
						break;
					}
					listFBEntity.RemoveAt(((List<DataGridViewRow>)val2)[(int)val4].Index);
					val4 = (T2)(val4 - 1);
				}
			}
			T0 val6 = (T0)(listFBEntity.Count <= 0);
			if (val6 != null)
			{
				listFBEntity.Add(new FBEntity());
			}
			else
			{
				T0 val7 = (T0)(string.IsNullOrWhiteSpace(listFBEntity[0].UID) && listFBEntity.Count > 1);
				if (val7 != null)
				{
					listFBEntity.RemoveAt(0);
				}
			}
			gvData.DataSource = null;
			gvData.DataSource = listFBEntity;
			fblistSaving<T6, T0, T7>((T0)1);
			setQuantityFolder<T2, T0, string, TimeSpan, DateTime, DateTime?, TimeSpan?>();
		}
		infoMessage("Done!");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void sortEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T2 sender, T3 e)
	{
		//IL_001d: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_0087: Expected O, but got I4
		//IL_00d8: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_010c: Expected O, but got I4
		//IL_015d: Expected O, but got I4
		//IL_01ae: Expected O, but got I4
		//IL_01ff: Expected O, but got I4
		//IL_02c6: Expected O, but got I4
		//IL_02de: Expected O, but got I4
		//IL_02f7: Expected O, but got I4
		//IL_0311: Expected O, but got I4
		//IL_0362: Expected O, but got I4
		//IL_03b3: Expected O, but got I4
		//IL_0404: Expected O, but got I4
		//IL_041b: Expected O, but got I4
		//IL_0540: Expected O, but got I4
		T0 val = (T0)sender;
		isDesc = !isDesc;
		T1 val2 = (T1)isDesc;
		if (val2 == null)
		{
			T1 val3 = (T1)((MenuItem)val).Text.Equals("Row");
			if (val3 != null)
			{
				listFBEntity = listFBEntity.OrderBy((Func<FBEntity, T4>)(object)(Func<FBEntity, int>)((FBEntity a) => (T4)a.Row)).ToList();
			}
			else
			{
				T1 val4 = (T1)((MenuItem)val).Text.Equals("Name");
				if (val4 != null)
				{
					listFBEntity = listFBEntity.OrderBy((Func<FBEntity, T5>)(object)(Func<FBEntity, string>)((FBEntity a) => (T5)a.Name)).ToList();
				}
				else
				{
					T1 val5 = (T1)((MenuItem)val).Text.Equals("UID");
					if (val5 == null)
					{
						T1 val6 = (T1)((MenuItem)val).Text.Equals("Friends");
						if (val6 == null)
						{
							T1 val7 = (T1)((MenuItem)val).Text.Equals("Group");
							if (val7 != null)
							{
								listFBEntity = listFBEntity.OrderBy((Func<FBEntity, T4>)(object)(Func<FBEntity, int>)((FBEntity a) => (T4)a.Group)).ToList();
							}
							else
							{
								T1 val8 = (T1)((MenuItem)val).Text.Equals("Page");
								if (val8 != null)
								{
									listFBEntity = listFBEntity.OrderBy((Func<FBEntity, T5>)(object)(Func<FBEntity, string>)((FBEntity a) => (T5)a.Page)).ToList();
								}
								else
								{
									T1 val9 = (T1)((MenuItem)val).Text.Equals("Status");
									if (val9 != null)
									{
										listFBEntity = listFBEntity.OrderBy((Func<FBEntity, T5>)(object)(Func<FBEntity, string>)((FBEntity a) => (T5)a.Status)).ToList();
									}
									else
									{
										T1 val10 = (T1)((MenuItem)val).Text.Equals("Message");
										if (val10 != null)
										{
											listFBEntity = listFBEntity.OrderBy((Func<FBEntity, T5>)(object)(Func<FBEntity, string>)((FBEntity a) => (T5)a.Message)).ToList();
										}
									}
								}
							}
						}
						else
						{
							listFBEntity = listFBEntity.OrderBy((Func<FBEntity, T4>)(object)(Func<FBEntity, int>)((FBEntity a) => (T4)a.Friends)).ToList();
						}
					}
					else
					{
						listFBEntity = listFBEntity.OrderBy((Func<FBEntity, T5>)(object)(Func<FBEntity, string>)((FBEntity a) => (T5)a.UID)).ToList();
					}
				}
			}
		}
		else
		{
			T1 val11 = (T1)((MenuItem)val).Text.Equals("Row");
			if (val11 == null)
			{
				T1 val12 = (T1)((MenuItem)val).Text.Equals("Name");
				if (val12 == null)
				{
					T1 val13 = (T1)((MenuItem)val).Text.Equals("UID");
					if (val13 == null)
					{
						T1 val14 = (T1)((MenuItem)val).Text.Equals("Friends");
						if (val14 != null)
						{
							listFBEntity = listFBEntity.OrderByDescending((Func<FBEntity, T4>)(object)(Func<FBEntity, int>)((FBEntity a) => (T4)a.Friends)).ToList();
						}
						else
						{
							T1 val15 = (T1)((MenuItem)val).Text.Equals("Group");
							if (val15 != null)
							{
								listFBEntity = listFBEntity.OrderByDescending((Func<FBEntity, T4>)(object)(Func<FBEntity, int>)((FBEntity a) => (T4)a.Group)).ToList();
							}
							else
							{
								T1 val16 = (T1)((MenuItem)val).Text.Equals("Page");
								if (val16 != null)
								{
									listFBEntity = listFBEntity.OrderByDescending((Func<FBEntity, T5>)(object)(Func<FBEntity, string>)((FBEntity a) => (T5)a.Page)).ToList();
								}
								else
								{
									T1 val17 = (T1)((MenuItem)val).Text.Equals("Status");
									if (val17 == null)
									{
										T1 val18 = (T1)((MenuItem)val).Text.Equals("Message");
										if (val18 != null)
										{
											listFBEntity = listFBEntity.OrderByDescending((Func<FBEntity, T5>)(object)(Func<FBEntity, string>)((FBEntity a) => (T5)a.Message)).ToList();
										}
									}
									else
									{
										listFBEntity = listFBEntity.OrderByDescending((Func<FBEntity, T5>)(object)(Func<FBEntity, string>)((FBEntity a) => (T5)a.Status)).ToList();
									}
								}
							}
						}
					}
					else
					{
						listFBEntity = listFBEntity.OrderByDescending((Func<FBEntity, T5>)(object)(Func<FBEntity, string>)((FBEntity a) => (T5)a.UID)).ToList();
					}
				}
				else
				{
					listFBEntity = listFBEntity.OrderByDescending((Func<FBEntity, T5>)(object)(Func<FBEntity, string>)((FBEntity a) => (T5)a.Name)).ToList();
				}
			}
			else
			{
				listFBEntity = listFBEntity.OrderByDescending((Func<FBEntity, T4>)(object)(Func<FBEntity, int>)((FBEntity a) => (T4)a.Row)).ToList();
			}
		}
		fblistSaving<T6, T1, T7>((T1)1);
		gvData.DataSource = null;
		gvData.DataSource = listFBEntity;
	}

	private void statusReadyEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0083: Expected I4, but got O
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00ae: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 != null)
		{
			T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Status = STATUS.Ready.ToString();
				val3 = (T2)(val3 - 1);
			}
		}
		gvData.Refresh();
		fblistSaving<T6, T1, T7>((T1)1);
	}

	private void statusDoneEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0083: Expected I4, but got O
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00ae: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 != null)
		{
			T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Status = STATUS.Done.ToString();
				val3 = (T2)(val3 - 1);
			}
		}
		gvData.Refresh();
		fblistSaving<T6, T1, T7>((T1)1);
	}

	private void statuslỗiEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_0083: Expected I4, but got O
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00ae: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 != null)
		{
			T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Status = STATUS.lỗi.ToString();
				val3 = (T2)(val3 - 1);
			}
		}
		gvData.Refresh();
		fblistSaving<T6, T1, T7>((T1)1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void removeAllEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T7 sender, T8 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_008c: Expected O, but got I4
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00f7: Expected O, but got I4
		//IL_0138: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		T0 val = (T0)(questioniMessage<DialogResult, T2>((T2)"Are you sure?") == DialogResult.Yes);
		if (val == null)
		{
			return;
		}
		try
		{
			T1 enumerator = (T1)listFBEntity.GetEnumerator();
			try
			{
				while (((List<FBEntity>.Enumerator*)(&enumerator))->MoveNext())
				{
					FBEntity current = ((List<FBEntity>.Enumerator*)(&enumerator))->Current;
					T2 path = (T2)(PROFILE_CHROME_UID + current.UID);
					T0 val2 = (T0)Directory.Exists((string)path);
					if (val2 != null)
					{
						T3 val3 = (T3)new DirectoryInfo((string)path);
						T4[] files = (T4[])(object)((DirectoryInfo)val3).GetFiles();
						T5 val4 = (T5)0;
						while ((nint)val4 < files.Length)
						{
							T4 val5 = (T4)((object[])(object)files)[(object)val4];
							((FileSystemInfo)val5).Delete();
							val4 = (T5)(val4 + 1);
						}
						T3[] directories = (T3[])(object)((DirectoryInfo)val3).GetDirectories();
						T5 val6 = (T5)0;
						while ((nint)val6 < directories.Length)
						{
							T3 val7 = (T3)((object[])(object)directories)[(object)val6];
							((DirectoryInfo)val7).Delete(recursive: true);
							val6 = (T5)(val6 + 1);
						}
					}
				}
			}
			finally
			{
				((IDisposable)(*(List<FBEntity>.Enumerator*)(&enumerator))).Dispose();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		listFBEntity.Clear();
		T0 val8 = (T0)(listFBEntity.Count <= 0);
		if (val8 != null)
		{
			listFBEntity.Add(new FBEntity());
		}
		else
		{
			T0 val9 = (T0)(string.IsNullOrWhiteSpace(listFBEntity[0].UID) && listFBEntity.Count > 1);
			if (val9 != null)
			{
				listFBEntity.RemoveAt(0);
			}
		}
		gvData.ClearSelection();
		gvData.DataSource = null;
		gvData.DataSource = listFBEntity;
		fblistSaving<T9, T0, T6>((T0)1);
		setQuantityFolder<T5, T0, T2, TimeSpan, DateTime, DateTime?, TimeSpan?>();
	}

	private void configFlowEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T4 sender, T5 e)
	{
		//IL_0078: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		//IL_0090: Expected I4, but got O
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00aa: Expected O, but got I4
		//IL_00c1: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
		if (val3 != null)
		{
			T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T2 val5 = (T2)((nint)val4 >= 0);
				if (val5 == null)
				{
					break;
				}
				((List<int>)val).Add(((List<DataGridViewRow>)val2)[(int)val4].Index);
				val4 = (T3)(val4 - 1);
			}
		}
		frmModule frmModule2 = new frmModule(this, (List<int>)val);
		T2 val6 = (T2)(frmModule2.ShowDialog() == DialogResult.OK);
		if (val6 != null)
		{
			fblistSaving<T7, T2, T8>((T2)1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void removeSelectedEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T7 sender, T8 e)
	{
		//IL_000f: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		//IL_00b0: Expected I4, but got O
		//IL_00cf: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0112: Expected O, but got I4
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0157: Expected I4, but got O
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_017d: Expected O, but got I4
		//IL_01ac: Expected O, but got I4
		//IL_01f2: Expected O, but got I4
		T0 val = (T0)(questioniMessage<DialogResult, T3>((T3)"Are you sure?") == DialogResult.Yes);
		if (val == null)
		{
			return;
		}
		T1 val2 = (T1)gvData.SelectedRows.Cast<T9>().Where((Func<T9, bool>)(object)(Func<DataGridViewRow, bool>)((T9 row) => (T0)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T9, T2>)(object)(Func<DataGridViewRow, int>)((T9 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T0 val3 = (T0)(((List<DataGridViewRow>)val2).Count > 0);
		if (val3 != null)
		{
			T2 val4 = (T2)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T0 val5 = (T0)((nint)val4 >= 0);
				if (val5 == null)
				{
					break;
				}
				try
				{
					T3 path = (T3)(PROFILE_CHROME_UID + listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index].UID);
					T0 val6 = (T0)Directory.Exists((string)path);
					if (val6 != null)
					{
						T4 val7 = (T4)new DirectoryInfo((string)path);
						T5[] files = (T5[])(object)((DirectoryInfo)val7).GetFiles();
						T2 val8 = (T2)0;
						while ((nint)val8 < files.Length)
						{
							T5 val9 = (T5)((object[])(object)files)[(object)val8];
							((FileSystemInfo)val9).Delete();
							val8 = (T2)(val8 + 1);
						}
						T4[] directories = (T4[])(object)((DirectoryInfo)val7).GetDirectories();
						T2 val10 = (T2)0;
						while ((nint)val10 < directories.Length)
						{
							T4 val11 = (T4)((object[])(object)directories)[(object)val10];
							((DirectoryInfo)val11).Delete(recursive: true);
							val10 = (T2)(val10 + 1);
						}
						((FileSystemInfo)val7).Delete();
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				listFBEntity.RemoveAt(((List<DataGridViewRow>)val2)[(int)val4].Index);
				val4 = (T2)(val4 - 1);
			}
		}
		T0 val12 = (T0)(listFBEntity.Count <= 0);
		if (val12 == null)
		{
			T0 val13 = (T0)(string.IsNullOrWhiteSpace(listFBEntity[0].UID) && listFBEntity.Count > 1);
			if (val13 != null)
			{
				listFBEntity.RemoveAt(0);
			}
		}
		else
		{
			listFBEntity.Add(new FBEntity());
		}
		gvData.DataSource = null;
		gvData.DataSource = listFBEntity;
		fblistSaving<T10, T0, T6>((T0)1);
		setQuantityFolder<T2, T0, T3, TimeSpan, DateTime, DateTime?, TimeSpan?>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void copyAllEvent<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		Clipboard.Clear();
		T0 val = (T0)"";
		T1 enumerator = (T1)listFBEntity.GetEnumerator();
		try
		{
			while (((List<FBEntity>.Enumerator*)(&enumerator))->MoveNext())
			{
				FBEntity current = ((List<FBEntity>.Enumerator*)(&enumerator))->Current;
				val = (T0)((string)val + $"{(T2)current.UID}|{(T2)current.Password}|{(T2)current.Code2FA}|{(T2)current.Status}|{(T2)current.Note}|{(T2)current.Email}|{(T2)current.EmailPassword}" + Environment.NewLine);
			}
		}
		finally
		{
			((IDisposable)(*(List<FBEntity>.Enumerator*)(&enumerator))).Dispose();
		}
		Clipboard.SetText((string)val);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void copyErrorEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0073: Expected O, but got I4
		//IL_007f: Expected O, but got I4
		//IL_008e: Expected I4, but got O
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00c5: Expected O, but got I4
		Clipboard.Clear();
		T0 val = (T0)"";
		T1 val2 = (T1)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
		if (val3 != null)
		{
			T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T2 val5 = (T2)((nint)val4 >= 0);
				if (val5 == null)
				{
					break;
				}
				FBEntity fBEntity = listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index];
				val = (T0)((string)val + $"{fBEntity.Error}" + Environment.NewLine);
				val4 = (T3)(val4 - 1);
			}
		}
		Clipboard.SetText((string)val);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void copyUIDEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T6 sender, T7 e)
	{
		//IL_007a: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		//IL_009d: Expected I4, but got O
		//IL_00bc: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		//IL_0195: Expected O, but got I4
		//IL_01c1: Expected O, but got I4
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		//IL_01f0: Expected O, but got I4
		//IL_01ff: Expected O, but got I4
		//IL_020f: Expected O, but got I4
		T0 val = (T0)sender;
		Clipboard.Clear();
		T1 val2 = (T1)"";
		T2 val3 = (T2)gvData.SelectedRows.Cast<T8>().Where((Func<T8, bool>)(object)(Func<DataGridViewRow, bool>)((T8 row) => (T3)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T8, T4>)(object)(Func<DataGridViewRow, int>)((T8 row) => (T4)((DataGridViewBand)row).Index))
			.ToList();
		T3 val4 = (T3)(((List<DataGridViewRow>)val3).Count > 0);
		if (val4 != null)
		{
			T4 val5 = (T4)(((List<DataGridViewRow>)val3).Count - 1);
			while (true)
			{
				T3 val6 = (T3)((nint)val5 >= 0);
				if (val6 == null)
				{
					break;
				}
				FBEntity fBEntity = listFBEntity[((List<DataGridViewRow>)val3)[(int)val5].Index];
				T3 val7 = (T3)((MenuItem)val).Text.Equals("Copy ID tài khoản quảng cáo");
				if (val7 != null)
				{
					T3 val8 = (T3)(fBEntity.fullAdsInfo != null && fBEntity.fullAdsInfo.adaccounts != null && fBEntity.fullAdsInfo.adaccounts.data != null && fBEntity.fullAdsInfo.adaccounts.data.Count > 0);
					if (val8 != null)
					{
						T5 enumerator = (T5)fBEntity.fullAdsInfo.adaccounts.data.GetEnumerator();
						try
						{
							while (((List<adaccountsData>.Enumerator*)(&enumerator))->MoveNext())
							{
								adaccountsData current = ((List<adaccountsData>.Enumerator*)(&enumerator))->Current;
								val2 = (T1)((string)val2 + current.id.Replace("act_", "") + "|");
							}
						}
						finally
						{
							((IDisposable)(*(List<adaccountsData>.Enumerator*)(&enumerator))).Dispose();
						}
					}
				}
				else
				{
					T3 val9 = (T3)((MenuItem)val).Text.Equals("Copy Tên");
					if (val9 != null)
					{
						T3 val10 = (T3)(!string.IsNullOrEmpty((string)val2));
						if (val10 != null)
						{
							val2 = (T1)((string)val2 + "|");
						}
						val2 = (T1)((string)val2 + fBEntity.Name);
					}
					else
					{
						T3 val11 = (T3)(!string.IsNullOrEmpty((string)val2));
						if (val11 != null)
						{
							val2 = (T1)((string)val2 + "|");
						}
						val2 = (T1)((string)val2 + fBEntity.UID);
					}
				}
				val5 = (T4)(val5 - 1);
			}
		}
		T3 val12 = (T3)string.IsNullOrWhiteSpace((string)val2);
		if (val12 == null)
		{
			T3 val13 = (T3)((nint)((IEnumerable<T9>)val2).Last() == 124);
			if (val13 != null)
			{
				val2 = (T1)((string)val2).Substring(0, ((string)val2).Length - 1);
			}
		}
		else
		{
			val2 = (T1)"null";
		}
		Clipboard.SetText((string)val2);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void copyTokenEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_0002: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_0037: Expected O, but got I4
		//IL_004e: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		//IL_00dd: Expected O, but got I4
		//IL_00f0: Expected I4, but got O
		//IL_0102: Expected O, but got I4
		//IL_010c: Expected O, but got I4
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_018c: Expected O, but got I4
		T0 val = (T0)0;
		T1 val2 = (T1)((sender is T1) ? sender : null);
		T4 val3 = (T4)((MenuItem)val2).Text.Equals("Copy Cookie");
		if (val3 != null)
		{
			val = (T0)2;
		}
		else
		{
			T4 val4 = (T4)((MenuItem)val2).Text.Equals("Copy Token EAAB");
			if (val4 == null)
			{
				T4 val5 = (T4)((MenuItem)val2).Text.Equals("Copy Token EAAG");
				if (val5 != null)
				{
					val = (T0)1;
				}
			}
			else
			{
				val = (T0)0;
			}
		}
		Clipboard.Clear();
		T2 val6 = (T2)"";
		T3 val7 = (T3)gvData.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T4)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T0>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T0)((DataGridViewBand)row).Index))
			.ToList();
		T4 val8 = (T4)(((List<DataGridViewRow>)val7).Count > 0);
		if (val8 != null)
		{
			T0 val9 = (T0)(((List<DataGridViewRow>)val7).Count - 1);
			while (true)
			{
				T4 val10 = (T4)((nint)val9 >= 0);
				if (val10 == null)
				{
					break;
				}
				FBEntity fBEntity = listFBEntity[((List<DataGridViewRow>)val7)[(int)val9].Index];
				T4 val11 = (T4)(val == null);
				if (val11 == null)
				{
					T4 val12 = (T4)((nint)val == 1);
					val6 = (T2)((val12 == null) ? ((string)val6 + $"{fBEntity.Cookie}" + Environment.NewLine) : ((string)val6 + $"{fBEntity.Cookie}|{fBEntity.TokenEAAG}" + Environment.NewLine));
				}
				else
				{
					val6 = (T2)((string)val6 + $"{fBEntity.Cookie}|{fBEntity.TokenEAAB}" + Environment.NewLine);
				}
				val9 = (T0)(val9 - 1);
			}
		}
		Clipboard.SetText((string)val6);
	}

	private void copySelectedEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0073: Expected O, but got I4
		//IL_007f: Expected O, but got I4
		//IL_008e: Expected I4, but got O
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00ba: Expected O, but got I4
		Clipboard.Clear();
		T0 val = (T0)"";
		T1 val2 = (T1)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
		if (val3 != null)
		{
			T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T2 val5 = (T2)((nint)val4 >= 0);
				if (val5 == null)
				{
					break;
				}
				FBEntity fBEntity = listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index];
				val = (T0)((string)val + fBEntity.FullInfo + Environment.NewLine);
				val4 = (T3)(val4 - 1);
			}
		}
		Clipboard.SetText((string)val);
	}

	private void copySelectedJsonEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T6 sender, T7 e)
	{
		//IL_007e: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_0094: Expected I4, but got O
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00ba: Expected O, but got I4
		try
		{
			Clipboard.Clear();
			T0 val = (T0)Activator.CreateInstance(typeof(T0));
			T1 val2 = (T1)gvData.SelectedRows.Cast<T8>().Where((Func<T8, bool>)(object)(Func<DataGridViewRow, bool>)((T8 row) => (T3)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T8, T4>)(object)(Func<DataGridViewRow, int>)((T8 row) => (T4)((DataGridViewBand)row).Index))
				.ToList();
			T3 val3 = (T3)(((List<DataGridViewRow>)val2).Count > 0);
			if (val3 != null)
			{
				T4 val4 = (T4)0;
				while (true)
				{
					T3 val5 = (T3)((nint)val4 < ((List<DataGridViewRow>)val2).Count);
					if (val5 == null)
					{
						break;
					}
					FBEntity item = listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index];
					((List<FBEntity>)val).Add(item);
					val4 = (T4)(val4 + 1);
				}
			}
			T2 val6 = (T2)JsonConvert.SerializeObject((object)val);
			Clipboard.SetText((string)val6);
		}
		catch (Exception ex)
		{
			errorMessage((T2)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void copySelectedLinkRivalEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_0074: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_0096: Expected I4, but got O
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c2: Expected O, but got I4
		try
		{
			Clipboard.Clear();
			T0 val = (T0)"";
			T1 val2 = (T1)gvData.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T3>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T3)((DataGridViewBand)row).Index))
				.ToList();
			T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
			if (val3 != null)
			{
				T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count - 1);
				while (true)
				{
					T2 val5 = (T2)((nint)val4 >= 0);
					if (val5 == null)
					{
						break;
					}
					val = (T0)((string)val + $"{listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index].RivalLink}" + Environment.NewLine);
					val4 = (T3)(val4 - 1);
				}
			}
			Clipboard.SetText((string)val);
		}
		catch (Exception ex)
		{
			errorMessage((T0)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void pasteShopeeEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T6 sender, T7 e)
	{
		//IL_0027: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_029b: Expected O, but got I4
		strClipboard = Clipboard.GetText();
		T0[] array = (T0[])(object)strClipboard.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		FBEntity fBEntity = null;
		T1 val = (T1)0;
		T2 val2 = (T2)Activator.CreateInstance(typeof(T2));
		T1 val3 = (T1)File.Exists("module.json");
		if (val3 != null)
		{
			val2 = JsonConvert.DeserializeObject<T2>(File.ReadAllText("module.json"));
			T1 val4 = (T1)(val2 == null);
			if (val4 != null)
			{
				val2 = (T2)Activator.CreateInstance(typeof(T2));
			}
		}
		T0[] array2 = array;
		T3 val5 = (T3)0;
		while ((nint)val5 < array2.Length)
		{
			T0 val6 = (T0)((object[])(object)array2)[(object)val5];
			T0 val7 = (T0)((string)val6).Replace("\t", "|");
			T1 val8 = (T1)(!string.IsNullOrEmpty((string)val7) && ((string)val7).Contains("|"));
			if (val8 != null)
			{
				val = (T1)1;
				fBEntity = new FBEntity();
				fBEntity.Select = true;
				fBEntity.Folder_Id = listFolder[folderCheckedIndex].ID;
				fBEntity.Flow = (List<FBFlow>)Activator.CreateInstance(typeof(T2));
				T4 enumerator = (T4)((List<FBFlow>)val2).GetEnumerator();
				try
				{
					while (((List<FBFlow>.Enumerator*)(&enumerator))->MoveNext())
					{
						FBFlow current = ((List<FBFlow>.Enumerator*)(&enumerator))->Current;
						FBFlow fBFlow = new FBFlow();
						fBFlow.Flow_Name = current.Flow_Name;
						T5 enumerator2 = (T5)current.Filed.GetEnumerator();
						try
						{
							while (((List<FBFlowField>.Enumerator*)(&enumerator2))->MoveNext())
							{
								FBFlowField current2 = ((List<FBFlowField>.Enumerator*)(&enumerator2))->Current;
								fBFlow.Filed.Add(new FBFlowField
								{
									key = current2.key,
									type = current2.type,
									value = current2.value
								});
							}
						}
						finally
						{
							((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator2))).Dispose();
						}
						fBEntity.Flow.Add(fBFlow);
					}
				}
				finally
				{
					((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator))).Dispose();
				}
				fBEntity.Shopee_UserName = ((string)val7).Split((char[])(object)new T8[1] { (T8)124 })[0];
				fBEntity.Shopee_Password = ((string)val7).Split((char[])(object)new T8[1] { (T8)124 })[1];
				fBEntity.UID = ((string)val7).Split((char[])(object)new T8[1] { (T8)124 })[0];
				fBEntity.Password = ((string)val7).Split((char[])(object)new T8[1] { (T8)124 })[1];
				fBEntity.Shopee_Status = STATUS.Ready.ToString();
				fBEntity.Status = STATUS.Ready.ToString();
				listFBEntity.Add(fBEntity);
			}
			val5 = (T3)(val5 + 1);
		}
		listFolder[folderCheckedIndex].Quanity = listFBEntity.Count;
		loadData<T1, T3>();
		fblistSaving<T9, T1, T10>((T1)1);
		setQuantityFolder<T3, T1, T0, TimeSpan, DateTime, DateTime?, TimeSpan?>();
		T1 val9 = val;
		if (val9 != null)
		{
			new Thread(loadToServer).Start();
		}
	}

	private void pasteJsonEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_002d: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		try
		{
			strClipboard = "";
			strClipboard = Clipboard.GetText();
			T0 collection = JsonConvert.DeserializeObject<T0>(strClipboard);
			T1 val = (T1)(listFBEntity != null);
			if (val != null)
			{
				listFBEntity.AddRange((IEnumerable<FBEntity>)collection);
				fblistSaving<T5, T1, T2>((T1)1);
				loadData<T1, int>();
			}
		}
		catch (Exception ex)
		{
			errorMessage(ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void pasteFaceCookieEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T6 sender, T7 e)
	{
		//IL_0027: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_00f5: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018e: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		//IL_02c5: Expected O, but got I4
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_02f9: Expected O, but got I4
		//IL_0304: Expected O, but got I4
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_0383: Expected O, but got I4
		strClipboard = Clipboard.GetText();
		T0[] array = (T0[])(object)strClipboard.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		FBEntity fBEntity = null;
		T1 val = (T1)0;
		T2 val2 = (T2)Activator.CreateInstance(typeof(T2));
		T1 val3 = (T1)File.Exists("module.json");
		if (val3 != null)
		{
			val2 = JsonConvert.DeserializeObject<T2>(File.ReadAllText("module.json"));
			T1 val4 = (T1)(val2 == null);
			if (val4 != null)
			{
				val2 = (T2)Activator.CreateInstance(typeof(T2));
			}
		}
		T0 val5 = (T0)"";
		T0[] array2 = array;
		T3 val6 = (T3)0;
		while ((nint)val6 < array2.Length)
		{
			T0 val7 = (T0)((object[])(object)array2)[(object)val6];
			val5 = val7;
			T1 val8 = (T1)(!string.IsNullOrEmpty((string)val5));
			if (val8 != null)
			{
				val5 = (T0)((string)val5).Replace("\t", "|");
				fBEntity = new FBEntity();
				T0[] array3 = (T0[])(object)((string)val5).Split((char[])(object)new T8[1] { (T8)124 });
				T3 val9 = (T3)0;
				while ((nint)val9 < array3.Length)
				{
					T0 val10 = (T0)((object[])(object)array3)[(object)val9];
					T1 val11 = (T1)((string)val10).ToLower().Contains("c_user");
					if (val11 == null)
					{
						T1 val12 = (T1)(((string)val10).ToLower().Contains("mozilla") || ((string)val10).ToLower().Contains("gecko") || ((string)val10).ToLower().Contains("safari") || ((string)val10).ToLower().Contains("applewebKit"));
						if (val12 == null)
						{
							fBEntity.Note = ((string)val10).Trim();
						}
						else
						{
							fBEntity.UserAgent = ((string)val10).Trim();
						}
					}
					else
					{
						fBEntity.Cookie = ((string)val10).Trim();
					}
					val9 = (T3)(val9 + 1);
				}
				val = (T1)1;
				fBEntity.Select = false;
				fBEntity.Folder_Id = listFolder[folderCheckedIndex].ID;
				fBEntity.Flow = (List<FBFlow>)Activator.CreateInstance(typeof(T2));
				T4 enumerator = (T4)((List<FBFlow>)val2).GetEnumerator();
				try
				{
					while (((List<FBFlow>.Enumerator*)(&enumerator))->MoveNext())
					{
						FBFlow current = ((List<FBFlow>.Enumerator*)(&enumerator))->Current;
						FBFlow fBFlow = new FBFlow();
						fBFlow.Flow_Name = current.Flow_Name;
						T5 enumerator2 = (T5)current.Filed.GetEnumerator();
						try
						{
							while (((List<FBFlowField>.Enumerator*)(&enumerator2))->MoveNext())
							{
								FBFlowField current2 = ((List<FBFlowField>.Enumerator*)(&enumerator2))->Current;
								fBFlow.Filed.Add(new FBFlowField
								{
									key = current2.key,
									type = current2.type,
									value = current2.value
								});
							}
						}
						finally
						{
							((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator2))).Dispose();
						}
						fBEntity.Flow.Add(fBFlow);
					}
				}
				finally
				{
					((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator))).Dispose();
				}
				T0 val13 = (T0)"";
				T0[] array4 = (T0[])(object)fBEntity.Cookie.Split((char[])(object)new T8[1] { (T8)59 });
				T3 val14 = (T3)0;
				while ((nint)val14 < array4.Length)
				{
					T0 val15 = (T0)((object[])(object)array4)[(object)val14];
					T1 val16 = (T1)((string)val15).ToLower().Contains("c_user");
					if (val16 == null)
					{
						val14 = (T3)(val14 + 1);
						continue;
					}
					val13 = ((IEnumerable<T0>)(object)((string)val15).Split((char[])(object)new T8[1] { (T8)61 })).Last();
					break;
				}
				T0 val17 = RandomString<T0, T3, T8>((T3)10);
				T1 val18 = (T1)string.IsNullOrWhiteSpace((string)val13);
				if (val18 == null)
				{
					fBEntity.UID = (string)val13;
				}
				else
				{
					fBEntity.UID = (string)val17;
				}
				fBEntity.Password = (string)val17;
				fBEntity.Status = STATUS.Ready.ToString();
				listFBEntity.Add(fBEntity);
			}
			val6 = (T3)(val6 + 1);
		}
		listFolder[folderCheckedIndex].Quanity = listFBEntity.Count;
		loadData<T1, T3>();
		fblistSaving<T9, T1, T10>((T1)1);
		setQuantityFolder<T3, T1, T0, TimeSpan, DateTime, DateTime?, TimeSpan?>();
		T1 val19 = val;
		if (val19 != null)
		{
			new Thread(loadToServer).Start();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void pasteUIDEvent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T7 sender, T8 e)
	{
		//IL_0027: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_005f: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_01c3: Expected O, but got F4
		//IL_01da: Expected O, but got I4
		//IL_0230: Expected O, but got I4
		//IL_0251: Expected O, but got I4
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_028f: Expected O, but got I4
		//IL_02a3: Expected O, but got I4
		//IL_02c1: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		//IL_0348: Expected O, but got I4
		//IL_038f: Expected O, but got I4
		//IL_03b5: Expected O, but got I4
		//IL_03dd: Expected O, but got I4
		//IL_0413: Expected O, but got I4
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Expected O, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Expected O, but got Unknown
		//IL_04ff: Expected O, but got I4
		strClipboard = Clipboard.GetText();
		T0[] array = (T0[])(object)strClipboard.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		FBEntity fBEntity = null;
		T1 val = (T1)0;
		T2 val2 = (T2)Activator.CreateInstance(typeof(T2));
		T1 val3 = (T1)File.Exists("module.json");
		if (val3 != null)
		{
			val2 = JsonConvert.DeserializeObject<T2>(File.ReadAllText("module.json"));
			T1 val4 = (T1)(val2 == null);
			if (val4 != null)
			{
				val2 = (T2)Activator.CreateInstance(typeof(T2));
			}
		}
		T0[] array2 = array;
		T3 val5 = (T3)0;
		while ((nint)val5 < array2.Length)
		{
			T0 val6 = (T0)((object[])(object)array2)[(object)val5];
			T0 val7 = (T0)((string)val6).Replace("\t", "|");
			T1 val8 = (T1)(!string.IsNullOrEmpty((string)val7) && ((string)val7).Contains("|"));
			if (val8 != null)
			{
				val = (T1)1;
				fBEntity = new FBEntity();
				fBEntity.Select = false;
				fBEntity.Folder_Id = listFolder[folderCheckedIndex].ID;
				fBEntity.Flow = (List<FBFlow>)Activator.CreateInstance(typeof(T2));
				T5 enumerator = (T5)((List<FBFlow>)val2).GetEnumerator();
				try
				{
					while (((List<FBFlow>.Enumerator*)(&enumerator))->MoveNext())
					{
						FBFlow current = ((List<FBFlow>.Enumerator*)(&enumerator))->Current;
						FBFlow fBFlow = new FBFlow();
						fBFlow.Flow_Name = current.Flow_Name;
						T6 enumerator2 = (T6)current.Filed.GetEnumerator();
						try
						{
							while (((List<FBFlowField>.Enumerator*)(&enumerator2))->MoveNext())
							{
								FBFlowField current2 = ((List<FBFlowField>.Enumerator*)(&enumerator2))->Current;
								fBFlow.Filed.Add(new FBFlowField
								{
									key = current2.key,
									type = current2.type,
									value = current2.value
								});
							}
						}
						finally
						{
							((IDisposable)(*(List<FBFlowField>.Enumerator*)(&enumerator2))).Dispose();
						}
						fBEntity.Flow.Add(fBFlow);
					}
				}
				finally
				{
					((IDisposable)(*(List<FBFlow>.Enumerator*)(&enumerator))).Dispose();
				}
				T4 result = (T4)0f;
				T0[] array3 = (T0[])(object)((string)val7).Split((char[])(object)new T9[1] { (T9)124 });
				T3 val9 = (T3)0;
				while ((nint)val9 < array3.Length)
				{
					T0 val10 = (T0)((object[])(object)array3)[(object)val9];
					T1 val11 = (T1)((string.IsNullOrEmpty(fBEntity.UID) && float.TryParse(((string)val10).Replace(" ", ""), out *(float*)(&result))) || (((string)val10).Contains("@") && string.IsNullOrEmpty(fBEntity.UID)));
					if (val11 == null)
					{
						T1 val12 = (T1)(!string.IsNullOrEmpty(fBEntity.UID) && string.IsNullOrEmpty(fBEntity.Password));
						if (val12 != null)
						{
							fBEntity.Password = (string)val10;
							break;
						}
					}
					else
					{
						fBEntity.UID = ((string)val10).Trim();
					}
					val9 = (T3)(val9 + 1);
				}
				T1 val13 = (T1)(!string.IsNullOrEmpty(fBEntity.UID));
				if (val13 != null)
				{
					T1 val14 = (T1)string.IsNullOrWhiteSpace(fBEntity.Cookie);
					if (val14 != null)
					{
						T0[] array4 = (T0[])(object)((string)val7).Split((char[])(object)new T9[1] { (T9)124 });
						T3 val15 = (T3)0;
						while ((nint)val15 < array4.Length)
						{
							T0 val16 = (T0)((object[])(object)array4)[(object)val15];
							T1 val17 = (T1)(string.IsNullOrWhiteSpace(fBEntity.Cookie) && ((string)val16).Contains("c_user"));
							if (val17 != null)
							{
								fBEntity.Cookie = (string)val16;
							}
							else
							{
								T1 val18 = (T1)(string.IsNullOrWhiteSpace(fBEntity.Code2FA) && !string.IsNullOrWhiteSpace((string)val16) && (((string)val16).Replace(" ", "").Length == 32 || ((string)val16).ToLower().Contains("2fa")));
								if (val18 == null)
								{
									T1 val19 = (T1)(string.IsNullOrWhiteSpace(fBEntity.UserAgent) && (((string)val16).Contains("Mozilla") || ((string)val16).Contains("Chrome") || ((string)val16).Contains("Safari")));
									if (val19 == null)
									{
										T1 val20 = (T1)(string.IsNullOrWhiteSpace(fBEntity.Email) && ((string)val16).Contains("@"));
										if (val20 != null)
										{
											T1 val21 = (T1)(!((string)val16).Equals(fBEntity.Password) && !((string)val16).Equals(fBEntity.UID));
											if (val21 != null)
											{
												fBEntity.Email = ((string)val16).Trim();
											}
										}
										else
										{
											T1 val22 = (T1)(!string.IsNullOrWhiteSpace(fBEntity.Email) && string.IsNullOrWhiteSpace(fBEntity.EmailPassword));
											if (val22 != null)
											{
												fBEntity.EmailPassword = ((string)val16).Trim();
											}
										}
									}
									else
									{
										fBEntity.UserAgent = (string)val16;
									}
								}
								else
								{
									fBEntity.Code2FA = ((string)val16).ToLower();
									fBEntity.Code2FA = fBEntity.Code2FA.Replace("2fa", "").Replace(":", "");
									fBEntity.Code2FA = fBEntity.Code2FA.ToUpper();
								}
							}
							val15 = (T3)(val15 + 1);
						}
					}
					fBEntity.UserAgent = "";
					fBEntity.Status = STATUS.Ready.ToString();
					fBEntity.FullInfo = (string)val7;
					listFBEntity.Add(fBEntity);
				}
			}
			val5 = (T3)(val5 + 1);
		}
		listFolder[folderCheckedIndex].Quanity = listFBEntity.Count;
		loadData<T1, T3>();
		fblistSaving<T10, T1, T11>((T1)1);
		setQuantityFolder<T3, T1, T0, TimeSpan, DateTime, DateTime?, TimeSpan?>();
		T1 val23 = val;
		if (val23 != null)
		{
			new Thread(loadToServer).Start();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void setQuantityFolder<T0, T1, T2, T3, T4, T5, T6>()
	{
		//IL_0069: Expected O, but got I4
		listFolder[folderCheckedIndex].Quanity = listFBEntity.Count;
		cbListFolder.Items[folderCheckedIndex] = $"{listFolder[folderCheckedIndex].Name}({(T0)listFolder[folderCheckedIndex].Quanity})";
		listFolderSaving<T1, T2, T3, T4, T5, T6>();
	}

	private void loadToServer()
	{
	}

	public T1 Base64Decode<T0, T1>(T1 base64EncodedData)
	{
		try
		{
			T0[] bytes = (T0[])(object)Convert.FromBase64String((string)base64EncodedData);
			return (T1)Encoding.UTF8.GetString((byte[])(object)bytes);
		}
		catch
		{
		}
		return (T1)"";
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void loadFolder<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>()
	{
		//IL_001a: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		//IL_0135: Expected O, but got I4
		T0 val = (T0)(listFolder == null || listFolder.Count == 0);
		if (val != null)
		{
			listFolder = (List<Folder>)Activator.CreateInstance(typeof(T3));
			Folder folder = new Folder();
			folder.ID = (string)RandomString<T4, T9, char>((T9)20);
			folder.Name = "Default";
			folder.Quanity = listFBEntity.Count;
			T1 enumerator = (T1)listFBEntity.GetEnumerator();
			try
			{
				while (((List<FBEntity>.Enumerator*)(&enumerator))->MoveNext())
				{
					FBEntity current = ((List<FBEntity>.Enumerator*)(&enumerator))->Current;
					current.Folder_Id = folder.ID;
				}
			}
			finally
			{
				((IDisposable)(*(List<FBEntity>.Enumerator*)(&enumerator))).Dispose();
			}
			listFolder.Add(folder);
			listFolderSaving<T0, T4, T5, T6, T7, T8>();
		}
		cbListFolder.Items.Clear();
		T2 enumerator2 = (T2)listFolder.GetEnumerator();
		try
		{
			while (((List<Folder>.Enumerator*)(&enumerator2))->MoveNext())
			{
				Folder current2 = ((List<Folder>.Enumerator*)(&enumerator2))->Current;
				cbListFolder.Items.Add($"{current2.Name}({(T9)current2.Quanity})", isChecked: false);
			}
		}
		finally
		{
			((IDisposable)(*(List<Folder>.Enumerator*)(&enumerator2))).Dispose();
		}
		T0 val2 = (T0)(listFolder.Count == 1);
		if (val2 != null)
		{
			cbListFolder.SetItemChecked(0, value: true);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T0 RandomString<T0, T1, T2>(T1 length)
	{
		//IL_000c: Expected I4, but got O
		return (T0)new string((char[])(object)Enumerable.Repeat((T0)"qwertyuiopasdfghjklzxcvbnm", (int)length).Select((Func<T0, T2>)(object)(Func<string, char>)((T0 s) => (T2)((string)s)[rnd.Next(((string)s).Length)])).ToArray());
	}

	private void loadData<T0, T1>()
	{
		//IL_0012: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_00d1: Expected O, but got I4
		T0 val = (T0)(listFBEntity.Count <= 0);
		if (val == null)
		{
			T0 val2 = (T0)(string.IsNullOrWhiteSpace(listFBEntity[0].UID) && listFBEntity.Count > 1);
			if (val2 != null)
			{
				listFBEntity.RemoveAt(0);
			}
		}
		else
		{
			listFBEntity.Add(new FBEntity());
		}
		gvData.DataSource = null;
		gvData.DataSource = listFBEntity;
		lbTotalFB.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)listFBEntity.Count).ToString();
		lbSelected.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)((IEnumerable<FBEntity>)listFBEntity).Where((Func<FBEntity, bool>)((FBEntity a) => (T0)a.Select)).Count()).ToString();
	}

	private void copy2faEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T3 sender, T4 e)
	{
		//IL_0013: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		T0 val = (T0)gvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
		T1 val2 = (T1)((nint)val > 0);
		if (val2 != null)
		{
			T2 val3 = ChromeControl.authenCode<T0, T1, T2, T5, T6, T7>((T2)listFBEntity[gvData.SelectedRows[0].Index].Code2FA);
			Clipboard.Clear();
			Clipboard.SetText((string)val3);
		}
	}

	private unsafe void checkedAllSelectEvent<T0, T1, T2, T3, T4, T5, T6>(T2 sender, T3 e)
	{
		//IL_00a3: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		T0 enumerator = (T0)listFBEntity.GetEnumerator();
		try
		{
			while (((List<FBEntity>.Enumerator*)(&enumerator))->MoveNext())
			{
				FBEntity current = ((List<FBEntity>.Enumerator*)(&enumerator))->Current;
				current.Select = true;
				current.Message = "";
				current.Step = "";
				current.Status = STATUS.Ready.ToString();
			}
		}
		finally
		{
			((IDisposable)(*(List<FBEntity>.Enumerator*)(&enumerator))).Dispose();
		}
		gvData.Refresh();
		lbSelected.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)((IEnumerable<FBEntity>)listFBEntity).Where((Func<FBEntity, bool>)((FBEntity a) => (T5)a.Select)).Count()).ToString();
		fblistSaving<T4, T5, T6>((T5)1);
	}

	private unsafe void uncheckAllSelectEvent<T0, T1, T2, T3, T4, T5, T6>(T2 sender, T3 e)
	{
		//IL_0078: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		T0 enumerator = (T0)listFBEntity.GetEnumerator();
		try
		{
			while (((List<FBEntity>.Enumerator*)(&enumerator))->MoveNext())
			{
				FBEntity current = ((List<FBEntity>.Enumerator*)(&enumerator))->Current;
				current.Select = false;
			}
		}
		finally
		{
			((IDisposable)(*(List<FBEntity>.Enumerator*)(&enumerator))).Dispose();
		}
		gvData.Refresh();
		lbSelected.Text = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)((IEnumerable<FBEntity>)listFBEntity).Where((Func<FBEntity, bool>)((FBEntity a) => (T5)a.Select)).Count()).ToString();
		fblistSaving<T4, T5, T6>((T5)1);
	}

	private void checkedSelectEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0089: Expected I4, but got O
		//IL_00a6: Expected I4, but got O
		//IL_00c7: Expected I4, but got O
		//IL_00e8: Expected I4, but got O
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0113: Expected O, but got I4
		//IL_015c: Expected O, but got I4
		//IL_016f: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 != null)
		{
			T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Select = true;
				listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Message = "";
				listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Step = "";
				listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Status = STATUS.Ready.ToString();
				val3 = (T2)(val3 - 1);
			}
			gvData.Refresh();
			lbSelected.Text = System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)((IEnumerable<FBEntity>)listFBEntity).Where((Func<FBEntity, bool>)((FBEntity a) => (T1)a.Select)).Count()).ToString();
		}
		fblistSaving<T6, T1, T7>((T1)1);
	}

	private void uncheckSelectEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0086: Expected I4, but got O
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_00a2: Expected O, but got I4
		//IL_00e7: Expected O, but got I4
		//IL_00fa: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 != null)
		{
			T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
			while (true)
			{
				T1 val4 = (T1)((nint)val3 >= 0);
				if (val4 == null)
				{
					break;
				}
				listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Select = false;
				val3 = (T2)(val3 - 1);
			}
			gvData.Refresh();
			lbSelected.Text = System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)((IEnumerable<FBEntity>)listFBEntity).Where((Func<FBEntity, bool>)((FBEntity a) => (T1)a.Select)).Count()).ToString();
		}
		fblistSaving<T6, T1, T7>((T1)1);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void infoMessage<T0>(T0 ms)
	{
		MessageBox.Show((string)ms, "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void errorMessage<T0>(T0 ms)
	{
		MessageBox.Show((string)ms, "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static T0 questioniMessage<T0, T1>(T1 ms)
	{
		//IL_0010: Expected O, but got I4
		return (T0)MessageBox.Show((string)ms, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	}

	private void gvData_CellContentClick<T0, T1>(T0 sender, T1 e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void genFlowTiktok<T0, T1>()
	{
		FBFlow fBFlow = null;
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Bắt_đầu_Random";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_lần_lặp_lại",
			value = "1",
			type = typeof(T0)
		});
		moduleTiktok.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Kết_thúc_Random";
		moduleTiktok.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Mở_trình_duyệt";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_extension",
			value = "false",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Update_User_Agent",
			value = "false",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Save_Profile_Folder",
			value = "true",
			type = typeof(T1)
		});
		moduleTiktok.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Đăng_nhập";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Login_By_Cookie",
			value = "",
			type = typeof(T1)
		});
		moduleTiktok.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tương_tác_dạo";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_video_lướt",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Thả_tim",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Thả_tim_random",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Follow",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Follow_random",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Comment_dạo",
			value = "",
			type = typeof(CategoryComment)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_comment",
			value = "1",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "On_Site_From",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "On_Site_To",
			value = "",
			type = typeof(T0)
		});
		moduleTiktok.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Close_Browser";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Clear_Cookie",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Save_Last_Cookie",
			value = "true",
			type = typeof(T1)
		});
		moduleTiktok.Add(fBFlow);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void genFlowFacebookApi<T0, T1, T2>()
	{
		//IL_0166: Expected O, but got I4
		//IL_06bf: Expected O, but got I4
		//IL_1218: Expected O, but got I4
		//IL_1fa1: Expected O, but got I4
		//IL_200f: Expected O, but got I4
		FBFlow fBFlow = null;
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Đăng_nhập";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Update_User_Agent",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Cookie",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Cập_nhật_nhóm",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Khóa_nhóm",
			value = "false",
			type = typeof(T0)
		});
		moduleFacebookApi.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Delay";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_giây_nghỉ",
			value = "0",
			type = typeof(T1)
		});
		moduleFacebookApi.Add(fBFlow);
		T0 val = (T0)GROUP_MANAGER;
		if (val != null)
		{
			fBFlow = new FBFlow();
			fBFlow.Flow_Name = "Tham_gia_nhóm";
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Số_nhóm_tham_gia",
				value = "5",
				type = typeof(T1)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Delay_From",
				value = "2",
				type = typeof(T1)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Delay_To",
				value = "8",
				type = typeof(T1)
			});
			moduleFacebookApi.Add(fBFlow);
			fBFlow = new FBFlow();
			fBFlow.Flow_Name = "Hủy_tham_gia_nhóm";
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Số_nhóm",
				value = "100",
				type = typeof(T1)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Nhóm_mới",
				value = "true",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Nhóm_không_kiểm_duyệt",
				value = "",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Nhóm_kiểm_duyệt",
				value = "",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Nhóm_khóa",
				value = "",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Delay_From",
				value = "2",
				type = typeof(T1)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Delay_To",
				value = "8",
				type = typeof(T1)
			});
			moduleFacebookApi.Add(fBFlow);
			fBFlow = new FBFlow();
			fBFlow.Flow_Name = "Đăng_bài_vào_nhóm";
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Số_nhóm",
				value = "5",
				type = typeof(T1)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Nhóm_mới",
				value = "true",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Nhóm_không_kiểm_duyệt",
				value = "",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Nhóm_kiểm_duyệt",
				value = "",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đăng_bài_mồi",
				value = "true",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Bài_đăng_mồi",
				value = "",
				type = typeof(CategoryComment)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Nghỉ_sửa_bài_mồi",
				value = "10",
				type = typeof(T1)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Nội_dung",
				value = "",
				type = typeof(CategoryComment)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Bài_live_stream",
				value = "",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "ID_bài_viết",
				value = "",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Delay_From",
				value = "3",
				type = typeof(T1)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Delay_To",
				value = "5",
				type = typeof(T1)
			});
			moduleFacebookApi.Add(fBFlow);
		}
		T0 val2 = (T0)ADS_MANAGER;
		if (val2 != null)
		{
			fBFlow = new FBFlow();
			fBFlow.Flow_Name = "Share_TKQC_cá_nhân";
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Share_vào_via",
				value = "",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Share_vào_BM",
				value = "true",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Check_live",
				value = "true",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_tên",
				value = "",
				type = typeof(T2)
			});
			moduleFacebookApi.Add(fBFlow);
			fBFlow = new FBFlow();
			fBFlow.Flow_Name = "Add_thẻ_vô_hạn";
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Địa_chỉ",
				value = "Cherkasy Oblast",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Thành_phố",
				value = "Shpola",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Bang",
				value = "",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "ZipCode",
				value = "20600",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Mã_số_thuế",
				value = "142841724120",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_quốc_gia",
				value = "UA",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_tiền_tệ",
				value = "UAH",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_múi_giờ",
				value = "Asia/Ho_Chi_Minh",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Approved_payment",
				value = "false",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đẩy_thẻ_lên_chính",
				value = "false",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Set_limit",
				value = "40",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_tên",
				value = "",
				type = typeof(T2)
			});
			moduleFacebookApi.Add(fBFlow);
			fBFlow = new FBFlow();
			fBFlow.Flow_Name = "Tạo_tài_khoản_BM";
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "BM_ID_nhận_TK",
				value = "",
				type = typeof(string[])
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Địa_chỉ",
				value = "Cherkasy Oblast",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Thành_phố",
				value = "Shpola",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Bang",
				value = "",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "ZipCode",
				value = "20600",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Mã_số_thuế",
				value = "142841724120",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_quốc_gia",
				value = "UA",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_tiền_tệ",
				value = "UAH",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_múi_giờ",
				value = "Asia/Ho_Chi_Minh",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Add_thẻ",
				value = "true",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Mã_quốc_gia_thẻ",
				value = "",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Dùng_lại_thẻ_thành_công",
				value = "false",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "VHH_tk_khi_add_thẻ",
				value = "true",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Approved_payment",
				value = "false",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Set_limit",
				value = "40",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_tên",
				value = "",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Check_không_đủ_tiền",
				value = "true",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Link_2",
				value = "true",
				type = typeof(T0)
			});
			moduleFacebookApi.Add(fBFlow);
			fBFlow = new FBFlow();
			fBFlow.Flow_Name = "Tạo_TKQC_cá_nhân";
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Share_vào_via",
				value = "",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Share_vào_BM",
				value = "true",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Add_thẻ",
				value = "true",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Mã_quốc_gia_thẻ",
				value = "",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Địa_chỉ",
				value = "121 Brown St",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Thành_phố",
				value = "Kettleman City",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Bang",
				value = "CA",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "ZipCode",
				value = "93239",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Mã_số_thuế",
				value = "142841724120",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_quốc_gia",
				value = "US",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_tiền_tệ",
				value = "USD",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_múi_giờ",
				value = "America/Los_Angeles",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Set_limit",
				value = "",
				type = typeof(T2)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Đổi_tên",
				value = "",
				type = typeof(T2)
			});
			moduleFacebookApi.Add(fBFlow);
		}
		T0 val3 = (T0)PAGE_MANAGER;
		if (val3 != null)
		{
			fBFlow = new FBFlow();
			fBFlow.Flow_Name = "Tạo_Page";
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Số_Page",
				value = "2",
				type = typeof(T1)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Page_thường",
				value = "true",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Tạo_Bằng_API",
				value = "",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Loại_PAGE",
				value = "",
				type = typeof(CategoryComment)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Tên_PAGE",
				value = "",
				type = typeof(CategoryComment)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Share_via",
				value = "",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Delay_From",
				value = "2",
				type = typeof(T1)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Delay_To",
				value = "5",
				type = typeof(T1)
			});
			moduleFacebookApi.Add(fBFlow);
		}
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tạo_Page_Nhanh";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Page_thường",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tên_PAGE",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random_tên_page",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Loại_PAGE",
			value = "200046713342752",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Share_via",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "BM_Cầm_Page",
			value = "",
			type = typeof(T2)
		});
		moduleFacebookApi.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Rip_clone";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Rip_ngày_sinh",
			value = "true",
			type = typeof(T0)
		});
		moduleFacebookApi.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tạo_TKQC_cá_nhân_2";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Share_vào_BM",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Quốc_gia",
			value = "AS",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tiền_tệ",
			value = "USD",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Múi_giờ",
			value = "America/Los_Angeles",
			type = typeof(T2)
		});
		moduleFacebookApi.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tạo_BM";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Đổi_proxy",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Limit_dừng_lại",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Link_2",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_BM_cần_tạo",
			value = "2",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tên_BM",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Mail_BM",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Mail_link_mời",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_link_mời",
			value = "0",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_From",
			value = "1",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_To",
			value = "2",
			type = typeof(T1)
		});
		moduleFacebookApi.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tạo_TKQC_BM";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "BM_Cầm_TK",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Quốc_gia",
			value = "AS",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "MS_Thuế",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tiền_tệ",
			value = "USD",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Múi_giờ",
			value = "America/Los_Angeles",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Đổi_tên",
			value = "",
			type = typeof(T2)
		});
		moduleFacebookApi.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Add_thẻ_2";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_lại_khi_lỗi",
			value = "3",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "VHH_Tk",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Chrome",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Chọn_TK",
			value = "",
			type = null
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_TK_Cá_Nhân",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_TK_Của_BM",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Thông_tin_TK",
			value = "",
			type = null
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Quốc_gia_add_thẻ",
			value = "US",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Chỉ_Add_vào_BM",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Đẩy_chính_TK_BM",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_link_1",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_link_2",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_thẳng_TK",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_link_667",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_qua_m_facebook",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_qua_Bostpost",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_qua_Suite",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_qua_API",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_m_facebook_2",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_Pro_5",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Bin_mồi",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Danh_sách_thẻ",
			value = "",
			type = typeof(GroupCreditCard)
		});
		T0 val4 = (T0)User.AddCardByPro5;
		if (val4 != null)
		{
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Add_theo_danh_sách",
				value = "",
				type = typeof(T0)
			});
		}
		moduleFacebookApi.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Share_pixel";
		moduleFacebookApi.Add(fBFlow);
		T0 val5 = (T0)User.Page_Partner;
		if (val5 != null)
		{
			fBFlow = new FBFlow();
			fBFlow.Flow_Name = "Share_page_đối_tác";
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "share_tất_cả_bm",
				value = "false",
				type = typeof(T0)
			});
			moduleFacebookApi.Add(fBFlow);
		}
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Set_camp_chuyển_đổi_PE";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Lỗi_dừng_lại",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Page",
			value = "",
			type = null
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random-Tên-Id",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Campaign",
			value = "",
			type = null
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Link_web",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Nội_dung",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Folder_ảnh",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Giới_tính_0_1_2",
			value = "0",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tuổi_min",
			value = "18",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tuổi_max",
			value = "65",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Quốc_gia",
			value = "\"AS\",\"US\"",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Ngân_sách",
			value = "2000",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Pixcel_Id",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Domain_Pixel",
			value = "",
			type = typeof(T2)
		});
		moduleFacebookApi.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Set_camp_chuyển_đổi_Suite";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Lỗi_dừng_lại",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Page",
			value = "",
			type = null
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random-Tên-Id",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "LWICometCreateBoostedComponentMutation",
			value = "",
			type = typeof(T2)
		});
		moduleFacebookApi.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Approved_hold";
		moduleFacebookApi.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Set_limit";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Limit",
			value = "",
			type = typeof(T2)
		});
		moduleFacebookApi.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Lưu_ID_TKQC";
		moduleFacebookApi.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Hoàn_thành";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Lưu_cookies",
			value = "true",
			type = typeof(T0)
		});
		moduleFacebookApi.Add(fBFlow);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void genFlowShopee<T0, T1, T2>()
	{
		FBFlow fBFlow = null;
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Bắt_đầu_Random";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_lần_lặp_lại",
			value = "1",
			type = typeof(T0)
		});
		moduleShopee.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Kết_thúc_Random";
		moduleShopee.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Mở_trình_duyệt";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Disable_image",
			value = "false",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_extension",
			value = "false",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Update_User_Agent",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Save_Profile_Folder",
			value = "true",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Ẩn_chrome",
			value = "false",
			type = typeof(T1)
		});
		moduleShopee.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Đăng_nhập";
		moduleShopee.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "SEO_Từ_Khóa_Shopee";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Từ_khóa",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Id_sản_phẩm",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Sắp_xếp_theo",
			value = "Mới Nhất|Bán Chạy|Giá Thấp Đến Cao|Giá Cao Đến Thấp",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Giới_hạn_tìm_sp",
			value = "100",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tgian_online_từ",
			value = "15",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tgian_online_đến",
			value = "30",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Thả_tim",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Thêm_vào_giỏ_hàng",
			value = "0",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random_sp_liên_quan",
			value = "0",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Link_sp_liên_quan",
			value = "",
			type = typeof(string[])
		});
		moduleShopee.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Click_quảng_cáo_đối_thủ";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Từ_khóa",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Id_sản_phẩm",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Sắp_xếp_theo",
			value = "Mới Nhất|Bán Chạy|Giá Thấp Đến Cao|Giá Cao Đến Thấp",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tgian_online_từ",
			value = "15",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tgian_online_đến",
			value = "30",
			type = typeof(T0)
		});
		moduleShopee.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Đóng_trình_duyệt";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Clear_Cookie",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Save_Last_Cookie",
			value = "true",
			type = typeof(T1)
		});
		moduleShopee.Add(fBFlow);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void genFlowFacebook<T0, T1, T2, T3>()
	{
		//IL_19e9: Expected O, but got I4
		//IL_242d: Expected O, but got I4
		FBFlow fBFlow = null;
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Bắt_đầu_Random";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_lần_lặp_lại",
			value = "1",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay",
			value = "30",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Kết_thúc_Random";
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Delay";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_giây_nghỉ",
			value = "0",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Mở_trình_duyệt";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Disable_image",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_extension",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Update_User_Agent",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Save_Profile_Folder",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Ẩn_chrome",
			value = "false",
			type = typeof(T0)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Đăng_nhập";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Login_By_Cookie",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "mbasic.facebook",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "m.facebook",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Cập_nhật_nhóm",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Cập_nhật_page",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Lấy_Token_EAAG",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Lấy_Token_EAAB",
			value = "false",
			type = typeof(T0)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tham_gia_nhóm";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_nhóm_tham_gia",
			value = "5",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_From",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_To",
			value = "",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Rời_khỏi_nhóm";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Rời_khỏi_toàn_bộ_nhóm",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tick",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "UnTick",
			value = "",
			type = typeof(T0)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Truy_cập_link";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "List URL",
			value = "",
			type = typeof(string[])
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "On_Site_From",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "On_Site_To",
			value = "",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tương_tác_dạo";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Link",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random_bài_viết_từ",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random_bài_viết_đến",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Like_bài_viết",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Comment",
			value = "",
			type = typeof(CategoryComment)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_comment",
			value = "1",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_From",
			value = "3",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_To",
			value = "8",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tương_tác_marketplace";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Link",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Next_ảnh",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Message",
			value = "",
			type = typeof(CategoryComment)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_Message",
			value = "1",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random",
			value = "false",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_From",
			value = "5",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_To",
			value = "10",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tương_tác_live_stream";
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Like_share_bài_viết";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "ID_bài_viết",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "22=Pro+5_11=Page",
			value = "22",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Message",
			value = "",
			type = typeof(CategoryComment)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Like",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Share_lên_tường",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Share_toàn_bộ_nhóm",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tick",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "UnTick",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Giới_hạn_nhóm",
			value = "5",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Post_bài_group";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Bài_viết",
			value = "",
			type = typeof(CategoryComment)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Share_toàn_bộ_nhóm",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tick",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "UnTick",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Giới_hạn_nhóm",
			value = "",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Post_bài_lên_tường";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Bài_viết",
			value = "",
			type = typeof(CategoryComment)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_Bài_viết",
			value = "1",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_From",
			value = "5",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_To",
			value = "10",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Kết_bạn_theo_gợi_ý";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "URL_redirection",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Quantity",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_From",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_To",
			value = "",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Kết_bạn_theo_UID";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "List_UID",
			value = "",
			type = typeof(string[])
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Reload",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_From",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_To",
			value = "",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Kết_bạn_theo_profile_đối_thủ";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số lượng",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Kết bạn với đối thủ",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "KB thành phố",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "KB khu vực",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "KB theo dõi",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "KB đang theo dõi",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Thời gian trễ từ",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Thời gian trễ đến",
			value = "",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Chấp_nhận_kết_bạn";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Gender_F_or_M",
			value = "M",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Location",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Quantity",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Age_From",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Age_To",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_From",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_To",
			value = "",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Hủy_kết_bạn";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "List_UID",
			value = "",
			type = typeof(string[])
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Reload",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_From",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_To",
			value = "",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Post_bài_trên_newfeed";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Share_with",
			value = "Public",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Content_(Spin{ | | | })",
			value = "",
			type = typeof(T3)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Image_Path",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Number_Of_Images",
			value = "3",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random_Images",
			value = "",
			type = typeof(T0)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tạo_Page";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_page_cần_tạo",
			value = "1",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Loại_page",
			value = "",
			type = typeof(CategoryComment)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_From",
			value = "2",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_To",
			value = "5",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tạo_page_nhanh";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tạo_page_thường",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tên_page",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random_tên_page",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Loại_page",
			value = "200046713342752",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "BM_Page_Gốc",
			value = "",
			type = typeof(T2)
		});
		moduleFacebook.Add(fBFlow);
		T0 val = (T0)User.Page_Partner;
		if (val != null)
		{
			fBFlow = new FBFlow();
			fBFlow.Flow_Name = "Share_page_đối_tác";
			moduleFacebook.Add(fBFlow);
		}
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Spam_support";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Link_support",
			value = "",
			type = typeof(string[])
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Message",
			value = "",
			type = typeof(CategoryComment)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_From",
			value = "120",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_To",
			value = "300",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Comment_Post_On_Newfeed";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Quantity",
			value = "",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Join_Group";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Quantity",
			value = "",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "List_Group",
			value = "",
			type = typeof(T2)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Change_Password";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Old_Password_And_Datetime",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Default_Password",
			value = "",
			type = typeof(T2)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Logout";
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tạo_BM";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Số_BM_cần_tạo",
			value = "3",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Domain_mail",
			value = "",
			type = typeof(string[])
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random_domain_mail",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_From",
			value = "2",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Delay_To",
			value = "5",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tạo_Tk_trong_BM";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "BM_TK_Gốc",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Đổi_tên",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Quốc_gia_tài_khoản",
			value = "AS",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tiền_tệ_tài_khoản",
			value = "USD",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Múi_giờ_tài_khoản",
			value = "America/Los_Angeles",
			type = typeof(T2)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Lưu_ID_TKQC";
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Tạo_Tk_Cá_Nhân";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Share_cho_BM",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "MS_thuế",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Đổi_quốc_gia",
			value = "AS",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Đổi_tiền_tệ",
			value = "CNY",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Đổi_múi_giờ",
			value = "America/Los_Angeles",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Đổi_tên",
			value = "",
			type = typeof(T2)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Share_Tk_Cá_Nhân_Vào_BM";
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Share_Tk_BM_sang_BM_đối_tác";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "BM_TK_Gốc",
			value = "",
			type = typeof(T2)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Add_thẻ";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Chỉ_add_tk_không_thẻ",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_lại_khi_lỗi",
			value = "3",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Quốc_gia_add_thẻ",
			value = "AS",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tiền_tệ",
			value = "USD",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_vào_BM",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_thẻ_từ_BM",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Add_thẳng_TK",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "M_Facebook",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "M_Facebook_2",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Bostpost",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Suite",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "API",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Danh_sách_thẻ",
			value = "",
			type = typeof(GroupCreditCard)
		});
		T0 val2 = (T0)User.AddCardByPro5;
		if (val2 != null)
		{
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Add_qua_Pro5",
				value = "",
				type = typeof(T0)
			});
			fBFlow.Filed.Add(new FBFlowField
			{
				key = "Add_theo_danh_sách",
				value = "",
				type = typeof(T0)
			});
		}
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Add_thẻ_từ_BM";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "API",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Loại_thẻ",
			value = "AMERICANEXPRESS|VISA|MASTERCARD",
			type = typeof(T2)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Xóa_thẻ";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Loại_thẻ",
			value = "ALL|AMERICANEXPRESS|VISA|MASTERCARD",
			type = typeof(T2)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Approved_hold";
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Share_pixel";
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Lên_camp_boostpost_30e";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tên_page",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Target",
			value = "",
			type = typeof(string[])
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Xóa_thẻ",
			value = "true",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Độ_trễ",
			value = "2",
			type = typeof(T1)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Lên_camp_chuyển_đổi";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Page",
			value = "",
			type = null
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Random-Tên-Id",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Campaign",
			value = "",
			type = null
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Link_web",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Nội_dung",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Folder_ảnh",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Giới_tính_0_1_2",
			value = "0",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tuổi_min",
			value = "18",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Tuổi_max",
			value = "65",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Quốc_gia",
			value = "\"AS\",\"US\"",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Ngân_sách",
			value = "2000",
			type = typeof(T1)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Pixcel_Id",
			value = "",
			type = typeof(T2)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Domain_Pixel",
			value = "",
			type = typeof(T2)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Set_camp_PE";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Campaign_PE",
			value = "",
			type = typeof(string[])
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Set_limit";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Set_limit",
			value = "",
			type = typeof(T2)
		});
		moduleFacebook.Add(fBFlow);
		fBFlow = new FBFlow();
		fBFlow.Flow_Name = "Close_Browser";
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Clear_Cookie",
			value = "",
			type = typeof(T0)
		});
		fBFlow.Filed.Add(new FBFlowField
		{
			key = "Save_Last_Cookie",
			value = "true",
			type = typeof(T0)
		});
		moduleFacebook.Add(fBFlow);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void setColumnData<T0, T1, T2, T3, T4, T5, T6>()
	{
		//IL_0023: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_0106: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		gvData.Columns.Clear();
		T0 val = (T0)(!string.IsNullOrWhiteSpace(setting.ColumnDisplay));
		if (val == null)
		{
			return;
		}
		setting.ColumnDisplay = "Select-bool,Row-int,Note-string,Name-string,UID-string,Password-string,Code2FA-string,Cookie-string,Step-string,Message-string,Status-string,Socks-string,Useragent-string,TokenEAAG-string,TokenEAAB-string,Friends-string,GroupUId-string,Group-string,Page-string";
		T1[] array = (T1[])(object)setting.ColumnDisplay.Split((char[])(object)new T6[1] { (T6)44 });
		T1[] array2 = array;
		T2 val2 = (T2)0;
		while ((nint)val2 < array2.Length)
		{
			T1 val3 = (T1)((object[])(object)array2)[(object)val2];
			T0 val4 = (T0)(!string.IsNullOrWhiteSpace((string)val3));
			if (val4 != null)
			{
				T1 val5 = (T1)((string)val3).Split((char[])(object)new T6[1] { (T6)45 })[0];
				T1 val6 = (T1)((string)val3).Split((char[])(object)new T6[1] { (T6)45 })[1];
				T0 val7 = (T0)((string)val6).ToLower().Equals("bool");
				if (val7 != null)
				{
					T3 val8 = (T3)Activator.CreateInstance(typeof(DataGridViewCheckBoxColumn));
					((DataGridViewColumn)val8).DataPropertyName = (string)val5;
					((DataGridViewColumn)val8).HeaderText = (string)val5;
					((DataGridViewColumn)val8).Name = "cl" + (string)val5;
					try
					{
						T0 val9 = (T0)(ADSPRoject.Properties.Settings.Default[(string)val5] != null);
						if (val9 != null)
						{
							((DataGridViewColumn)val8).ToolTipText = ADSPRoject.Properties.Settings.Default[(string)val5].ToString();
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}
					gvData.Columns.Add((DataGridViewColumn)val8);
				}
				else
				{
					T5 val10 = (T5)Activator.CreateInstance(typeof(DataGridViewTextBoxColumn));
					((DataGridViewColumn)val10).DataPropertyName = (string)val5;
					((DataGridViewColumn)val10).HeaderText = (string)val5;
					((DataGridViewColumn)val10).Name = "cl" + (string)val5;
					try
					{
						T0 val11 = (T0)(ADSPRoject.Properties.Settings.Default[(string)val5] != null);
						if (val11 != null)
						{
							((DataGridViewColumn)val10).ToolTipText = ADSPRoject.Properties.Settings.Default[(string)val5].ToString();
						}
					}
					catch (Exception ex2)
					{
						Console.WriteLine(ex2.Message);
					}
					gvData.Columns.Add((DataGridViewColumn)val10);
				}
			}
			val2 = (T2)(val2 + 1);
		}
		gvData.Columns["clMessage"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		gvData.Columns["clMessage"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
		gvData.Columns["clStep"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		gvData.Columns["clStep"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void chromeSizeSaving<T0>()
	{
		try
		{
			File.WriteAllText("chromesize.json", JsonConvert.SerializeObject((object)chromeSize));
		}
		catch (Exception)
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void loadChromeSize<T0, T1, T2, T3>()
	{
		try
		{
			ccbSizeChrome.Items.Clear();
			chromeSize = (List<ChromeSizeEntity>)JsonConvert.DeserializeObject<T2>(File.ReadAllText("chromesize.json"));
			T0 enumerator = (T0)chromeSize.GetEnumerator();
			try
			{
				while (((List<ChromeSizeEntity>.Enumerator*)(&enumerator))->MoveNext())
				{
					ChromeSizeEntity current = ((List<ChromeSizeEntity>.Enumerator*)(&enumerator))->Current;
					ccbSizeChrome.Items.Add(current.Name + ": " + current.Size);
				}
			}
			finally
			{
				((IDisposable)(*(List<ChromeSizeEntity>.Enumerator*)(&enumerator))).Dispose();
			}
			ccbSizeChrome.Items.Add("Manager");
			ccbSizeChrome.SelectedIndex = setting.ccbChromeSize;
		}
		catch (Exception ex)
		{
			errorMessage((T3)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void frmMain_Load<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23>(T4 sender, T5 e)
	{
		//IL_002c: Expected O, but got I4
		//IL_01fb: Expected O, but got I4
		//IL_0231: Expected O, but got I4
		//IL_0251: Expected O, but got I4
		//IL_029c: Expected O, but got I4
		//IL_02c3: Expected I4, but got O
		//IL_033f: Expected O, but got I4
		//IL_03aa: Expected O, but got I4
		//IL_03ea: Expected O, but got I4
		//IL_041c: Expected O, but got I4
		//IL_0479: Expected O, but got I4
		//IL_04a0: Expected O, but got I4
		//IL_04da: Expected O, but got I4
		Text = Text + "\t Version: " + base.ProductVersion;
		T1 val = (T1)(!Directory.Exists("TKQC"));
		if (val != null)
		{
			Directory.CreateDirectory("TKQC");
		}
		danhSáchTKQCToolStripMenuItem.Visible = User.AddCardByPro5;
		quảnLýPageĐốiTácToolStripMenuItem.Visible = User.Page_Partner;
		SetLanguage((T0)setting.Language);
		ResouceControl.RESOUCE_VERSION = "ResouceV2";
		ResouceControl.API_URL = "https://api.meta-soft.tech/";
		genFlowFacebook<T1, T2, T0, T6>();
		genFlowFacebookApi<T1, T2, T0>();
		loadChromeSize<T7, T3, T8, T0>();
		setColumnData<T1, T0, T2, T9, T3, T10, T11>();
		numTimeDelay.Value = setting.numTimeDelay;
		txtSearch.Text = setting.txtKeyword;
		ccbTarget.Text = setting.ccbTarget;
		FORM_TITLE = Text;
		gvData.DataSource = listFBEntity;
		ResouceControl.getResouce("RESOUCE_FB_HOME");
		numToChangeIP.Value = setting.numToChangeIP;
		numThread.Value = setting.numThread;
		numFromDelay.Value = setting.numFromDelay;
		numToDelay.Value = setting.numToDelay;
		txtTinSoftSV.Text = setting.txtTinSoftSV;
		txtTmProxy.Text = setting.txtTmProxy;
		ccbTypeTMProxy.SelectedIndex = 0;
		cbCheckLive.Checked = setting.cbCheckLive;
		numChromeCustomSizeWidth.Value = setting.numChromeWidth;
		numChromeCustomSizeHeigth.Value = setting.numChromeHeight;
		T1 val2 = (T1)(setting.numProtonVPN == 0);
		if (val2 != null)
		{
			setting.numProtonVPN = 2;
		}
		numProtonVPN.Value = setting.numProtonVPN;
		T1 val3 = (T1)(setting.ChromeSize == 1);
		if (val3 != null)
		{
			rbAutoSortSizeChrome.Checked = true;
		}
		else
		{
			T1 val4 = (T1)(setting.ChromeSize == 2);
			if (val4 != null)
			{
				rbCustomSizeChrome.Checked = true;
			}
			else
			{
				rbMaximumChrome.Checked = true;
			}
		}
		txt922Url.Text = setting.txt922Url;
		type = setting.rbTypeChangeIP;
		T2 val5 = (T2)type;
		T2 val6 = val5;
		switch ((int)val6)
		{
		default:
			rbNotChangeIP.Checked = true;
			break;
		case 0:
			rbNotChangeIP.Checked = true;
			break;
		case 1:
			rbTinSoftVN.Checked = true;
			break;
		case 2:
			rbHMA.Checked = true;
			break;
		case 3:
			rb922.Checked = true;
			break;
		case 4:
			rbUseXproxy.Checked = true;
			break;
		case 5:
			rbTMProxy.Checked = true;
			break;
		case 6:
			rbProtonVPN.Checked = true;
			break;
		}
		try
		{
			T1 val7 = (T1)File.Exists("useragent.json");
			if (val7 != null)
			{
				listUserAgent = (List<UserAgentEntity>)JsonConvert.DeserializeObject<T12>(File.ReadAllText("useragent.json"));
			}
			loadUserAgent<T1>();
		}
		catch (Exception ex)
		{
			errorMessage((T0)ex.Message);
		}
		new Thread(loadCommentStroll<T1, T3, List<CategoryComment>, T0>).Start();
		new Thread(loadListGroupId<T1, List<ListGroupEntity>>).Start();
		try
		{
			T1 val8 = (T1)File.Exists("folder.json");
			if (val8 != null)
			{
				listFolder = (List<Folder>)JsonConvert.DeserializeObject<T13>(File.ReadAllText("folder.json"));
			}
			loadFolder<T1, T14, T15, T13, T0, T16, T17, T18, T19, T2>();
		}
		catch (Exception ex2)
		{
			errorMessage((T0)ex2.Message);
		}
		try
		{
			T1 val9 = (T1)File.Exists("cartgen.json");
			if (val9 != null)
			{
				groupCreditCard = (List<GroupCreditCard>)JsonConvert.DeserializeObject<T20>(File.ReadAllText("cartgen.json"));
			}
			T1 val10 = (T1)(groupCreditCard == null || groupCreditCard.Count == 0);
			if (val10 != null)
			{
				groupCreditCard = (List<GroupCreditCard>)Activator.CreateInstance(typeof(T20));
				groupCreditCard.Add(new GroupCreditCard
				{
					Name = "Mặc định",
					listCreditCardEntity = (List<CreditCardEntity>)Activator.CreateInstance(typeof(T21))
				});
				cartSaving();
			}
		}
		catch
		{
		}
		T1 val11 = (T1)(listFBEntity == null);
		if (val11 != null)
		{
			listFBEntity = (List<FBEntity>)Activator.CreateInstance(typeof(T22));
		}
		try
		{
			T1 val12 = (T1)File.Exists("country.json");
			if (val12 != null)
			{
				listCountry = (List<CountryLanguage>)JsonConvert.DeserializeObject<T23>(File.ReadAllText("country.json"));
			}
		}
		catch (Exception ex3)
		{
			errorMessage((T0)ex3.Message);
		}
		try
		{
			T1 val13 = (T1)File.Exists("tokennolimit.json");
			if (val13 != null)
			{
				TokenNolimit = JsonConvert.DeserializeObject<TokenNolimit>(File.ReadAllText("tokennolimit.json"));
			}
		}
		catch (Exception ex4)
		{
			errorMessage((T0)ex4.Message);
		}
		new Thread(thr).Start();
	}

	private void thr()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void loadCommentStroll<T0, T1, T2, T3>()
	{
		//IL_000d: Expected O, but got I4
		try
		{
			T0 val = (T0)File.Exists("commentstroll.json");
			if (val != null)
			{
				listCommentStroll = (List<CategoryComment>)JsonConvert.DeserializeObject<T2>(File.ReadAllText("commentstroll.json"));
			}
		}
		catch (Exception ex)
		{
			errorMessage((T3)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void loadListGroupId<T0, T1>()
	{
		//IL_000c: Expected O, but got I4
		T0 val = (T0)File.Exists("listgroupid.json");
		if (val != null)
		{
			listGroupEntity = (List<ListGroupEntity>)JsonConvert.DeserializeObject<T1>(File.ReadAllText("listgroupid.json"));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void saveListGroupId()
	{
		try
		{
			File.WriteAllText("listgroupid.json", JsonConvert.SerializeObject((object)listGroupEntity));
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void saveTokenNolimit()
	{
		try
		{
			File.WriteAllText("tokennolimit.json", JsonConvert.SerializeObject((object)TokenNolimit));
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void saveCommentStroll()
	{
		try
		{
			File.WriteAllText("commentstroll.json", JsonConvert.SerializeObject((object)listCommentStroll));
		}
		catch
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void resouceNull()
	{
		Console.WriteLine("lỗiLING");
		isRunning = false;
		killChromeDriver<List<Process>, Process, int, bool>();
		Process.GetCurrentProcess().Kill();
	}

	private void numThread_ValueChanged2()
	{
	}

	private void numThread_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		setting.numThread = int.Parse(((decimal)(T0)numThread.Value).ToString());
		settingSaving();
	}

	private void txtTinSoftSV_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		setting.txtTinSoftSV = txtTinSoftSV.Text;
		settingSaving();
	}

	private void numToChangeIP_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		setting.numToChangeIP = int.Parse(((decimal)(T0)numToChangeIP.Value).ToString());
		settingSaving();
	}

	private void rbNotChangeIP_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		setTypeChangeIP<bool>();
	}

	private void rbTinSoftVN_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		setTypeChangeIP<bool>();
	}

	private void setTypeChangeIP<T0>()
	{
		//IL_0043: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_00ad: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_00cf: Expected O, but got I4
		proxy = "";
		txtTinSoftSV.Enabled = rbTinSoftVN.Checked;
		txtTmProxy.Enabled = rbTMProxy.Checked;
		T0 val = (T0)rbNotChangeIP.Checked;
		if (val == null)
		{
			T0 val2 = (T0)rbTinSoftVN.Checked;
			if (val2 != null)
			{
				getLocationTinsoft<T0, string, List<LocationTinsoftData>.Enumerator>();
				type = 1;
			}
			else
			{
				T0 val3 = (T0)rbTMProxy.Checked;
				if (val3 != null)
				{
					getLocationTmProxy<T0, string, List<location_data_locations>.Enumerator>();
					type = 5;
				}
				else
				{
					T0 val4 = (T0)rbHMA.Checked;
					if (val4 != null)
					{
						type = 2;
					}
					else
					{
						T0 val5 = (T0)rb922.Checked;
						if (val5 == null)
						{
							T0 val6 = (T0)rbUseXproxy.Checked;
							if (val6 == null)
							{
								T0 val7 = (T0)rbProtonVPN.Checked;
								if (val7 != null)
								{
									type = 6;
								}
							}
							else
							{
								type = 4;
							}
						}
						else
						{
							type = 3;
						}
					}
				}
			}
		}
		else
		{
			type = 0;
		}
		setting.rbTypeChangeIP = type;
		settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void getLocationTmProxy<T0, T1, T2>()
	{
		//IL_0046: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_00e9: Expected O, but got I4
		T0 val = (T0)(listLocationTmProxy == null || listLocationTmProxy.data == null || listLocationTmProxy.data.locations == null || listLocationTmProxy.data.locations.Count <= 0);
		if (val != null)
		{
			T1 val2 = HttpRequestClassToken.Get<T1, HttpWebRequest, HttpWebResponse, StreamReader, WebException, Exception>((T1)"https://tmproxy.com/api/proxy/location");
			listLocationTmProxy = JsonConvert.DeserializeObject<location>((string)val2);
		}
		T0 val3 = (T0)(listLocationTmProxy != null);
		if (val3 == null)
		{
			return;
		}
		ccbLocationTmProxy.Items.Clear();
		T2 enumerator = (T2)listLocationTmProxy.data.locations.GetEnumerator();
		try
		{
			while (((List<location_data_locations>.Enumerator*)(&enumerator))->MoveNext())
			{
				location_data_locations current = ((List<location_data_locations>.Enumerator*)(&enumerator))->Current;
				ccbLocationTmProxy.Items.Add(current.name);
			}
		}
		finally
		{
			((IDisposable)(*(List<location_data_locations>.Enumerator*)(&enumerator))).Dispose();
		}
		T0 val4 = (T0)(ccbLocationTmProxy.Items.Count > 0);
		if (val4 != null)
		{
			ccbLocationTmProxy.SelectedIndex = 0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void getLocationTinsoft<T0, T1, T2>()
	{
		//IL_002f: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		//IL_00cd: Expected O, but got I4
		T0 val = (T0)(listLocationTinsoft == null || listLocationTinsoft.data == null || listLocationTinsoft.data.Count <= 0);
		if (val != null)
		{
			T1 val2 = HttpRequestClassToken.Get<T1, HttpWebRequest, HttpWebResponse, StreamReader, WebException, Exception>((T1)"http://proxy.tinsoftsv.com/api/getLocations.php");
			listLocationTinsoft = JsonConvert.DeserializeObject<LocationTinsoft>((string)val2);
		}
		T0 val3 = (T0)(listLocationTinsoft != null);
		if (val3 == null)
		{
			return;
		}
		ccbLocationTinsoft.Items.Clear();
		T2 enumerator = (T2)listLocationTinsoft.data.GetEnumerator();
		try
		{
			while (((List<LocationTinsoftData>.Enumerator*)(&enumerator))->MoveNext())
			{
				LocationTinsoftData current = ((List<LocationTinsoftData>.Enumerator*)(&enumerator))->Current;
				ccbLocationTinsoft.Items.Add(current.name);
			}
		}
		finally
		{
			((IDisposable)(*(List<LocationTinsoftData>.Enumerator*)(&enumerator))).Dispose();
		}
		T0 val4 = (T0)(ccbLocationTinsoft.Items.Count > 0);
		if (val4 != null)
		{
			ccbLocationTinsoft.SelectedIndex = 0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Start<T0, T1>()
	{
		//IL_000b: Expected O, but got I4
		//IL_002f: Expected I4, but got O
		//IL_00a0: Expected O, but got I4
		//IL_00cd: Expected O, but got I4
		//IL_00e7: Expected O, but got I4
		T0 val = (T0)setting.rbTypeChangeIP;
		T0 val2 = val;
		switch ((int)val2)
		{
		case 0:
			countUseProxy = 0;
			break;
		case 1:
			countUseProxy = 0;
			break;
		case 2:
			countUseProxy = setting.numToChangeIP;
			break;
		case 3:
			countUseProxy = 0;
			break;
		case 4:
			countUseProxy = setting.numToChangeIP;
			break;
		case 5:
			countUseProxy = 0;
			break;
		case 6:
			countUseProxy = setting.numToChangeIP;
			break;
		}
		T1 val3 = (T1)btnStart.Text.Equals("START");
		if (val3 != null)
		{
			isRunning = false;
		}
		isRunning = !isRunning;
		btnStart.Text = "START";
		T1 val4 = (T1)isRunning;
		if (val4 != null)
		{
			T1 val5 = (T1)setting.ccbTarget.Equals("Facebook API");
			if (val5 != null)
			{
				nolimitApi = new FacebookNoLimitApi(this);
			}
			btnStart.Text = "STOP";
			new Thread(startChrome<T0, T1>).Start();
		}
	}

	private unsafe void startChromeXProxy<T0, T1, T2, T3, T4>()
	{
		//IL_0002: Expected O, but got I4
		//IL_0010: Expected I4, but got O
		//IL_0016: Expected O, but got I4
		//IL_0025: Expected I4, but got O
		//IL_003b: Expected I4, but got O
		//IL_0051: Expected I4, but got O
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0078: Expected O, but got I4
		//IL_00cd: Expected O, but got I4
		//IL_00df: Expected I4, but got O
		//IL_00f3: Expected I4, but got O
		//IL_0111: Expected O, but got I4
		//IL_0122: Expected I4, but got O
		//IL_0160: Expected O, but got I4
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_0194: Expected O, but got I4
		//IL_01a7: Expected O, but got I4
		T0 val = (T0)0;
		while (true)
		{
			T1 val2 = (T1)((nint)val < listFBEntity.Count);
			if (val2 == null)
			{
				break;
			}
			T1 val3 = (T1)listFBEntity[(int)val].Select;
			if (val3 != null)
			{
				listFBEntity[(int)val].Message = "";
				listFBEntity[(int)val].Shopee_Status = "";
				listFBEntity[(int)val].Status = STATUS.Ready.ToString();
			}
			val = (T0)(val + 1);
		}
		T2 enumerator = (T2)setting.XproxyList.GetEnumerator();
		try
		{
			while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
			{
				XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
				current.CountDown = setting.numToChangeIP;
				current.IsBusy = false;
			}
		}
		finally
		{
			((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
		}
		T0 val4 = (T0)0;
		while (true)
		{
			T1 val5 = (T1)((nint)val4 < listFBEntity.Count);
			if (val5 == null)
			{
				break;
			}
			T1 val6 = (T1)(listFBEntity[(int)val4].Select && listFBEntity[(int)val4].Status.Equals(STATUS.Ready.ToString()));
			if (val6 != null)
			{
				listFBEntity[(int)val4].Status = STATUS.Processing.ToString();
				T2 enumerator2 = (T2)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator2))->MoveNext())
					{
						XProxy current2 = ((List<XProxy>.Enumerator*)(&enumerator2))->Current;
						T1 val7 = (T1)(current2.CountDown == 1);
						if (val7 == null)
						{
						}
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator2))).Dispose();
				}
			}
			val4 = (T0)(val4 + 1);
		}
		settingSaving();
		fblistSaving<T3, T1, T4>((T1)1);
	}

	private void startChrome<T0, T1>()
	{
		//IL_0002: Expected O, but got I4
		//IL_0010: Expected I4, but got O
		//IL_0016: Expected O, but got I4
		//IL_0025: Expected I4, but got O
		//IL_003b: Expected I4, but got O
		//IL_0051: Expected I4, but got O
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0078: Expected O, but got I4
		T0 val = (T0)0;
		while (true)
		{
			T1 val2 = (T1)((nint)val < listFBEntity.Count);
			if (val2 == null)
			{
				break;
			}
			T1 val3 = (T1)listFBEntity[(int)val].Select;
			if (val3 != null)
			{
				listFBEntity[(int)val].Message = "";
				listFBEntity[(int)val].Shopee_Status = "";
				listFBEntity[(int)val].Status = STATUS.Ready.ToString();
			}
			val = (T0)(val + 1);
		}
		autoOpenChrome<List<FBEntity>, T1, string, T0>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void autoOpenChrome<T0, T1, T2, T3>()
	{
		//IL_0040: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		//IL_006f: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0089: Expected I4, but got O
		//IL_00b2: Expected I4, but got O
		//IL_00bc: Expected O, but got I4
		//IL_00da: Expected I4, but got O
		//IL_00ee: Expected O, but got I4
		//IL_012d: Expected I4, but got O
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_014a: Expected O, but got I4
		//IL_015e: Expected O, but got I4
		//IL_0185: Expected I4, but got O
		//IL_01b5: Expected O, but got I4
		//IL_01f3: Expected O, but got I4
		//IL_0220: Expected O, but got I4
		//IL_022f: Expected O, but got I4
		//IL_0265: Expected O, but got I4
		//IL_0270: Expected O, but got I4
		//IL_0292: Expected O, but got I4
		//IL_02ca: Expected O, but got I4
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_0352: Expected O, but got I4
		//IL_0372: Expected O, but got I4
		//IL_03b4: Expected O, but got I4
		//IL_03ca: Expected O, but got I4
		//IL_03e5: Expected O, but got I4
		//IL_0411: Expected O, but got I4
		//IL_0420: Expected O, but got I4
		//IL_0433: Expected O, but got I4
		//IL_0436: Expected O, but got I4
		//IL_043e: Expected O, but got I4
		//IL_0450: Expected I4, but got O
		//IL_0479: Expected I4, but got O
		//IL_0483: Expected O, but got I4
		//IL_04a4: Expected I4, but got O
		//IL_04b8: Expected O, but got I4
		//IL_0505: Expected I4, but got O
		//IL_050e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Expected O, but got Unknown
		//IL_0522: Expected O, but got I4
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Expected O, but got Unknown
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_0599: Expected O, but got Unknown
		//IL_05a1: Expected O, but got I4
		//IL_05b3: Expected O, but got I4
		//IL_05f5: Expected O, but got I4
		//IL_060a: Expected O, but got I4
		while (true)
		{
			T1 val = (T1)isRunning;
			if (val == null)
			{
				break;
			}
			T0 val2 = (T0)((IEnumerable<FBEntity>)listFBEntity).Where((Func<FBEntity, bool>)((FBEntity a) => (T1)(a.Status.Equals(STATUS.Working.ToString()) && a.Select))).ToList();
			T1 val3 = (T1)(type == 0);
			if (val3 == null)
			{
				T1 val4 = (T1)(((List<FBEntity>)val2).Count <= 0);
				if (val4 != null)
				{
					T3 val5 = (T3)0;
					countChrome = 0;
					T2 message = (T2)"";
					T3 val6 = (T3)0;
					while (true)
					{
						T1 val7 = (T1)((nint)val6 < setting.numThread);
						if (val7 == null)
						{
							break;
						}
						T3 val8 = (T3)0;
						while (true)
						{
							T1 val9 = (T1)((nint)val8 < listFBEntity.Count);
							if (val9 == null)
							{
								break;
							}
							T1 val10 = (T1)(listFBEntity[(int)val8].Status.Equals(STATUS.Ready.ToString()) && listFBEntity[(int)val8].Select);
							if (val10 != null)
							{
								T1 val11 = (T1)(setting.cbCheckLive && CheckUID<T1, T2, HttpRequest, Exception>((T2)listFBEntity[(int)val8].UID, out *(string*)(&message)) == null);
								if (val11 == null)
								{
									T3 val12 = (T3)type;
									T3 val13 = val12;
									switch ((int)val13)
									{
									case 0:
										proxy = "";
										break;
									case 1:
									{
										T1 val16 = (T1)(countUseProxy <= 0 && setting.numToChangeIP > 0);
										if (val16 != null)
										{
											proxy = (string)getProxyTinSoft<T2, T1, T3, Exception>();
										}
										break;
									}
									case 2:
									{
										proxy = "";
										T1 val15 = (T1)(countUseProxy <= 0 && setting.numToChangeIP > 0);
										if (val15 != null)
										{
											changeIPHMA<Process, T3, List<Process>, T1, T2>();
										}
										break;
									}
									case 3:
									{
										T1 val17 = (T1)(countUseProxy <= 0 && setting.numToChangeIP > 0);
										if (val17 != null)
										{
											proxy = (string)getIP922<T2, T1, T3, object>((T1)0);
										}
										break;
									}
									case 4:
									{
										proxy = "xproxy";
										T1 val18 = (T1)(countUseProxy <= 0 && setting.numToChangeIP > 0);
										if (val18 != null)
										{
											changeIPXproxy<T3, T1, List<XProxy>.Enumerator, T2, Exception, object>((T1)0);
										}
										break;
									}
									case 5:
									{
										T1 val19 = (T1)(countUseProxy <= 0 && setting.numToChangeIP > 0);
										if (val19 != null)
										{
											proxy = (string)getProxyTmProxy<T2, T3, T1, Exception>();
										}
										break;
									}
									case 6:
									{
										proxy = "";
										T1 val14 = (T1)(countUseProxy <= 0 && setting.numToChangeIP > 0);
										if (val14 != null)
										{
											changeIPProtonVPN<Process, T3, List<Process>, T1, T2>();
										}
										break;
									}
									}
									SetCellText<T1, T3, T2>(val8, (T2)"Status", (T2)STATUS.Working.ToString());
									new Thread(thrChrome<T1, List<XProxy>, List<XProxy>.Enumerator, T3, object>).Start($"{val8}|{val5}");
									val5 = (T3)(val5 + 1);
									Thread.Sleep(setting.numTimeDelay * 1000);
									break;
								}
								SetCellText<T1, T3, T2>(val8, (T2)"Status", (T2)STATUS.Checkpoint.ToString());
								SetCellText<T1, T3, T2>(val8, (T2)"Message", message);
								listFBEntity[(int)val8].Select = false;
							}
							val8 = (T3)(val8 + 1);
						}
						val6 = (T3)(val6 + 1);
					}
					countUseProxy--;
					T1 val20 = (T1)(countChrome == 0);
					if (val20 != null)
					{
						val2 = (T0)((IEnumerable<FBEntity>)listFBEntity).Where((Func<FBEntity, bool>)((FBEntity a) => (T1)(a.Select && a.Status.Equals(STATUS.Working.ToString())))).ToList();
						T1 val21 = (T1)(((List<FBEntity>)val2).Count <= 0);
						if (val21 != null)
						{
							updateTextButton<T1, Button, T2, Thread, Exception>(btnStart, (T2)"START");
							infoMessage((T2)"Complete!");
							isRunning = false;
							break;
						}
					}
				}
				T1 val22 = (T1)(setting.ChromeSize == 1);
				if (val22 != null)
				{
					T1 val23 = (T1)(countChrome == setting.numThread);
					if (val23 != null)
					{
						countChrome = 0;
						changeSizeChrome<Rectangle, Process, T3, List<Process>, T1, IntPtr, List<Process>.Enumerator>();
					}
				}
			}
			else
			{
				T1 val24 = (T1)(((List<FBEntity>)val2).Count < setting.numThread);
				if (val24 != null)
				{
					T2 message2 = (T2)"";
					T3 val25 = (T3)0;
					T3 val26 = (T3)(setting.numThread - ((List<FBEntity>)val2).Count);
					T3 val27 = (T3)0;
					while (true)
					{
						T1 val28 = (T1)(val27 < val26);
						if (val28 == null)
						{
							break;
						}
						T3 val29 = (T3)0;
						while (true)
						{
							T1 val30 = (T1)((nint)val29 < listFBEntity.Count);
							if (val30 == null)
							{
								break;
							}
							T1 val31 = (T1)(listFBEntity[(int)val29].Status.Equals(STATUS.Ready.ToString()) && listFBEntity[(int)val29].Select);
							if (val31 != null)
							{
								T1 val32 = (T1)(setting.cbCheckLive && CheckUID<T1, T2, HttpRequest, Exception>((T2)listFBEntity[(int)val29].UID, out *(string*)(&message2)) == null);
								if (val32 == null)
								{
									SetCellText<T1, T3, T2>(val29, (T2)"Status", (T2)STATUS.Working.ToString());
									new Thread(thrChrome<T1, List<XProxy>, List<XProxy>.Enumerator, T3, object>).Start($"{val29}|{val25}");
									val25 = (T3)(val25 + 1);
									Thread.Sleep(setting.numTimeDelay * 1000);
									break;
								}
								SetCellText<T1, T3, T2>(val29, (T2)"Status", (T2)STATUS.Checkpoint.ToString());
								SetCellText<T1, T3, T2>(val29, (T2)"Message", (T2)STATUS.Checkpoint.ToString());
								listFBEntity[(int)val29].Select = false;
							}
							val29 = (T3)(val29 + 1);
						}
						val27 = (T3)(val27 + 1);
					}
					T1 val33 = (T1)(countChrome == 0);
					if (val33 != null)
					{
						val2 = (T0)((IEnumerable<FBEntity>)listFBEntity).Where((Func<FBEntity, bool>)((FBEntity a) => (T1)(a.Select && a.Status.Equals(STATUS.Working.ToString())))).ToList();
						T1 val34 = (T1)(((List<FBEntity>)val2).Count <= 0);
						if (val34 != null)
						{
							updateTextButton<T1, Button, T2, Thread, Exception>(btnStart, (T2)"START");
							infoMessage((T2)"Complete!");
							isRunning = false;
							break;
						}
					}
				}
			}
			Thread.Sleep(5000);
		}
	}

	public void updateTextButton<T0, T1, T2, T3, T4>(T1 btn, T2 text)
	{
		//IL_0022: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		Button btn2 = (Button)btn;
		string text2 = (string)text;
		T0 val = (T0)_206F_200C_202A_200C_200B_206A_202E_206C_206C_202D_206B_200E_202C_200F_206D_206D_200D_206A_206A_202D_202D_200B_200C_202D_206D_202E_202E_206D_202C_202C_200E_202D_202D_202E_202D_206A_206B_200B_206A_206E_202E();
		if (val != null)
		{
			Invoke((MethodInvoker)delegate
			{
				updateTextButton<T0, T1, T2, T3, T4>((T1)btn2, (T2)text2);
			});
		}
		else
		{
			btn2.Text = text2;
			fblistSaving<T3, T0, T4>((T0)1);
		}
	}

	private void openBrowserLoginShopeeEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_0094: Expected I4, but got O
		//IL_009e: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b9: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		isRunning = true;
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				new Thread((ParameterizedThreadStart)thrChromeLoginShopeeNoFlow<T1, List<XProxy>, List<XProxy>.Enumerator, T2, T3>).Start((T2)((List<DataGridViewRow>)val)[(int)val3].Index);
				Thread.Sleep(300);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private void openBrowserLoginFacebookByCookieEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_0094: Expected I4, but got O
		//IL_009e: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b9: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		isRunning = true;
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				new Thread((ParameterizedThreadStart)thrChromeLoginFaceBookByCookieNoFlow<T2, T1, List<XProxy>, List<XProxy>.Enumerator, T3>).Start((T2)((List<DataGridViewRow>)val)[(int)val3].Index);
				Thread.Sleep(300);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private void addCardEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_0094: Expected I4, but got O
		//IL_009e: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b9: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		isRunning = true;
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				new Thread(addCardForm).Start((T2)((List<DataGridViewRow>)val)[(int)val3].Index);
				Thread.Sleep(300);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private void addCardForm<T0>(T0 index)
	{
		frmAddCard frmAddCard2 = new frmAddCard(this, int.Parse(index.ToString()));
		frmAddCard2.ShowDialog();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void adsManagerEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0019: Expected O, but got I4
		//IL_0037: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		//IL_00ca: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		//IL_00f9: Expected I4, but got O
		//IL_0103: Expected O, but got I4
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0122: Expected O, but got I4
		T0 val = (T0)sender;
		T2 val2 = (T2)((MenuItem)val).Text.Equals("Quản lý quảng cáo + Cookie");
		if (val2 != null)
		{
			flagAdsManager = 2;
		}
		else
		{
			T2 val3 = (T2)((MenuItem)val).Text.Equals("Quản lý quảng cáo + M.Facebook");
			if (val3 == null)
			{
				T2 val4 = (T2)((MenuItem)val).Text.Equals("Quản lý quảng cáo");
				if (val4 != null)
				{
					flagAdsManager = 3;
				}
			}
			else
			{
				flagAdsManager = 1;
			}
		}
		T1 val5 = (T1)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T2 val6 = (T2)(((List<DataGridViewRow>)val5).Count > 0);
		if (val6 == null)
		{
			return;
		}
		isRunning = true;
		T3 val7 = (T3)(((List<DataGridViewRow>)val5).Count - 1);
		while (true)
		{
			T2 val8 = (T2)((nint)val7 >= 0);
			if (val8 != null)
			{
				new Thread((ParameterizedThreadStart)thrAdsManager<T3, T2, List<XProxy>, List<XProxy>.Enumerator, T4>).Start((T3)((List<DataGridViewRow>)val5)[(int)val7].Index);
				Thread.Sleep(300);
				val7 = (T3)(val7 - 1);
				continue;
			}
			break;
		}
	}

	private unsafe void thrAdsManager<T0, T1, T2, T3, T4>(T4 index)
	{
		//IL_0002: Expected O, but got I4
		//IL_000c: Expected O, but got I4
		//IL_0011: Expected O, but got I4
		//IL_001d: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_00fb: Expected I4, but got O
		//IL_0105: Expected O, but got I4
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_0124: Expected O, but got I4
		//IL_013b: Expected I4, but got O
		//IL_0153: Expected I4, but got O
		//IL_0175: Expected I4, but got O
		//IL_0190: Expected I4, but got O
		T0 val = (T0)8;
		T1 val2 = (T1)(flagAdsManager == 0);
		if (val2 != null)
		{
			val = (T0)8;
		}
		else
		{
			T1 val3 = (T1)(flagAdsManager == 1);
			if (val3 == null)
			{
				T1 val4 = (T1)(flagAdsManager == 2);
				if (val4 == null)
				{
					T1 val5 = (T1)(flagAdsManager == 3);
					if (val5 != null)
					{
						val = (T0)14;
					}
				}
				else
				{
					val = (T0)12;
				}
			}
			else
			{
				val = (T0)13;
			}
		}
		T1 val6 = (T1)(setting.rbTypeChangeIP == 4);
		if (val6 != null)
		{
			T2 val7 = (T2)((IEnumerable<XProxy>)setting.XproxyList).Where((Func<XProxy, bool>)((XProxy a) => (T1)(!a.IsUsed))).ToList();
			T1 val8 = (T1)(((List<XProxy>)val7).Count <= 0);
			if (val8 != null)
			{
				T3 enumerator = (T3)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
					{
						XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
						current.IsUsed = false;
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val9 = (T0)0;
			while (true)
			{
				T1 val10 = (T1)((nint)val9 < setting.XproxyList.Count);
				if (val10 != null)
				{
					T1 val11 = (T1)(!setting.XproxyList[(int)val9].IsUsed);
					if (val11 != null)
					{
						break;
					}
					val9 = (T0)(val9 + 1);
					continue;
				}
				return;
			}
			setting.XproxyList[(int)val9].IsUsed = true;
			proxy = setting.XproxyList[(int)val9].Proxy;
			new ChromeControl(proxy, int.Parse(index.ToString()), this, (int)val);
		}
		else
		{
			new ChromeControl(proxy, int.Parse(index.ToString()), this, (int)val);
		}
	}

	private void openBrowserLoginMFacebookEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_0094: Expected I4, but got O
		//IL_009e: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b9: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		isRunning = true;
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				new Thread((ParameterizedThreadStart)thrChromeLoginMFacebookNoFlow<T2, T1, List<XProxy>, List<XProxy>.Enumerator, T3>).Start((T2)((List<DataGridViewRow>)val)[(int)val3].Index);
				Thread.Sleep(300);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private void openBrowserLoginMBasicFacebookEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_0094: Expected I4, but got O
		//IL_009e: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b9: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		isRunning = true;
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				new Thread((ParameterizedThreadStart)thrChromeLoginMBasicNoFlow<T2, T1, List<XProxy>, List<XProxy>.Enumerator, T3>).Start((T2)((List<DataGridViewRow>)val)[(int)val3].Index);
				Thread.Sleep(300);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private void openBrowserLoginFacebookEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_0094: Expected I4, but got O
		//IL_009e: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b9: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		isRunning = true;
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				new Thread((ParameterizedThreadStart)thrChromeLoginNoFlow<T2, T1, List<XProxy>, List<XProxy>.Enumerator, T3>).Start((T2)((List<DataGridViewRow>)val)[(int)val3].Index);
				Thread.Sleep(300);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private void verifyZohoMailModuleEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_0094: Expected I4, but got O
		//IL_009e: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b9: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		isRunning = true;
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				new Thread((ParameterizedThreadStart)thrChromeVerifyMailZoho<T1, List<XProxy>, List<XProxy>.Enumerator, T2, T3>).Start((T2)((List<DataGridViewRow>)val)[(int)val3].Index);
				Thread.Sleep(300);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private unsafe void thrChromeVerifyMailZoho<T0, T1, T2, T3, T4>(T4 index)
	{
		//IL_000e: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_0098: Expected O, but got I4
		//IL_00ab: Expected I4, but got O
		//IL_00b5: Expected O, but got I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00d4: Expected O, but got I4
		//IL_00eb: Expected I4, but got O
		//IL_0103: Expected I4, but got O
		T0 val = (T0)(setting.rbTypeChangeIP == 4);
		if (val != null)
		{
			T1 val2 = (T1)((IEnumerable<XProxy>)setting.XproxyList).Where((Func<XProxy, bool>)((XProxy a) => (T0)(!a.IsUsed))).ToList();
			T0 val3 = (T0)(((List<XProxy>)val2).Count <= 0);
			if (val3 != null)
			{
				T2 enumerator = (T2)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
					{
						XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
						current.IsUsed = false;
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T3 val4 = (T3)0;
			while (true)
			{
				T0 val5 = (T0)((nint)val4 < setting.XproxyList.Count);
				if (val5 != null)
				{
					T0 val6 = (T0)(!setting.XproxyList[(int)val4].IsUsed);
					if (val6 != null)
					{
						break;
					}
					val4 = (T3)(val4 + 1);
					continue;
				}
				return;
			}
			setting.XproxyList[(int)val4].IsUsed = true;
			proxy = setting.XproxyList[(int)val4].Proxy;
			new ChromeControl(proxy, int.Parse(index.ToString()), this, 9);
		}
		else
		{
			new ChromeControl(proxy, int.Parse(index.ToString()), this, 9);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void openBrowserEvent<T0, T1, T2, T3, T4, T5, T6, T7>(T5 sender, T6 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_0095: Expected O, but got I4
		//IL_00a8: Expected I4, but got O
		//IL_00af: Expected O, but got I4
		//IL_00eb: Expected I4, but got O
		//IL_00f2: Expected O, but got I4
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0136: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T7>().Where((Func<T7, bool>)(object)(Func<DataGridViewRow, bool>)((T7 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T7, T3>)(object)(Func<DataGridViewRow, int>)((T7 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		T2 val3 = (T2)sender;
		isRunning = true;
		T3 val4 = (T3)0;
		while (true)
		{
			T1 val5 = (T1)((nint)val4 < ((List<DataGridViewRow>)val).Count);
			if (val5 != null)
			{
				T1 val6 = (T1)((MenuItem)val3).Text.Equals("Mở trình duyệt");
				if (val6 != null)
				{
					T4[] parameter = new T4[2]
					{
						(T4)System.Runtime.CompilerServices.Unsafe.As<T3, int>(ref (T3)((List<DataGridViewRow>)val)[(int)val4].Index).ToString(),
						(T4)"2"
					};
					new Thread((ParameterizedThreadStart)thrStartModuleFlow<T4, T3, T1, List<XProxy>, List<XProxy>.Enumerator, T5>).Start(parameter);
				}
				else
				{
					T4[] parameter2 = new T4[2]
					{
						(T4)System.Runtime.CompilerServices.Unsafe.As<T3, int>(ref (T3)((List<DataGridViewRow>)val)[(int)val4].Index).ToString(),
						(T4)"16"
					};
					new Thread((ParameterizedThreadStart)thrStartModuleFlow<T4, T3, T1, List<XProxy>, List<XProxy>.Enumerator, T5>).Start(parameter2);
				}
				Thread.Sleep(300);
				val4 = (T3)(val4 + 1);
				continue;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void startModuleEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_008b: Expected I4, but got O
		//IL_0092: Expected O, but got I4
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00d2: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T2>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		isRunning = true;
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				T3[] parameter = new T3[2]
				{
					(T3)System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)((List<DataGridViewRow>)val)[(int)val3].Index).ToString(),
					(T3)"1"
				};
				new Thread((ParameterizedThreadStart)thrStartModuleFlow<T3, T2, T1, List<XProxy>, List<XProxy>.Enumerator, T4>).Start(parameter);
				Thread.Sleep(300);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private unsafe void thrStartModuleFlow<T0, T1, T2, T3, T4, T5>(T5 objTypes)
	{
		//IL_0010: Expected O, but got I4
		//IL_0019: Expected O, but got I4
		//IL_0027: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_00c9: Expected I4, but got O
		//IL_00d3: Expected O, but got I4
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00f2: Expected O, but got I4
		//IL_0109: Expected I4, but got O
		//IL_0121: Expected I4, but got O
		//IL_0144: Expected I4, but got O
		//IL_0160: Expected I4, but got O
		T0[] array = (T0[])(object)(string[])objTypes;
		T1 val = (T1)int.Parse((string)((object[])(object)array)[0]);
		T1 val2 = (T1)int.Parse((string)((object[])(object)array)[1]);
		T2 val3 = (T2)(setting.rbTypeChangeIP == 4);
		if (val3 != null)
		{
			T3 val4 = (T3)((IEnumerable<XProxy>)setting.XproxyList).Where((Func<XProxy, bool>)((XProxy a) => (T2)(!a.IsUsed))).ToList();
			T2 val5 = (T2)(((List<XProxy>)val4).Count <= 0);
			if (val5 != null)
			{
				T4 enumerator = (T4)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
					{
						XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
						current.IsUsed = false;
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T1 val6 = (T1)0;
			while (true)
			{
				T2 val7 = (T2)((nint)val6 < setting.XproxyList.Count);
				if (val7 != null)
				{
					T2 val8 = (T2)(!setting.XproxyList[(int)val6].IsUsed);
					if (val8 == null)
					{
						val6 = (T1)(val6 + 1);
						continue;
					}
					setting.XproxyList[(int)val6].IsUsed = true;
					proxy = setting.XproxyList[(int)val6].Proxy;
					new ChromeControl(proxy, int.Parse(((int*)(&val))->ToString()), this, (int)val2);
					break;
				}
				break;
			}
		}
		else
		{
			new ChromeControl(proxy, int.Parse(((int*)(&val))->ToString()), this, (int)val2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void checkGroupFriendEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		//IL_008f: Expected I4, but got O
		//IL_00a9: Expected O, but got I4
		//IL_00c3: Expected I4, but got O
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e6: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T2>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		HttpRequestClass httpRequestClass = new HttpRequestClass();
		isRunning = true;
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				T3 val5 = (T3)listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].UserAgent;
				T1 val6 = (T1)string.IsNullOrWhiteSpace((string)val5);
				if (val6 != null)
				{
					val5 = (T3)"Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 96.0.4664.45 Safari / 537.36";
				}
				httpRequestClass.GetListGroup2<WebRequest, T3, byte, Stream, WebResponse, StreamReader, HttpWebResponse>((T3)listFBEntity[((List<DataGridViewRow>)val)[(int)val3].Index].Cookie, val5);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private void seedingEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_0094: Expected I4, but got O
		//IL_009e: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b9: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		isRunning = true;
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				new Thread((ParameterizedThreadStart)thrSeeding<T1, List<XProxy>, List<XProxy>.Enumerator, T2, T3>).Start((T2)((List<DataGridViewRow>)val)[(int)val3].Index);
				Thread.Sleep(300);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private unsafe void thrSeeding<T0, T1, T2, T3, T4>(T4 index)
	{
		//IL_000e: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_0098: Expected O, but got I4
		//IL_00ab: Expected I4, but got O
		//IL_00b5: Expected O, but got I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00d4: Expected O, but got I4
		//IL_00eb: Expected I4, but got O
		//IL_0103: Expected I4, but got O
		T0 val = (T0)(setting.rbTypeChangeIP == 4);
		if (val != null)
		{
			T1 val2 = (T1)((IEnumerable<XProxy>)setting.XproxyList).Where((Func<XProxy, bool>)((XProxy a) => (T0)(!a.IsUsed))).ToList();
			T0 val3 = (T0)(((List<XProxy>)val2).Count <= 0);
			if (val3 != null)
			{
				T2 enumerator = (T2)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
					{
						XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
						current.IsUsed = false;
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T3 val4 = (T3)0;
			while (true)
			{
				T0 val5 = (T0)((nint)val4 < setting.XproxyList.Count);
				if (val5 != null)
				{
					T0 val6 = (T0)(!setting.XproxyList[(int)val4].IsUsed);
					if (val6 != null)
					{
						break;
					}
					val4 = (T3)(val4 + 1);
					continue;
				}
				return;
			}
			setting.XproxyList[(int)val4].IsUsed = true;
			proxy = setting.XproxyList[(int)val4].Proxy;
			new ChromeControl(proxy, int.Parse(index.ToString()), this, 7);
		}
		else
		{
			new ChromeControl(proxy, int.Parse(index.ToString()), this, 7);
		}
	}

	private void remarketingEvent<T0, T1, T2, T3, T4, T5>(T3 sender, T4 e)
	{
		//IL_0068: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		//IL_0094: Expected I4, but got O
		//IL_009e: Expected O, but got I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b9: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T5>().Where((Func<T5, bool>)(object)(Func<DataGridViewRow, bool>)((T5 row) => (T1)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T5, T2>)(object)(Func<DataGridViewRow, int>)((T5 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)(((List<DataGridViewRow>)val).Count > 0);
		if (val2 == null)
		{
			return;
		}
		isRunning = true;
		T2 val3 = (T2)(((List<DataGridViewRow>)val).Count - 1);
		while (true)
		{
			T1 val4 = (T1)((nint)val3 >= 0);
			if (val4 != null)
			{
				new Thread((ParameterizedThreadStart)thrReMarketing<T1, List<XProxy>, List<XProxy>.Enumerator, T2, T3>).Start((T2)((List<DataGridViewRow>)val)[(int)val3].Index);
				Thread.Sleep(300);
				val3 = (T2)(val3 - 1);
				continue;
			}
			break;
		}
	}

	private unsafe void thrReMarketing<T0, T1, T2, T3, T4>(T4 index)
	{
		//IL_000e: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_0098: Expected O, but got I4
		//IL_00ab: Expected I4, but got O
		//IL_00b5: Expected O, but got I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00d4: Expected O, but got I4
		//IL_00eb: Expected I4, but got O
		//IL_0103: Expected I4, but got O
		T0 val = (T0)(setting.rbTypeChangeIP == 4);
		if (val != null)
		{
			T1 val2 = (T1)((IEnumerable<XProxy>)setting.XproxyList).Where((Func<XProxy, bool>)((XProxy a) => (T0)(!a.IsUsed))).ToList();
			T0 val3 = (T0)(((List<XProxy>)val2).Count <= 0);
			if (val3 != null)
			{
				T2 enumerator = (T2)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
					{
						XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
						current.IsUsed = false;
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T3 val4 = (T3)0;
			while (true)
			{
				T0 val5 = (T0)((nint)val4 < setting.XproxyList.Count);
				if (val5 != null)
				{
					T0 val6 = (T0)(!setting.XproxyList[(int)val4].IsUsed);
					if (val6 == null)
					{
						val4 = (T3)(val4 + 1);
						continue;
					}
					setting.XproxyList[(int)val4].IsUsed = true;
					proxy = setting.XproxyList[(int)val4].Proxy;
					new ChromeControl(proxy, int.Parse(index.ToString()), this, 6);
					break;
				}
				break;
			}
		}
		else
		{
			new ChromeControl(proxy, int.Parse(index.ToString()), this, 6);
		}
	}

	private void receiptBMLinkEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0070: Expected O, but got I4
		//IL_007a: Expected I4, but got O
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0093: Expected O, but got I4
		T0 val = (T0)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T3)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T2>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T2)((DataGridViewBand)row).Index))
			.ToList();
		T1 val2 = (T1)Activator.CreateInstance(typeof(T1));
		T2 val3 = (T2)0;
		while (true)
		{
			T3 val4 = (T3)((nint)val3 < ((List<DataGridViewRow>)val).Count);
			if (val4 == null)
			{
				break;
			}
			((List<int>)val2).Add(((List<DataGridViewRow>)val)[(int)val3].Index);
			val3 = (T2)(val3 + 1);
		}
		frmReceiptBM frmReceiptBM2 = new frmReceiptBM(null, this, (List<int>)val2);
		frmReceiptBM2.Show();
	}

	private void checkLiveEvent<T0, T1>(T0 sender, T1 e)
	{
		isGvRefesh = true;
		timer_gv_refesh.Start();
		new Thread(thrCheckLive<bool, int, Thread, ParameterizedThreadStart, DataGridViewRow>).Start();
	}

	private void thrCheckLive<T0, T1, T2, T3, T4>()
	{
		//IL_007f: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_009f: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected I4, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0121: Expected O, but got I4
		_003C_003Ec__DisplayClass158_0 _003C_003Ec__DisplayClass158_ = new _003C_003Ec__DisplayClass158_0();
		_003C_003Ec__DisplayClass158_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass158_.rows = (List<DataGridViewRow>)(object)gvData.SelectedRows.Cast<T4>().Where((Func<T4, bool>)(object)(Func<DataGridViewRow, bool>)((T4 row) => (T0)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T4, T1>)(object)(Func<DataGridViewRow, int>)((T4 row) => (T1)((DataGridViewBand)row).Index))
			.ToList();
		T0 val = (T0)(_003C_003Ec__DisplayClass158_.rows.Count > 0);
		if (val != null)
		{
			_003C_003Ec__DisplayClass158_1 _003C_003Ec__DisplayClass158_2 = new _003C_003Ec__DisplayClass158_1();
			_003C_003Ec__DisplayClass158_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass158_;
			_003C_003Ec__DisplayClass158_2.countThread = 0;
			T1 val2 = (T1)30;
			T1 val3 = (T1)0;
			while (true)
			{
				T0 val4 = (T0)((nint)val3 < _003C_003Ec__DisplayClass158_2.CS_0024_003C_003E8__locals1.rows.Count);
				if (val4 == null)
				{
					break;
				}
				while (true)
				{
					T0 val5 = (T0)(_003C_003Ec__DisplayClass158_2.countThread >= (nint)val2);
					if (val5 == null)
					{
						break;
					}
					Thread.Sleep(1500);
				}
				T2 val6 = (T2)new Thread(_003C_003Ec__DisplayClass158_2._003CthrCheckLive_003Eb__2<T1, string, T0, object, HttpRequest, Exception>);
				((Thread)val6).Start((object)val3);
				T1 val7 = (T1)_003C_003Ec__DisplayClass158_2.countThread;
				_003C_003Ec__DisplayClass158_2.countThread = val7 + 1;
				val3 = (T1)(val3 + 1);
			}
		}
		isGvRefesh = false;
	}

	private void addFriendByRivalEvent<T0, T1, T2, T3, T4, T5, T6>(T4 sender, T5 e)
	{
		//IL_0078: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_0094: Expected I4, but got O
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00b5: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)gvData.SelectedRows.Cast<T6>().Where((Func<T6, bool>)(object)(Func<DataGridViewRow, bool>)((T6 row) => (T2)(!((DataGridViewRow)row).IsNewRow))).OrderBy((Func<T6, T3>)(object)(Func<DataGridViewRow, int>)((T6 row) => (T3)((DataGridViewBand)row).Index))
			.ToList();
		T2 val3 = (T2)(((List<DataGridViewRow>)val2).Count > 0);
		if (val3 != null)
		{
			T3 val4 = (T3)(((List<DataGridViewRow>)val2).Count - 1);
			while (true)
			{
				T2 val5 = (T2)((nint)val4 >= 0);
				if (val5 == null)
				{
					break;
				}
				((List<string>)val).Add(listFBEntity[((List<DataGridViewRow>)val2)[(int)val4].Index].UID);
				val4 = (T3)(val4 - 1);
			}
		}
		T2 val6 = (T2)(((List<string>)val).Count > 0);
		if (val6 != null)
		{
			frmAddFriendsByRival frmAddFriendsByRival2 = new frmAddFriendsByRival(this, (List<string>)val);
			frmAddFriendsByRival2.Show();
			gvData.Refresh();
		}
	}

	private unsafe void thrChromeLoginShopeeNoFlow<T0, T1, T2, T3, T4>(T4 index)
	{
		//IL_000e: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_0098: Expected O, but got I4
		//IL_00ab: Expected I4, but got O
		//IL_00b5: Expected O, but got I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00d4: Expected O, but got I4
		//IL_00eb: Expected I4, but got O
		//IL_0103: Expected I4, but got O
		T0 val = (T0)(setting.rbTypeChangeIP == 4);
		if (val != null)
		{
			T1 val2 = (T1)((IEnumerable<XProxy>)setting.XproxyList).Where((Func<XProxy, bool>)((XProxy a) => (T0)(!a.IsUsed))).ToList();
			T0 val3 = (T0)(((List<XProxy>)val2).Count <= 0);
			if (val3 != null)
			{
				T2 enumerator = (T2)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
					{
						XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
						current.IsUsed = false;
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T3 val4 = (T3)0;
			while (true)
			{
				T0 val5 = (T0)((nint)val4 < setting.XproxyList.Count);
				if (val5 != null)
				{
					T0 val6 = (T0)(!setting.XproxyList[(int)val4].IsUsed);
					if (val6 == null)
					{
						val4 = (T3)(val4 + 1);
						continue;
					}
					setting.XproxyList[(int)val4].IsUsed = true;
					proxy = setting.XproxyList[(int)val4].Proxy;
					new ChromeControl(proxy, int.Parse(index.ToString()), this, 4);
					break;
				}
				break;
			}
		}
		else
		{
			new ChromeControl(proxy, int.Parse(index.ToString()), this, 3);
		}
	}

	private unsafe void thrChromeLoginFaceBookByCookieNoFlow<T0, T1, T2, T3, T4>(T4 index)
	{
		//IL_0002: Expected O, but got I4
		//IL_0010: Expected O, but got I4
		//IL_0057: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00ae: Expected I4, but got O
		//IL_00b8: Expected O, but got I4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00d7: Expected O, but got I4
		//IL_00ee: Expected I4, but got O
		//IL_0106: Expected I4, but got O
		//IL_0128: Expected I4, but got O
		//IL_0143: Expected I4, but got O
		T0 val = (T0)5;
		T1 val2 = (T1)(setting.rbTypeChangeIP == 4);
		if (val2 != null)
		{
			T2 val3 = (T2)((IEnumerable<XProxy>)setting.XproxyList).Where((Func<XProxy, bool>)((XProxy a) => (T1)(!a.IsUsed))).ToList();
			T1 val4 = (T1)(((List<XProxy>)val3).Count <= 0);
			if (val4 != null)
			{
				T3 enumerator = (T3)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
					{
						XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
						current.IsUsed = false;
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val5 = (T0)0;
			while (true)
			{
				T1 val6 = (T1)((nint)val5 < setting.XproxyList.Count);
				if (val6 != null)
				{
					T1 val7 = (T1)(!setting.XproxyList[(int)val5].IsUsed);
					if (val7 != null)
					{
						break;
					}
					val5 = (T0)(val5 + 1);
					continue;
				}
				return;
			}
			setting.XproxyList[(int)val5].IsUsed = true;
			proxy = setting.XproxyList[(int)val5].Proxy;
			new ChromeControl(proxy, int.Parse(index.ToString()), this, (int)val);
		}
		else
		{
			new ChromeControl(proxy, int.Parse(index.ToString()), this, (int)val);
		}
	}

	private unsafe void thrChromeLoginMFacebookNoFlow<T0, T1, T2, T3, T4>(T4 index)
	{
		//IL_0003: Expected O, but got I4
		//IL_0011: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_00af: Expected I4, but got O
		//IL_00b9: Expected O, but got I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00d8: Expected O, but got I4
		//IL_00ef: Expected I4, but got O
		//IL_0107: Expected I4, but got O
		//IL_0129: Expected I4, but got O
		//IL_0144: Expected I4, but got O
		T0 val = (T0)11;
		T1 val2 = (T1)(setting.rbTypeChangeIP == 4);
		if (val2 != null)
		{
			T2 val3 = (T2)((IEnumerable<XProxy>)setting.XproxyList).Where((Func<XProxy, bool>)((XProxy a) => (T1)(!a.IsUsed))).ToList();
			T1 val4 = (T1)(((List<XProxy>)val3).Count <= 0);
			if (val4 != null)
			{
				T3 enumerator = (T3)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
					{
						XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
						current.IsUsed = false;
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val5 = (T0)0;
			while (true)
			{
				T1 val6 = (T1)((nint)val5 < setting.XproxyList.Count);
				if (val6 != null)
				{
					T1 val7 = (T1)(!setting.XproxyList[(int)val5].IsUsed);
					if (val7 != null)
					{
						break;
					}
					val5 = (T0)(val5 + 1);
					continue;
				}
				return;
			}
			setting.XproxyList[(int)val5].IsUsed = true;
			proxy = setting.XproxyList[(int)val5].Proxy;
			new ChromeControl(proxy, int.Parse(index.ToString()), this, (int)val);
		}
		else
		{
			new ChromeControl(proxy, int.Parse(index.ToString()), this, (int)val);
		}
	}

	private unsafe void thrChromeLoginMBasicNoFlow<T0, T1, T2, T3, T4>(T4 index)
	{
		//IL_0003: Expected O, but got I4
		//IL_0011: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_00af: Expected I4, but got O
		//IL_00b9: Expected O, but got I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00d8: Expected O, but got I4
		//IL_00ef: Expected I4, but got O
		//IL_0107: Expected I4, but got O
		//IL_0129: Expected I4, but got O
		//IL_0144: Expected I4, but got O
		T0 val = (T0)10;
		T1 val2 = (T1)(setting.rbTypeChangeIP == 4);
		if (val2 != null)
		{
			T2 val3 = (T2)((IEnumerable<XProxy>)setting.XproxyList).Where((Func<XProxy, bool>)((XProxy a) => (T1)(!a.IsUsed))).ToList();
			T1 val4 = (T1)(((List<XProxy>)val3).Count <= 0);
			if (val4 != null)
			{
				T3 enumerator = (T3)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
					{
						XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
						current.IsUsed = false;
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val5 = (T0)0;
			while (true)
			{
				T1 val6 = (T1)((nint)val5 < setting.XproxyList.Count);
				if (val6 != null)
				{
					T1 val7 = (T1)(!setting.XproxyList[(int)val5].IsUsed);
					if (val7 != null)
					{
						break;
					}
					val5 = (T0)(val5 + 1);
					continue;
				}
				return;
			}
			setting.XproxyList[(int)val5].IsUsed = true;
			proxy = setting.XproxyList[(int)val5].Proxy;
			new ChromeControl(proxy, int.Parse(index.ToString()), this, (int)val);
		}
		else
		{
			new ChromeControl(proxy, int.Parse(index.ToString()), this, (int)val);
		}
	}

	private unsafe void thrChromeLoginNoFlow<T0, T1, T2, T3, T4>(T4 index)
	{
		//IL_0002: Expected O, but got I4
		//IL_0010: Expected O, but got I4
		//IL_0057: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_00ae: Expected I4, but got O
		//IL_00b8: Expected O, but got I4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00d7: Expected O, but got I4
		//IL_00ee: Expected I4, but got O
		//IL_0106: Expected I4, but got O
		//IL_0128: Expected I4, but got O
		//IL_0143: Expected I4, but got O
		T0 val = (T0)3;
		T1 val2 = (T1)(setting.rbTypeChangeIP == 4);
		if (val2 != null)
		{
			T2 val3 = (T2)((IEnumerable<XProxy>)setting.XproxyList).Where((Func<XProxy, bool>)((XProxy a) => (T1)(!a.IsUsed))).ToList();
			T1 val4 = (T1)(((List<XProxy>)val3).Count <= 0);
			if (val4 != null)
			{
				T3 enumerator = (T3)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
					{
						XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
						current.IsUsed = false;
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T0 val5 = (T0)0;
			while (true)
			{
				T1 val6 = (T1)((nint)val5 < setting.XproxyList.Count);
				if (val6 != null)
				{
					T1 val7 = (T1)(!setting.XproxyList[(int)val5].IsUsed);
					if (val7 != null)
					{
						break;
					}
					val5 = (T0)(val5 + 1);
					continue;
				}
				return;
			}
			setting.XproxyList[(int)val5].IsUsed = true;
			proxy = setting.XproxyList[(int)val5].Proxy;
			new ChromeControl(proxy, int.Parse(index.ToString()), this, (int)val);
		}
		else
		{
			new ChromeControl(proxy, int.Parse(index.ToString()), this, (int)val);
		}
	}

	private unsafe void thrChrome<T0, T1, T2, T3, T4>(T4 index)
	{
		//IL_000e: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_0098: Expected O, but got I4
		//IL_00ab: Expected I4, but got O
		//IL_00b5: Expected O, but got I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00d4: Expected O, but got I4
		//IL_00eb: Expected I4, but got O
		//IL_0103: Expected I4, but got O
		T0 val = (T0)(setting.rbTypeChangeIP == 4);
		if (val != null)
		{
			T1 val2 = (T1)((IEnumerable<XProxy>)setting.XproxyList).Where((Func<XProxy, bool>)((XProxy a) => (T0)(!a.IsUsed))).ToList();
			T0 val3 = (T0)(((List<XProxy>)val2).Count <= 0);
			if (val3 != null)
			{
				T2 enumerator = (T2)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
					{
						XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
						current.IsUsed = false;
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
				}
			}
			T3 val4 = (T3)0;
			while (true)
			{
				T0 val5 = (T0)((nint)val4 < setting.XproxyList.Count);
				if (val5 != null)
				{
					T0 val6 = (T0)(!setting.XproxyList[(int)val4].IsUsed);
					if (val6 != null)
					{
						break;
					}
					val4 = (T3)(val4 + 1);
					continue;
				}
				return;
			}
			setting.XproxyList[(int)val4].IsUsed = true;
			proxy = setting.XproxyList[(int)val4].Proxy;
			openChrome<string, T3, T0, T4, char>(index);
		}
		else
		{
			openChrome<string, T3, T0, T4, char>(index);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void openChrome<T0, T1, T2, T3, T4>(T3 objStrIndex)
	{
		//IL_0009: Expected O, but got I4
		//IL_0016: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_0059: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		T0 val = (T0)objStrIndex.ToString();
		T1 val2 = (T1)0;
		T2 val3 = (T2)((string)val).Contains("|");
		if (val3 != null)
		{
			val2 = (T1)int.Parse(((string)val).Split((char[])(object)new T4[1] { (T4)124 })[0]);
			int.Parse(((string)val).Split((char[])(object)new T4[1] { (T4)124 })[1]);
		}
		else
		{
			val2 = (T1)int.Parse(objStrIndex.ToString());
		}
		T2 val4 = (T2)setting.ccbTarget.Equals("Facebook Chrome");
		if (val4 != null)
		{
			new ChromeControl(proxy, int.Parse(((int*)(&val2))->ToString()), this, 1);
			return;
		}
		T2 val5 = (T2)setting.ccbTarget.Equals("Facebook API");
		if (val5 != null)
		{
			new FacebookApi(this, int.Parse(((int*)(&val2))->ToString()), proxy, isAuto_Run_Follow: true);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 getProxyTmProxy<T0, T1, T2, T3>()
	{
		//IL_000c: Expected O, but got I4
		//IL_0015: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_00ae: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_0122: Expected O, but got I4
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_014c: Expected I4, but got O
		T0 result = (T0)"";
		T1 val = (T1)12000;
		GetNewProxy getNewProxy = null;
		while (true)
		{
			T2 val2 = (T2)isRunning;
			if (val2 == null)
			{
				break;
			}
			try
			{
				T0 id_location = (T0)listLocationTmProxy.data.locations[setting.ccbLocationTmProxy].id_location;
				T0 data = (T0)string.Concat((string[])(object)new T0[5]
				{
					(T0)"{\"api_key\":\"",
					(T0)setting.txtTmProxy,
					(T0)"\",\"sign\":\"string\",\"id_location\":",
					id_location,
					(T0)"}"
				});
				T0 val3 = HttpRequestClassToken.Post<T0, HttpWebRequest, HttpWebResponse, StreamWriter, StreamReader, WebException, T3>((T0)"https://tmproxy.com/api/proxy/get-new-proxy", data);
				getNewProxy = JsonConvert.DeserializeObject<GetNewProxy>((string)val3);
				T2 val4 = (T2)(getNewProxy.code == 0);
				if (val4 != null)
				{
					countUseProxy = int.Parse(System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)setting.numToChangeIP).ToString());
					T2 val5 = (T2)(setting.ccbTypeTMProxy == 0);
					result = (T0)((val5 != null) ? (getNewProxy.data.socks5 ?? "") : (getNewProxy.data.https ?? ""));
					break;
				}
				try
				{
					val = (T1)int.Parse(Regex.Match(getNewProxy.message, "\\d+").Value.ToString());
					val = (T1)(val + 15);
					val = (T1)(val * 1000);
				}
				catch
				{
				}
				goto IL_0146;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				goto IL_0146;
			}
			IL_0146:
			Thread.Sleep((int)val);
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 getProxyTinSoft<T0, T1, T2, T3>()
	{
		//IL_0009: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_006a: Expected O, but got I4
		//IL_0082: Expected O, but got I4
		//IL_0089: Expected I4, but got O
		//IL_00de: Expected O, but got I4
		//IL_00f0: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		//IL_0132: Expected O, but got I4
		//IL_016b: Expected O, but got I4
		//IL_0172: Expected I4, but got O
		//IL_0199: Expected O, but got I4
		TinSoftSV tinSoftSV = null;
		while (true)
		{
			T1 val = (T1)isRunning;
			if (val == null)
			{
				break;
			}
			try
			{
				T0 val2 = HttpRequestClassToken.Get<T0, HttpWebRequest, HttpWebResponse, StreamReader, WebException, T3>((T0)("http://proxy.tinsoftsv.com/api/getProxy.php?key=" + setting.txtTinSoftSV));
				T1 val3 = (T1)((string)val2).Contains("next_change");
				if (val3 != null)
				{
					T0 value = (T0)Regex.Match((string)val2, "next_change\":(.*?),\"").Groups[1].Value;
					T1 val4 = (T1)(!((string)value).Equals("0"));
					if (val4 != null)
					{
						T2 val5 = (T2)(int.Parse((string)value) * 1000 + 3000);
						Thread.Sleep((int)val5);
					}
				}
				countUseProxy = 0;
				val2 = HttpRequestClassToken.Get<T0, HttpWebRequest, HttpWebResponse, StreamReader, WebException, T3>((T0)("http://proxy.tinsoftsv.com/api/changeProxy.php?key=" + setting.txtTinSoftSV + "&location=" + listLocationTinsoft.data[setting.ccbLocationTinsoft].location));
				T1 val6 = (T1)((string)val2).Contains("wait");
				if (val6 == null)
				{
					T1 val7 = (T1)((string)val2).Contains("so fast");
					if (val7 != null)
					{
						Thread.Sleep(120000);
					}
					else
					{
						tinSoftSV = JsonConvert.DeserializeObject<TinSoftSV>((string)val2);
						countUseProxy = int.Parse(System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)setting.numToChangeIP).ToString());
						T1 val8 = (T1)bool.Parse(tinSoftSV.success);
						if (val8 != null)
						{
							break;
						}
					}
				}
				else
				{
					T0 value2 = (T0)Regex.Match((string)val2, "wait (.*?)s for next change").Groups[1].Value;
					T2 val9 = (T2)(int.Parse((string)value2) * 1000 + 2000);
					Thread.Sleep((int)val9);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Thread.Sleep(5000);
		}
		T1 val10 = (T1)(tinSoftSV == null);
		if (val10 == null)
		{
			return (T0)tinSoftSV.proxy;
		}
		return (T0)"";
	}

	private void timer_start_Tick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_0006: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0088: Expected O, but got I4
		T0 val = (T0)isRunning;
		if (val != null)
		{
			T1 val2 = (T1)((IEnumerable<FBEntity>)listFBEntity).Where((Func<FBEntity, bool>)((FBEntity a) => (T0)(a.Select && (a.Status.Equals(STATUS.Ready.ToString()) || a.Status.Equals(STATUS.Working.ToString()))))).ToList();
			T0 val3 = (T0)(((List<FBEntity>)val2).Count <= 0);
			if (val3 != null)
			{
				Stop<Thread, T0, Exception, string>();
			}
			lbSelected.Text = System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)((IEnumerable<FBEntity>)listFBEntity).Where((Func<FBEntity, bool>)((FBEntity a) => (T0)a.Select)).Count()).ToString();
		}
	}

	public void SetCellColor<T0, T1, T2>(T1 index, T2 color)
	{
		//IL_0014: Expected I4, but got O
		//IL_0022: Expected O, but got I4
		int index2 = (int)index;
		Color color2 = (Color)color;
		T0 val = (T0)_206F_200C_202A_200C_200B_206A_202E_206C_206C_202D_206B_200E_202C_200F_206D_206D_200D_206A_206A_202D_202D_200B_200C_202D_206D_202E_202E_206D_202C_202C_200E_202D_202D_202E_202D_206A_206B_200B_206A_206E_202E();
		if (val == null)
		{
			gvData.Rows[index2].DefaultCellStyle.ForeColor = color2;
			return;
		}
		Invoke((MethodInvoker)delegate
		{
			//IL_0017: Expected O, but got I4
			SetCellColor<T0, T1, T2>((T1)index2, (T2)color2);
		});
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetCellText<T0, T1, T2>(T1 index, T2 column, T2 value)
	{
		//IL_0014: Expected I4, but got O
		//IL_0029: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_00ef: Expected O, but got I4
		//IL_0109: Expected O, but got I4
		//IL_0146: Expected O, but got I4
		//IL_0160: Expected O, but got I4
		//IL_017a: Expected O, but got I4
		//IL_0194: Expected O, but got I4
		//IL_01ae: Expected O, but got I4
		//IL_01e6: Expected O, but got I4
		//IL_021e: Expected O, but got I4
		//IL_0238: Expected O, but got I4
		//IL_0270: Expected O, but got I4
		//IL_028a: Expected O, but got I4
		//IL_02a4: Expected O, but got I4
		//IL_02be: Expected O, but got I4
		//IL_02f6: Expected O, but got I4
		//IL_030d: Expected O, but got I4
		int index2 = (int)index;
		string column2 = (string)column;
		string value2 = (string)value;
		T0 val = (T0)_206F_200C_202A_200C_200B_206A_202E_206C_206C_202D_206B_200E_202C_200F_206D_206D_200D_206A_206A_202D_202D_200B_200C_202D_206D_202E_202E_206D_202C_202C_200E_202D_202D_202E_202D_206A_206B_200B_206A_206E_202E();
		if (val != null)
		{
			Invoke((MethodInvoker)delegate
			{
				//IL_001d: Expected O, but got I4
				SetCellText<T0, T1, T2>((T1)index2, (T2)column2, (T2)value2);
			});
			return;
		}
		T0 val2 = (T0)(gvData.Columns["cl" + column2] != null);
		if (val2 == null)
		{
			T0 val3 = (T0)(gvData.Columns[column2] != null);
			if (val3 != null)
			{
				gvData.Rows[index2].Cells[column2].Value = value2;
				return;
			}
			T0 val4 = (T0)column2.Equals("Note");
			if (val4 == null)
			{
				T0 val5 = (T0)column2.Equals("Name");
				if (val5 == null)
				{
					T0 val6 = (T0)column2.Equals("Friends");
					if (val6 != null)
					{
						listFBEntity[index2].Friends = int.Parse(value2);
						return;
					}
					T0 val7 = (T0)column2.Equals("GroupUId");
					if (val7 == null)
					{
						T0 val8 = (T0)column2.Equals("Group");
						if (val8 == null)
						{
							T0 val9 = (T0)column2.Equals("UID");
							if (val9 == null)
							{
								T0 val10 = (T0)column2.Equals("Password");
								if (val10 == null)
								{
									T0 val11 = (T0)column2.Equals("Code2FA");
									if (val11 != null)
									{
										listFBEntity[index2].Code2FA = value2;
										return;
									}
									T0 val12 = (T0)column2.Equals("Cookie");
									if (val12 != null)
									{
										listFBEntity[index2].Cookie = value2;
										return;
									}
									T0 val13 = (T0)column2.Equals("Socks");
									if (val13 == null)
									{
										T0 val14 = (T0)column2.Equals("UserAgent");
										if (val14 != null)
										{
											listFBEntity[index2].UserAgent = value2;
											return;
										}
										T0 val15 = (T0)column2.Equals("Message");
										if (val15 == null)
										{
											T0 val16 = (T0)column2.Equals("Status");
											if (val16 == null)
											{
												T0 val17 = (T0)column2.Equals("RivalLink");
												if (val17 == null)
												{
													T0 val18 = (T0)column2.Equals("TokenEAAG");
													if (val18 != null)
													{
														listFBEntity[index2].TokenEAAG = value2;
														return;
													}
													T0 val19 = (T0)column2.Equals("TokenEAAB");
													if (val19 == null)
													{
														T0 val20 = (T0)column2.Equals("Note");
														if (val20 != null)
														{
															listFBEntity[index2].Note = value2;
														}
													}
													else
													{
														listFBEntity[index2].TokenEAAB = value2;
													}
												}
												else
												{
													listFBEntity[index2].RivalLink = value2;
												}
											}
											else
											{
												listFBEntity[index2].Status = value2;
											}
										}
										else
										{
											listFBEntity[index2].Message = value2;
										}
									}
									else
									{
										listFBEntity[index2].Socks = value2;
									}
								}
								else
								{
									listFBEntity[index2].Password = value2;
								}
							}
							else
							{
								listFBEntity[index2].UID = value2;
							}
						}
						else
						{
							listFBEntity[index2].Group = int.Parse(value2);
						}
					}
					else
					{
						listFBEntity[index2].GroupUId = value2;
					}
				}
				else
				{
					listFBEntity[index2].Name = value2;
				}
			}
			else
			{
				listFBEntity[index2].Note = value2;
			}
		}
		else
		{
			gvData.Rows[index2].Cells["cl" + column2].Value = value2;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Stop<T0, T1, T2, T3>()
	{
		//IL_0007: Expected O, but got I4
		fblistSaving<T0, T1, T2>((T1)0);
		isRunning = false;
		isRunningVia = false;
		infoMessage((T3)"Complete!");
		btnStart.Text = "START";
	}

	private void numFromDelay_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		setting.numFromDelay = int.Parse(((decimal)(T0)numFromDelay.Value).ToString());
		settingSaving();
	}

	private void numToDelay_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		setting.numToDelay = int.Parse(((decimal)(T0)numToDelay.Value).ToString());
		settingSaving();
	}

	private void frmMain_FormClosing<T0, T1, T2, T3, T4>(T0 sender, T1 e)
	{
		//IL_0007: Expected O, but got I4
		fblistSaving<T2, T3, T4>((T3)0);
		cartSaving();
		Process.GetCurrentProcess().Kill();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void killChromeDriver<T0, T1, T2, T3>()
	{
		//IL_001a: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		Activator.CreateInstance(typeof(T0));
		T1[] processes = (T1[])(object)Process.GetProcesses();
		T1[] array = processes;
		T2 val = (T2)0;
		while ((nint)val < array.Length)
		{
			T1 val2 = (T1)((object[])(object)array)[(object)val];
			try
			{
				T3 val3 = (T3)(((Process)val2).ProcessName.Equals("chromedriver") || ((Process)val2).ProcessName.Equals("chrome"));
				if (val3 != null)
				{
					((Process)val2).Kill();
				}
			}
			catch (Exception)
			{
			}
			val = (T2)(val + 1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvData_CellClick<T0, T1, T2, T3, T4, T5>(T2 sender, T3 e)
	{
		//IL_000b: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		//IL_0075: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_00ad: Expected O, but got I4
		try
		{
			T0 val = (T0)(((DataGridViewCellEventArgs)e).ColumnIndex == 0);
			if (val != null)
			{
				SetCellText<T0, T4, T5>((T4)((DataGridViewCellEventArgs)e).RowIndex, (T5)"Select", (T5)System.Runtime.CompilerServices.Unsafe.As<T0, bool>(ref (T0)(!listFBEntity[((DataGridViewCellEventArgs)e).RowIndex].Select)).ToString());
				T0 val2 = (T0)listFBEntity[((DataGridViewCellEventArgs)e).RowIndex].Select;
				if (val2 != null)
				{
					SetCellText<T0, T4, T5>((T4)((DataGridViewCellEventArgs)e).RowIndex, (T5)"Message", (T5)"");
					SetCellText<T0, T4, T5>((T4)((DataGridViewCellEventArgs)e).RowIndex, (T5)"Step", (T5)"");
					SetCellText<T0, T4, T5>((T4)((DataGridViewCellEventArgs)e).RowIndex, (T5)"Status", (T5)STATUS.Ready.ToString());
				}
			}
		}
		catch (Exception ex)
		{
			errorMessage((T5)ex.Message);
		}
	}

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void changeSizeChrome<T0, T1, T2, T3, T4, T5, T6>()
	{
		//IL_0013: Expected O, but got I4
		//IL_0029: Expected O, but got I4
		//IL_005d: Expected O, but got I
		//IL_006c: Expected O, but got I4
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_0091: Expected O, but got I4
		//IL_0098: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_00c3: Expected O, but got I4
		//IL_00d7: Expected O, but got I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_00e1: Expected O, but got I4
		//IL_0107: Expected O, but got I
		//IL_0136: Expected I4, but got O
		//IL_0136: Expected I4, but got O
		//IL_0136: Expected I4, but got O
		//IL_0136: Expected I4, but got O
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_0141: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		T0 bounds = (T0)Screen.PrimaryScreen.Bounds;
		T1[] processes = (T1[])(object)Process.GetProcesses();
		T2 val = (T2)0;
		T3 val2 = (T3)Activator.CreateInstance(typeof(T3));
		T1[] array = processes;
		T2 val3 = (T2)0;
		while ((nint)val3 < array.Length)
		{
			T1 val4 = (T1)((object[])(object)array)[(object)val3];
			T4 val5 = (T4)(!string.IsNullOrWhiteSpace(((Process)val4).ProcessName) && ((Process)val4).ProcessName.Equals("chrome") && System.Runtime.CompilerServices.Unsafe.As<T5, IntPtr>(ref (T5)(nint)((Process)val4).MainWindowHandle).ToInt32() != 0);
			if (val5 != null)
			{
				((List<Process>)val2).Add((Process)val4);
			}
			val3 = (T2)(val3 + 1);
		}
		T2 val6 = (T2)(((Rectangle*)(&bounds))->Width / 3);
		T2 val7 = (T2)500;
		T4 val8 = (T4)(((List<Process>)val2).Count > 3);
		if (val8 == null)
		{
			val7 = (T2)(((Rectangle*)(&bounds))->Height - 40);
			val6 = (T2)(((Rectangle*)(&bounds))->Width / ((List<Process>)val2).Count);
		}
		else
		{
			val7 = (T2)(((Rectangle*)(&bounds))->Height / (((List<Process>)val2).Count / 2));
			val7 = (T2)(val7 + 40);
		}
		T2 val9 = (T2)0;
		T6 enumerator = (T6)((List<Process>)val2).GetEnumerator();
		try
		{
			while (((List<Process>.Enumerator*)(&enumerator))->MoveNext())
			{
				T1 current = (T1)((List<Process>.Enumerator*)(&enumerator))->Current;
				Console.WriteLine("{0}=>{1}=>{2}", (T5)(nint)((Process)current).MainWindowHandle, ((Process)current).MainWindowTitle, ((Process)current).ProcessName);
				SetWindowPos(((Process)current).MainWindowHandle, IntPtr.Zero, (object)val6 * (object)val, (int)val9, (int)val6, (int)val7, 0u);
				val = (T2)(val + 1);
				T4 val10 = (T4)((nint)val == 3);
				if (val10 != null)
				{
					val9 = (T2)((object)val9 + (object)val7);
					val = (T2)0;
				}
			}
		}
		finally
		{
			((IDisposable)(*(List<Process>.Enumerator*)(&enumerator))).Dispose();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button2_Click<T0, T1, T2, T3, T4>(T2 sender, T3 e)
	{
		//IL_0018: Expected O, but got I4
		//IL_003d: Expected I4, but got O
		//IL_00cb: Expected O, but got I4
		//IL_00f9: Expected O, but got I4
		type = setting.rbTypeChangeIP;
		T1 val = (T1)type;
		T1 val2 = val;
		switch ((int)val2)
		{
		default:
			rbNotChangeIP.Checked = true;
			break;
		case 0:
			infoMessage((T0)"Không chọn đổi IP!");
			break;
		case 1:
		{
			T0 ms = HttpRequestClassToken.Get<T0, HttpWebRequest, HttpWebResponse, StreamReader, WebException, Exception>((T0)("http://proxy.tinsoftsv.com/api/changeProxy.php?key=" + setting.txtTinSoftSV + "&location=" + listLocationTinsoft.data[setting.ccbLocationTinsoft].location));
			infoMessage(ms);
			break;
		}
		case 2:
			new Thread(changeIPHMA<Process, T1, List<Process>, T4, T0>).Start();
			break;
		case 3:
			getIP922<T0, T4, T1, T2>((T2)(object)(T4)1);
			break;
		case 4:
			button2.Enabled = false;
			new Thread((ParameterizedThreadStart)changeIPXproxy<T1, T4, List<XProxy>.Enumerator, T0, Exception, T2>).Start((T4)1);
			break;
		case 5:
		{
			T0 id_location = (T0)listLocationTmProxy.data.locations[setting.ccbLocationTmProxy].id_location;
			T0 data = (T0)string.Concat((string[])(object)new T0[5]
			{
				(T0)"{\"api_key\":\"",
				(T0)setting.txtTmProxy,
				(T0)"\",\"sign\":\"string\",\"id_location\":",
				id_location,
				(T0)"}"
			});
			T0 ms = HttpRequestClassToken.Post<T0, HttpWebRequest, HttpWebResponse, StreamWriter, StreamReader, WebException, Exception>((T0)"https://tmproxy.com/api/proxy/get-new-proxy", data);
			infoMessage(ms);
			break;
		}
		case 6:
			new Thread(changeIPProtonVPN<Process, T1, List<Process>, T4, T0>).Start();
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private T0 getIP922<T0, T1, T2, T3>(T3 boolTestIP)
	{
		//IL_0010: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		T1 val = (T1)string.IsNullOrWhiteSpace(setting.txt922Url);
		if (val != null)
		{
			errorMessage((T0)"Điền 922 url");
			txt922Url.Focus();
			return (T0)"";
		}
		T0 val2 = HttpRequestClassToken.Get<T0, HttpWebRequest, HttpWebResponse, StreamReader, WebException, Exception>((T0)setting.txt922Url);
		T1 val3 = (T1)(!string.IsNullOrWhiteSpace((string)val2));
		if (val3 != null)
		{
			countUseProxy = int.Parse(System.Runtime.CompilerServices.Unsafe.As<T2, int>(ref (T2)setting.numToChangeIP).ToString());
			val2 = (T0)((string)val2).Replace("\r\n", "");
			val2 = (T0)((string)val2).Trim();
		}
		T1 val4 = (T1)bool.Parse(boolTestIP.ToString());
		if (val4 != null)
		{
			infoMessage(val2);
		}
		return val2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void changeIPXproxy<T0, T1, T2, T3, T4, T5>(T5 boolTestIP)
	{
		//IL_002b: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_00e9: Expected O, but got I4
		//IL_00ef: Expected O, but got I4
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_011d: Expected O, but got I4
		//IL_018d: Expected O, but got I4
		//IL_0193: Expected O, but got I4
		//IL_01b8: Expected O, but got I4
		//IL_01db: Expected O, but got I4
		//IL_0203: Expected O, but got I4
		try
		{
			T1 val = (T1)(string.IsNullOrWhiteSpace(setting.XproxyIP) || setting.XproxyList.Count <= 0);
			if (val == null)
			{
				T2 enumerator = (T2)setting.XproxyList.GetEnumerator();
				try
				{
					while (((List<XProxy>.Enumerator*)(&enumerator))->MoveNext())
					{
						XProxy current = ((List<XProxy>.Enumerator*)(&enumerator))->Current;
						HttpRequestClassToken.Get<T3, HttpWebRequest, HttpWebResponse, StreamReader, WebException, T4>((T3)$"{setting.XproxyIP}/reset?proxy={current.Proxy}");
					}
				}
				finally
				{
					((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator))).Dispose();
				}
				T0 val2 = (T0)0;
				T1 val3 = (T1)1;
				while (true)
				{
					val3 = (T1)1;
					T2 enumerator2 = (T2)setting.XproxyList.GetEnumerator();
					try
					{
						while (((List<XProxy>.Enumerator*)(&enumerator2))->MoveNext())
						{
							XProxy current2 = ((List<XProxy>.Enumerator*)(&enumerator2))->Current;
							T3 val4 = (T3)((string)HttpRequestClassToken.Get<T3, HttpWebRequest, HttpWebResponse, StreamReader, WebException, T4>((T3)$"{setting.XproxyIP}/status?proxy={current2.Proxy}")).ToLower();
							T1 val5 = (T1)(!((string)val4).Contains("modem_ready") && !((string)val4).Contains("true"));
							if (val5 != null)
							{
								val3 = (T1)0;
							}
						}
					}
					finally
					{
						((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator2))).Dispose();
					}
					T1 val6 = val3;
					if (val6 != null)
					{
						break;
					}
					val2 = (T0)(val2 + 1);
					T1 val7 = (T1)((nint)val2 == 10);
					if (val7 != null)
					{
						T2 enumerator3 = (T2)setting.XproxyList.GetEnumerator();
						try
						{
							while (((List<XProxy>.Enumerator*)(&enumerator3))->MoveNext())
							{
								XProxy current3 = ((List<XProxy>.Enumerator*)(&enumerator3))->Current;
								T3 val8 = (T3)((string)HttpRequestClassToken.Get<T3, HttpWebRequest, HttpWebResponse, StreamReader, WebException, T4>((T3)$"{setting.XproxyIP}/reboot_usb?proxy={current3.Proxy}")).ToLower();
								T1 val9 = (T1)(!((string)val8).Contains("modem_ready") && !((string)val8).Contains("true"));
								if (val9 != null)
								{
									val3 = (T1)0;
								}
							}
						}
						finally
						{
							((IDisposable)(*(List<XProxy>.Enumerator*)(&enumerator3))).Dispose();
						}
					}
					Thread.Sleep(1500);
				}
				T1 val10 = (T1)bool.Parse(boolTestIP.ToString());
				if (val10 != null)
				{
					button2.Enabled = true;
					infoMessage((T3)"Change IP sucess!");
				}
				countUseProxy = int.Parse(System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)setting.numToChangeIP).ToString());
			}
			else
			{
				errorMessage((T3)"Please config Xproxy!");
			}
		}
		catch (Exception ex)
		{
			errorMessage((T3)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void changeIPProtonVPN<T0, T1, T2, T3, T4>()
	{
		//IL_001b: Expected O, but got I4
		//IL_004e: Expected O, but got I4
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0088: Expected O, but got I4
		T0[] processes = (T0[])(object)Process.GetProcesses();
		Activator.CreateInstance(typeof(T2));
		T0[] array = processes;
		T1 val = (T1)0;
		while ((nint)val < array.Length)
		{
			T0 val2 = (T0)((object[])(object)array)[(object)val];
			T3 val3 = (T3)(((Process)val2).MainWindowTitle.Equals("ProtonVPN") || ((Process)val2).MainWindowTitle.Equals("Proton VPN"));
			if (val3 == null)
			{
				val = (T1)(val + 1);
				continue;
			}
			hwnd = ((Process)val2).MainWindowHandle;
			procesHMA = (Process)val2;
			break;
		}
		T3 val4 = (T3)(hwnd == IntPtr.Zero);
		if (val4 != null)
		{
			isRunning = false;
			errorMessage((T4)"Chưa bật ProtonVPN!");
		}
		else
		{
			disableProtonVPN<T4, T1, Point, T3>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void disableProtonVPN<T0, T1, T2, T3>()
	{
		//IL_003b: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0062: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_007c: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c1: Expected O, but got I4
		//IL_00cf: Expected O, but got I4
		//IL_0103: Expected O, but got I4
		//IL_0109: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		//IL_014b: Expected O, but got I4
		//IL_015b: Expected O, but got I4
		//IL_015f: Expected O, but got I4
		//IL_016b: Expected O, but got I4
		//IL_0175: Expected O, but got I4
		radioHMA = FindHandle<IntPtr, T0, List<IntPtr>>(hwnd, (T0)classNameHMA, (T0)"");
		radioHMA = hwnd;
		T3 val = (T3)(radioHMA == IntPtr.Zero);
		if (val == null)
		{
			T0 message = (T0)"";
			T0 myIP = GetMyIP<T0, WebRequest, HttpWebResponse, Stream, StreamReader, T3, Exception>(out *(string*)(&message));
			T1 val2 = (T1)0;
			T3 val12;
			do
			{
				SetForegroundWindow(hwnd);
				Thread.Sleep(3000);
				rectRadioHMA = GetWindowRectImp(hwnd);
				T2 globalPoint = GetGlobalPoint<T2, IntPtr, T1>(radioHMA, (T1)270, (T1)230);
				MouseClick(globalPoint);
				T1 val3 = (T1)310;
				T1 val4 = (T1)50;
				T1 val5 = (T1)setting.numProtonVPN;
				T3 val6 = (T3)((nint)val5 >= 3);
				if (val6 != null)
				{
					val5 = (T1)(val5 + 1);
					val4 = (T1)45;
				}
				T1 val7 = (T1)1;
				while (true)
				{
					T3 val8 = (T3)(val7 < val5);
					if (val8 == null)
					{
						break;
					}
					val3 = (T1)((object)val3 + (object)val4);
					val7 = (T1)(val7 + 1);
				}
				globalPoint = GetGlobalPoint<T2, IntPtr, T1>(radioHMA, (T1)270, val3);
				MouseClick(globalPoint);
				Thread.Sleep(1500);
				MouseClick(globalPoint);
				T3 val11;
				do
				{
					Thread.Sleep(3000);
					T0 myIP2 = GetMyIP<T0, WebRequest, HttpWebResponse, Stream, StreamReader, T3, Exception>(out *(string*)(&message));
					T3 val9 = (T3)(!string.IsNullOrWhiteSpace((string)myIP2) && !((string)myIP2).Equals((string)myIP));
					if (val9 == null)
					{
						val2 = (T1)(val2 + 1);
						T3 val10 = (T3)((nint)val2 == 3);
						if (val10 != null)
						{
							break;
						}
						val11 = (T3)((nint)val2 >= 10);
						continue;
					}
					val2 = (T1)0;
					break;
				}
				while (val11 == null);
				val12 = (T3)((nint)val2 == 3);
			}
			while (val12 != null);
			countUseProxy = setting.numToChangeIP;
		}
		else
		{
			errorMessage((T0)"Chưa bật ProtonVPN!");
		}
	}

	[DllImport("user32.dll")]
	internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void changeIPHMA<T0, T1, T2, T3, T4>()
	{
		//IL_001b: Expected O, but got I4
		//IL_0037: Expected O, but got I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0071: Expected O, but got I4
		T0[] processes = (T0[])(object)Process.GetProcesses();
		Activator.CreateInstance(typeof(T2));
		T0[] array = processes;
		T1 val = (T1)0;
		while ((nint)val < array.Length)
		{
			T0 val2 = (T0)((object[])(object)array)[(object)val];
			T3 val3 = (T3)((Process)val2).MainWindowTitle.Equals("HMA VPN");
			if (val3 == null)
			{
				val = (T1)(val + 1);
				continue;
			}
			hwnd = ((Process)val2).MainWindowHandle;
			procesHMA = (Process)val2;
			break;
		}
		T3 val4 = (T3)(hwnd == IntPtr.Zero);
		if (val4 != null)
		{
			isRunning = false;
			errorMessage((T4)"Chưa bật HMA!");
		}
		else
		{
			disableHMA<T4, T1, T3>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private unsafe void disableHMA<T0, T1, T2>()
	{
		//IL_002e: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_005e: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_00ca: Expected O, but got I4
		//IL_00ca: Expected O, but got I4
		//IL_00ca: Expected O, but got I4
		radioHMA = FindHandle<IntPtr, T0, List<IntPtr>>(hwnd, (T0)classNameHMA, (T0)"");
		T2 val = (T2)(radioHMA == IntPtr.Zero);
		if (val != null)
		{
			errorMessage((T0)"Chưa bật HMA!");
			return;
		}
		T0 message = (T0)"";
		T0 myIP = GetMyIP<T0, WebRequest, HttpWebResponse, Stream, StreamReader, T2, Exception>(out *(string*)(&message));
		T1 val2 = (T1)0;
		T2 val6;
		do
		{
			rectRadioHMA = GetWindowRectImp(hwnd);
			SendClickOnPosition<T1, IntPtr, T2>(radioHMA, (T1)460, (T1)370, EMouseKey.LEFT, (T1)1);
			T2 val5;
			do
			{
				Thread.Sleep(3000);
				T0 myIP2 = GetMyIP<T0, WebRequest, HttpWebResponse, Stream, StreamReader, T2, Exception>(out *(string*)(&message));
				T2 val3 = (T2)(!((string)myIP2).Equals((string)myIP));
				if (val3 == null)
				{
					val2 = (T1)(val2 + 1);
					T2 val4 = (T2)((nint)val2 == 3);
					if (val4 != null)
					{
						break;
					}
					val5 = (T2)((nint)val2 >= 10);
					continue;
				}
				val2 = (T1)0;
				break;
			}
			while (val5 == null);
			val6 = (T2)((nint)val2 == 3);
		}
		while (val6 != null);
		countUseProxy = setting.numToChangeIP;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void whilePopup<T0, T1>(T0 old_count_vpn, T1 isEqual)
	{
		//IL_0002: Expected O, but got I4
		//IL_0019: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0032: Expected O, but got I4
		T0 val = (T0)0;
		while (true)
		{
			T0 val2 = countProcessByName<Process, T0, string>("vpn");
			Console.WriteLine($"{old_count_vpn}={val2}={isEqual}");
			T1 val3 = (T1)((isEqual != null && (object)old_count_vpn == (object)val2) || (isEqual == null && (object)old_count_vpn != (object)val2));
			if (val3 != null)
			{
				break;
			}
			T1 val4 = (T1)(isEqual == null);
			if (val4 != null)
			{
				val = (T0)(val + 1);
				T1 val5 = (T1)((nint)val >= 15);
				if (val5 != null)
				{
					break;
				}
			}
			Thread.Sleep(1000);
		}
	}

	private T1 countProcessByName<T0, T1, T2>(T2 processName)
	{
		//IL_0036: Expected O, but got I4
		T0[] processes = (T0[])(object)Process.GetProcesses();
		return (T1)((List<Process>)(object)processes.Where((Func<T0, bool>)(object)new Func<Process, bool>(_003C_003Ec._003C_003E9._003CcountProcessByName_003Eb__202_0<bool, T0>)).ToList()).Count;
	}

	public static T1 GetText<T0, T1, T2>(T2 hWnd)
	{
		//IL_0017: Expected I, but got O
		T0 val = (T0)new StringBuilder(256);
		GetWindowText((IntPtr)hWnd, (StringBuilder)val, 256);
		return (T1)val.ToString().Trim();
	}

	public static string GetClassName(IntPtr hWnd)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		GetClassName(hWnd, stringBuilder, 256);
		return stringBuilder.ToString().Trim();
	}

	public static T0 FindHandlesWithText<T0, T1, T2>(T0 handles, T1 className, T1 text)
	{
		_003C_003Ec__DisplayClass205_0 _003C_003Ec__DisplayClass205_ = new _003C_003Ec__DisplayClass205_0();
		_003C_003Ec__DisplayClass205_.className = (string)className;
		_003C_003Ec__DisplayClass205_.text = (string)text;
		Activator.CreateInstance(typeof(T0));
		return (T0)((IEnumerable<T2>)handles).Where((Func<T2, bool>)(object)new Func<IntPtr, bool>(_003C_003Ec__DisplayClass205_._003CFindHandlesWithText_003Eb__0<bool, T2, StringBuilder, T1>)).ToList();
	}

	public static T0 FindHandles<T0, T1, T2>(T1 parentHandle, T2 className, T2 text)
	{
		return FindHandlesWithText<T0, T2, T1>(GetChildHandle<T0, T1>(parentHandle), className, text);
	}

	public static T0 GetChildHandle<T0, T1>(T1 parentHandle)
	{
		//IL_001c: Expected O, but got I
		//IL_0044: Expected I, but got O
		//IL_0044: Expected I, but got O
		T0 val = (T0)Activator.CreateInstance(typeof(T0));
		T1 val2 = (T1)(nint)GCHandle.ToIntPtr(GCHandle.Alloc(val));
		try
		{
			EnumWindowProc callback = _003C_003Ec._003C_003E9._003CGetChildHandle_003Eb__207_0<bool, GCHandle, T1>;
			EnumChildWindows((IntPtr)parentHandle, callback, (IntPtr)val2);
		}
		finally
		{
		}
		return val;
	}

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	public static void SendClickOnPosition<T0, T1, T2>(T1 controlHandle, T0 x, T0 y, EMouseKey mouseButton = EMouseKey.LEFT, T0 clickTimes = 1)
	{
		//IL_0002: Expected O, but got I4
		//IL_0004: Expected O, but got I4
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		//IL_0028: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_0056: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_0080: Expected I, but got O
		//IL_0080: Expected I4, but got O
		//IL_0080: Expected I, but got O
		//IL_008f: Expected I, but got O
		//IL_008f: Expected I4, but got O
		//IL_008f: Expected I, but got O
		//IL_0095: Expected O, but got I4
		//IL_00a5: Expected I, but got O
		//IL_00a5: Expected I, but got O
		//IL_00b4: Expected I, but got O
		//IL_00b4: Expected I4, but got O
		//IL_00b4: Expected I, but got O
		//IL_00c3: Expected I, but got O
		//IL_00c3: Expected I4, but got O
		//IL_00c3: Expected I, but got O
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d5: Expected O, but got I4
		T0 val = (T0)0;
		T0 val2 = (T0)0;
		T2 val3 = (T2)(mouseButton == EMouseKey.LEFT);
		if (val3 != null)
		{
			val = (T0)513;
			val2 = (T0)514;
		}
		T2 val4 = (T2)(mouseButton == EMouseKey.RIGHT);
		if (val4 != null)
		{
			val = (T0)516;
			val2 = (T0)517;
		}
		T1 val5 = MakeLParamFromXY<T1, T0>(x, y);
		T2 val6 = (T2)(mouseButton == EMouseKey.LEFT || mouseButton == EMouseKey.RIGHT);
		if (val6 == null)
		{
			T2 val7 = (T2)(mouseButton == EMouseKey.DOUBLE_LEFT);
			if (val7 != null)
			{
				val = (T0)515;
				val2 = (T0)514;
			}
			T2 val8 = (T2)(mouseButton == EMouseKey.DOUBLE_RIGHT);
			if (val8 != null)
			{
				val = (T0)518;
				val2 = (T0)517;
			}
			PostMessage((IntPtr)controlHandle, (int)val, new IntPtr(1), (IntPtr)val5);
			PostMessage((IntPtr)controlHandle, (int)val2, new IntPtr(0), (IntPtr)val5);
			return;
		}
		T0 val9 = (T0)0;
		while (true)
		{
			T2 val10 = (T2)(val9 >= clickTimes);
			if (val10 == null)
			{
				PostMessage((IntPtr)controlHandle, 6, new IntPtr(1), (IntPtr)val5);
				PostMessage((IntPtr)controlHandle, (int)val, new IntPtr(1), (IntPtr)val5);
				PostMessage((IntPtr)controlHandle, (int)val2, new IntPtr(0), (IntPtr)val5);
				val9 = (T0)(val9 + 1);
				continue;
			}
			break;
		}
	}

	public static T0 MakeLParamFromXY<T0, T1>(T1 x, T1 y)
	{
		//IL_000b: Expected I4, but got O
		//IL_000c: Expected O, but got I
		return (T0)(nint)(IntPtr)((object)((object)y << 16) | (object)x);
	}

	public new void MouseClick<T0>(T0 point, EMouseKey mouseKey = EMouseKey.LEFT)
	{
		Cursor.Position = (Point)point;
		Click(mouseKey);
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	public static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

	public new void Click(EMouseKey mouseKey = EMouseKey.LEFT)
	{
		switch (mouseKey)
		{
		case EMouseKey.LEFT:
			mouse_event(32774u, 0, 0, 0, UIntPtr.Zero);
			break;
		case EMouseKey.RIGHT:
			mouse_event(32792u, 0, 0, 0, UIntPtr.Zero);
			break;
		case EMouseKey.DOUBLE_LEFT:
			mouse_event(32774u, 0, 0, 0, UIntPtr.Zero);
			mouse_event(32774u, 0, 0, 0, UIntPtr.Zero);
			break;
		case EMouseKey.DOUBLE_RIGHT:
			mouse_event(32792u, 0, 0, 0, UIntPtr.Zero);
			mouse_event(32792u, 0, 0, 0, UIntPtr.Zero);
			break;
		}
	}

	public unsafe T0 GetGlobalPoint<T0, T1, T2>(T1 hWnd, T2 x = 0, T2 y = 0)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected I4, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected I4, but got Unknown
		T0 result = default(T0);
		RECT windowRectImp = GetWindowRectImp(hWnd);
		((Point*)(&result))->X = x + windowRectImp.Left;
		((Point*)(&result))->Y = y + windowRectImp.Top;
		return result;
	}

	[DllImport("user32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

	public RECT GetWindowRectImp<T0>(T0 hWnd)
	{
		//IL_0010: Expected I, but got O
		RECT lpRect = default(RECT);
		GetWindowRect((IntPtr)hWnd, ref lpRect);
		return lpRect;
	}

	public T0 FindHandle<T0, T1, T2>(T0 parentHandle, T1 className, T1 text)
	{
		return FindHandleWithText<T0, T2, T1>(GetChildHandle<T2, T0>(parentHandle), className, text);
	}

	public T0 FindHandleWithText<T0, T1, T2>(T1 handles, T2 className, T2 text)
	{
		//IL_0027: Expected O, but got I
		_003C_003Ec__DisplayClass220_0 _003C_003Ec__DisplayClass220_ = new _003C_003Ec__DisplayClass220_0();
		_003C_003Ec__DisplayClass220_.className = (string)className;
		_003C_003Ec__DisplayClass220_.text = (string)text;
		return (T0)(nint)((List<IntPtr>)handles).Find((Predicate<IntPtr>)_003C_003Ec__DisplayClass220_._003CFindHandleWithText_003Eb__0<bool, T0, StringBuilder, T2>);
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

	[DllImport("user32")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

	[DllImport("User32.dll")]
	public static extern int GetWindowText(IntPtr hWnd, StringBuilder s, int nMaxCount);

	private void rb911_CheckedChanged<T0, T1, T2>(T0 sender, T1 e)
	{
		setTypeChangeIP<T2>();
	}

	private void rbHMA_CheckedChanged<T0, T1, T2>(T0 sender, T1 e)
	{
		setTypeChangeIP<T2>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void txtCamp_TextChanged<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_000c: Expected O, but got I4
		T0 val = (T0)File.Exists("campaigns.txt");
		if (val != null)
		{
			File.Delete("campaigns.txt");
		}
		T1 val2 = (T1)new StreamWriter(File.Open("campaigns.txt", FileMode.OpenOrCreate), Encoding.Unicode);
		try
		{
			((TextWriter)val2).WriteLine(CAMPAIGNS);
		}
		finally
		{
			if (val2 != null)
			{
				((IDisposable)val2).Dispose();
			}
		}
	}

	private void button1_Click_2<T0, T1, T2, T3>(T0 sender, T1 e)
	{
		listPro5Used.Clear();
		Start<T2, T3>();
	}

	private void gvData_CellValueChanged<T0, T1>(T0 sender, T1 e)
	{
	}

	private void txtKeyword_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		setting.txtKeyword = txtSearch.Text;
		settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvUserAgent_MouseClick<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(((MouseEventArgs)e).Button == MouseButtons.Right);
		if (val != null)
		{
			T1 val2 = (T1)Activator.CreateInstance(typeof(ContextMenu));
			T2 item = (T2)new MenuItem("Paste Useragent", (EventHandler)pasteUserAgentEvent<string, int, T0, T3, EventArgs>);
			((Menu)val2).MenuItems.Add((MenuItem)item);
			T2 item2 = (T2)new MenuItem("Xóa toàn bộ", (EventHandler)deleteAllUserAgentEvent<T0, T3, EventArgs, DialogResult, string>);
			((Menu)val2).MenuItems.Add((MenuItem)item2);
			((ContextMenu)val2).Show((Control)gvUserAgent, new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pasteUserAgentEvent<T0, T1, T2, T3, T4>(T3 sender, T4 e)
	{
		//IL_001e: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		T0 val = (T0)Clipboard.GetText();
		T0[] array = (T0[])(object)((string)val).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		T0[] array2 = array;
		T1 val2 = (T1)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T2 val4 = (T2)(!string.IsNullOrEmpty((string)val3));
			if (val4 != null)
			{
				UserAgentEntity item = new UserAgentEntity
				{
					UserAgent = (string)val3
				};
				listUserAgent.Add(item);
			}
			val2 = (T1)(val2 + 1);
		}
		loadUserAgent<T2>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void deleteAllUserAgentEvent<T0, T1, T2, T3, T4>(T1 sender, T2 e)
	{
		//IL_000f: Expected O, but got I4
		T0 val = (T0)((nint)questioniMessage<T3, T4>((T4)"Are you sure?") == 6);
		if (val != null)
		{
			listUserAgent.Clear();
			loadUserAgent<T0>();
		}
	}

	private void loadUserAgent<T0>()
	{
		//IL_0012: Expected O, but got I4
		//IL_0051: Expected O, but got I4
		T0 val = (T0)(listUserAgent.Count <= 0);
		if (val != null)
		{
			listUserAgent.Add(new UserAgentEntity());
		}
		else
		{
			T0 val2 = (T0)(string.IsNullOrWhiteSpace(listUserAgent[0].UserAgent) && listUserAgent.Count > 1);
			if (val2 != null)
			{
				listUserAgent.RemoveAt(0);
			}
		}
		gvUserAgent.DataSource = null;
		gvUserAgent.DataSource = listUserAgent;
		useragentSaving();
	}

	private void btnConfig_Click<T0, T1, T2, T3>(T1 sender, T2 e)
	{
		//IL_0020: Expected O, but got I4
		frmModule frmModule2 = new frmModule(this, (List<int>)Activator.CreateInstance(typeof(T3)));
		T0 val = (T0)(frmModule2.ShowDialog() == DialogResult.OK);
		if (val != null)
		{
		}
	}

	private void numTimeDelay_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		setting.numTimeDelay = int.Parse(((decimal)(T0)numTimeDelay.Value).ToString());
		settingSaving();
	}

	private void button5_Click<T0, T1>(T0 sender, T1 e)
	{
		searchVia<string, int, bool, char>();
	}

	private void searchVia<T0, T1, T2, T3>()
	{
		//IL_0037: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_0064: Expected I4, but got O
		//IL_007d: Expected I4, but got O
		//IL_00a0: Expected I4, but got O
		//IL_00b9: Expected I4, but got O
		//IL_00dc: Expected I4, but got O
		//IL_00f5: Expected I4, but got O
		//IL_0118: Expected I4, but got O
		//IL_0131: Expected I4, but got O
		//IL_0154: Expected I4, but got O
		//IL_016d: Expected I4, but got O
		//IL_018d: Expected I4, but got O
		//IL_01a6: Expected I4, but got O
		//IL_01c6: Expected I4, but got O
		//IL_01df: Expected I4, but got O
		//IL_0202: Expected I4, but got O
		//IL_021b: Expected I4, but got O
		//IL_0231: Expected O, but got I4
		//IL_0247: Expected I4, but got O
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_0264: Expected O, but got I4
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		gvData.ClearSelection();
		T0 val = (T0)txtSearch.Text.ToLower().Trim();
		T0[] array = (T0[])(object)((string)val).Split((char[])(object)new T3[1] { (T3)124 });
		T0[] array2 = array;
		T1 val2 = (T1)0;
		while ((nint)val2 < array2.Length)
		{
			T0 val3 = (T0)((object[])(object)array2)[(object)val2];
			T0 value = (T0)((string)val3).Trim().ToLower();
			T1 val4 = (T1)0;
			while (true)
			{
				T2 val5 = (T2)((nint)val4 < listFBEntity.Count);
				if (val5 == null)
				{
					break;
				}
				T2 val6 = (T2)((!string.IsNullOrWhiteSpace(listFBEntity[(int)val4].Status) && listFBEntity[(int)val4].Status.ToLower().Contains((string)value)) || (!string.IsNullOrWhiteSpace(listFBEntity[(int)val4].Message) && listFBEntity[(int)val4].Message.ToLower().Contains((string)value)) || (!string.IsNullOrWhiteSpace(listFBEntity[(int)val4].UID) && listFBEntity[(int)val4].UID.ToLower().Contains((string)value)) || (!string.IsNullOrWhiteSpace(listFBEntity[(int)val4].Name) && listFBEntity[(int)val4].Name.ToLower().Contains((string)value)) || (!string.IsNullOrWhiteSpace(listFBEntity[(int)val4].Shopee_Status) && listFBEntity[(int)val4].Shopee_Status.ToLower().Contains((string)value)) || (!string.IsNullOrWhiteSpace(listFBEntity[(int)val4].UserAgent) && listFBEntity[(int)val4].UserAgent.ToLower().Contains((string)value)) || (!string.IsNullOrWhiteSpace(listFBEntity[(int)val4].Note) && listFBEntity[(int)val4].Note.ToLower().Contains((string)value)) || (!string.IsNullOrWhiteSpace(listFBEntity[(int)val4].Step) && listFBEntity[(int)val4].Step.ToLower().Contains((string)value)));
				if (val6 != null)
				{
					gvData.Rows[(int)val4].Selected = true;
				}
				val4 = (T1)(val4 + 1);
			}
			val2 = (T1)(val2 + 1);
		}
	}

	private void SetLanguage<T0>(T0 cultureName)
	{
	}

	private void rbUseXproxy_CheckedChanged<T0, T1, T2>(T0 sender, T1 e)
	{
		btnConfigXproxy.Enabled = rbUseXproxy.Checked;
		setTypeChangeIP<T2>();
	}

	private void lbLanguage_LinkClicked<T0, T1>(T0 sender, T1 e)
	{
	}

	private void groupBox1_Enter<T0, T1>(T0 sender, T1 e)
	{
	}

	private void rbMaximumChrome_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		setting.ChromeSize = 0;
		settingSaving();
		setChromeSize<bool>();
	}

	private void rbAutoSortSizeChrome_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		setting.ChromeSize = 1;
		settingSaving();
		setChromeSize<bool>();
	}

	private void rbCustomSizeChrome_CheckedChanged_1<T0, T1>(T0 sender, T1 e)
	{
		setting.ChromeSize = 2;
		settingSaving();
		setChromeSize<bool>();
	}

	private void setChromeSize<T0>()
	{
		//IL_000e: Expected O, but got I4
		T0 val = (T0)(setting.ChromeSize == 2);
		if (val == null)
		{
			numChromeCustomSizeHeigth.Enabled = false;
			numChromeCustomSizeWidth.Enabled = false;
		}
		else
		{
			numChromeCustomSizeHeigth.Enabled = true;
			numChromeCustomSizeWidth.Enabled = true;
		}
	}

	private void numChromeCustomSizeWidth_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		setting.numChromeWidth = int.Parse(((decimal)(T0)numChromeCustomSizeWidth.Value).ToString());
		settingSaving();
	}

	private void numChromeCustomSizeHeigth_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		setting.numChromeHeight = int.Parse(((decimal)(T0)numChromeCustomSizeHeigth.Value).ToString());
		settingSaving();
	}

	private void càiĐặtToolStripMenuItem_Click<T0, T1>(T0 sender, T1 e)
	{
	}

	private void hiệnThịCộtDữLiệuToolStripMenuItem_Click<T0, T1>(T0 sender, T1 e)
	{
		frmSetting frmSetting2 = new frmSetting(this);
		frmSetting2.Show();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cbListFolder_ItemCheck<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T4 sender, T5 e)
	{
		//IL_0007: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0042: Expected I4, but got O
		//IL_0054: Expected O, but got I4
		//IL_0064: Expected I4, but got O
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_007d: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		T0 val = (T0)((T1)((ItemCheckEventArgs)e).NewValue).ToString().ToLower().Equals("checked");
		if (val == null)
		{
			return;
		}
		fblistSaving<T6, T0, T3>((T0)0);
		T2 val2 = (T2)0;
		while (true)
		{
			T0 val3 = (T0)((nint)val2 < cbListFolder.Items.Count);
			if (val3 == null)
			{
				break;
			}
			T0 val4 = (T0)(cbListFolder.GetItemChecked((int)val2) && (nint)val2 != ((ItemCheckEventArgs)e).Index);
			if (val4 != null)
			{
				cbListFolder.SetItemChecked((int)val2, value: false);
			}
			val2 = (T2)(val2 + 1);
		}
		folderCheckedIndex = ((ItemCheckEventArgs)e).Index;
		FileNameFBList = $"Data\\{listFolder[folderCheckedIndex].ID}.json";
		groupFolder.Text = listFolder[folderCheckedIndex].Name;
		try
		{
			T0 val5 = (T0)File.Exists(FileNameFBList);
			if (val5 != null)
			{
				listFBEntity = (List<FBEntity>)JsonConvert.DeserializeObject<T7>(File.ReadAllText(FileNameFBList));
			}
			else
			{
				listFBEntity.Clear();
				listFBEntity = (List<FBEntity>)Activator.CreateInstance(typeof(T7));
			}
			setQuantityFolder<T2, T0, T8, T9, T10, T11, T12>();
			loadData<T0, T2>();
		}
		catch (Exception ex)
		{
			errorMessage((T8)ex.Message);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button1_Click<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 sender, T2 e)
	{
		//IL_0023: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		frmFolder frmFolder2 = new frmFolder("", isNew: true, "Thư mục");
		frmFolder2.ShowDialog();
		T0 val = (T0)(frmFolder2.isSave == 1);
		if (val != null)
		{
			listFolder.Add(new Folder
			{
				ID = (string)RandomString<T3, T4, T5>((T4)20),
				Name = frmFolder2.newName,
				Quanity = 0
			});
			listFolderSaving<T0, T3, T6, T7, T8, T9>();
			loadFolder<T0, T10, T11, T12, T3, T6, T7, T8, T9, T4>();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button3_Click<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T2 sender, T3 e)
	{
		//IL_0012: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		T0 val = (T0)(cbListFolder.SelectedIndex != -1);
		if (val == null)
		{
			return;
		}
		T1 name = (T1)listFolder[cbListFolder.SelectedIndex].Name;
		frmFolder frmFolder2 = new frmFolder((string)name, isNew: false, "Thư mục");
		frmFolder2.ShowDialog();
		T0 val2 = (T0)(frmFolder2.isSave == 1);
		if (val2 != null)
		{
			listFolder[cbListFolder.SelectedIndex].Name = frmFolder2.newName;
			listFolderSaving<T0, T1, T4, T5, T6, T7>();
		}
		else
		{
			T0 val3 = (T0)(frmFolder2.isSave == 2);
			if (val3 != null)
			{
				listFolder.RemoveAt(cbListFolder.SelectedIndex);
				listFolderSaving<T0, T1, T4, T5, T6, T7>();
			}
		}
		loadFolder<T0, T8, T9, T10, T1, T4, T5, T6, T7, T11>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gvData_DataSourceChanged<T0, T1, T2, T3>(T2 sender, T3 e)
	{
		//IL_001a: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_0032: Expected I4, but got O
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_006a: Expected O, but got I4
		//IL_008a: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		//IL_00a5: Expected I4, but got O
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00e2: Expected O, but got I4
		T0 val = (T0)(gvData.Columns["clRow"] != null);
		if (val != null)
		{
			T1 val2 = (T1)0;
			while (true)
			{
				T0 val3 = (T0)((nint)val2 < gvData.Rows.Count);
				if (val3 != null)
				{
					gvData.Rows[(int)val2].Cells["clRow"].Value = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)(val2 + 1)).ToString();
					val2 = (T1)(val2 + 1);
					continue;
				}
				break;
			}
			return;
		}
		T0 val4 = (T0)(gvData.Columns["Row"] != null);
		if (val4 == null)
		{
			return;
		}
		T1 val5 = (T1)0;
		while (true)
		{
			T0 val6 = (T0)((nint)val5 < gvData.Rows.Count);
			if (val6 != null)
			{
				gvData.Rows[(int)val5].Cells["Row"].Value = System.Runtime.CompilerServices.Unsafe.As<T1, int>(ref (T1)(val5 + 1)).ToString();
				val5 = (T1)(val5 + 1);
				continue;
			}
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void btnDown_Click<T0, T1, T2, T3, T4, T5, T6>(T2 sender, T3 e)
	{
		//IL_0013: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		//IL_00a3: Expected I4, but got O
		//IL_00b3: Expected I4, but got O
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected I4, but got Unknown
		//IL_00cf: Expected I4, but got O
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected I4, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected I4, but got Unknown
		//IL_00f7: Expected O, but got I4
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected I4, but got Unknown
		T0 val = (T0)gvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
		T1 val2 = (T1)(val == null);
		if (val2 == null)
		{
			T1 val3 = (T1)((nint)val > 1);
			if (val3 != null)
			{
				errorMessage((T4)"Chỉ được phép chọn 1 dòng!");
				return;
			}
			T1 val4 = (T1)((nint)val == 1 && gvData.SelectedRows[0].Index + 1 >= gvData.Rows.Count);
			if (val4 != null)
			{
				errorMessage((T4)"Hết dòng!");
				return;
			}
			T0 val5 = (T0)gvData.SelectedRows[0].Index;
			FBEntity value = listFBEntity[(int)val5];
			listFBEntity[(int)val5] = null;
			listFBEntity[(int)val5] = listFBEntity[val5 + 1];
			listFBEntity[val5 + 1] = null;
			listFBEntity[val5 + 1] = value;
			fblistSaving<T5, T1, T6>((T1)1);
			gvData.ClearSelection();
			gvData.Rows[val5 + 1].Selected = true;
		}
		else
		{
			errorMessage((T4)"Chọn dòng muốn sắp xếp!");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void btnUp_Click<T0, T1, T2, T3, T4, T5, T6>(T2 sender, T3 e)
	{
		//IL_0013: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_0059: Expected O, but got I4
		//IL_0077: Expected O, but got I4
		//IL_0084: Expected I4, but got O
		//IL_0094: Expected I4, but got O
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected I4, but got Unknown
		//IL_00b0: Expected I4, but got O
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected I4, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected I4, but got Unknown
		//IL_00d8: Expected O, but got I4
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected I4, but got Unknown
		T0 val = (T0)gvData.Rows.GetRowCount(DataGridViewElementStates.Selected);
		T1 val2 = (T1)(val == null);
		if (val2 == null)
		{
			T1 val3 = (T1)((nint)val > 1);
			if (val3 != null)
			{
				errorMessage((T4)"Chỉ được phép chọn 1 dòng!");
				return;
			}
			T1 val4 = (T1)((nint)val == 1 && gvData.SelectedRows[0].Index - 1 < 0);
			if (val4 == null)
			{
				T0 val5 = (T0)gvData.SelectedRows[0].Index;
				FBEntity value = listFBEntity[(int)val5];
				listFBEntity[(int)val5] = null;
				listFBEntity[(int)val5] = listFBEntity[val5 - 1];
				listFBEntity[val5 - 1] = null;
				listFBEntity[val5 - 1] = value;
				fblistSaving<T5, T1, T6>((T1)1);
				gvData.ClearSelection();
				gvData.Rows[val5 - 1].Selected = true;
			}
			else
			{
				errorMessage((T4)"Hết dòng!");
			}
		}
		else
		{
			errorMessage((T4)"Chọn dòng muốn sắp xếp!");
		}
	}

	private void gvData_CellEndEdit<T0, T1, T2, T3, T4>(T0 sender, T1 e)
	{
		//IL_0007: Expected O, but got I4
		fblistSaving<T2, T3, T4>((T3)1);
	}

	private void button4_Click<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T2 sender, T3 e)
	{
		//IL_000c: Expected O, but got I4
		//IL_0011: Expected O, but got I4
		//IL_0020: Expected I4, but got O
		//IL_002e: Expected I4, but got O
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected I4, but got Unknown
		//IL_0048: Expected I4, but got O
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected I4, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected I4, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected I4, but got Unknown
		T0 val = (T0)cbListFolder.SelectedIndex;
		T1 val2 = (T1)((nint)val > 0);
		if (val2 != null)
		{
			Folder value = listFolder[(int)val];
			listFolder[(int)val] = null;
			listFolder[(int)val] = listFolder[val - 1];
			listFolder[val - 1] = null;
			listFolder[val - 1] = value;
			listFolderSaving<T1, T4, T5, T6, T7, T8>();
			loadFolder<T1, T9, T10, T11, T4, T5, T6, T7, T8, T0>();
			cbListFolder.ClearSelected();
			cbListFolder.SelectedIndex = val - 1;
		}
	}

	private void button6_Click<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T2 sender, T3 e)
	{
		//IL_000c: Expected O, but got I4
		//IL_0029: Expected O, but got I4
		//IL_0038: Expected I4, but got O
		//IL_0046: Expected I4, but got O
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected I4, but got Unknown
		//IL_0060: Expected I4, but got O
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected I4, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected I4, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected I4, but got Unknown
		T0 val = (T0)cbListFolder.SelectedIndex;
		T1 val2 = (T1)((nint)val >= 0 && (nint)val < cbListFolder.Items.Count - 1);
		if (val2 != null)
		{
			Folder value = listFolder[(int)val];
			listFolder[(int)val] = null;
			listFolder[(int)val] = listFolder[val + 1];
			listFolder[val + 1] = null;
			listFolder[val + 1] = value;
			listFolderSaving<T1, T4, T5, T6, T7, T8>();
			loadFolder<T1, T9, T10, T11, T4, T5, T6, T7, T8, T0>();
			cbListFolder.ClearSelected();
			cbListFolder.SelectedIndex = val + 1;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 Spin_String<T0, T1, T2, T3>(T0 str)
	{
		//IL_0080: Expected O, but got I4
		T0 pattern = (T0)"{[^{}]*}";
		T1 val = (T1)Regex.Match((string)str, (string)pattern);
		while (true)
		{
			T2 val2 = (T2)((Group)val).Success;
			if (val2 == null)
			{
				break;
			}
			T0 val3 = (T0)((string)str).Substring(((Capture)val).Index + 1, ((Capture)val).Length - 2);
			T0[] array = (T0[])(object)((string)val3).Split((char[])(object)new T3[1] { (T3)124 });
			str = (T0)(((string)str).Substring(0, ((Capture)val).Index) + (string)((object[])(object)array)[rnd.Next(array.Length)] + ((string)str).Substring(((Capture)val).Index + ((Capture)val).Length));
			val = (T1)Regex.Match((string)str, (string)pattern);
		}
		return str;
	}

	private void btnConfigXproxy_Click<T0, T1>(T0 sender, T1 e)
	{
		frmConfigXproxy frmConfigXproxy2 = new frmConfigXproxy(this);
		frmConfigXproxy2.ShowDialog();
	}

	private void ccbTarget_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		setting.ccbTarget = ccbTarget.Text;
		settingSaving();
	}

	private void cấuHìnhCommentDạoToolStripMenuItem_Click<T0, T1>(T0 sender, T1 e)
	{
		frmCommentStroll frmCommentStroll2 = new frmCommentStroll(this);
		frmCommentStroll2.ShowDialog();
	}

	private void ccbSizeChrome_SelectedIndexChanged<T0, T1, T2, T3, T4, T5, T6>(T1 sender, T2 e)
	{
		//IL_0020: Expected O, but got I4
		T0 val = (T0)(ccbSizeChrome.SelectedIndex == ccbSizeChrome.Items.Count - 1);
		if (val != null)
		{
			frmChromeSize frmChromeSize2 = new frmChromeSize(this);
			frmChromeSize2.ShowDialog();
			loadChromeSize<T3, T4, T5, T6>();
		}
		else
		{
			setting.ccbChromeSize = ccbSizeChrome.SelectedIndex;
			settingSaving();
		}
	}

	private void seddingLiveStreamToolStripMenuItem_Click<T0, T1>(T0 sender, T1 e)
	{
		frmSedding frmSedding2 = new frmSedding(this);
		frmSedding2.Show();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void timer_gv_refesh_Tick<T0, T1, T2, T3>(T1 sender, T2 e)
	{
		//IL_000a: Expected O, but got I4
		T0 val = (T0)(!isGvRefesh);
		if (val != null)
		{
			timer_gv_refesh.Stop();
			infoMessage((T3)"Done");
		}
		gvData.Refresh();
	}

	private void groupĐãThamGiaToolStripMenuItem_Click<T0, T1>(T0 sender, T1 e)
	{
		frmGroup frmGroup2 = new frmGroup();
		frmGroup2.Show();
	}

	private void danhSáchNhómToolStripMenuItem_Click<T0, T1>(T0 sender, T1 e)
	{
		frmListGroupToJoin frmListGroupToJoin2 = new frmListGroupToJoin(this);
		frmListGroupToJoin2.ShowDialog();
	}

	private void gvData_ColumnHeaderMouseClick<T0, T1>(T0 sender, T1 e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button7_Click<T0, T1, T2, T3, T4, T5>(T4 sender, T5 e)
	{
		//IL_0031: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		isRunning = false;
		btnStart.Text = "START";
		Activator.CreateInstance(typeof(T0));
		T1[] processes = (T1[])(object)Process.GetProcesses();
		T1[] array = processes;
		T2 val = (T2)0;
		while ((nint)val < array.Length)
		{
			T1 val2 = (T1)((object[])(object)array)[(object)val];
			try
			{
				T3 val3 = (T3)((Process)val2).ProcessName.Equals("chrome");
				if (val3 != null)
				{
					((Process)val2).Kill();
				}
			}
			catch (Exception)
			{
			}
			val = (T2)(val + 1);
		}
	}

	private void thẻẢoToolStripMenuItem_Click<T0, T1>(T0 sender, T1 e)
	{
		frmCart frmCart2 = new frmCart();
		frmCart2.Show();
	}

	private void button8_Click<T0, T1, T2, T3, T4, T5>(T1 sender, T2 e)
	{
		try
		{
			listLocationTinsoft.data.Clear();
			getLocationTinsoft<T3, T4, T5>();
		}
		catch (Exception ex)
		{
			errorMessage((T4)ex.Message);
		}
	}

	private void ccbLocationTinsoft_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		setting.ccbLocationTinsoft = ccbLocationTinsoft.SelectedIndex;
		settingSaving();
	}

	private void mailToolStripMenuItem_Click<T0, T1>(T0 sender, T1 e)
	{
		frmBMRequestAds frmBMRequestAds2 = new frmBMRequestAds(this);
		frmBMRequestAds2.Show();
	}

	private void rbTMProxy_CheckedChanged<T0, T1, T2>(T0 sender, T1 e)
	{
		setTypeChangeIP<T2>();
	}

	private void button9_Click<T0, T1, T2, T3, T4, T5>(T1 sender, T2 e)
	{
		try
		{
			listLocationTmProxy.data.locations.Clear();
			getLocationTmProxy<T3, T4, T5>();
		}
		catch (Exception ex)
		{
			errorMessage((T4)ex.Message);
		}
	}

	private void txtTmProxy_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		setting.txtTmProxy = txtTmProxy.Text;
		settingSaving();
	}

	private void ccbLocationTmProxy_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		setting.ccbLocationTmProxy = ccbLocationTmProxy.SelectedIndex;
		settingSaving();
	}

	private void ccbTypeTMProxy_SelectedIndexChanged<T0, T1>(T0 sender, T1 e)
	{
		setting.ccbTypeTMProxy = ccbTypeTMProxy.SelectedIndex;
		settingSaving();
	}

	private void quảnLýTKTrongBMToolStripMenuItem_Click<T0, T1>(T0 sender, T1 e)
	{
		frmAdsManager frmAdsManager2 = new frmAdsManager(null);
		frmAdsManager2.Show();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void button10_Click<T0, T1>(T0 sender, T1 e)
	{
		isRunning = false;
		btnStart.Text = "START";
		closeDriver<List<Process>, Process, int, bool>();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void closeDriver<T0, T1, T2, T3>()
	{
		//IL_001a: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		Activator.CreateInstance(typeof(T0));
		T1[] processes = (T1[])(object)Process.GetProcesses();
		T1[] array = processes;
		T2 val = (T2)0;
		while ((nint)val < array.Length)
		{
			T1 val2 = (T1)((object[])(object)array)[(object)val];
			try
			{
				T3 val3 = (T3)((Process)val2).ProcessName.Equals("chromedriver");
				if (val3 != null)
				{
					((Process)val2).Kill();
				}
			}
			catch (Exception)
			{
			}
			val = (T2)(val + 1);
		}
	}

	private void rbProtonVPN_CheckedChanged<T0, T1, T2>(T0 sender, T1 e)
	{
		setTypeChangeIP<T2>();
	}

	private void numProtonVPN_ValueChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		setting.numProtonVPN = int.Parse(((decimal)(T0)numProtonVPN.Value).ToString());
		settingSaving();
	}

	private void menuStrip1_ItemClicked<T0, T1>(T0 sender, T1 e)
	{
	}

	private void txtSearch_KeyDown<T0, T1, T2, T3, T4, T5>(T1 sender, T2 e)
	{
		//IL_000b: Expected O, but got I4
		T0 val = (T0)(((KeyEventArgs)e).KeyCode == Keys.Return);
		if (val != null)
		{
			searchVia<T3, T4, T0, T5>();
		}
	}

	private void rb922_CheckedChanged<T0, T1, T2>(T0 sender, T1 e)
	{
		btnConfigXproxy.Enabled = rbUseXproxy.Checked;
		setTypeChangeIP<T2>();
	}

	private void txt922Url_TextChanged<T0, T1>(T0 sender, T1 e)
	{
		setting.txt922Url = txt922Url.Text;
		settingSaving();
	}

	private void gvData_Click<T0, T1>(T0 sender, T1 e)
	{
	}

	private void gvData_RowStateChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_0017: Expected O, but got I4
		lbRowSelected.Text = System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)gvData.SelectedRows.Count).ToString();
	}

	private void gvData_CellMouseMove<T0, T1>(T0 sender, T1 e)
	{
	}

	private void cbCheckLive_CheckedChanged<T0, T1>(T0 sender, T1 e)
	{
		setting.cbCheckLive = cbCheckLive.Checked;
		settingSaving();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 CheckUID<T0, T1, T2, T3>(T1 UID, out string message)
	{
		//IL_0002: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		T0 result = (T0)1;
		message = "Live";
		try
		{
			T1 val = (T1)("https://graph.facebook.com/" + (string)UID + "?fields=picture");
			T2 val2 = (T2)null;
			val2 = (T2)Activator.CreateInstance(typeof(HttpRequest));
			((HttpRequest)val2).SslProtocols = SslProtocols.Tls12;
			T1 val3 = (T1)((object)((HttpRequest)val2).Get((string)val, (RequestParams)null)).ToString();
			T0 val4 = (T0)((string)val3).ToLower().Contains("error");
			if (val4 != null)
			{
				result = (T0)0;
				message = "Die";
			}
		}
		catch (Exception ex)
		{
			result = (T0)0;
			message = ex.Message;
		}
		return result;
	}

	private void frmMain_HelpButtonClicked<T0, T1>(T0 sender, T1 e)
	{
	}

	private void lbRowSelected_Click<T0, T1>(T0 sender, T1 e)
	{
		gvData.SelectAll();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void liênHệToolStripMenuItem_Click<T0, T1>(T0 sender, T1 e)
	{
		Process.Start("https://www.meta-soft.tech/contact.aspx");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void updateToolStripMenuItem_Click<T0, T1, T2, T3, T4>(T2 sender, T3 e)
	{
		//IL_0010: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		frmUpdate frmUpdate2 = new frmUpdate();
		T0 val = (T0)(frmUpdate2.ShowDialog() == DialogResult.OK);
		if (val != null)
		{
			T0 val2 = (T0)File.Exists("update.exe");
			if (val2 != null)
			{
				T1 val3 = (T1)Activator.CreateInstance(typeof(Process));
				((Process)val3).StartInfo.FileName = "update.exe";
				((Process)val3).Start();
			}
			else
			{
				errorMessage((T4)"Tool update không tồn tại! Vui lòng truy cập web tải bản Update vào thư mục tool.");
			}
		}
	}

	private unsafe void btnSaveData_Click<T0, T1, T2, T3, T4, T5, T6>(T2 sender, T3 e)
	{
		//IL_000c: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		T0 val = (T0)btnSaveData.Enabled;
		if (val == null)
		{
			return;
		}
		T1 enumerator = (T1)listFBEntity.GetEnumerator();
		try
		{
			while (((List<FBEntity>.Enumerator*)(&enumerator))->MoveNext())
			{
				FBEntity current = ((List<FBEntity>.Enumerator*)(&enumerator))->Current;
				current.addraft_fragments_2 = new addraft_fragments_2();
				current.fullAdsInfo = new CheckInfo();
				current.listCard = (List<CreditCardEntity>)Activator.CreateInstance(typeof(T4));
			}
		}
		finally
		{
			((IDisposable)(*(List<FBEntity>.Enumerator*)(&enumerator))).Dispose();
		}
		fblistSaving<T5, T0, T6>((T0)0);
	}

	private void danhSáchTKQCToolStripMenuItem_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		try
		{
			frmActControl frmActControl2 = new frmActControl(this);
			frmActControl2.Show();
		}
		catch (Exception)
		{
		}
	}

	private void gvData_ColumnDisplayIndexChanged<T0, T1, T2>(T1 sender, T2 e)
	{
		//IL_000c: Expected O, but got I4
		Console.WriteLine(System.Runtime.CompilerServices.Unsafe.As<T0, int>(ref (T0)((DataGridViewColumnEventArgs)e).Column.Index).ToString());
	}

	private void quảnLýPageĐốiTácToolStripMenuItem_Click<T0, T1, T2>(T1 sender, T2 e)
	{
		try
		{
			frmPagePartner frmPagePartner2 = new frmPagePartner(this);
			frmPagePartner2.Show();
		}
		catch (Exception)
		{
		}
	}

	private void gvData_CurrentCellDirtyStateChanged<T0, T1>(T0 sender, T1 e)
	{
		gvData.CommitEdit(DataGridViewDataErrorContexts.Commit);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public T0 GetMyIP<T0, T1, T2, T3, T4, T5, T6>(out string message)
	{
		//IL_006b: Expected O, but got I4
		T0 result = (T0)"";
		message = "";
		try
		{
			T0 requestUriString = (T0)"https://ip.seeip.org/jsonip?";
			T1 val = (T1)WebRequest.Create((string)requestUriString);
			((WebRequest)val).Credentials = CredentialCache.DefaultCredentials;
			T2 val2 = (T2)((WebRequest)val).GetResponse();
			Console.WriteLine(((HttpWebResponse)val2).StatusDescription);
			T3 responseStream = (T3)((WebResponse)val2).GetResponseStream();
			T4 val3 = (T4)new StreamReader((Stream)responseStream);
			T0 val4 = (T0)((TextReader)val3).ReadToEnd();
			T5 val5 = (T5)((string)val4).ToLower().Contains("error");
			if (val5 == null)
			{
				ipify ipify2 = JsonConvert.DeserializeObject<ipify>((string)val4);
				result = (T0)ipify2.ip;
			}
			else
			{
				message = "Die";
			}
			((TextReader)val3).Close();
			((Stream)responseStream).Close();
			((WebResponse)val2).Close();
		}
		catch (Exception ex)
		{
			message = ex.Message;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
	private void InitializeComponent<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, T31, T32, T33, T34, T35, T36, T37, T38, T39, T40, T41, T42, T43, T44, T45, T46, T47, T48, T49, T50, T51, T52, T53, T54, T55, T56, T57, T58, T59, T60, T61, T62, T63, T64, T65, T66, T67, T68>()
	{
		this.components = (System.ComponentModel.IContainer)System.Activator.CreateInstance(typeof(System.ComponentModel.Container));
		T0 val = (T0)new System.ComponentModel.ComponentResourceManager(typeof(ADSPRoject.frmMain));
		this.statusStrip1 = (System.Windows.Forms.StatusStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.StatusStrip));
		this.toolStripStatusLabel1 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbSelected = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.toolStripStatusLabel2 = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.lbTotalFB = (System.Windows.Forms.ToolStripStatusLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripStatusLabel));
		this.tabControl1 = (System.Windows.Forms.TabControl)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabControl));
		this.tabPage1 = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.panel1 = (System.Windows.Forms.Panel)System.Activator.CreateInstance(typeof(System.Windows.Forms.Panel));
		this.groupBox2 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.cbCheckLive = (System.Windows.Forms.CheckBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckBox));
		this.btnStart = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button7 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.btnConfig = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button10 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.numTimeDelay = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.label10 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.ccbSizeChrome = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.ccbTarget = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.groupBox1 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.label2 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.txt922Url = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.rb922 = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.numProtonVPN = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.rbProtonVPN = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.ccbTypeTMProxy = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.button9 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.ccbLocationTmProxy = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.txtTmProxy = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.rbTMProxy = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.button8 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.ccbLocationTinsoft = (System.Windows.Forms.ComboBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.ComboBox));
		this.btnConfigXproxy = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.rbUseXproxy = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.numToChangeIP = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.button2 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.rbHMA = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.txtTinSoftSV = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.rbNotChangeIP = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.rbTinSoftVN = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.label4 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.groupBox3 = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.numChromeCustomSizeWidth = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.numChromeCustomSizeHeigth = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.rbCustomSizeChrome = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.rbAutoSortSizeChrome = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.rbMaximumChrome = (System.Windows.Forms.RadioButton)System.Activator.CreateInstance(typeof(System.Windows.Forms.RadioButton));
		this.label5 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.label1 = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.numThread = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.numFromDelay = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.numToDelay = (System.Windows.Forms.NumericUpDown)System.Activator.CreateInstance(typeof(System.Windows.Forms.NumericUpDown));
		this.splitContainer1 = (System.Windows.Forms.SplitContainer)System.Activator.CreateInstance(typeof(System.Windows.Forms.SplitContainer));
		this.btnSaveData = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button6 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button4 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.button3 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.groupFolder = (System.Windows.Forms.GroupBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.GroupBox));
		this.cbListFolder = (System.Windows.Forms.CheckedListBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.CheckedListBox));
		this.button1 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.lbRowSelected = (System.Windows.Forms.Label)System.Activator.CreateInstance(typeof(System.Windows.Forms.Label));
		this.btnUp = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.btnDown = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.gvData = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.txtSearch = (System.Windows.Forms.TextBox)System.Activator.CreateInstance(typeof(System.Windows.Forms.TextBox));
		this.button5 = (System.Windows.Forms.Button)System.Activator.CreateInstance(typeof(System.Windows.Forms.Button));
		this.tabPage3 = (System.Windows.Forms.TabPage)System.Activator.CreateInstance(typeof(System.Windows.Forms.TabPage));
		this.gvUserAgent = (System.Windows.Forms.DataGridView)System.Activator.CreateInstance(typeof(System.Windows.Forms.DataGridView));
		this.imageList1 = new System.Windows.Forms.ImageList(this.components);
		this.lbLanguage = (System.Windows.Forms.LinkLabel)System.Activator.CreateInstance(typeof(System.Windows.Forms.LinkLabel));
		this.menuStrip1 = (System.Windows.Forms.MenuStrip)System.Activator.CreateInstance(typeof(System.Windows.Forms.MenuStrip));
		this.càiĐặtToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.hiệnThịCộtDữLiệuToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.cấuHìnhCommentDạoToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.cấuHìnhGroupToolStripMenuItem1 = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.groupĐãThamGiaToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.danhSáchNhómToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.thẻẢoToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.mailToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.quảnLýTKTrongBMToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.danhSáchTKQCToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.quảnLýPageĐốiTácToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.côngCụToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.seddingLiveStreamToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.hỗTrợToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.liênHệToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.updateToolStripMenuItem = (System.Windows.Forms.ToolStripMenuItem)System.Activator.CreateInstance(typeof(System.Windows.Forms.ToolStripMenuItem));
		this.timer_gv_refesh = new System.Windows.Forms.Timer(this.components);
		this.statusStrip1.SuspendLayout();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.panel1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numTimeDelay).BeginInit();
		this.groupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numProtonVPN).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numToChangeIP).BeginInit();
		this.groupBox3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numChromeCustomSizeWidth).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numChromeCustomSizeHeigth).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numFromDelay).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numToDelay).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).BeginInit();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.groupFolder.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gvData).BeginInit();
		this.tabPage3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gvUserAgent).BeginInit();
		this.menuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.statusStrip1.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T21[4]
		{
			(T21)this.toolStripStatusLabel1,
			(T21)this.lbSelected,
			(T21)this.toolStripStatusLabel2,
			(T21)this.lbTotalFB
		});
		this.statusStrip1.Location = new System.Drawing.Point(0, 794);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
		this.statusStrip1.Size = new System.Drawing.Size(1764, 26);
		this.statusStrip1.TabIndex = 1;
		this.statusStrip1.Text = "statusStrip1";
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(69, 20);
		this.toolStripStatusLabel1.Text = "Selected:";
		this.lbSelected.Name = "lbSelected";
		this.lbSelected.Size = new System.Drawing.Size(17, 20);
		this.lbSelected.Text = "0";
		this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
		this.toolStripStatusLabel2.Size = new System.Drawing.Size(15, 20);
		this.toolStripStatusLabel2.Text = "/";
		this.lbTotalFB.Name = "lbTotalFB";
		this.lbTotalFB.Size = new System.Drawing.Size(17, 20);
		this.lbTotalFB.Text = "0";
		this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage3);
		this.tabControl1.ImageList = this.imageList1;
		this.tabControl1.Location = new System.Drawing.Point(0, 27);
		this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(1752, 769);
		this.tabControl1.TabIndex = 33;
		this.tabPage1.Controls.Add(this.panel1);
		this.tabPage1.Controls.Add(this.splitContainer1);
		this.tabPage1.ImageIndex = 0;
		this.tabPage1.Location = new System.Drawing.Point(4, 25);
		this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.tabPage1.Size = new System.Drawing.Size(1744, 740);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "Tài Nguyên";
		this.tabPage1.UseVisualStyleBackColor = true;
		this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panel1.AutoScroll = true;
		this.panel1.Controls.Add(this.groupBox2);
		this.panel1.Controls.Add(this.groupBox1);
		this.panel1.Controls.Add(this.groupBox3);
		this.panel1.Location = new System.Drawing.Point(3, 3);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(1721, 162);
		this.panel1.TabIndex = 53;
		this.groupBox2.Controls.Add(this.cbCheckLive);
		this.groupBox2.Controls.Add(this.btnStart);
		this.groupBox2.Controls.Add(this.button7);
		this.groupBox2.Controls.Add(this.btnConfig);
		this.groupBox2.Controls.Add(this.button10);
		this.groupBox2.Controls.Add(this.numTimeDelay);
		this.groupBox2.Controls.Add(this.label10);
		this.groupBox2.Controls.Add(this.ccbSizeChrome);
		this.groupBox2.Controls.Add(this.ccbTarget);
		this.groupBox2.Location = new System.Drawing.Point(1155, 0);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(520, 143);
		this.groupBox2.TabIndex = 54;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Control";
		this.cbCheckLive.AutoSize = true;
		this.cbCheckLive.Location = new System.Drawing.Point(10, 46);
		this.cbCheckLive.Name = "cbCheckLive";
		this.cbCheckLive.Size = new System.Drawing.Size(99, 21);
		this.cbCheckLive.TabIndex = 54;
		this.cbCheckLive.Text = "Check live";
		this.cbCheckLive.UseVisualStyleBackColor = true;
		this.cbCheckLive.CheckedChanged += new System.EventHandler(cbCheckLive_CheckedChanged);
		this.btnStart.BackColor = System.Drawing.Color.Gray;
		this.btnStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.btnStart.Location = new System.Drawing.Point(289, 52);
		this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnStart.Name = "btnStart";
		this.btnStart.Size = new System.Drawing.Size(225, 84);
		this.btnStart.TabIndex = 44;
		this.btnStart.Text = "START";
		this.btnStart.UseVisualStyleBackColor = false;
		this.btnStart.Click += new System.EventHandler(button1_Click_2<T22, T23, T24, T25>);
		this.button7.Location = new System.Drawing.Point(102, 70);
		this.button7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(86, 66);
		this.button7.TabIndex = 52;
		this.button7.Text = "Đóng Chrome";
		this.button7.UseVisualStyleBackColor = true;
		this.button7.Click += new System.EventHandler(button7_Click<T26, T27, T24, T25, T22, T23>);
		this.btnConfig.BackColor = System.Drawing.Color.Gray;
		this.btnConfig.Font = new System.Drawing.Font("Verdana", 8f);
		this.btnConfig.ForeColor = System.Drawing.Color.White;
		this.btnConfig.Location = new System.Drawing.Point(197, 70);
		this.btnConfig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnConfig.Name = "btnConfig";
		this.btnConfig.Size = new System.Drawing.Size(86, 66);
		this.btnConfig.TabIndex = 46;
		this.btnConfig.Text = "Cầu Hình Module";
		this.btnConfig.UseVisualStyleBackColor = false;
		this.btnConfig.Click += new System.EventHandler(btnConfig_Click<T25, T22, T23, T28>);
		this.button10.Font = new System.Drawing.Font("Verdana", 8f);
		this.button10.ForeColor = System.Drawing.Color.Black;
		this.button10.Location = new System.Drawing.Point(10, 70);
		this.button10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.button10.Name = "button10";
		this.button10.Size = new System.Drawing.Size(86, 66);
		this.button10.TabIndex = 53;
		this.button10.Text = "Đóng Chrome Driver";
		this.button10.UseVisualStyleBackColor = true;
		this.button10.Click += new System.EventHandler(button10_Click);
		this.numTimeDelay.Location = new System.Drawing.Point(149, 24);
		this.numTimeDelay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.numTimeDelay.Maximum = new decimal((int[])(object)new T24[4]
		{
			(T24)9999999,
			default(T24),
			default(T24),
			default(T24)
		});
		this.numTimeDelay.Name = "numTimeDelay";
		this.numTimeDelay.Size = new System.Drawing.Size(134, 24);
		this.numTimeDelay.TabIndex = 48;
		this.numTimeDelay.ValueChanged += new System.EventHandler(numTimeDelay_ValueChanged<T29, T22, T23>);
		this.label10.AutoSize = true;
		this.label10.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11f);
		this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.label10.Location = new System.Drawing.Point(6, 20);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(137, 25);
		this.label10.TabIndex = 47;
		this.label10.Text = "Thời gian nghỉ:";
		this.ccbSizeChrome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbSizeChrome.FormattingEnabled = true;
		this.ccbSizeChrome.Location = new System.Drawing.Point(6, 85);
		this.ccbSizeChrome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.ccbSizeChrome.Name = "ccbSizeChrome";
		this.ccbSizeChrome.Size = new System.Drawing.Size(222, 24);
		this.ccbSizeChrome.TabIndex = 51;
		this.ccbSizeChrome.Visible = false;
		this.ccbSizeChrome.SelectedIndexChanged += new System.EventHandler(ccbSizeChrome_SelectedIndexChanged<T25, T22, T23, T30, T31, T32, T33>);
		this.ccbTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbTarget.Font = new System.Drawing.Font("Verdana", 12f);
		this.ccbTarget.FormattingEnabled = true;
		this.ccbTarget.Items.AddRange((object[])(object)new T22[2]
		{
			(T22)"Facebook Chrome",
			(T22)"Facebook API"
		});
		this.ccbTarget.Location = new System.Drawing.Point(289, 18);
		this.ccbTarget.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.ccbTarget.Name = "ccbTarget";
		this.ccbTarget.Size = new System.Drawing.Size(225, 33);
		this.ccbTarget.TabIndex = 50;
		this.ccbTarget.SelectedIndexChanged += new System.EventHandler(ccbTarget_SelectedIndexChanged);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.txt922Url);
		this.groupBox1.Controls.Add(this.rb922);
		this.groupBox1.Controls.Add(this.numProtonVPN);
		this.groupBox1.Controls.Add(this.rbProtonVPN);
		this.groupBox1.Controls.Add(this.ccbTypeTMProxy);
		this.groupBox1.Controls.Add(this.button9);
		this.groupBox1.Controls.Add(this.ccbLocationTmProxy);
		this.groupBox1.Controls.Add(this.txtTmProxy);
		this.groupBox1.Controls.Add(this.rbTMProxy);
		this.groupBox1.Controls.Add(this.button8);
		this.groupBox1.Controls.Add(this.ccbLocationTinsoft);
		this.groupBox1.Controls.Add(this.btnConfigXproxy);
		this.groupBox1.Controls.Add(this.rbUseXproxy);
		this.groupBox1.Controls.Add(this.numToChangeIP);
		this.groupBox1.Controls.Add(this.button2);
		this.groupBox1.Controls.Add(this.rbHMA);
		this.groupBox1.Controls.Add(this.txtTinSoftSV);
		this.groupBox1.Controls.Add(this.rbNotChangeIP);
		this.groupBox1.Controls.Add(this.rbTinSoftVN);
		this.groupBox1.Controls.Add(this.label4);
		this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(0, 120, 228);
		this.groupBox1.Location = new System.Drawing.Point(3, 4);
		this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.groupBox1.Size = new System.Drawing.Size(824, 143);
		this.groupBox1.TabIndex = 26;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "IP";
		this.groupBox1.Enter += new System.EventHandler(groupBox1_Enter);
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(479, 43);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(99, 20);
		this.label2.TabIndex = 65;
		this.label2.Text = "Link đổi 922";
		this.txt922Url.Location = new System.Drawing.Point(584, 42);
		this.txt922Url.Name = "txt922Url";
		this.txt922Url.Size = new System.Drawing.Size(214, 24);
		this.txt922Url.TabIndex = 64;
		this.txt922Url.TextChanged += new System.EventHandler(txt922Url_TextChanged);
		this.rb922.AutoSize = true;
		this.rb922.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rb922.ForeColor = System.Drawing.Color.FromArgb(0, 120, 228);
		this.rb922.Location = new System.Drawing.Point(417, 45);
		this.rb922.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.rb922.Name = "rb922";
		this.rb922.Size = new System.Drawing.Size(56, 21);
		this.rb922.TabIndex = 63;
		this.rb922.TabStop = true;
		this.rb922.Text = "922";
		this.rb922.UseVisualStyleBackColor = true;
		this.rb922.CheckedChanged += new System.EventHandler(rb922_CheckedChanged<T22, T23, T25>);
		this.numProtonVPN.Location = new System.Drawing.Point(316, 18);
		this.numProtonVPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.numProtonVPN.Maximum = new decimal((int[])(object)new T24[4]
		{
			(T24)99999999,
			default(T24),
			default(T24),
			default(T24)
		});
		this.numProtonVPN.Name = "numProtonVPN";
		this.numProtonVPN.Size = new System.Drawing.Size(48, 24);
		this.numProtonVPN.TabIndex = 62;
		this.numProtonVPN.ValueChanged += new System.EventHandler(numProtonVPN_ValueChanged<T29, T22, T23>);
		this.rbProtonVPN.AutoSize = true;
		this.rbProtonVPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rbProtonVPN.ForeColor = System.Drawing.Color.FromArgb(0, 120, 228);
		this.rbProtonVPN.Location = new System.Drawing.Point(202, 19);
		this.rbProtonVPN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.rbProtonVPN.Name = "rbProtonVPN";
		this.rbProtonVPN.Size = new System.Drawing.Size(108, 21);
		this.rbProtonVPN.TabIndex = 61;
		this.rbProtonVPN.TabStop = true;
		this.rbProtonVPN.Text = "ProtonVPN";
		this.rbProtonVPN.UseVisualStyleBackColor = true;
		this.rbProtonVPN.CheckedChanged += new System.EventHandler(rbProtonVPN_CheckedChanged<T22, T23, T25>);
		this.ccbTypeTMProxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbTypeTMProxy.FormattingEnabled = true;
		this.ccbTypeTMProxy.Items.AddRange((object[])(object)new T22[2]
		{
			(T22)"Socks5",
			(T22)"HTTPS"
		});
		this.ccbTypeTMProxy.Location = new System.Drawing.Point(117, 99);
		this.ccbTypeTMProxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.ccbTypeTMProxy.Name = "ccbTypeTMProxy";
		this.ccbTypeTMProxy.Size = new System.Drawing.Size(124, 24);
		this.ccbTypeTMProxy.TabIndex = 60;
		this.ccbTypeTMProxy.SelectedIndexChanged += new System.EventHandler(ccbTypeTMProxy_SelectedIndexChanged);
		this.button9.Location = new System.Drawing.Point(385, 71);
		this.button9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.button9.Name = "button9";
		this.button9.Size = new System.Drawing.Size(27, 22);
		this.button9.TabIndex = 59;
		this.button9.Text = "o";
		this.button9.UseVisualStyleBackColor = true;
		this.button9.Click += new System.EventHandler(button9_Click<T31, T22, T23, T25, T33, T34>);
		this.ccbLocationTmProxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbLocationTmProxy.FormattingEnabled = true;
		this.ccbLocationTmProxy.Location = new System.Drawing.Point(247, 99);
		this.ccbLocationTmProxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.ccbLocationTmProxy.Name = "ccbLocationTmProxy";
		this.ccbLocationTmProxy.Size = new System.Drawing.Size(132, 24);
		this.ccbLocationTmProxy.TabIndex = 58;
		this.ccbLocationTmProxy.SelectedIndexChanged += new System.EventHandler(ccbLocationTmProxy_SelectedIndexChanged);
		this.txtTmProxy.Enabled = false;
		this.txtTmProxy.Location = new System.Drawing.Point(117, 73);
		this.txtTmProxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.txtTmProxy.Name = "txtTmProxy";
		this.txtTmProxy.Size = new System.Drawing.Size(262, 24);
		this.txtTmProxy.TabIndex = 56;
		this.txtTmProxy.TextChanged += new System.EventHandler(txtTmProxy_TextChanged);
		this.rbTMProxy.AutoSize = true;
		this.rbTMProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rbTMProxy.ForeColor = System.Drawing.Color.FromArgb(0, 120, 228);
		this.rbTMProxy.Location = new System.Drawing.Point(8, 72);
		this.rbTMProxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.rbTMProxy.Name = "rbTMProxy";
		this.rbTMProxy.Size = new System.Drawing.Size(91, 21);
		this.rbTMProxy.TabIndex = 57;
		this.rbTMProxy.Text = "TmProxy";
		this.rbTMProxy.UseVisualStyleBackColor = true;
		this.rbTMProxy.CheckedChanged += new System.EventHandler(rbTMProxy_CheckedChanged<T22, T23, T25>);
		this.button8.Location = new System.Drawing.Point(384, 43);
		this.button8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.button8.Name = "button8";
		this.button8.Size = new System.Drawing.Size(27, 22);
		this.button8.TabIndex = 54;
		this.button8.Text = "o";
		this.button8.UseVisualStyleBackColor = true;
		this.button8.Click += new System.EventHandler(button8_Click<T31, T22, T23, T25, T33, T35>);
		this.ccbLocationTinsoft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ccbLocationTinsoft.FormattingEnabled = true;
		this.ccbLocationTinsoft.Location = new System.Drawing.Point(254, 44);
		this.ccbLocationTinsoft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.ccbLocationTinsoft.Name = "ccbLocationTinsoft";
		this.ccbLocationTinsoft.Size = new System.Drawing.Size(124, 24);
		this.ccbLocationTinsoft.TabIndex = 53;
		this.ccbLocationTinsoft.SelectedIndexChanged += new System.EventHandler(ccbLocationTinsoft_SelectedIndexChanged);
		this.btnConfigXproxy.Enabled = false;
		this.btnConfigXproxy.Location = new System.Drawing.Point(443, 17);
		this.btnConfigXproxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnConfigXproxy.Name = "btnConfigXproxy";
		this.btnConfigXproxy.Size = new System.Drawing.Size(68, 22);
		this.btnConfigXproxy.TabIndex = 36;
		this.btnConfigXproxy.Text = "Xproxy";
		this.btnConfigXproxy.UseVisualStyleBackColor = true;
		this.btnConfigXproxy.Click += new System.EventHandler(btnConfigXproxy_Click);
		this.rbUseXproxy.AutoSize = true;
		this.rbUseXproxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rbUseXproxy.ForeColor = System.Drawing.Color.FromArgb(0, 120, 228);
		this.rbUseXproxy.Location = new System.Drawing.Point(367, 19);
		this.rbUseXproxy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.rbUseXproxy.Name = "rbUseXproxy";
		this.rbUseXproxy.Size = new System.Drawing.Size(78, 21);
		this.rbUseXproxy.TabIndex = 35;
		this.rbUseXproxy.TabStop = true;
		this.rbUseXproxy.Text = "Xproxy";
		this.rbUseXproxy.UseVisualStyleBackColor = true;
		this.rbUseXproxy.CheckedChanged += new System.EventHandler(rbUseXproxy_CheckedChanged<T22, T23, T25>);
		this.numToChangeIP.Location = new System.Drawing.Point(607, 18);
		this.numToChangeIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.numToChangeIP.Maximum = new decimal((int[])(object)new T24[4]
		{
			(T24)99999999,
			default(T24),
			default(T24),
			default(T24)
		});
		this.numToChangeIP.Name = "numToChangeIP";
		this.numToChangeIP.Size = new System.Drawing.Size(77, 24);
		this.numToChangeIP.TabIndex = 13;
		this.numToChangeIP.ValueChanged += new System.EventHandler(numToChangeIP_ValueChanged<T29, T22, T23>);
		this.button2.Location = new System.Drawing.Point(690, 17);
		this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(108, 22);
		this.button2.TabIndex = 25;
		this.button2.Text = "Test đổi IP";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click<T33, T24, T22, T23, T25>);
		this.rbHMA.AutoSize = true;
		this.rbHMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rbHMA.ForeColor = System.Drawing.Color.FromArgb(0, 120, 228);
		this.rbHMA.Location = new System.Drawing.Point(117, 19);
		this.rbHMA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.rbHMA.Name = "rbHMA";
		this.rbHMA.Size = new System.Drawing.Size(62, 21);
		this.rbHMA.TabIndex = 24;
		this.rbHMA.TabStop = true;
		this.rbHMA.Text = "HMA";
		this.rbHMA.UseVisualStyleBackColor = true;
		this.rbHMA.CheckedChanged += new System.EventHandler(rbHMA_CheckedChanged<T22, T23, T25>);
		this.txtTinSoftSV.Enabled = false;
		this.txtTinSoftSV.Location = new System.Drawing.Point(115, 44);
		this.txtTinSoftSV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.txtTinSoftSV.Name = "txtTinSoftSV";
		this.txtTinSoftSV.Size = new System.Drawing.Size(132, 24);
		this.txtTinSoftSV.TabIndex = 9;
		this.txtTinSoftSV.TextChanged += new System.EventHandler(txtTinSoftSV_TextChanged);
		this.rbNotChangeIP.AutoSize = true;
		this.rbNotChangeIP.Checked = true;
		this.rbNotChangeIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rbNotChangeIP.ForeColor = System.Drawing.Color.FromArgb(0, 120, 228);
		this.rbNotChangeIP.Location = new System.Drawing.Point(8, 19);
		this.rbNotChangeIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.rbNotChangeIP.Name = "rbNotChangeIP";
		this.rbNotChangeIP.Size = new System.Drawing.Size(102, 21);
		this.rbNotChangeIP.TabIndex = 10;
		this.rbNotChangeIP.TabStop = true;
		this.rbNotChangeIP.Text = "Không đổi";
		this.rbNotChangeIP.UseVisualStyleBackColor = true;
		this.rbNotChangeIP.CheckedChanged += new System.EventHandler(rbNotChangeIP_CheckedChanged);
		this.rbTinSoftVN.AutoSize = true;
		this.rbTinSoftVN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rbTinSoftVN.ForeColor = System.Drawing.Color.FromArgb(0, 120, 228);
		this.rbTinSoftVN.Location = new System.Drawing.Point(8, 45);
		this.rbTinSoftVN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.rbTinSoftVN.Name = "rbTinSoftVN";
		this.rbTinSoftVN.Size = new System.Drawing.Size(101, 21);
		this.rbTinSoftVN.TabIndex = 11;
		this.rbTinSoftVN.Text = "TinSoftSV";
		this.rbTinSoftVN.UseVisualStyleBackColor = true;
		this.rbTinSoftVN.CheckedChanged += new System.EventHandler(rbTinSoftVN_CheckedChanged);
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(512, 20);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(89, 20);
		this.label4.TabIndex = 12;
		this.label4.Text = "Lượt đổi IP";
		this.groupBox3.Controls.Add(this.numChromeCustomSizeWidth);
		this.groupBox3.Controls.Add(this.numChromeCustomSizeHeigth);
		this.groupBox3.Controls.Add(this.rbCustomSizeChrome);
		this.groupBox3.Controls.Add(this.rbAutoSortSizeChrome);
		this.groupBox3.Controls.Add(this.rbMaximumChrome);
		this.groupBox3.Controls.Add(this.label5);
		this.groupBox3.Controls.Add(this.label1);
		this.groupBox3.Controls.Add(this.numThread);
		this.groupBox3.Controls.Add(this.numFromDelay);
		this.groupBox3.Controls.Add(this.numToDelay);
		this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(0, 120, 228);
		this.groupBox3.Location = new System.Drawing.Point(833, 4);
		this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.groupBox3.Size = new System.Drawing.Size(316, 143);
		this.groupBox3.TabIndex = 28;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "Luồng xử lý";
		this.numChromeCustomSizeWidth.Enabled = false;
		this.numChromeCustomSizeWidth.Location = new System.Drawing.Point(125, 96);
		this.numChromeCustomSizeWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.numChromeCustomSizeWidth.Maximum = new decimal((int[])(object)new T24[4]
		{
			(T24)99999999,
			default(T24),
			default(T24),
			default(T24)
		});
		this.numChromeCustomSizeWidth.Name = "numChromeCustomSizeWidth";
		this.numChromeCustomSizeWidth.Size = new System.Drawing.Size(78, 24);
		this.numChromeCustomSizeWidth.TabIndex = 26;
		this.numChromeCustomSizeWidth.ValueChanged += new System.EventHandler(numChromeCustomSizeWidth_ValueChanged<T29, T22, T23>);
		this.numChromeCustomSizeHeigth.Enabled = false;
		this.numChromeCustomSizeHeigth.Location = new System.Drawing.Point(213, 96);
		this.numChromeCustomSizeHeigth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.numChromeCustomSizeHeigth.Maximum = new decimal((int[])(object)new T24[4]
		{
			(T24)99999999,
			default(T24),
			default(T24),
			default(T24)
		});
		this.numChromeCustomSizeHeigth.Name = "numChromeCustomSizeHeigth";
		this.numChromeCustomSizeHeigth.Size = new System.Drawing.Size(68, 24);
		this.numChromeCustomSizeHeigth.TabIndex = 27;
		this.numChromeCustomSizeHeigth.ValueChanged += new System.EventHandler(numChromeCustomSizeHeigth_ValueChanged<T29, T22, T23>);
		this.rbCustomSizeChrome.AutoSize = true;
		this.rbCustomSizeChrome.ForeColor = System.Drawing.Color.FromArgb(0, 120, 228);
		this.rbCustomSizeChrome.Location = new System.Drawing.Point(19, 99);
		this.rbCustomSizeChrome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.rbCustomSizeChrome.Name = "rbCustomSizeChrome";
		this.rbCustomSizeChrome.Size = new System.Drawing.Size(94, 21);
		this.rbCustomSizeChrome.TabIndex = 25;
		this.rbCustomSizeChrome.TabStop = true;
		this.rbCustomSizeChrome.Text = "Tùy chọn";
		this.rbCustomSizeChrome.UseVisualStyleBackColor = true;
		this.rbCustomSizeChrome.CheckedChanged += new System.EventHandler(rbCustomSizeChrome_CheckedChanged_1);
		this.rbAutoSortSizeChrome.AutoSize = true;
		this.rbAutoSortSizeChrome.ForeColor = System.Drawing.Color.FromArgb(0, 120, 228);
		this.rbAutoSortSizeChrome.Location = new System.Drawing.Point(106, 74);
		this.rbAutoSortSizeChrome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.rbAutoSortSizeChrome.Name = "rbAutoSortSizeChrome";
		this.rbAutoSortSizeChrome.Size = new System.Drawing.Size(176, 21);
		this.rbAutoSortSizeChrome.TabIndex = 24;
		this.rbAutoSortSizeChrome.TabStop = true;
		this.rbAutoSortSizeChrome.Text = "Tự căn chỉnh chrome";
		this.rbAutoSortSizeChrome.UseVisualStyleBackColor = true;
		this.rbAutoSortSizeChrome.CheckedChanged += new System.EventHandler(rbAutoSortSizeChrome_CheckedChanged);
		this.rbMaximumChrome.AutoSize = true;
		this.rbMaximumChrome.ForeColor = System.Drawing.Color.FromArgb(0, 120, 228);
		this.rbMaximumChrome.Location = new System.Drawing.Point(19, 74);
		this.rbMaximumChrome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.rbMaximumChrome.Name = "rbMaximumChrome";
		this.rbMaximumChrome.Size = new System.Drawing.Size(87, 21);
		this.rbMaximumChrome.TabIndex = 23;
		this.rbMaximumChrome.TabStop = true;
		this.rbMaximumChrome.Text = "Full màn";
		this.rbMaximumChrome.UseVisualStyleBackColor = true;
		this.rbMaximumChrome.CheckedChanged += new System.EventHandler(rbMaximumChrome_CheckedChanged);
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(10, 48);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(129, 20);
		this.label5.TabIndex = 17;
		this.label5.Text = "Tốc độ gõ phím:";
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 11f);
		this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.label1.Location = new System.Drawing.Point(9, 22);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(91, 25);
		this.label1.TabIndex = 2;
		this.label1.Text = "Số luồng:";
		this.numThread.Location = new System.Drawing.Point(105, 20);
		this.numThread.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.numThread.Maximum = new decimal((int[])(object)new T24[4]
		{
			(T24)9999999,
			default(T24),
			default(T24),
			default(T24)
		});
		this.numThread.Name = "numThread";
		this.numThread.Size = new System.Drawing.Size(176, 24);
		this.numThread.TabIndex = 3;
		this.numThread.ValueChanged += new System.EventHandler(numThread_ValueChanged<T29, T22, T23>);
		this.numFromDelay.Location = new System.Drawing.Point(145, 46);
		this.numFromDelay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.numFromDelay.Maximum = new decimal((int[])(object)new T24[4]
		{
			(T24)99999999,
			default(T24),
			default(T24),
			default(T24)
		});
		this.numFromDelay.Name = "numFromDelay";
		this.numFromDelay.Size = new System.Drawing.Size(58, 24);
		this.numFromDelay.TabIndex = 18;
		this.numFromDelay.ValueChanged += new System.EventHandler(numFromDelay_ValueChanged<T29, T22, T23>);
		this.numToDelay.Location = new System.Drawing.Point(213, 48);
		this.numToDelay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.numToDelay.Maximum = new decimal((int[])(object)new T24[4]
		{
			(T24)99999999,
			default(T24),
			default(T24),
			default(T24)
		});
		this.numToDelay.Name = "numToDelay";
		this.numToDelay.Size = new System.Drawing.Size(68, 24);
		this.numToDelay.TabIndex = 19;
		this.numToDelay.ValueChanged += new System.EventHandler(numToDelay_ValueChanged<T29, T22, T23>);
		this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.splitContainer1.Location = new System.Drawing.Point(6, 168);
		this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Panel1.Controls.Add(this.btnSaveData);
		this.splitContainer1.Panel1.Controls.Add(this.button6);
		this.splitContainer1.Panel1.Controls.Add(this.button4);
		this.splitContainer1.Panel1.Controls.Add(this.button3);
		this.splitContainer1.Panel1.Controls.Add(this.groupFolder);
		this.splitContainer1.Panel1.Controls.Add(this.button1);
		this.splitContainer1.Panel2.Controls.Add(this.lbRowSelected);
		this.splitContainer1.Panel2.Controls.Add(this.btnUp);
		this.splitContainer1.Panel2.Controls.Add(this.btnDown);
		this.splitContainer1.Panel2.Controls.Add(this.gvData);
		this.splitContainer1.Panel2.Controls.Add(this.txtSearch);
		this.splitContainer1.Panel2.Controls.Add(this.button5);
		this.splitContainer1.Size = new System.Drawing.Size(1729, 570);
		this.splitContainer1.SplitterDistance = 324;
		this.splitContainer1.SplitterWidth = 5;
		this.splitContainer1.TabIndex = 0;
		this.btnSaveData.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.btnSaveData.BackColor = System.Drawing.Color.DodgerBlue;
		this.btnSaveData.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnSaveData.Location = new System.Drawing.Point(8, 536);
		this.btnSaveData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnSaveData.Name = "btnSaveData";
		this.btnSaveData.Size = new System.Drawing.Size(313, 26);
		this.btnSaveData.TabIndex = 53;
		this.btnSaveData.Text = "Saved";
		this.btnSaveData.UseVisualStyleBackColor = false;
		this.btnSaveData.Click += new System.EventHandler(btnSaveData_Click<T25, T36, T22, T23, T37, T38, T31>);
		this.button6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button6.Location = new System.Drawing.Point(289, 4);
		this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(29, 22);
		this.button6.TabIndex = 52;
		this.button6.Text = "⇩";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new System.EventHandler(button6_Click<T24, T25, T22, T23, T33, T39, T40, T41, T42, T36, T43, T44>);
		this.button4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button4.Location = new System.Drawing.Point(253, 4);
		this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(29, 22);
		this.button4.TabIndex = 51;
		this.button4.Text = "⇫";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new System.EventHandler(button4_Click<T24, T25, T22, T23, T33, T39, T40, T41, T42, T36, T43, T44>);
		this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button3.Location = new System.Drawing.Point(219, 4);
		this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(27, 22);
		this.button3.TabIndex = 50;
		this.button3.Text = "❁";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click<T25, T33, T22, T23, T39, T40, T41, T42, T36, T43, T44, T24>);
		this.groupFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupFolder.Controls.Add(this.cbListFolder);
		this.groupFolder.Location = new System.Drawing.Point(7, 34);
		this.groupFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.groupFolder.Name = "groupFolder";
		this.groupFolder.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.groupFolder.Size = new System.Drawing.Size(314, 502);
		this.groupFolder.TabIndex = 49;
		this.groupFolder.TabStop = false;
		this.groupFolder.Text = "Thư mục";
		this.cbListFolder.Dock = System.Windows.Forms.DockStyle.Fill;
		this.cbListFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cbListFolder.FormattingEnabled = true;
		this.cbListFolder.Items.AddRange((object[])(object)new T22[5]
		{
			(T22)"fdsaf",
			(T22)"fdsafdas",
			(T22)"fdsaf",
			(T22)"gfdsgfd",
			(T22)"432432"
		});
		this.cbListFolder.Location = new System.Drawing.Point(3, 21);
		this.cbListFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.cbListFolder.Name = "cbListFolder";
		this.cbListFolder.Size = new System.Drawing.Size(308, 477);
		this.cbListFolder.TabIndex = 2;
		this.cbListFolder.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(cbListFolder_ItemCheck<T25, T45, T24, T31, T22, T46, T38, T47, T33, T39, T40, T41, T42>);
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.button1.Location = new System.Drawing.Point(3, 4);
		this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(211, 22);
		this.button1.TabIndex = 1;
		this.button1.Text = "+ Thêm thư mục";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click<T25, T22, T23, T33, T24, T48, T39, T40, T41, T42, T36, T43, T44>);
		this.lbRowSelected.AutoSize = true;
		this.lbRowSelected.Font = new System.Drawing.Font("Verdana", 8f, System.Drawing.FontStyle.Bold);
		this.lbRowSelected.Location = new System.Drawing.Point(5, 35);
		this.lbRowSelected.Name = "lbRowSelected";
		this.lbRowSelected.Size = new System.Drawing.Size(18, 17);
		this.lbRowSelected.TabIndex = 53;
		this.lbRowSelected.Text = "0";
		this.lbRowSelected.Click += new System.EventHandler(lbRowSelected_Click);
		this.btnUp.Location = new System.Drawing.Point(3, 1);
		this.btnUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnUp.Name = "btnUp";
		this.btnUp.Size = new System.Drawing.Size(37, 22);
		this.btnUp.TabIndex = 52;
		this.btnUp.Text = "⇫";
		this.btnUp.UseVisualStyleBackColor = true;
		this.btnUp.Click += new System.EventHandler(btnUp_Click<T24, T25, T22, T23, T33, T38, T31>);
		this.btnDown.Location = new System.Drawing.Point(48, 1);
		this.btnDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnDown.Name = "btnDown";
		this.btnDown.Size = new System.Drawing.Size(37, 22);
		this.btnDown.TabIndex = 51;
		this.btnDown.Text = "⇩";
		this.btnDown.UseVisualStyleBackColor = true;
		this.btnDown.Click += new System.EventHandler(btnDown_Click<T24, T25, T22, T23, T33, T38, T31>);
		this.gvData.AllowUserToAddRows = false;
		this.gvData.AllowUserToDeleteRows = false;
		this.gvData.AllowUserToOrderColumns = true;
		this.gvData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvData.Location = new System.Drawing.Point(3, 31);
		this.gvData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.gvData.Name = "gvData";
		this.gvData.RowHeadersWidth = 51;
		this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvData.Size = new System.Drawing.Size(1391, 533);
		this.gvData.TabIndex = 0;
		this.gvData.DataSourceChanged += new System.EventHandler(gvData_DataSourceChanged<T25, T24, T22, T23>);
		this.gvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvData_CellClick<T25, T31, T22, T49, T24, T33>);
		this.gvData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(gvData_CellEndEdit<T22, T49, T38, T25, T31>);
		this.gvData.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(gvData_CellMouseMove);
		this.gvData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(gvData_CellValueChanged);
		this.gvData.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(gvData_ColumnDisplayIndexChanged<T24, T22, T51>);
		this.gvData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(gvData_ColumnHeaderMouseClick);
		this.gvData.CurrentCellDirtyStateChanged += new System.EventHandler(gvData_CurrentCellDirtyStateChanged);
		this.gvData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(gvData_RowStateChanged<T24, T22, T52>);
		this.gvData.Click += new System.EventHandler(gvData_Click);
		this.gvData.MouseClick += new System.Windows.Forms.MouseEventHandler(gvData_MouseClick<T25, T53, T54, T24, T22, T55, T33>);
		this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSearch.Location = new System.Drawing.Point(92, 4);
		this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.txtSearch.Name = "txtSearch";
		this.txtSearch.Size = new System.Drawing.Size(1224, 24);
		this.txtSearch.TabIndex = 42;
		this.txtSearch.TextChanged += new System.EventHandler(txtKeyword_TextChanged);
		this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(txtSearch_KeyDown<T25, T22, T56, T33, T24, T48>);
		this.button5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button5.Location = new System.Drawing.Point(1322, 6);
		this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(72, 22);
		this.button5.TabIndex = 43;
		this.button5.Text = "Tìm kiếm";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new System.EventHandler(button5_Click);
		this.tabPage3.Controls.Add(this.gvUserAgent);
		this.tabPage3.ImageIndex = 1;
		this.tabPage3.Location = new System.Drawing.Point(4, 25);
		this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.tabPage3.Name = "tabPage3";
		this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.tabPage3.Size = new System.Drawing.Size(1744, 740);
		this.tabPage3.TabIndex = 2;
		this.tabPage3.Text = "UserAgent";
		this.tabPage3.UseVisualStyleBackColor = true;
		this.gvUserAgent.AllowUserToAddRows = false;
		this.gvUserAgent.AllowUserToDeleteRows = false;
		this.gvUserAgent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.gvUserAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.gvUserAgent.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gvUserAgent.Location = new System.Drawing.Point(3, 4);
		this.gvUserAgent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.gvUserAgent.Name = "gvUserAgent";
		this.gvUserAgent.ReadOnly = true;
		this.gvUserAgent.RowHeadersWidth = 51;
		this.gvUserAgent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.gvUserAgent.Size = new System.Drawing.Size(1738, 732);
		this.gvUserAgent.TabIndex = 2;
		this.gvUserAgent.MouseClick += new System.Windows.Forms.MouseEventHandler(gvUserAgent_MouseClick<T25, T53, T54, T22, T55>);
		this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)(T57)((System.Resources.ResourceManager)val).GetObject("imageList1.ImageStream");
		this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.imageList1.Images.SetKeyName(0, "facebook.ico");
		this.imageList1.Images.SetKeyName(1, "useragent.ico");
		this.imageList1.Images.SetKeyName(2, "chrome.ico");
		this.imageList1.Images.SetKeyName(3, "driver-booster-logo-png-8.ico");
		this.imageList1.Images.SetKeyName(4, "module.png");
		this.lbLanguage.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.lbLanguage.AutoSize = true;
		this.lbLanguage.Location = new System.Drawing.Point(1700, 796);
		this.lbLanguage.Name = "lbLanguage";
		this.lbLanguage.Size = new System.Drawing.Size(52, 17);
		this.lbLanguage.TabIndex = 34;
		this.lbLanguage.TabStop = true;
		this.lbLanguage.Text = "en-US";
		this.lbLanguage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lbLanguage_LinkClicked);
		this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.menuStrip1.Items.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T21[3]
		{
			(T21)this.càiĐặtToolStripMenuItem,
			(T21)this.côngCụToolStripMenuItem,
			(T21)this.hỗTrợToolStripMenuItem
		});
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
		this.menuStrip1.Size = new System.Drawing.Size(1764, 30);
		this.menuStrip1.TabIndex = 35;
		this.menuStrip1.Text = "menuStrip1";
		this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(menuStrip1_ItemClicked);
		this.càiĐặtToolStripMenuItem.DropDownItems.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T21[8]
		{
			(T21)this.hiệnThịCộtDữLiệuToolStripMenuItem,
			(T21)this.cấuHìnhCommentDạoToolStripMenuItem,
			(T21)this.cấuHìnhGroupToolStripMenuItem1,
			(T21)this.thẻẢoToolStripMenuItem,
			(T21)this.mailToolStripMenuItem,
			(T21)this.quảnLýTKTrongBMToolStripMenuItem,
			(T21)this.danhSáchTKQCToolStripMenuItem,
			(T21)this.quảnLýPageĐốiTácToolStripMenuItem
		});
		this.càiĐặtToolStripMenuItem.Name = "càiĐặtToolStripMenuItem";
		this.càiĐặtToolStripMenuItem.Size = new System.Drawing.Size(82, 26);
		this.càiĐặtToolStripMenuItem.Text = "Tùy chọn";
		this.càiĐặtToolStripMenuItem.Click += new System.EventHandler(càiĐặtToolStripMenuItem_Click);
		this.hiệnThịCộtDữLiệuToolStripMenuItem.Name = "hiệnThịCộtDữLiệuToolStripMenuItem";
		this.hiệnThịCộtDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
		this.hiệnThịCộtDữLiệuToolStripMenuItem.Text = "Cài đặt Token";
		this.hiệnThịCộtDữLiệuToolStripMenuItem.Click += new System.EventHandler(hiệnThịCộtDữLiệuToolStripMenuItem_Click);
		this.cấuHìnhCommentDạoToolStripMenuItem.Name = "cấuHìnhCommentDạoToolStripMenuItem";
		this.cấuHìnhCommentDạoToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
		this.cấuHìnhCommentDạoToolStripMenuItem.Text = "Cấu hình content";
		this.cấuHìnhCommentDạoToolStripMenuItem.Click += new System.EventHandler(cấuHìnhCommentDạoToolStripMenuItem_Click);
		this.cấuHìnhGroupToolStripMenuItem1.DropDownItems.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T21[2]
		{
			(T21)this.groupĐãThamGiaToolStripMenuItem,
			(T21)this.danhSáchNhómToolStripMenuItem
		});
		this.cấuHìnhGroupToolStripMenuItem1.Name = "cấuHìnhGroupToolStripMenuItem1";
		this.cấuHìnhGroupToolStripMenuItem1.Size = new System.Drawing.Size(229, 26);
		this.cấuHìnhGroupToolStripMenuItem1.Text = "Cấu hình nhóm FB";
		this.groupĐãThamGiaToolStripMenuItem.Name = "groupĐãThamGiaToolStripMenuItem";
		this.groupĐãThamGiaToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
		this.groupĐãThamGiaToolStripMenuItem.Text = "Nhóm đã tham gia";
		this.groupĐãThamGiaToolStripMenuItem.Click += new System.EventHandler(groupĐãThamGiaToolStripMenuItem_Click);
		this.danhSáchNhómToolStripMenuItem.Name = "danhSáchNhómToolStripMenuItem";
		this.danhSáchNhómToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
		this.danhSáchNhómToolStripMenuItem.Text = "Danh sách nhóm";
		this.danhSáchNhómToolStripMenuItem.Click += new System.EventHandler(danhSáchNhómToolStripMenuItem_Click);
		this.thẻẢoToolStripMenuItem.Name = "thẻẢoToolStripMenuItem";
		this.thẻẢoToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
		this.thẻẢoToolStripMenuItem.Text = "Thẻ ảo";
		this.thẻẢoToolStripMenuItem.Click += new System.EventHandler(thẻẢoToolStripMenuItem_Click);
		this.mailToolStripMenuItem.Name = "mailToolStripMenuItem";
		this.mailToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
		this.mailToolStripMenuItem.Text = "BM nhận tkcn";
		this.mailToolStripMenuItem.Visible = false;
		this.mailToolStripMenuItem.Click += new System.EventHandler(mailToolStripMenuItem_Click);
		this.quảnLýTKTrongBMToolStripMenuItem.Name = "quảnLýTKTrongBMToolStripMenuItem";
		this.quảnLýTKTrongBMToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
		this.quảnLýTKTrongBMToolStripMenuItem.Text = "Quản lý TK trong BM";
		this.quảnLýTKTrongBMToolStripMenuItem.Visible = false;
		this.quảnLýTKTrongBMToolStripMenuItem.Click += new System.EventHandler(quảnLýTKTrongBMToolStripMenuItem_Click);
		this.danhSáchTKQCToolStripMenuItem.Name = "danhSáchTKQCToolStripMenuItem";
		this.danhSáchTKQCToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
		this.danhSáchTKQCToolStripMenuItem.Text = "Danh sách TKQC";
		this.danhSáchTKQCToolStripMenuItem.Click += new System.EventHandler(danhSáchTKQCToolStripMenuItem_Click<T31, T22, T23>);
		this.quảnLýPageĐốiTácToolStripMenuItem.Name = "quảnLýPageĐốiTácToolStripMenuItem";
		this.quảnLýPageĐốiTácToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
		this.quảnLýPageĐốiTácToolStripMenuItem.Text = "Page đối tác";
		this.quảnLýPageĐốiTácToolStripMenuItem.Click += new System.EventHandler(quảnLýPageĐốiTácToolStripMenuItem_Click<T31, T22, T23>);
		this.côngCụToolStripMenuItem.DropDownItems.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T21[1] { (T21)this.seddingLiveStreamToolStripMenuItem });
		this.côngCụToolStripMenuItem.Name = "côngCụToolStripMenuItem";
		this.côngCụToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
		this.côngCụToolStripMenuItem.Text = "Công cụ";
		this.côngCụToolStripMenuItem.Visible = false;
		this.seddingLiveStreamToolStripMenuItem.Name = "seddingLiveStreamToolStripMenuItem";
		this.seddingLiveStreamToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
		this.seddingLiveStreamToolStripMenuItem.Text = "Sedding Live Stream";
		this.seddingLiveStreamToolStripMenuItem.Click += new System.EventHandler(seddingLiveStreamToolStripMenuItem_Click);
		this.hỗTrợToolStripMenuItem.DropDownItems.AddRange((System.Windows.Forms.ToolStripItem[])(object)new T21[2]
		{
			(T21)this.liênHệToolStripMenuItem,
			(T21)this.updateToolStripMenuItem
		});
		this.hỗTrợToolStripMenuItem.Name = "hỗTrợToolStripMenuItem";
		this.hỗTrợToolStripMenuItem.Size = new System.Drawing.Size(66, 26);
		this.hỗTrợToolStripMenuItem.Text = "Hỗ trợ";
		this.liênHệToolStripMenuItem.Name = "liênHệToolStripMenuItem";
		this.liênHệToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
		this.liênHệToolStripMenuItem.Text = "Liên hệ";
		this.liênHệToolStripMenuItem.Click += new System.EventHandler(liênHệToolStripMenuItem_Click);
		this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
		this.updateToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
		this.updateToolStripMenuItem.Text = "Update";
		this.updateToolStripMenuItem.Click += new System.EventHandler(updateToolStripMenuItem_Click<T25, T27, T22, T23, T33>);
		this.timer_gv_refesh.Interval = 1000;
		this.timer_gv_refesh.Tick += new System.EventHandler(timer_gv_refesh_Tick<T25, T22, T23, T33>);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(1764, 820);
		base.Controls.Add(this.lbLanguage);
		base.Controls.Add(this.tabControl1);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.menuStrip1);
		this.Font = new System.Drawing.Font("Verdana", 8f);
		base.Icon = (System.Drawing.Icon)(T60)((System.Resources.ResourceManager)val).GetObject("$this.Icon");
		base.MainMenuStrip = this.menuStrip1;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "frmMain";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "METASOFT - www.meta-soft.tech";
		base.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(frmMain_HelpButtonClicked);
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmMain_FormClosing<T22, T62, T38, T25, T31>);
		base.Load += new System.EventHandler(frmMain_Load<T33, T25, T24, T31, T22, T23, T63, T30, T32, T64, T65, T48, T66, T44, T36, T43, T39, T40, T41, T42, T67, T37, T47, T68>);
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.panel1.ResumeLayout(false);
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numTimeDelay).EndInit();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numProtonVPN).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numToChangeIP).EndInit();
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numChromeCustomSizeWidth).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numChromeCustomSizeHeigth).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numThread).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numFromDelay).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numToDelay).EndInit();
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.Panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainer1).EndInit();
		this.splitContainer1.ResumeLayout(false);
		this.groupFolder.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gvData).EndInit();
		this.tabPage3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gvUserAgent).EndInit();
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	bool _206F_200C_202A_200C_200B_206A_202E_206C_206C_202D_206B_200E_202C_200F_206D_206D_200D_206A_206A_202D_202D_200B_200C_202D_206D_202E_202E_206D_202C_202C_200E_202D_202D_202E_202D_206A_206B_200B_206A_206E_202E()
	{
		return base.InvokeRequired;
	}
}
