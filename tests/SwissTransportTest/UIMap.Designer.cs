﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 15.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace SwissTransport
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public partial class UIMap
    {
        
        /// <summary>
        /// RecordedMethod1 - Use 'RecordedMethod1Params' to pass parameters into this method.
        /// </summary>
        public void RecordedMethod1()
        {
            #region Variable Declarations
            WpfEdit uITextBoxEdit = this.UIMainWindowWindow.UITextBoxEdit;
            WpfEdit uITextBox_CopyEdit = this.UIMainWindowWindow.UITextBox_CopyEdit;
            WpfListItem uISwissTransportConnecListItem = this.UIMainWindowWindow.UIListBox_Copy1List.UISwissTransportConnecListItem;
            #endregion

            // Type 'hildisrieden' in 'textBox' text box
            uITextBoxEdit.Text = this.RecordedMethod1Params.UITextBoxEditText;

            // Last action on list item was not recorded because the control does not have any good identification property.

            // Type 'luzern' in 'textBox_Copy' text box
            uITextBox_CopyEdit.Text = this.RecordedMethod1Params.UITextBox_CopyEditText;

            // Last action on list item was not recorded because the control does not have any good identification property.

            // Click 'SwissTransport.Connection' list item
            Mouse.Click(uISwissTransportConnecListItem, new Point(129, 7));
        }
        
        #region Properties
        public virtual RecordedMethod1Params RecordedMethod1Params
        {
            get
            {
                if ((this.mRecordedMethod1Params == null))
                {
                    this.mRecordedMethod1Params = new RecordedMethod1Params();
                }
                return this.mRecordedMethod1Params;
            }
        }
        
        public UIMainWindowWindow UIMainWindowWindow
        {
            get
            {
                if ((this.mUIMainWindowWindow == null))
                {
                    this.mUIMainWindowWindow = new UIMainWindowWindow();
                }
                return this.mUIMainWindowWindow;
            }
        }
        #endregion
        
        #region Fields
        private RecordedMethod1Params mRecordedMethod1Params;
        
        private UIMainWindowWindow mUIMainWindowWindow;
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'RecordedMethod1'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class RecordedMethod1Params
    {
        
        #region Fields
        /// <summary>
        /// Type 'hildisrieden' in 'textBox' text box
        /// </summary>
        public string UITextBoxEditText = "hildisrieden";
        
        /// <summary>
        /// Type 'luzern' in 'textBox_Copy' text box
        /// </summary>
        public string UITextBox_CopyEditText = "luzern";
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIMainWindowWindow : WpfWindow
    {
        
        public UIMainWindowWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "MainWindow";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("MainWindow");
            #endregion
        }
        
        #region Properties
        public WpfEdit UITextBoxEdit
        {
            get
            {
                if ((this.mUITextBoxEdit == null))
                {
                    this.mUITextBoxEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITextBoxEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "textBox";
                    this.mUITextBoxEdit.WindowTitles.Add("MainWindow");
                    #endregion
                }
                return this.mUITextBoxEdit;
            }
        }
        
        public WpfEdit UITextBox_CopyEdit
        {
            get
            {
                if ((this.mUITextBox_CopyEdit == null))
                {
                    this.mUITextBox_CopyEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUITextBox_CopyEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "textBox_Copy";
                    this.mUITextBox_CopyEdit.WindowTitles.Add("MainWindow");
                    #endregion
                }
                return this.mUITextBox_CopyEdit;
            }
        }
        
        public UIListBox_Copy1List UIListBox_Copy1List
        {
            get
            {
                if ((this.mUIListBox_Copy1List == null))
                {
                    this.mUIListBox_Copy1List = new UIListBox_Copy1List(this);
                }
                return this.mUIListBox_Copy1List;
            }
        }
        #endregion
        
        #region Fields
        private WpfEdit mUITextBoxEdit;
        
        private WpfEdit mUITextBox_CopyEdit;
        
        private UIListBox_Copy1List mUIListBox_Copy1List;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIListBox_Copy1List : WpfList
    {
        
        public UIListBox_Copy1List(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfList.PropertyNames.AutomationId] = "listBox_Copy1";
            this.WindowTitles.Add("MainWindow");
            #endregion
        }
        
        #region Properties
        public WpfListItem UISwissTransportConnecListItem
        {
            get
            {
                if ((this.mUISwissTransportConnecListItem == null))
                {
                    this.mUISwissTransportConnecListItem = new WpfListItem(this);
                    #region Search Criteria
                    this.mUISwissTransportConnecListItem.SearchProperties[WpfListItem.PropertyNames.Name] = "SwissTransport.Connection";
                    this.mUISwissTransportConnecListItem.SearchProperties[WpfListItem.PropertyNames.Instance] = "4";
                    this.mUISwissTransportConnecListItem.WindowTitles.Add("MainWindow");
                    #endregion
                }
                return this.mUISwissTransportConnecListItem;
            }
        }
        #endregion
        
        #region Fields
        private WpfListItem mUISwissTransportConnecListItem;
        #endregion
    }
}