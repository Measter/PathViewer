using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;

namespace PathViewer
{
  public partial class Form1 : Form
  {
    private ListBox m_selectedListBox;
    private string m_userPathString = null;
    private string m_machinePathString = null;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load( object sender, EventArgs e )
    {
      GetPaths( lbUser, EnvironmentVariableTarget.User, ref m_userPathString );
      GetPaths( lbMachine, EnvironmentVariableTarget.Machine, ref m_machinePathString );

      lbUser.SelectedIndex = 0;
      lbMachine.SelectedIndex = 0;

      m_selectedListBox = lbMachine;

      UpdateButtons();

      if ( lbMachine.Enabled || lbUser.Enabled )
      {
        btnBackup.Enabled = true;
        btnRestore.Enabled = true;
        btnSave.Enabled = true;
      }
    }

    private void GetPaths( ListBox lb, EnvironmentVariableTarget target, ref string path )
    {
      if( lb == null )
        throw new ArgumentNullException( "Listbox cannot be null." );

      lb.Enabled = true;

      try
      {
        string ID = "Path";
        path = Environment.GetEnvironmentVariable( ID, target );
        if( path == null )
          path = Environment.GetEnvironmentVariable( ID.ToUpper(), target );
        if( path == null )
          path = Environment.GetEnvironmentVariable( ID.ToLower(), target );

        ParsePaths( lb, path );
      } catch( NullReferenceException )
      {
        lb.Items.Add( "Unable to fetch environment variable for target: " + target.ToString() );
        lb.Enabled = false;
      } catch( NotSupportedException )
      {
        lb.Items.Add( "The current platform is not supported." );
        lb.Enabled = false;
      } catch( ArgumentException )
      {
        lb.Items.Add( "The following target is invalid: " + target.ToString() );
        lb.Enabled = false;
      } catch( SecurityException )
      {
        lb.Items.Add( "This program does not have the required security privaliges to fetch the Path variable." );
        lb.Enabled = false;
      }
    }
    private void WritePaths( string path, EnvironmentVariableTarget target )
    {
      if ( path == null )
        throw new ArgumentNullException( "Path cannot be null." );

      try
      {
        Environment.SetEnvironmentVariable( "Path", path, target );
      } catch( NullReferenceException )
      {
        MessageBox.Show( this, "A NullReferenceException was thrown while attempting to write" +
                               "to the Paths variable at the target: " + target.ToString(),
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      } catch( ArgumentException )
      {
        MessageBox.Show( this, "An ArgumentExcepiton was thrown while attempting to write" +
                               "to the Paths variable at the target: " + target.ToString(),
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
      } catch( NotSupportedException )
      {
        MessageBox.Show( this, "Unable to write to the Paths variable at the target: " + target.ToString() +
                               "The current platform is unsupported.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
      } catch( SecurityException )
      {
        MessageBox.Show( this, "A SecurityException was thrown while attempting to write" +
                               "to the Paths variable at the target: " + target.ToString() +
                               "\n\nPlease ensure you have the appropriate permission.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
      }
    }

    private void ParsePaths( ListBox lb, string path )
    {
      lb.Items.Clear();

      if ( path == null )
      {
        lb.Items.Add( "Unable to fetch environment variable for target: " + ( lb == lbMachine ? "Machine" : "User" ) );
        lb.Enabled = false;
        return;
      }
      
      string[] splitPaths = path.Split( new[] { ';' }, StringSplitOptions.RemoveEmptyEntries );

      foreach ( string s in splitPaths )
        lb.Items.Add( s.Trim() );
    }

    private string AssemblePath( ListBox lb )
    {
      if ( !lb.Enabled )
        return null;

      string output = (string)lb.Items[0];

      for ( int i = 1; i < lb.Items.Count; i++ )
      {
        output += ";";
        output += lb.Items[i];
      }

      return output;
    }

    private void btnAdd_Click( object sender, EventArgs e )
    {
      fbdFolderSelector.SelectedPath = string.Empty;
      if ( fbdFolderSelector.ShowDialog( this ) == DialogResult.OK )
        m_selectedListBox.Items.Add( fbdFolderSelector.SelectedPath );
    }
    private void btnEdit_Click( object sender, EventArgs e )
    {
      int index = m_selectedListBox.SelectedIndex;
      string path = (string)m_selectedListBox.Items[index];
      
      DialogResult res = MessageBox.Show( this, "Are you sure you want to edit the following path?:\n\n" + path,
                                 "Edit Path?", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

      if ( res != DialogResult.Yes )
        return;

      fbdFolderSelector.SelectedPath = path;
      if ( fbdFolderSelector.ShowDialog(this) == DialogResult.OK )
      {
        path = fbdFolderSelector.SelectedPath;

        m_selectedListBox.Items[index] = path;
      }
    }
    private void btnDelete_Click( object sender, EventArgs e )
    {
      int index = m_selectedListBox.SelectedIndex;
      string path = (string)m_selectedListBox.Items[index];

      DialogResult res = MessageBox.Show( this, "Are you sure you want to delete the following path:\n\n" + path,
                                 "Delete Path?", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

      if( res == DialogResult.Yes )
      {
        m_selectedListBox.Items.RemoveAt( index );
        if ( index >= m_selectedListBox.Items.Count )
          m_selectedListBox.SelectedIndex = index - 1;
        else
          m_selectedListBox.SelectedIndex = index;
      }
    }

    private void btnBackup_Click( object sender, EventArgs e )
    {
      sfdRestore.FileName = "Paths Backup " + DateTime.Now.ToString( "yyyyMMdd-HHmmss" ) + ".txt";

      if ( sfdRestore.ShowDialog(this) == DialogResult.OK )
      {
        using ( FileStream fs = new FileStream( sfdRestore.FileName, FileMode.Create ) )
        using ( TextWriter tw = new StreamWriter( fs ) )
        {
          tw.WriteLine( "[Machine]" );
          tw.WriteLine( m_machinePathString ?? "null" );

          tw.WriteLine( "[User]" );
          tw.Write( m_userPathString ?? "null" );
        }
      }
    }
    private void btnRestore_Click( object sender, EventArgs e )
    {
      if( MessageBox.Show( this, "Are you sure you wish to overwrite" +
                                  " the loaded PATH data?",
                                  "Overwrite Paths?", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question ) == DialogResult.No )
      {
        return;
      }

      if ( ofdBackup.ShowDialog(this) == DialogResult.OK )
      {
        using ( FileStream fs = new FileStream( ofdBackup.FileName, FileMode.Open ) )
        using ( TextReader tr = new StreamReader( fs ) )
        {
          string line, nLine;
          while ( (line = tr.ReadLine()) != null )
          {
            if( line == "[Machine]" )
            {
              nLine = tr.ReadLine();
              m_machinePathString = nLine == "null" ? null : nLine;
            }
            if( line == "[User]" )
            {
              nLine = tr.ReadLine();
              m_userPathString = nLine == "null" ? null : nLine;
            }
          }
        }

        ParsePaths( lbMachine, m_machinePathString );
        ParsePaths( lbUser, m_userPathString );
      }
    }

    private void btnSave_Click( object sender, EventArgs e )
    {
      DialogResult result = MessageBox.Show( this, "This will overwrite the PATH environment variable in" +
                                    " Windows.\n\nMake a backup before making any changes.",
                                    "Save Changes", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning );

      if ( result != DialogResult.Yes )
        return;

      string path = AssemblePath( lbMachine );
      if ( path != null )
        WritePaths( path, EnvironmentVariableTarget.Machine );

      path = AssemblePath( lbUser );
    }

    private void tabControl1_SelectedIndexChanged( object sender, EventArgs e )
    {
      if ( tabControl1.SelectedIndex == 0 )
        m_selectedListBox = lbMachine;
      else if ( tabControl1.SelectedIndex == 1 )
        m_selectedListBox = lbUser;

      UpdateButtons();
    }

    private void UpdateButtons()
    {
      if( m_selectedListBox.Enabled )
      {
        btnAdd.Enabled = true;
        btnEdit.Enabled = true;
        btnDelete.Enabled = true;
      } else
      {
        btnAdd.Enabled = false;
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
      }
    }
  }
}
