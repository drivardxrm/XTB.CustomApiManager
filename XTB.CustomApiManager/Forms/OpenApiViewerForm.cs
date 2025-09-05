using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using System.Xml.Linq;
using XTB.CustomApiManager.Entities;
using XTB.CustomApiManager.Helpers;
using XTB.CustomApiManager.Proxy;

namespace XTB.CustomApiManager.Forms
{
    public partial class OpenApiViewerForm : Form
    {
        #region Private Fields

        private ConnectionDetail _connection;
        private IOrganizationService _service;
        private CustomApiProxy _customapiproxy;
        private List<CustomApiRequestParameterProxy> _requestParameters = new List<CustomApiRequestParameterProxy>();
        private List<CustomApiResponsePropertyProxy> _responseProperties = new List<CustomApiResponsePropertyProxy>();
        private string _baseUrl = string.Empty;
        private string _tenantid = string.Empty;
        private string _boundEntitySetName = string.Empty;
        private Settings _settings;

        #endregion Private Fields

        #region Public Constructors

        public OpenApiViewerForm(IOrganizationService service, CustomApiProxy customapi, ConnectionDetail connection, Settings settings)
        {
            InitializeComponent();

            _service = service;
            _customapiproxy = customapi;
            _connection = connection;
            _settings = settings;



            //// Set font
            //scinJson.StyleResetDefault();
            //scinJson.Styles[Style.Default].Font = "Consolas";
            //scinJson.Styles[Style.Default].Size = 10;
            //scinJson.StyleClearAll();

            //// Configure JSON syntax highlighting
            //scinJson.Styles[Style.Json.Default].ForeColor = Color.Black;
            //scinJson.Styles[Style.Json.Number].ForeColor = Color.Blue;
            //scinJson.Styles[Style.Json.String].ForeColor = Color.Red;
            //scinJson.Styles[Style.Json.PropertyName].ForeColor = Color.DarkBlue;
            //scinJson.Styles[Style.Json.Keyword].ForeColor = Color.Purple;

            //// Line numbers
            //scinJson.Margins[0].Width = 30;
            //scinJson.Margins[0].Type = MarginType.Number;
            //scinJson.Margins[0].Sensitive = true;
            //scinJson.Margins[0].Mask = Marker.MaskAll;





            // Get the required data
            var allParameters = _service.GetCustomApisRequestParametersFor(customapi.CustomApiRow);
            foreach (var param in allParameters.Entities)
            {
                var paramFull = _service.GetRequestParameter(param.Id);
                _requestParameters.Add(new CustomApiRequestParameterProxy(paramFull, true));
            }

            var allResponseProps = _service.GetCustomApisResponsePropertiesFor(customapi.CustomApiRow);
            foreach (var resp in allResponseProps.Entities)
            {
                var respFull = _service.GetResponseProperty(resp.Id);
                _responseProperties.Add(new CustomApiResponsePropertyProxy(respFull, true));
            }


            _baseUrl = _connection.WebApplicationUrl.TrimEnd('/');
            _tenantid = _connection.TenantId.ToString();

            if (!string.IsNullOrEmpty(_customapiproxy.BoundEntityLogicalName))
            {
                _boundEntitySetName = _service.GetEntityCollectionName(_customapiproxy.BoundEntityLogicalName);               
            }

            if (_settings.OpenApiDefaultFormat == "yaml")
            {
                rdYaml.Checked = true;
                DisplayOpenApiYaml();
            }
            else
            {
                rdJson.Checked = true;
                DisplayOpenApiJson();
            }

            
            

        }

        private void DisplayOpenApiJson()
        {
            // Generate the OpenAPI JSON
            InitializeScintillaJson();
            string openApiJson = OpenApiGenerator.GenerateOpenApiJson(
                _customapiproxy,
                _requestParameters,
                _responseProperties,
                _baseUrl,
                _tenantid,
                _boundEntitySetName
            );
            scinJson.Text = openApiJson;
            scinJson.Visible = true;
            scinYaml.Visible = false;
        }

        private void DisplayOpenApiYaml()
        {
            // Generate the OpenAPI YAML
            InitializeScintillaYaml();
            string openApiYaml = OpenApiGenerator.GenerateOpenApiYaml(
                _customapiproxy,
                _requestParameters,
                _responseProperties,
                _baseUrl,
                _tenantid,
                _boundEntitySetName
            );
            scinYaml.Text = openApiYaml;
            scinYaml.Visible = true;
            scinJson.Visible = false;
        }
        #endregion Public Constructors


