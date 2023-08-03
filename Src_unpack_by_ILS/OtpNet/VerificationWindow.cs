using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OtpNet;

public class VerificationWindow
{
	[CompilerGenerated]
	private sealed class _003CValidationCandidates_003Ed__3 : IEnumerable<long>, IEnumerator<long>, IEnumerable, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private long _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private long initialFrame;

		public long _003C_003E3__initialFrame;

		public VerificationWindow _003C_003E4__this;

		private int _003Ci_003E5__1;

		private long _003Cval_003E5__2;

		private int _003Ci_003E5__3;

		long IEnumerator<long>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CValidationCandidates_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = initialFrame;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__1 = 1;
				goto IL_0062;
			case 2:
				_003C_003E1__state = -1;
				_003Ci_003E5__1++;
				goto IL_0062;
			case 3:
				{
					_003C_003E1__state = -1;
					_003Ci_003E5__3++;
					break;
				}
				IL_0062:
				if (_003Ci_003E5__1 <= _003C_003E4__this.previous)
				{
					_003Cval_003E5__2 = initialFrame - _003Ci_003E5__1;
					if (_003Cval_003E5__2 >= 0L)
					{
						_003C_003E2__current = _003Cval_003E5__2;
						_003C_003E1__state = 2;
						return true;
					}
				}
				_003Ci_003E5__3 = 1;
				break;
			}
			if (_003Ci_003E5__3 <= _003C_003E4__this.future)
			{
				_003C_003E2__current = initialFrame + _003Ci_003E5__3;
				_003C_003E1__state = 3;
				return true;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw Activator.CreateInstance(typeof(NotSupportedException));
		}

		[DebuggerHidden]
		IEnumerator<long> IEnumerable<long>.GetEnumerator()
		{
			_003CValidationCandidates_003Ed__3 _003CValidationCandidates_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CValidationCandidates_003Ed__ = this;
			}
			else
			{
				_003CValidationCandidates_003Ed__ = new _003CValidationCandidates_003Ed__3(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CValidationCandidates_003Ed__.initialFrame = _003C_003E3__initialFrame;
			return _003CValidationCandidates_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<long>)this).GetEnumerator();
		}
	}

	private readonly int previous;

	private readonly int future;

	public static readonly VerificationWindow RfcSpecifiedNetworkDelay = new VerificationWindow(1, 1);

	public VerificationWindow(int previous = 0, int future = 0)
	{
		this.previous = previous;
		this.future = future;
	}

	[IteratorStateMachine(typeof(_003CValidationCandidates_003Ed__3))]
	public T0 ValidationCandidates<T0, T1>(T1 initialFrame)
	{
		//IL_0015: Expected I8, but got O
		return (T0)new _003CValidationCandidates_003Ed__3(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__initialFrame = (long)initialFrame
		};
	}
}
