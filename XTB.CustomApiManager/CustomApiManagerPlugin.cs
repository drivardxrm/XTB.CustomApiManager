using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace XTB.CustomApiManager
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
         ExportMetadata("Name", "Custom API Manager"),
        ExportMetadata("Description", "Dataverse Custom API Management Tool"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "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"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "DarkSlateGray"),
        ExportMetadata("PrimaryFontColor", "WhiteSmoke"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class CustomApiManagerPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new CustomApiManagerControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public CustomApiManagerPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}