using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TrelloMemberAdder.Properties;
using TrelloNet;

namespace TrelloMemberAdder
{
	public partial class Form1 : Form
	{
		private Trello m_trello;
		
		private Board	SelectedBoard	{ get { return m_boardComboBox.SelectedItem as Board;	} }
		private List	SelectedList	{ get { return m_listComboBox.SelectedItem as List;		} }
		private Member	SelectedMember	{ get { return m_memberComboBox.SelectedItem as Member;	} }

		private IEnumerable<Card> SelectedCards
		{
			get { return SelectedList != null ? m_trello.Cards.ForList( SelectedList ) : new Card[ 0 ];	}
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			var key = m_keyTextBox.Text;
			if ( string.IsNullOrWhiteSpace( key ) ) return;
			var token = m_tokenTextBox.Text;
			if ( string.IsNullOrWhiteSpace( token ) ) return;

			m_trello = new Trello( key );
			m_trello.Authorize( token );
			
			OnAuthorize();
		}

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

		private void Form1_FormClosing( object sender, FormClosingEventArgs e )
		{
			Settings.Default.Save();
		}
		
		private void OnInput( object sender, EventArgs e )
		{
			var key				= m_keyTextBox.Text;
			var token			= m_tokenTextBox.Text;
			var isEnabledKey	= !string.IsNullOrWhiteSpace( key );
			var isEnabledToken	= !string.IsNullOrWhiteSpace( token );
			var isEnabled		= isEnabledKey && isEnabledToken;

			m_authButton.Enabled = isEnabled;
		}

		private void authButton_Click( object sender, EventArgs e )
		{
			m_trello = new Trello( m_keyTextBox.Text );
			m_trello.Authorize( m_tokenTextBox.Text );

			OnAuthorize();
		}

		private void m_boardComboBox_SelectedValueChanged( object sender, EventArgs e )
		{
			var board = m_boardComboBox.SelectedItem as Board;
			
			m_listComboBox.Set( m_trello.Lists.ForBoard( board ) );
			m_listComboBox.SelectedIndex = 0;

			m_memberComboBox.Set( m_trello.Members.ForBoard( board ) );
			m_memberComboBox.SelectedIndex = 0;
			
			OnSelected( sender, e );
		}

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

		private void m_addButton_Click( object sender, EventArgs e )
		{
			var member	= SelectedMember;
			var cards	= SelectedCards.Where( c => !c.IdMembers.Contains( member.Id ) );

			foreach ( var n in cards )
			{
				m_trello.Cards.AddMember( n, SelectedMember );
			}
		}

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

public static class ComboBoxExt
{
	public static void Set( this ComboBox self, IEnumerable<object> items )
	{
		self.Items.Set( items );
	}
}

public static class IListExt
{
	public static void Set( this IList self, IEnumerable<object> items )
	{
		self.Clear();
		foreach ( var n in items )
		{
			self.Add( n );
		}
	}

	public static void Set( this IList self, params object[] items )
	{
		self.Clear();
		for ( int i = 0; i < items.Length; i++ )
		{
			self.Add( items[ i ] );
		}
	}
}