        private void InitializeScintillaJson()
        {
            // Clear all existing styles and reset to defaults
            scinJson.StyleResetDefault();
            scinJson.StyleClearAll();

            scinJson.Lexer = Lexer.Json;
            scinJson.SetKeywords(0, @"true false");

            #region Syntax Colors

            scinJson.Styles[Style.Json.Number].ForeColor = Color.DodgerBlue;
            scinJson.Styles[Style.Json.BlockComment].ForeColor = Color.Green;
            scinJson.Styles[Style.Json.LineComment].ForeColor = Color.Green;
            scinJson.Styles[Style.Json.Default].ForeColor = Color.Black;
            scinJson.Styles[Style.Json.PropertyName].ForeColor = Color.Gray;
            scinJson.Styles[Style.Json.Error].ForeColor = Color.Red;
            scinJson.Styles[Style.Json.Uri].ForeColor = Color.MediumBlue;
            scinJson.Styles[Style.Json.Uri].Underline = true;
            scinJson.Styles[Style.Json.CompactIRI].ForeColor = Color.MediumBlue;
            scinJson.Styles[Style.Json.CompactIRI].Underline = true;
            scinJson.Styles[Style.Json.EscapeSequence].ForeColor = Color.BurlyWood;
            scinJson.Styles[Style.Json.Keyword].ForeColor = Color.Blue;
            scinJson.Styles[Style.Json.Operator].ForeColor = Color.Black;
            scinJson.Styles[Style.Json.String].ForeColor = Color.OrangeRed;

            #endregion Syntax Colors

            foreach (var style in scinJson.Styles)
            {
                style.Font = "JetBrains Mono";
                style.SizeF = 12;
            }

            #region Folding

            scinJson.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;

            // Instruct the lexer to calculate folding
            scinJson.SetProperty("fold", "1");
            scinJson.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            scinJson.Margins[2].Type = MarginType.Symbol;
            scinJson.Margins[2].Mask = Marker.MaskFolders;
            scinJson.Margins[2].Sensitive = true;
            scinJson.Margins[2].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                scinJson.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scinJson.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            scinJson.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scinJson.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scinJson.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scinJson.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scinJson.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scinJson.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scinJson.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            scinJson.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;

            #endregion Folding

            #region Line Numbers

            scinJson.Styles[Style.LineNumber].ForeColor = Color.LightSlateGray;

            #endregion Line Numbers

            #region Whitespace

            scinJson.WhitespaceSize = 3;
            scinJson.SetWhitespaceForeColor(true, Color.FromArgb(200, 40, 40));

            #endregion Whitespace

            #region Brace Matching

            scinJson.IndentationGuides = IndentView.LookBoth;
            scinJson.Styles[Style.BraceLight].BackColor = Color.LightGray;
            scinJson.Styles[Style.BraceLight].ForeColor = Color.BlueViolet;
            scinJson.Styles[Style.BraceBad].ForeColor = Color.Red;

            #endregion Brace Matching

            scinJson.Margins[0].Width = 16;


        }

