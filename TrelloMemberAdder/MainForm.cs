﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TrelloMemberAdder.Properties;
using TrelloNet;

namespace TrelloMemberAdder
{
	public partial class MainForm : Form
	{
		//====================================================================================
		// 変数
		//====================================================================================
		private Trello m_trello;
		
		//====================================================================================
		// プロパティ
		//====================================================================================
		private Board	SelectedBoard	{ get { return m_boardComboBox.SelectedItem as Board;	} }
		private List	SelectedList	{ get { return m_listComboBox.SelectedItem as List;		} }
		private Member	SelectedMember	{ get { return m_memberComboBox.SelectedItem as Member;	} }

		private IEnumerable<Card> SelectedCards
		{
			get { return SelectedList != null ? m_trello.Cards.ForList( SelectedList ) : new Card[ 0 ];	}
		}

		//====================================================================================
		// 関数
		//====================================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// フォームが読み込まれた時に呼び出されます
		/// </summary>
		private void MainForm_Load( object sender, EventArgs e )
		{
			var key = m_keyTextBox.Text;
			if ( string.IsNullOrWhiteSpace( key ) ) return;
			var token = m_tokenTextBox.Text;
			if ( string.IsNullOrWhiteSpace( token ) ) return;

			m_trello = new Trello( key );
			m_trello.Authorize( token );
			
			OnAuthorize();
		}

		/// <summary>
		/// 認証された時に呼び出します
		/// </summary>
		private void OnAuthorize()
		{
			var isFinish = true;

			try
			{
				m_boardComboBox.Set( m_trello.Boards.ForMe() );
			}
			catch
			{
				isFinish = false;
			}
			finally
			{
				m_authLabel		.Enabled = 
				m_boardComboBox	.Enabled = isFinish;
			}
		}

		/// <summary>
		/// フォームが閉じられる時に呼び出されます
		/// </summary>
		private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
		{
			Settings.Default.Save();
		}
		
		/// <summary>
		/// キーかトークンが入力された時に呼び出されます
		/// </summary>
		private void OnInput( object sender, EventArgs e )
		{
			var key				= m_keyTextBox.Text;
			var token			= m_tokenTextBox.Text;
			var isEnabledKey	= !string.IsNullOrWhiteSpace( key );
			var isEnabledToken	= !string.IsNullOrWhiteSpace( token );
			var isEnabled		= isEnabledKey && isEnabledToken;

			m_authButton.Enabled = isEnabled;
		}

		/// <summary>
		/// 認証ボタンが押された時に呼び出されます
		/// </summary>
		private void authButton_Click( object sender, EventArgs e )
		{
			m_trello = new Trello( m_keyTextBox.Text );
			m_trello.Authorize( m_tokenTextBox.Text );

			OnAuthorize();
		}

		/// <summary>
		/// ボードのコンボボックスで選択されている項目が変更された時に呼び出されます
		/// </summary>
		private void m_boardComboBox_SelectedValueChanged( object sender, EventArgs e )
		{
			var board = m_boardComboBox.SelectedItem as Board;
			
			m_listComboBox.Set( m_trello.Lists.ForBoard( board ) );
			m_listComboBox.SelectedIndex = 0;

			m_memberComboBox.Set( m_trello.Members.ForBoard( board ) );
			m_memberComboBox.SelectedIndex = 0;
			
			OnSelected( sender, e );
		}
		
		/// <summary>
		/// コンボボックスで選択されている項目が変更された時に呼び出されます
		/// </summary>
		private void OnSelected( object sender, EventArgs e )
		{
			var isEnabledBoard	= null != SelectedBoard		;
			var isEnabledList	= null != SelectedList		;
			var isEnabledMember	= null != SelectedMember	;
			var isEnabled		= isEnabledBoard && isEnabledList && isEnabledMember;

			m_listComboBox		.Enabled = 
			m_memberComboBox	.Enabled = isEnabledBoard;

			m_addButton			.Enabled = 
			m_removeButton		.Enabled = isEnabled;
		}
		
		/// <summary>
		/// 追加ボタンが押された時に呼び出されます
		/// </summary>
		private void m_addButton_Click( object sender, EventArgs e )
		{
			var member	= SelectedMember;
			var cards	= SelectedCards.Where( c => !c.IdMembers.Contains( member.Id ) );

			foreach ( var n in cards )
			{
				m_trello.Cards.AddMember( n, SelectedMember );
			}
		}
		
		/// <summary>
		/// 削除ボタンが押された時に呼び出されます
		/// </summary>
		private void m_removeButton_Click( object sender, EventArgs e )
		{
			var member	= SelectedMember;
			var cards	= SelectedCards.Where( c => c.IdMembers.Contains( member.Id ) );

			foreach ( var n in cards )
			{
				m_trello.Cards.RemoveMember( n, SelectedMember );
			}
		}
	}
}

/// <summary>
/// ComboBox 型の拡張メソッドを管理するクラス
/// </summary>
public static class ComboBoxExt
{
	/// <summary>
	/// コレクションの要素を設定します
	/// </summary>
	public static void Set( this ComboBox self, IEnumerable<object> items )
	{
		self.Items.Set( items );
	}
}

/// <summary>
/// IList 型の拡張メソッドを管理するクラス
/// </summary>
public static class IListExt
{
	/// <summary>
	/// 要素を設定します
	/// </summary>
	public static void Set( this IList self, IEnumerable<object> items )
	{
		self.Clear();
		foreach ( var n in items )
		{
			self.Add( n );
		}
	}
}