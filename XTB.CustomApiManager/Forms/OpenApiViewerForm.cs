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
        private EntityCollection _requestParameters;
        private EntityCollection _responseProperties;
        private string _baseUrl = string.Empty;
        private string _tenantid = string.Empty;
        private string _boundEntitySetName = string.Empty;

        #endregion Private Fields

        #region Public Constructors

        public OpenApiViewerForm(IOrganizationService service, CustomApiProxy customapi, ConnectionDetail connection)
        {
            InitializeComponent();

            _service = service;
            _customapiproxy = customapi;
            _connection = connection;

            

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
            _requestParameters = _service.GetCustomApisRequestParametersFor(customapi.CustomApiRow);
            _responseProperties = _service.GetCustomApisResponsePropertiesFor(customapi.CustomApiRow);
            _baseUrl = _connection.WebApplicationUrl.TrimEnd('/');
            _tenantid = _connection.TenantId.ToString();

            if (!string.IsNullOrEmpty(_customapiproxy.BoundEntityLogicalName))
            {
                _boundEntitySetName = _service.GetEntityCollectionName(_customapiproxy.BoundEntityLogicalName);               
            }



            DisplayOpenApiJson();
            

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
            scinJson.Text = openApiYaml;
        }
        #endregion Public Constructors


        private void InitializeScintillaJson()
        {
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
                style.Font = "Courier New";
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
            scinJson.Lexer = Lexer.Python;
            scinJson.SetKeywords(0, @"true false null yes no on off");

            #region Syntax Colors

            scinJson.Styles[Style.Python.Default].ForeColor = Color.Black;
            scinJson.Styles[Style.Python.CommentLine].ForeColor = Color.Green;
            scinJson.Styles[Style.Python.Number].ForeColor = Color.DodgerBlue;
            scinJson.Styles[Style.Python.String].ForeColor = Color.OrangeRed;
            scinJson.Styles[Style.Python.Character].ForeColor = Color.OrangeRed;
            scinJson.Styles[Style.Python.Word].ForeColor = Color.Blue;
            scinJson.Styles[Style.Python.Triple].ForeColor = Color.OrangeRed;
            scinJson.Styles[Style.Python.TripleDouble].ForeColor = Color.OrangeRed;
            scinJson.Styles[Style.Python.ClassName].ForeColor = Color.DarkBlue;
            scinJson.Styles[Style.Python.DefName].ForeColor = Color.DarkBlue;
            scinJson.Styles[Style.Python.Operator].ForeColor = Color.Black;
            scinJson.Styles[Style.Python.Identifier].ForeColor = Color.Black;

            #endregion Syntax Colors

            foreach (var style in scinJson.Styles)
            {
                style.Font = "Courier New";
                style.SizeF = 12;
            }

            #region Remove Underscore Markings

            // Disable word part indicators that cause underscore markings
            scinJson.SetProperty("lexer.python.keywords2.no.sub.identifiers", "1");
            scinJson.SetProperty("lexer.python.unicode.identifiers", "1");
            
            // Clear any existing indicators
            scinJson.IndicatorCurrent = 0;
            scinJson.IndicatorClearRange(0, scinJson.TextLength);

            #endregion Remove Underscore Markings

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
    }
}