        private void InitializeScintillaYaml()
        {
            // Clear all existing styles and reset to defaults
            scinYaml.StyleResetDefault();
            scinYaml.StyleClearAll();

            // Use Properties lexer which handles key-value pairs well
            scinYaml.Lexer = Lexer.Properties;

            #region Properties-based YAML Colors
            scinYaml.Styles[Style.Properties.Default].ForeColor = Color.FromArgb(45, 45, 45);
            scinYaml.Styles[Style.Properties.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Comments
            scinYaml.Styles[Style.Properties.Section].ForeColor = Color.FromArgb(0, 0, 255); // Section headers (keys)
            scinYaml.Styles[Style.Properties.Assignment].ForeColor = Color.FromArgb(128, 128, 128); // : operator
            scinYaml.Styles[Style.Properties.Default].ForeColor = Color.FromArgb(163, 21, 21); // Values
            scinYaml.Styles[Style.Properties.Key].ForeColor = Color.FromArgb(43, 145, 175); // Keys
            #endregion

            foreach (var style in scinYaml.Styles)
            {
                style.Font = "JetBrains Mono";
                style.SizeF = 12;
            }

            // Configure for YAML-like behavior
            scinYaml.SetProperty("fold", "1");
            scinYaml.SetProperty("fold.compact", "1");

            #region Basic YAML Features
            scinYaml.TabWidth = 2;
            scinYaml.UseTabs = false;
            scinYaml.IndentWidth = 2;
            scinYaml.IndentationGuides = IndentView.LookBoth;
            scinYaml.Styles[Style.IndentGuide].ForeColor = Color.FromArgb(200, 200, 200);
            #endregion

            #region Line Numbers
            scinYaml.Margins[0].Type = MarginType.Number;
            scinYaml.Margins[0].Sensitive = true;
            scinYaml.Margins[0].Mask = Marker.MaskAll;
            scinYaml.Margins[0].Width = 25;
            scinYaml.Styles[Style.LineNumber].ForeColor = Color.FromArgb(128, 128, 128);
            #endregion

            #region Folding (Manual)
            scinYaml.Margins[2].Type = MarginType.Symbol;
            scinYaml.Margins[2].Mask = Marker.MaskFolders;
            scinYaml.Margins[2].Sensitive = true;
            scinYaml.Margins[2].Width = 20;

            for (int i = 25; i <= 31; i++)
            {
                scinYaml.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scinYaml.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            scinYaml.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scinYaml.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scinYaml.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scinYaml.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scinYaml.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scinYaml.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scinYaml.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
            #endregion

            #region YAML Specific
            scinYaml.WrapMode = WrapMode.Word;
            scinYaml.ViewWhitespace = WhitespaceMode.VisibleAfterIndent;
            scinYaml.WhitespaceSize = 1;
            scinYaml.SetWhitespaceForeColor(true, Color.FromArgb(180, 180, 180));
            #endregion
        }

        
        private void rdJson_CheckedChanged(object sender, EventArgs e)
        {
            if (rdJson.Checked == true) 
            {
                DisplayOpenApiJson();
            }

        }

        private void rdYaml_CheckedChanged(object sender, EventArgs e)
        {
            if (rdYaml.Checked == true)
            {
                DisplayOpenApiYaml();
            }

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                string textToCopy = string.Empty;
                
                // Determine which Scintilla control is currently visible and get its text
                if (scinJson.Visible)
                {
                    textToCopy = scinJson.Text;
                }
                else if (scinYaml.Visible)
                {
                    textToCopy = scinYaml.Text;
                }
                
                // Copy to clipboard if we have text
                if (!string.IsNullOrEmpty(textToCopy))
                {
                    Clipboard.SetText(textToCopy);
                    
                    // Optional: Show a brief confirmation message
                    MessageBox.Show("OpenAPI content copied to clipboard!", "Copy Successful", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No content available to copy.", "Copy Failed", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to copy to clipboard: {ex.Message}", "Copy Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string contentToSave = string.Empty;
                string fileExtension = string.Empty;
                string formatType = string.Empty;
                
                // Determine which content to save and appropriate file extension
                if (scinJson.Visible)
                {
                    contentToSave = scinJson.Text;
                    fileExtension = "json";
                    formatType = "JSON";
                }
                else if (scinYaml.Visible)
                {
                    contentToSave = scinYaml.Text;
                    fileExtension = "yaml";
                    formatType = "YAML";
                }
                
                if (string.IsNullOrEmpty(contentToSave))
                {
                    MessageBox.Show("No content available to save.", "Save Failed", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Generate filename based on custom API name
                string sanitizedApiName = SanitizeFileName(_customapiproxy.UniqueName ?? _customapiproxy.Name ?? "CustomAPI");
                string defaultFileName = $"{sanitizedApiName}_OpenAPI.{fileExtension}";
                
                // Configure SaveFileDialog
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = $"Save OpenAPI {formatType}";
                    saveFileDialog.FileName = defaultFileName;
                    saveFileDialog.DefaultExt = fileExtension;
                    
                    if (fileExtension == "json")
                    {
                        saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    }
                    else
                    {
                        saveFileDialog.Filter = "YAML files (*.yaml)|*.yaml|YAML files (*.yml)|*.yml|All files (*.*)|*.*";
                    }
                    
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;
                    
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Save the file
                        System.IO.File.WriteAllText(saveFileDialog.FileName, contentToSave, Encoding.UTF8);
                        
                        MessageBox.Show($"OpenAPI {formatType} saved successfully to:\n{saveFileDialog.FileName}", 
                                      "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save file: {ex.Message}", "Save Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SanitizeFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return "CustomAPI";
            
            // Remove invalid filename characters
            var invalidChars = System.IO.Path.GetInvalidFileNameChars();
            var sanitized = new StringBuilder();
            
            foreach (char c in fileName)
            {
                if (!invalidChars.Contains(c))
                {
                    sanitized.Append(c);
                }
                else
                {
                    sanitized.Append('_'); // Replace invalid chars with underscore
                }
            }
            
            // Ensure the filename is not empty and not too long
            string result = sanitized.ToString().Trim();
            if (string.IsNullOrEmpty(result))
                result = "CustomAPI";
            
            // Limit filename length (Windows has a 255 character limit)
            if (result.Length > 100)
                result = result.Substring(0, 100);
            
            return result;
        }
    }
}
